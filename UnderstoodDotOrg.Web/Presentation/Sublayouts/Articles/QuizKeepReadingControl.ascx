<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuizKeepReadingControl.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.QuizKeepReadingControl" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

      <!-- BEGIN PARTIAL: keep-reading -->
<%--<div class="keep-reading keep-reading-mobile">--%>

  <h3><%--Keep Reading--%>
      <sc:FieldRenderer ID="frHeadline"  runat="server" FieldName="Keep Reading Headline"/>
  </h3>
    <asp:Repeater ID="rptKeepReading" runat="server" OnItemDataBound="rptKeepReading_ItemDataBound">
        <ItemTemplate>
            <ul>
                <li>
                    <asp:HyperLink ID="hlPageTitle" runat="server">
                        <sc:FieldRenderer ID="frPageTitle" runat="server" FieldName="Page Title" />
                    </asp:HyperLink>
                </li>
            </ul>
        </ItemTemplate>
    </asp:Repeater>
  <%--<ul>
    <li><a href="REPLACE">10 Tips to Help Kids Get Organized</a></li>
    <li><a href="REPLACE">How to Build a Homework Plan</a></li>
    <li class="last-child"><a href="REPLACE">Make Space for Learning: The Perfect Study Nook</a></li>
  </ul>--%>

<!-- END PARTIAL: keep-reading -->