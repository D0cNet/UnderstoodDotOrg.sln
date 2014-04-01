<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Author Bio.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.Author_Bio" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="count-mobile">
    <!-- Show Authors details including Name, Bio, Image and list of posts from this author -->
    <table>
        <tr>
            <td>Author Image: 
                <sc:Image ID="ImgAuthorImage" runat="server" Field="Author Image" Alt="No any Image" />
            </td>
            <td>Author Name:
    <sc:FieldRenderer ID="frAuthorName" runat="server" FieldName="Author Name" />
                <br />
                Author Bio:
    <sc:FieldRenderer ID="frAuthorBio" runat="server" FieldName="Author Biodata" />
            </td>
        </tr>
        <tr>
            <!--list of all posts from this author -->
        </tr>
    </table>
    <br />

    <br />

</div>
