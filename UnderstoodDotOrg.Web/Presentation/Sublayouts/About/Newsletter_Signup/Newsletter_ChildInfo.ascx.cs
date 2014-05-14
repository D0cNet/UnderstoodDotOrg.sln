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
                    if (TwoRowdata != null)
                    {
                        for (int i = 0; i < TotalRows; i++)
                        {
                            _checkboxLocation = 0;
                            rptChildIssue.DataSource = TwoRowdata[i];
                            rptChildIssue.DataBind();
                        }

                    }

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
                        ddlGrades.Items.Add(new ListItem(_grade.Name, _grade.Name));
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
                _jaggedArray = new object[RowCounter][];

                for (int i = 0; i < RowCounter; i++)
                {
                    _jaggedArray[i] = new object[ItemPerRow];
                    for (int j = 0; j < ItemPerRow; j++)
                    {
                        if (_objectat< _listData.Count())
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
            if (e.IsItem())
            {
                Item _issue = e.Item.DataItem as Item;
                if (_issue != null)
                {
                    if (_checkboxLocation == 0)
                    {
                        Panel pnlRow1 = e.FindControlAs<Panel>("pnlRow1");
                        if (pnlRow1 != null)
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
                            pnlRow1.Visible = true;
                        }
                        
                    }
                    else
                    {
                        Panel pnlRow2 = e.FindControlAs<Panel>("pnlRow2");
                        if (pnlRow2 != null)
                        {
                            CheckBox chkIssue2 = e.FindControlAs<CheckBox>("chkIssue2");
                            if (chkIssue2 != null)
                            {
                                FieldRenderer frCheckItem2 = e.FindControlAs<FieldRenderer>("frCheckItem2");
                                if (frCheckItem2 != null)
                                {
                                    frCheckItem2.Item = _issue;
                                }
                            }
                            pnlRow2.Visible = true;
                        }
                        
                    }
                    _checkboxLocation++;
                }
            }
        }
    }
}