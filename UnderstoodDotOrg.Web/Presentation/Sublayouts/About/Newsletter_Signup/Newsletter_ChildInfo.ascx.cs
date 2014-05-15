using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages.NewsLetter;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.Understood.Helper;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About.Newsletter_Signup
{
    public partial class Newsletter_ChildInfo : System.Web.UI.UserControl
    {
        Newsletter_ChildInfoItem ObjChildInfo;
        IEnumerable<Item> _allIssues, _allGrades;
        int _checkboxLocation = 0;
        object[][] TwoRowdata;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjChildInfo = new Newsletter_ChildInfoItem(Sitecore.Context.Item);
            if (ObjChildInfo != null)
            {
                _allIssues = Newsletter_ChildInfoItem.GetAllIssues();
                if (_allIssues != null)
                {

                    int TotalRows = GetRowCount(_allIssues, 2);
                    TwoRowdata = GetTwoRowData(_allIssues, 2);
                    string[] Rows = new string[2];
                    Rows[0] = "One";
                    Rows[1] = "Two";

                    rptChildIssue.DataSource = Rows;
                    rptChildIssue.DataBind();



                }
                if (!string.IsNullOrEmpty(ObjChildInfo.NextpagetoShow.Url.ToString()))
                {
                    btnNext.PostBackUrl = ObjChildInfo.NextpagetoShow.Url;
                }
                _allGrades = Newsletter_ChildInfoItem.GetAllGrades();
                if (_allGrades != null)
                {
                    ddlGrades.Items.Clear();
                    ddlGrades.Items.Add(new ListItem("Select Grade", ""));
                    foreach (Item _grade in _allGrades)
                    {
                        if (_grade.Name.ToLower() != "all")
                        {
                            ddlGrades.Items.Add(new ListItem(_grade.Name, _grade.Name));
                        }
                    }

                }

            }
        }

        protected int GetRowCount(IEnumerable<Item> ListData1, int ItemPerRow1)
        {
            int RowCounter = 0;
            if (ListData1.Count() > ItemPerRow1)
            {
                if (ListData1.Count() % ItemPerRow1 != 0)
                {
                    RowCounter = (ListData1.Count() / ItemPerRow1) + 1;
                }
                else
                {
                    RowCounter = ListData1.Count() / ItemPerRow1;
                }
            }
            return RowCounter;
        }
        protected object[][] GetTwoRowData(IEnumerable<Item> ListData, int ItemPerRow)
        {
            int RowCounter = 0;
            object[][] _jaggedArray = null;

            RowCounter = GetRowCount(ListData, ItemPerRow);

            List<Item> _listData = new List<Item>(ListData.Count());
            foreach (Item expert in ListData)
            {
                _listData.Add(expert);
            }
            int _objectat = 0;
            if (RowCounter != 0)
            {

                _jaggedArray = new object[ItemPerRow][];

                for (int i = 0; i < ItemPerRow; i++)
                {
                    _jaggedArray[i] = new object[RowCounter];
                    for (int j = 0; j < RowCounter; j++)
                    {
                        if (_objectat < _listData.Count())
                        {
                            _jaggedArray[i][j] = _listData[_objectat];
                            _objectat++;
                        }
                    }
                }
            }

            return _jaggedArray;
        }


        protected void rptChildIssue_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            string Num = e.Item.DataItem as string;
            if (Num != "")
            {
                Repeater rptIssueCol = e.FindControlAs<Repeater>("rptIssueCol");
                if (rptIssueCol != null)
                {
                    if (Num == "One")
                    {

                        rptIssueCol.DataSource = TwoRowdata[0];
                        rptIssueCol.DataBind();
                    }
                    else
                    {
                        rptIssueCol.DataSource = TwoRowdata[1];
                        rptIssueCol.DataBind();
                    }
                }

            }


        }



        protected void rptIssueCol_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Item _issue = e.Item.DataItem as Item;
                if (_issue != null)
                {

                    CheckBox chkIssue1 = e.FindControlAs<CheckBox>("chkIssue1");
                    if (chkIssue1 != null)
                    {
                        FieldRenderer frCheckItem1 = e.FindControlAs<FieldRenderer>("frCheckItem1");
                        if (frCheckItem1 != null)
                        {
                            frCheckItem1.Item = _issue;
                        }
                    }


                }
            }
        }
    }
}