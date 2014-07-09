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
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Common;
using UnderstoodDotOrg.Services.MemberServices;
using UnderstoodDotOrg.Framework.UI;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{

    public partial class All_Parents_Search : BaseSublayout//System.Web.UI.UserControl
    {
        private int ResultCount
        {
            get
            {
                return (Int32)ViewState["_resultCount"];
            }
            set
            {
                ViewState["_resultCount"] = value;
            }
        }
        public int ResultSet { get { return 16; } }

        MemberCardList rptMemberCards;
        //Member member1 = new Member()
        //        {
        //            allowConnections = true,
        //            FirstName = "adolph",
        //            LastName = "rudolph",
        //            ScreenName = "PosesHoratio",
        //            ZipCode="55555",
        //             Interests = new List<Interest>(){
        //                  new Interest(){
        //                       Key=new Guid("{E9194DCB-1A67-4CFF-A8A4-B799639AFADC}"),
        //                       Value="Growing Up"
        //                  }
        //             },
        //            Children = new List<Child>(){
        //                            new Child(){ 
        //                                Grades=new List<Grade>(){
        //                                new Grade(){Value="7", Key=Constants.GradesByValue["7"] },
        //                                }, 
        //                                Gender="Male",
        //                                Issues = new List<Issue>()
        //                                {
        //                                    new Issue(){
        //                                         Key=new Guid("{28BB0311-D062-48F0-BEDF-C2D74EB6737E}"),
        //                                        Value="Hyperactivity or Impulsivity"
        //                                    },
        //                                    new Issue(){
        //                                        Key=new Guid("{1D338D37-CF4E-4C1C-9499-EBA6C0A2BBA0}"),
        //                                        Value="Math"
        //                                    }
        //                                }
                                                 
        //                            }
                                              
        //                        }
        //        };

        protected override void OnInit(EventArgs e)
            {
                Item parentItem = Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse(Constants.Pages.ParentsLikeMeRecommended));
                string itemHref = Sitecore.Links.LinkManager.GetItemUrl(parentItem);
                refRecommended.HRef = itemHref;
                showmore.Click += showmore_Click;
                base.OnInit(e);
            }

        protected void showmore_Click(object sender, EventArgs e)
        {
            ShowMore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            rptMemberCards = (MemberCardList)Page.LoadControl("~/Presentation/Sublayouts/Common/MemberCardList.ascx");
            rptMemberCards.ID = "rptMemberCards";
            memberList.Controls.Add(rptMemberCards);

            if (!IsPostBack)
            {

                Item currItem = Sitecore.Context.Item;
                Item[] items = null;
                ResultCount = 16;
                //Child Issue Drop List
                Sitecore.Data.Fields.MultilistField childIssues = currItem.Fields["Child Issues"];
                if (childIssues != null)
                {
                    items = childIssues.GetItems();

                    foreach (var item in items)
                    {
                        ddlChildIssues.Items.Add(new ListItem() { Text = item.Name, Value = item.ID.ToString() });
                    }

                    ddlChildIssues.DataBind();
                }

                //Topic Drop List
                Sitecore.Data.Fields.MultilistField topics = currItem.Fields["Topics"];
                if (topics != null)
                {
                    items = topics.GetItems();

                    foreach (var item in items)
                    {
                        ddlTopics.Items.Add(new ListItem() { Text = item.Name, Value = item.ID.ToString() });
                    }

                    ddlTopics.DataBind();
                }
                memberChkbx.Attributes.Add("value", Constants.TelligentRoles.RegisteredUser.ToString());
                expertChkbx.Attributes.Add("value", Constants.TelligentRoles.Expert.ToString());
                moderatorChkbx.Attributes.Add("value", Constants.TelligentRoles.Moderator.ToString());

                MembershipManager mem = new MembershipManager();

                //Get all members
                List<Member> members = mem.GetMembers().Where(m => !String.IsNullOrEmpty(m.ScreenName)).ToList<Member>();
                if (CurrentMember != null)
                {
                    if (!String.IsNullOrEmpty(CurrentMember.ScreenName))
                    {
                        //All members except current logged in user
                        members = mem.GetMembers().Where(m => !String.IsNullOrEmpty(m.ScreenName)).Where(m => m.ScreenName.Trim() != CurrentMember.ScreenName.Trim()).ToList<Member>();
                    }
                }


                Session["members"] = members;

                //List<Member> members = new List<Member>();
                //members.Add(member1);
                //Session["members"] = members;

                //TODO: To replace with actual data for production
                //MembershipManagerProxy mem = new MembershipManagerProxy();

                //List<Member> members = new List<Member>() { mem.GetMember(Guid.Empty) };
                //////////////////////////////////////////////////////////


                List<MemberCardModel> memberCardSrc = members.Select(m => new MemberCardModel(m, User.GetUserBadges)).ToList<MemberCardModel>();

                Session["members_parents"] = memberCardSrc;
                rptMemberCards.DataSource = memberCardSrc.Take(ResultCount).ToList<MemberCardModel>();
                rptMemberCards.DataBind();

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

            var role = new List<int>();
            //Check role types checked
            if (memberChkbx.Checked)
            {
                role.Add(Constants.TelligentRoles.RegisteredUser);
            }
            if (expertChkbx.Checked)
            {
                role.Add(Constants.TelligentRoles.Expert);
                
            }

            if (moderatorChkbx.Checked)
            {
                role.Add(Constants.TelligentRoles.Moderator);
            }
             
            //Perform search using criteria
            var test = FindMembers(zipcode, issue, topic, null);
            rptMemberCards.DataSource = test;
            rptMemberCards.DataBind();
        }

       

        private List<MemberCardModel> FindMembers(string zipcode,string issue,string topic,List<int> roles)
        {

            //MembershipManager mem = new MembershipManager();

            //List<Member> members = mem.GetMembers();
            //List<Member> members = new List<Member>();
            
            //members.Add(member1); 
            List<Member> members = Session["members"] as List<Member>;

            if (members != null)
            {
                IEnumerable<Member> workingSet = members;

                //List<MemberCardModel> memberCards = null;

                if (!String.IsNullOrEmpty(zipcode))
                {
                    workingSet = from m in workingSet
                                 where m.ZipCode == zipcode
                                 select m;

                }
                ///More criteria to be added
                if (!String.IsNullOrEmpty(issue))
                {

                    workingSet = workingSet.Where(m =>
                                                    (from c in m.Children
                                                     where c.Issues.Any(x => x.Key.ToString().Equals(new Guid(issue).ToString()))
                                                     select c).Count() > 0);

                }

                if (!String.IsNullOrEmpty(topic))
                {
                    workingSet = workingSet.Where(m => m.Interests.Any(x => x.Key.ToString().Equals(new Guid(topic).ToString())));



                }
                var memberModels = workingSet.Select(m => new MemberCardModel(m,User.GetUserBadges)).ToList<MemberCardModel>();
                Session["members_parents"] = memberModels;
                return memberModels;

            }
            return null;
        }

        protected void ShowMore()
        {
            //List<MemberCardModel> m = rptMemberCards.DataSource as List<MemberCardModel>;
            //if (m != null)
            //{
                var mems = (List<MemberCardModel>)Session["members_parents"];

                if (mems != null)
                {
                    ResultCount += ResultSet;
                    rptMemberCards.DataSource = mems.Take(ResultCount).ToList();
                    rptMemberCards.DataBind();

                    //If at the end of result set
                    if(mems.Count()<= ResultCount)
                        showmore.Visible = false;
                }
        }

      
    }
}