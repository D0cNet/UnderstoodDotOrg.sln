using Sitecore.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.Models.Telligent;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.MyAccount
{
	public partial class Private_Message_Tool : BaseSublayout //System.Web.UI.UserControl
	{
		public string ScreenName
		{
			get
			{
			    if (this.CurrentMember == null)
				    return "admin";
			    else
				    return this.CurrentMember.ScreenName;
			}
		}
        public string Name
        {
            get
            {
                if (this.CurrentMember == null)
                    return "administrator";
                else
                    return (this.CurrentMember.FirstName +" "+ this.CurrentMember.LastName);
            }
        }
		public string TelligentHost
		{
			get
			{
				return Settings.GetSetting(Constants.Settings.TelligentConfig);
			}
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                lblName.Text = Name;
                litMsgs.Text = "0";
                BindConversations(true);

			}
            CKEditor1.Text = String.Empty;
		}

        private void BindConversations(bool forceRefresh=false)
        {
            if (forceRefresh)
                Session["conversations"] = null;

            List<Message> messages = new List<Message>();
            if (Conversations != null)
            {
                litMsgs.Text = Conversations.Count().ToString();
                foreach (Conversation item in Conversations)
                {
                    //Get the latest message
                    Message m = item.Messages.OrderByDescending(x => x.CreatedDate).First();

                    messages.Add(m);

                    m = null;
                }


            }
            //Display messages
            lvLastMessages.DataSource = messages;
            lvLastMessages.DataBind();
        }
		public List<Conversation> Conversations
		{
			get
			{
                
			    List<Conversation> checkConvos = Session["conversations"] as List<Conversation>;
			    if (checkConvos != null)
			    {

				    return checkConvos;
			    }
			    else
			    {

				    checkConvos = TelligentService.GetConversations(ScreenName);
				    Session["conversations"] = checkConvos;
				    return checkConvos;
			    }

			}

		}
      

        protected void lvLastMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void lvLastMessages_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            //Grab conversation ID from hidden field
            if (e.NewSelectedIndex > -1)
            {
                HiddenField hdfield = (HiddenField)lvLastMessages.Items[e.NewSelectedIndex].FindControl("hfConvID");
                if (hdfield != null)
                {
                    //Extract the conversation messages from conversation list item
                    if (Conversations != null)
                    {
                        List<Message> msgs = Conversations.Where(c => c.ID.Equals(hdfield.Value)).First<Conversation>().Messages;
                                              

                        rptMessages.DataSource = msgs;
                        rptMessages.DataBind();
                    }


                }
                lvLastMessages.SelectedIndex = e.NewSelectedIndex;
            }

            BindConversations(false);
        }
        protected void btnReply_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(CKEditor1.Text))
            {
                if (lvLastMessages.SelectedIndex > -1)
                {
                    HiddenField hdfield = (HiddenField)lvLastMessages.Items[lvLastMessages.SelectedIndex].FindControl("hfConvID");
                    if (hdfield != null)
                    {
                        if (TelligentService.ReplyToMessage(ScreenName, hdfield.Value, CKEditor1.Text))
                            BindConversations(true);
                    }
                }
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //Call delete conversation API
             if (lvLastMessages.SelectedIndex > -1)
                {
                    HiddenField hdfield = (HiddenField)lvLastMessages.Items[lvLastMessages.SelectedIndex].FindControl("hfConvID");
                    if (hdfield != null)
                    {
                        if (TelligentService.DeleteConversation(ScreenName, hdfield.Value))
                        {
                            BindConversations(true);
                            rptMessages.DataSource = new List<Message>();
                            rptMessages.DataBind();
                        }

                    }
                }
           
        }

        

        protected void btnSendMessage_Click(object sender, EventArgs e)
        {

        }

      
            
	}
}