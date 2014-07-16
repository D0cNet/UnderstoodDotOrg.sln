<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserComments.aspx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.AjaxData.UserComments" %>
<%@ Register TagPrefix="uc1" TagName="CommentList" Src="~/Presentation/Sublayouts/Account/Common/CommentList.ascx" %>

<uc1:CommentList runat="server" ID="ucCommentList" />
<asp:Placeholder id="phMoreResults" runat="server" Visible="false"><input type="hidden" /></asp:Placeholder>