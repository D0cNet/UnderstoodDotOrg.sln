<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InternationalUserDisclaimer.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.InternationalUserDisclaimer" %>

<div class="container signup-international flush">
	<div class="row skiplink-content" aria-role="main">
		<!-- article -->
		<div class="col col-12 centered rs_read_this">
			<header>
				<h1><sc:FieldRenderer FieldName="Page Title" runat="server" /></h1>
			</header>
			<sc:FieldRenderer FieldName="Body Content" runat="server" />
            <asp:LinkButton runat="server" ID="lnkSignUp" OnClick="lnkSignUp_Click"></asp:LinkButton>
            &nbsp;<asp:Literal runat="server" ID="uxOr"></asp:Literal>&nbsp;
            <asp:LinkButton runat="server" ID="lnkSignIn" OnClick="lnkSignIn_Click"></asp:LinkButton>
		</div>
		<!-- .col-->
	</div>
	<!-- .row -->
</div>
<!-- .container-->
