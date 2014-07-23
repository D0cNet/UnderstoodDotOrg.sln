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
        private int FriendPageIndex
        {
            get { return (int)ViewState["_friend_page_count"]; }
            set { ViewState["_friend_page_count"] = value; }
        }
     
        private int TotalFriends
        {
            get {return  (int)ViewState["_total_friends"];}
            set { ViewState["_total_friends"] =value; }
        }
        //public string UnreadMessages
        //{
        //    get
        //    {
        //        string sessConv = Session["UnreadConversations"] as String;
        //        if ( sessConv!= null)
        //            return sessConv;
        //        else
        //        {
        //          var test =  TelligentService.GetConversations(ScreenName, Constants.TelligentConversationStatus.Unread);
        //          if(test!=null){
        //              sessConv = test.Count().ToString();
        //            Session["UnreadConversations"]= sessConv;
                  
        //          }
        //          return sessConv??"0";
        //        }
        //    }
        //}

        public string DeleteConversationMessage { get { return DictionaryConstants.DeleteConfirmationLabel; } }
        public string CancelButtonText { get { return DictionaryConstants.CancelButtonText; } }
        public string PopUpTitleText { get { return DictionaryConstants.SendPrivateMessageLabel; } }

        protected override void OnInit(EventArgs e)
        {
            lbLoadMore.Click += lbLoadMore_Click;
            lbLoadMore.Text = DictionaryConstants.ShowMoreLabel;
            litInboxText.Text = DictionaryConstants.InboxLabel;
            btn_new_message.Attributes.Add("title", DictionaryConstants.NewMessageLabel);
            btn_new_message.Value = DictionaryConstants.NewMessageLabel;
            btnDelete.Text = DictionaryConstants.DeleteButtonLabel;
            btnReply.Text = DictionaryConstants.SubmitReplyButtonLabel;
            btnSendNewMessage.Text = DictionaryConstants.SendMessageButtonLabel;

            base.OnInit(e);
        }

        void lbLoadMore_Click(object sender, EventArgs e)
        {
            LoadFriends();
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
                    FriendPageIndex = 1;
                    ///TODO:Enable multiuser selection
                    LoadFriends();
                  
                }catch(Exception ex)
                {
                    Sitecore.Diagnostics.Error.LogError("Private Message Tool (PageLoad):\n" +ex.Message);
                }
			}

		}

        private void LoadFriends()
        {
           
            int totalFriends = 0;
            var usernames = TelligentService.GetFriends(CurrentMember.ScreenName, FriendPageIndex, 10, out totalFriends).Select(x => new { Username = x.Username }); //TelligentService.GetUserNames().Select(x=> new {Username=x});

            if (usernames.Count() < totalFriends)
                FriendPageIndex++;

            TotalFriends = totalFriends;

            chklUsernames.DataSource = usernames;
            chklUsernames.DataBind();
        }

        private void BindConversations(bool forceRefresh=false)
        {
            if (forceRefresh)
                Session["_currentConvos"] = null;

            List<Message> messages = new List<Message>();
            if (PMConversations != null)
            {
                
                foreach (Conversation item in PMConversations)
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
		public List<Conversation> PMConversations
		{
			get
			{

                List<Conversation> checkConvos = Session["_currentConvos"] as List<Conversation>;
			    if (checkConvos != null)
			    {

				    return checkConvos;
			    }
			    else
			    {

				    checkConvos = TelligentService.GetConversations(ScreenName);
                    Session["_currentConvos"] = checkConvos;
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
                    if (PMConversations != null)
                    {
                        List<Message> msgs = PMConversations.Where(c => c.ID.Equals(hdfield.Value)).First<Conversation>().Messages;
                                              

                        rptMessages.DataSource = msgs;
                        rptMessages.DataBind();

                        //Mark conversation as read
                        TelligentService.MarkConversationRead( CurrentMember.ScreenName, hdfield.Value);
                        Conversations = null;
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
                            Conversations = null;
                            
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
            string usernames = String.Join(",", chklUsernames.Items.Cast<ListItem>()
                .Where(li => li.Selected)
                .Select(li => li.Value).ToArray());
            string newConvID = TelligentService.CreateConversation(ScreenName, txtSubject.Text, CKEditorControl1.Text, usernames);
           
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
                                                               ContactSettingsLink = MembershipHelper.GetPublicProfileUrl(username),
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
                chklUsernames.Items.Cast<ListItem>()
                    .ToList().ForEach(i => { i.Selected = false; }); 
            }
        }

      
            
	}
}