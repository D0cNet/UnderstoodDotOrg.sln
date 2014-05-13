using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Recommendation;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.ContentSearch.SearchTypes;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Recommendation
{
    public partial class Multiple_Children : System.Web.UI.UserControl
    {
        MultipleChildrenItem ObjMultipleChildren;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjMultipleChildren = new MultipleChildrenItem(Sitecore.Context.Item);
            if (ObjMultipleChildren != null)
            {
                //Get the list of chidlrens to assign rptChildBasicInfo
                //rptChildBasicInfo.DataSource= Child Item list;
                //rptChildBasicInfo.DataBind();

            }


        }

        protected void rptChildBasicInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                //Create item of type Child!
                //Child ObjChild= e.Item.DataItem as Child
                {
                    FieldRenderer frChildName = e.FindControlAs<FieldRenderer>("frChildName");
                    if (frChildName != null)
                    {
                        //frChildName.Item=current ChildControlsCreated Item;
                    }
                    FieldRenderer frWhyGrade = e.FindControlAs<FieldRenderer>("frWhyGrade");
                    if (frWhyGrade != null)
                    {
                        //frWhyGrade.Item=Current ChildControlsCreated Item;
                    }
                    FieldRenderer frWhyChildGender = e.FindControlAs<FieldRenderer>("frWhyChildGender");
                    if (frWhyChildGender!=null)
                    {
                        //frWhyChildGender.Item=current ChildControlsCreated item;
                    }
                    Label lblCHildNameRecommendText = e.FindControlAs<Label>("lblCHildNameRecommendText");
                    if (lblCHildNameRecommendText != null)
                    {
                        //lblCHildNameRecommendText.Text="Recommendations match what you told us about " + Child's Name;
                    }
                    
                    Repeater rptChildRelatedArticles = e.FindControlAs<Repeater>("rptChildRelatedArticles");
                    if (rptChildRelatedArticles != null)
                    {
                        //Get the list of matching articles according to each child and assign to rptChildRelatedArticles
                    }
                    //Get the list of matching issues of child and assign to rptChildIssuesList
                        
                 
                }
            }
        }

        protected void rptChildRelatedArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.IsItem())
            {
                //Create Obj of ARticle Type
                //Articles ObjArticle = e.Item.DataItem as Articles;
                {
                    HyperLink hlArticleImage = e.FindControlAs<HyperLink>("hlArticleImage");
                    if(hlArticleImage!=null)
                    {
                        //hlArticleImage.NavigateUrl=;
                        FieldRenderer frArticleImage = e.FindControlAs<FieldRenderer>("frArticleImage");
                        if (frArticleImage != null)
                        {
                            //frArticleImage.Item = ObjArticle;
                        }
                    }
                    HyperLink hlArtcielTitle = e.FindControlAs<HyperLink>("hlArtcielTitle");
                    if (hlArtcielTitle != null)
                    {
                        //hlArtcielTitle.NavigateUrl=;
                        FieldRenderer frArticleTitle = e.FindControlAs<FieldRenderer>("frArticleTitle");
                        if (frArticleTitle != null)
                        {
                            //frArticleTitle.Item = ObjArticle;
                        }
                    }
                    FieldRenderer frArticleGrade = e.FindControlAs<FieldRenderer>("frArticleGrade");
                    if (frArticleGrade != null)
                    {
                        //frArticleGrade.Item = ObjArticle;
                    }
                }

            }
        }

        protected void rptChildIssuesList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                //ChildIssue ObjChildIssue = e.Item.DataItem as ChildIssue;
                {
                    FieldRenderer frChildIssue = e.FindControlAs<FieldRenderer>("frChildIssue");
                    if (frChildIssue != null)
                    {
                        //frChildIssue.Item = ObjChildIssue;
                    }
                    HyperLink hlReplaceMatchingIssues = e.FindControlAs<HyperLink>("hlReplaceMatchingIssues");
                    if (hlReplaceMatchingIssues != null)
                    {
                        //hlReplaceMatchingIssues.NavigateUrl= Navigate to page where Usrer can edit childs related Info;
                    }
                }
            }
        }

     
    }
}