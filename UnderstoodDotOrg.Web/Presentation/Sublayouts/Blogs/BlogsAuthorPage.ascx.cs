using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;
using UnderstoodDotOrg.Common.Extensions;
using System.Web.UI.HtmlControls;
using Sitecore.Data.Fields;
using Sitecore.Links;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs
{
    public partial class BlogsAuthorPage : System.Web.UI.UserControl
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
        public int ResultSet { get { return 5; } }


        protected override void OnInit(EventArgs e)
        {
            rptrBlogPosts.ItemDataBound+=rptrBlogPosts_ItemDataBound;
            showmore.Click += showmore_Click;
            base.OnInit(e);
        }
        protected void showmore_Click(object sender, EventArgs e)
        {
            ShowMore();
        }

        protected void ShowMore()
        {
            //List<MemberCardModel> m = rptMemberCards.DataSource as List<MemberCardModel>;
            //if (m != null)
            //{
            var mems = (List<BlogsPostPageItem>)Session["_posts"];

            if (mems != null)
            {
                ResultCount += ResultSet;
                rptrBlogPosts.DataSource = mems.Take(ResultCount).ToList();
                rptrBlogPosts.DataBind();

                //If at the end of result set
                if (mems.Count() <= ResultCount)
                    showmore.Visible = false;
            }
        }
        private void rptrBlogPosts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.DataItem!=null)
            {
                if(e.Item.ItemType == ListItemType.Item ||e.Item.ItemType == ListItemType.AlternatingItem)
                {
                   
                   HtmlAnchor blogLink = e.FindControlAs<HtmlAnchor>("hrefBlogLink");
                    if(blogLink!=null)
                    {
                        blogLink.HRef = ((BlogsPostPageItem)e.Item.DataItem).GetUrl();
                    }

                    Literal blogName = e.FindControlAs<Literal>("litBlogPostName");
                    if(blogName!=null)
                    {
                        blogName.Text = ((BlogsPostPageItem)e.Item.DataItem).Title.Text;
                    }

                    Literal blogExceprt = e.FindControlAs<Literal>("litBlogExcerpt");
                    if (blogExceprt != null)
                    {
                        blogExceprt.Text = UnderstoodDotOrg.Domain.TelligentCommunity.CommunityHelper.FormatString100(((BlogsPostPageItem)e.Item.DataItem).Body.Text);
                    }


                    DateTime dateStamp = ((BlogsPostPageItem)e.Item.DataItem).Date.DateTime;
                    if (dateStamp != null)
                    {
                        string friendlyDate = UnderstoodDotOrg.Domain.TelligentCommunity.CommunityHelper.FormatDate(dateStamp.ToString());
                        char [] delim ={' '};
                        string [] timePieces  =friendlyDate.Split(delim,StringSplitOptions.RemoveEmptyEntries);
                        if (timePieces.Count() > 1)
                        {
                            int num;
                            if (Int32.TryParse(timePieces[0], out num))
                            {

                                Literal timePart = e.FindControlAs<Literal>("litBlogPostTime");
                                if (timePart != null)
                                {
                                    timePart.Text = num.ToString();
                                }
                            } 
                           
                            Literal AgePart = e.FindControlAs<Literal>("litBlogAge");
                            if (AgePart != null)
                            {
                                AgePart.Text = String.Join(new string(delim), timePieces, 1, timePieces.Length-1);
                            }
                            

                            

                        }
                        else
                        {
                            Literal AgePart = e.FindControlAs<Literal>("litBlogAge");
                            if (AgePart != null)
                            {
                                AgePart.Text = String.Join(new string(delim), timePieces, 0, timePieces.Length-1);
                            }
                        }
                    }
                }
            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Item authorItem = Sitecore.Context.Item;
            hrefBackLink.HRef = LinkManager.GetItemUrl( Sitecore.Context.Database.GetItem(Constants.Pages.AllBlogs));
            litBackLink.Text = Sitecore.Context.Database.GetItem(Constants.Pages.AllBlogs).Name;
            if (!IsPostBack)
            {
                ResultCount = 5;
                if (authorItem != null)
                {


                    //Retrieve all BlogPosts with author 
                    List<BlogsPostPageItem> posts = Sitecore.Context.Database.SelectItems("fast:/sitecore/content/Home//*[@@templateid='" + Constants.BlogPost.BlogPostTemplateID + "' and @Author='" + authorItem.Name + "']").Select(x => new BlogsPostPageItem(x)).ToList();
                    var temp = posts.OrderByDescending(x => x.Date.DateTime).ToList();
                    Session["_posts"] = temp;
                    rptrBlogPosts.DataSource = temp.Take(ResultCount).ToList();
                    rptrBlogPosts.DataBind();
                }
            }
        }
    }
}