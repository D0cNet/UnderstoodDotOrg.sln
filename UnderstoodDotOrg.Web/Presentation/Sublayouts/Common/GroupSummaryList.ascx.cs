using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.Understood.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class GroupSummaryList : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            rptGroupCards.ItemDataBound += rptGroupCards_ItemDataBound;

            base.OnInit(e);
        }
        void rptGroupCards_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
           
                //if (e.Item.DataItem != null)
                //{
                //    Image avaturl = (Image)e.Item.FindControl("UserAvatar");
                //    if (avaturl != null)
                //    {
                //        avaturl.ImageUrl = ((MemberCardModel)e.Item.DataItem).AvatarUrl;


                //    }

                //    Literal username = (Literal)e.Item.FindControl("UserName");
                //    if (username != null)
                //    {
                //        username.Text = ((MemberCardModel)e.Item.DataItem).UserName;


                //    }

                //    HtmlControl divImg = (HtmlControl)e.Item.FindControl("lblImg");
                //    Literal userlbl = (Literal)e.Item.FindControl("UserLabel");
                //    if (userlbl != null)
                //    {
                //        userlbl.Text = ((MemberCardModel)e.Item.DataItem).UserLabel;
                //        divImg.Visible = true;

                //    }

                //    Literal userloc = (Literal)e.Item.FindControl("UserLocation");
                //    if (userloc != null)
                //    {
                //        userloc.Text = ((MemberCardModel)e.Item.DataItem).UserLocation;


                //    }


                    //Repeater childModel_repeater = (Repeater)e.Item.FindControl("rptChildCard");
                    //if (childModel_repeater != null)
                    //{
                    //    childModel_repeater.DataSource = ((MemberCardModel)e.Item.DataItem).Children;
                    //    childModel_repeater.DataBind();
                    //}

              //  }

       


        }
        //protected void rptChildCard_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{

        //    Repeater childIssues_repeater = (Repeater)e.Item.FindControl("rptChildIssues");
        //    if (childIssues_repeater != null)
        //    {
        //        childIssues_repeater.DataSource = ((ChildCardModel)e.Item.DataItem).IssueList;
        //        childIssues_repeater.DataBind();
        //    }
        //}

       

        public List<GroupCardModel> DataSource
        {
            set
            {
                rptGroupCards.DataSource = value;
            }
            get
            {
                return rptGroupCards.DataSource as List<GroupCardModel>;
            }
        }

        public string EmptyText { get; set; }
        public override void DataBind()
        {
            rptGroupCards.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}