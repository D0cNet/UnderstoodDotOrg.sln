<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Private Message Tool.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.MyAccount.Private_Message_Tool" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<header>
			<div class="notification-tabs-wrapper select-inverted-mobile">
			  <div class="notifications-section-dropdown tab-widget">
				<span class="select-container">
				  <label for="notifications-tab-dropdown" class="visuallyhidden">Filter Notifications</label>
				  <select name="notifications-tab-dropdown">
					<option value="notifications">What's Been Happening</option>
					<option value="messages">Private Messages</option>
					<option value="email">Email & Alert Preferences</option>
				  </select>
				</span>
				<span class="notifications-count circle purple">0</span>
				<span class="messages-count circle purple">0</span>
			  </div>
			  <div class="notifications-section-tabs tab-widget tab-container">
				<ul>
				  <li class="notifications-tab ">
					<a href="REPLACE">What's Been Happening<span class="circle">0</span></a>
				  </li>
				  <li class="messages-tab active">
					<a href="REPLACE">Private Messages<span class="circle">0</span></a>
				  </li>
				  <li class="email-tab last ">
					<a href="REPLACE">Email & Alert Preferences</a>
				  </li>
				  <li class="dummy"><a href="#nowhere">&nbsp;</a></li>
				</ul>
			  </div>
			</div><!-- .notification-tabs-wrapper -->
		  </header>
<div class="account-body-wrapper">
			<!-- BEGIN PARTIAL: account-notification-tab-messages -->
		<section class="account-notifications-tab-messages">
			
      <%--      <asp:Panel Width="880" Height="700" runat="server">
                <div id="conversti"
                <div class="header"> 
                    <span>Inbox (3)
                    <asp:Button Text="New Message" CssClass="button" runat="server" /></span>
                    <span><asp:Label Text="Thomas Friedman"></asp:Label> </span>
                    <asp:Button Text="Delete" CssClass="button" runat="server" />
                </div>
                
                <CKEditor:CKEditorControl ID="CKEditor1"  
                    Toolbar="Basic" 
                    runat="server" 
                    BasePath="~/Presentation/Sublayouts/Tools/MyAccount/ckeditor" 
                    ContentsCss="~/Presentation/Sublayouts/Tools/MyAccount/ckeditor/contents.css" 
                    TemplatesFiles="~/Presentation/Sublayouts/Tools/MyAccount/ckeditor/plugins/templates/templates/default.js">

                </CKEditor:CKEditorControl>
                <asp:Button Text="Submit Reply" CssClass="button" ID="btnReply" runat="server" OnClick="btnReply_Click" />
               
              
        </asp:Panel>--%>
            <sc:PlaceHolder ID="Tool" runat="server"></sc:PlaceHolder>
		</section>

<!-- END PARTIAL: account-notification-tab-messages -->
</div><!-- .account-body-wrapper -->

