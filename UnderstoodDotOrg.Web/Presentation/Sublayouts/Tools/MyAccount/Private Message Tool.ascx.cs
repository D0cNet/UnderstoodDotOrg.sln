using Sitecore.Configuration;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.ExactTarget;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.ExactTarget;
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
        public string UnreadMessages
        {
            get
            {
                string sessConv = Session["UnreadConversations"] as String;
                if ( sessConv!= null)
                    return sessConv;
                else
                {
                  var test =  TelligentService.GetConversations(ScreenName, Constants.TelligentConversationStatus.Unread);
                  if(test!=null){
                      sessConv = test.Count().ToString();
                    Session["UnreadConversations"]= sessConv;
                  
                  }
                  return sessConv??"0";
                }
            }
        }
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                try
                {
                    lblName.Text = Name;
                    litMsgs.Text = "0";
                    BindConversations(true);

                    ///TODO:Enable multiuser selection
                    //MembershipManager memMan = new MembershipManager();
                    //var usernames = memMan.GetMembers().Where(x=>!String.IsNullOrEmpty(x.ScreenName)).Select(x => new { Username = x.ScreenName.Trim() }).ToList<object>();
                    //ddlUserNames.Items.Add(new ListItem() { Text = "", Value = "" });
                    var usernames = TelligentService.GetUserNames().Select(x=> new {Username=x});
                    ddlUserNames.Items.Add(new ListItem() { Text = "", Value = "" });
                    ddlUserNames.DataSource = usernames;
                    ddlUserNames.DataBind();
                }catch(Exception ex)
                {
                    Sitecore.Diagnostics.Error.LogError("Private Message Tool (PageLoad):\n" +ex.Message);
                }
			}

		}

        private void BindConversations(bool forceRefresh=false)
        {
            if (forceRefresh)
                Session["conversations"] = null;

            List<Message> messages = new List<Message>();
            if (Conversations != null)
            {
                
                foreach (Conversation item in Conversations)
                {
                    //Get the latest message
                    Message m = item.Messages.OrderByDescending(x => x.CreatedDate).First();
                    ///messages.Add(item.FirstMessage);
                    messages.Add(m);

                    m = null;
                   
            }


            }
            litMsgs.Text = messages.Count.ToString();
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
                        {
                           
                            BindConversations(true);

                            rptMessages.DataSource = new List<Message>();
                            rptMessages.DataBind();
                            CKEditor1.Text = String.Empty;
                            lvLastMessages.SelectedIndex = -1;
                            
                        }
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


        protected void sendExactTargetEmails(string conversationID,string usernames)
        {
            ////TODO: to implement refactoring

           
           

        }
        protected void btnSendNewMessage_Click(object sender, EventArgs e)
        {
            string newConvID = TelligentService.CreateConversation(ScreenName, txtSubject.Text, CKEditorControl1.Text, ddlUserNames.SelectedValue);
            string usernames = ddlUserNames.SelectedValue;
            if (!String.IsNullOrEmpty(newConvID))
            {
                try
                {
                    BindConversations(true);
                    rptMessages.DataSource = new List<Message>();
                    rptMessages.DataBind();

                    //Send ExactTarget Email
                    MembershipManager memMan = new MembershipManager();
                    string[] users = usernames.Split(',');
                    foreach (string username in users)
                    {
                        string memberEmail = TelligentService.GetMemberEmail(username);
                        string myAccountLink = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem(Constants.Pages.MyAccount.ToString()));

                        BaseReply reply = ExactTargetService.InvokeEM21PrivateMessage(
                                                           new InvokeEM21PrivateMessageRequest
                                                           {
															   PreferredLanguage = CurrentMember.PreferredLanguage,
                                                               ///TODO: change url to profile setting link
                                                               ContactSettingsLink = "www.google.com",
                                                               ///TODO: change URL to message centre link
                                                               MsgCenterLink = myAccountLink,
                                                               PMText = CKEditorControl1.Text,
                                                               ReportInappropriateLink = "flagged@understood.org",
                                                               ToEmail = memberEmail
                                                           });

                    }

                }catch(Exception ex)
                {
                    Sitecore.Diagnostics.Error.LogError("SendNewMessage Error:\n" + ex.Message);
                }

                
                txtSubject.Text = String.Empty;
                CKEditorControl1.Text = String.Empty;
                ddlUserNames.SelectedIndex = -1;
            }
        }

      
            
	}
}