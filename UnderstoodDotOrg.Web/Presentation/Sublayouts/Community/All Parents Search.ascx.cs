using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.Understood.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{

    
    public partial class All_Parents_Search : System.Web.UI.UserControl
    {
        Member member1 = new Member()
                {
                    allowConnections = true,
                    FirstName = "adolph",
                    LastName = "rudolph",
                    ScreenName = "AManJo",
                    ZipCode="55555",
                     Interests = new List<Interest>(){
                          new Interest(){
                               Key=new Guid("{E9194DCB-1A67-4CFF-A8A4-B799639AFADC}"),
                               Value="Growing Up"
                          }
                     },
                    Children = new List<Child>(){
                                    new Child(){ 
                                        Grades=new List<Grade>(){
                                        new Grade(){Value="7" },
                                        }, 
                                        Gender="Male",
                                        Issues = new List<Issue>()
                                        {
                                            new Issue(){
                                                 Key=new Guid("{28BB0311-D062-48F0-BEDF-C2D74EB6737E}"),
                                                Value="Hyperactivity or Impulsivity"
                                            },
                                            new Issue(){
                                                Key=new Guid("{1D338D37-CF4E-4C1C-9499-EBA6C0A2BBA0}"),
                                                Value="Math"
                                            }
                                        }
                                                 
                                    }
                                              
                                }
                };
        protected override void OnInit(EventArgs e)
        {
            rptMemberCards.ItemDataBound += rptMemberCards_ItemDataBound;
            
            base.OnInit(e);
        }


       
        void rptMemberCards_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.EmptyItem)
            {
                if (e.Item.DataItem != null)
                {
                    Label emptyText = (Label)e.Item.FindControl("txtEmpty");
                    if (emptyText != null)
                    {
                        emptyText.Text = "There are no community members within your selections, try to remove a filter option for better results";


                    }
                }
            }
            else if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                if (e.Item.DataItem != null)
                {
                    Image avaturl = (Image)e.Item.FindControl("UserAvatar");
                    if (avaturl != null)
                    {
                        avaturl.ImageUrl = ((MemberCardModel)e.Item.DataItem).AvatarUrl;


                    }

                    Literal username = (Literal)e.Item.FindControl("UserName");
                    if (username != null)
                    {
                        username.Text = ((MemberCardModel)e.Item.DataItem).UserName;


                    }

                    HtmlControl divImg = (HtmlControl)e.Item.FindControl("lblImg"); 
                    Literal userlbl = (Literal)e.Item.FindControl("UserLabel");
                    if (userlbl != null)
                    {
                        userlbl.Text = ((MemberCardModel)e.Item.DataItem).UserLabel;
                        divImg.Visible = true;

                    }

                    Literal userloc = (Literal)e.Item.FindControl("UserLocation");
                    if (userloc != null)
                    {
                        userloc.Text = ((MemberCardModel)e.Item.DataItem).UserLocation;


                    }

                   
                        Repeater childModel_repeater = (Repeater)e.Item.FindControl("rptChildCard");
                        if (childModel_repeater != null)
                        {
                            childModel_repeater.DataSource = ((MemberCardModel)e.Item.DataItem).Children;
                            childModel_repeater.DataBind();
                        }
                   
                }

            }


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Item currItem = Sitecore.Context.Item;

                //Child Issue Drop List
                Sitecore.Data.Fields.MultilistField childIssues = currItem.Fields["Child Issues"];
                Item[] items = childIssues.GetItems();

                foreach (var item in items)
                {
                    ddlChildIssues.Items.Add(new ListItem() { Text = item.Name, Value = item.ID.ToString() });
                }

                ddlChildIssues.DataBind();

                //Topic Drop List
                Sitecore.Data.Fields.MultilistField topics = currItem.Fields["Topics"];
                items = topics.GetItems();

                foreach (var item in items)
                {
                    ddlTopics.Items.Add(new ListItem() { Text = item.Name, Value = item.ID.ToString() });
                }

                ddlTopics.DataBind();

                memberChkbx.Attributes.Add("value", Constants.TelligentRole.Member.ToString());
                expertChkbx.Attributes.Add("value", Constants.TelligentRole.Expert.ToString());
                moderatorChkbx.Attributes.Add("value", Constants.TelligentRole.Moderator.ToString());

               // MembershipManager mem = new MembershipManager();

               // List<Member> members = mem.GetMembers();
              
                List<Member> members = new List<Member>();
                members.Add(member1);
                List<MemberCardModel> memberCardSrc = new List<MemberCardModel>();
                List<ChildCardModel> childCardSrc = new List<ChildCardModel>();
                foreach (var member in members)
                {

                    MemberCardModel mm = new MemberCardModel();
                    mm.AvatarUrl = UnderstoodDotOrg.Common.Constants.Settings.AnonymousAvatar;

                    //TODO: This is to change once we figure out retrieving users by roleid
                    mm.UserLabel = "UserLabel";

                    mm.UserLocation = UnderstoodDotOrg.Common.Constants.Settings.DefaultLocation;
                    mm.UserName = member.ScreenName;

                    ChildCardModel cm = new ChildCardModel();
                    cm.IssueList = new List<ChildCardModel.Issue>();
                    foreach (var child in member.Children)
                    {
                        cm.Gender = child.Gender;
                        cm.Grade = child.Grades.First().Value;


                        foreach (var issue in child.Issues)
                        {
                            ChildCardModel.Issue iss = new ChildCardModel.Issue();
                            iss.IssueName = issue.Value;
                            cm.IssueList.Add(iss);

                            iss = null;
                        }
                        childCardSrc.Add(cm);
                        cm = null;
                        
                    }
                    mm.Children = childCardSrc;

                    memberCardSrc.Add(mm);
                    mm = null;
                }

                rptMemberCards.DataSource = memberCardSrc;
                rptMemberCards.DataBind();

            }
            
        }

        protected void rptChildCard_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            Repeater childIssues_repeater = (Repeater)e.Item.FindControl("rptChildIssues");
            if (childIssues_repeater != null)
            {
                childIssues_repeater.DataSource = ((ChildCardModel)e.Item.DataItem).IssueList;
                childIssues_repeater.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Check values selected in search
            //Check zipcode
            string zipcode = txtZipCode.Text;
            //Check child issue selected
            string issue = ddlChildIssues.SelectedValue.ToString();
            
            //Check Topic selected
            string topic = ddlTopics.SelectedValue.ToString();

            List<Constants.TelligentRole> role = new List<Constants.TelligentRole>();
            //Check role types checked
            if (memberChkbx.Checked)
            {
                role.Add(Constants.TelligentRole.Member);
            }
            if (expertChkbx.Checked)
            {
                role.Add(Constants.TelligentRole.Expert);
                
            }

            if (moderatorChkbx.Checked)
            {
                role.Add(Constants.TelligentRole.Moderator);
            }
             
            //Perform search using criteria
            var test = FindMembers(zipcode, issue, topic, null);
            rptMemberCards.DataSource = test;
            rptMemberCards.DataBind();
        }

       

        public List<MemberCardModel> FindMembers(string zipcode,string issue,string topic,List<Constants.TelligentRole> roles)
        {

            //MembershipManager mem = new MembershipManager();

            //List<Member> members = mem.GetMembers();
            List<Member> members = new List<Member>();
            
            members.Add(member1); 
            IEnumerable <Member> workingSet = members;

            //List<MemberCardModel> memberCards = null;

            if(!String.IsNullOrEmpty(zipcode)){
                workingSet = from m in workingSet
                                    where m.ZipCode == zipcode
                                    select m;
              
            }
                                                 ///More criteria to be added
            if(!String.IsNullOrEmpty(issue)){

                workingSet = workingSet.Where(m =>
                                                (from c in m.Children
                                                 where c.Issues.Where(x => x.Key.Equals(new Guid(issue))).Count() > 0
                                                 select c).Count() > 0);
                      
            }

            if (!String.IsNullOrEmpty(topic))
            {
                workingSet = workingSet.Where(m => m.Interests.Select(x => x.Key.Equals(new Guid(topic))).Count() > 0);

                
                                                    
            }

            return workingSet.Select(m=> new MemberCardModel(m)).ToList<MemberCardModel>();


        }
    }
}