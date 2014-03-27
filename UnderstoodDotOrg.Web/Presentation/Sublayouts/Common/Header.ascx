<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Header" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- BEGIN PARTIAL: header -->
<header id="header-page" class="container">
    <div class="row">
        <div class="col col-24">

            <div class="logo-u-main">

                <asp:HyperLink runat="server" ID="hlLogoLink">
                    <sc:FieldRenderer runat="server" ID="scLogoImage" FieldName="Company Logo" Parameters="w=235&h=73&as=1" />
                </asp:HyperLink>
                <%--<a href="REPLACE.html">
                    <img alt="Understood Logo" src="/Presentation/includes/img/logo.u.default.png" /></a>--%>
            </div>
            <!-- logo-u-main -->
            <asp:Repeater runat="server" ID="rptLanguage" OnItemDataBound="rptLanguage_ItemDataBound">
                <HeaderTemplate>
                    <ul class="language-selection">
                </HeaderTemplate>
                <ItemTemplate>
                    <li><%--<a href="REPLACE.html" title="English" class="is-active">Eng</a>--%>
                        <asp:HyperLink runat="server" ID="hypLanguageLink"></asp:HyperLink>

                        <%--<sc:fieldrenderer id="frLanguageLink" runat="server" fieldname="Link" />--%>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
            <%-- <ul class="language-selection">
                <li><a href="REPLACE.html" title="English" class="is-active">Eng</a></li>
                <li><a href="REPLACE.html" title="Espa&ntilde;ol">Esp</a></li>
            </ul>--%>
            <!-- .language-selection -->

            <div class="l-bar">
                <asp:Repeater runat="server" ID="rptNavUtility" OnItemDataBound="rptNavUtility_ItemDataBound">
                    <HeaderTemplate>
                        <nav class="nav-utility">
                            <ul role="menu">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li role="menuitem" aria-haspopup="true"><%--<a href="REPLACE.html">About</a>--%>
                            <sc:FieldRenderer ID="frUtilityLink" runat="server" FieldName="Link" />
                            <asp:Literal runat="server" ID="ltRender" ></asp:Literal>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                </nav>
                    </FooterTemplate>
                </asp:Repeater>
                <%--<nav class="nav-utility">
                    <ul role="menu">
                        <li role="menuitem" aria-haspopup="true"><a href="REPLACE.html">About</a></li>
                        <li role="menuitem" aria-haspopup="true"><a href="REPLACE.html">Take Action</a></li>
                        <li role="menuitem" aria-haspopup="true"><a href="REPLACE.html">Donate</a></li>
                    </ul>
                </nav>--%>
                <!-- .nav-utility -->

                <!-- BEGIN PARTIAL: user-state -->
                <div class="sign-in" aria-haspopup="true">
                    <sc:FieldRenderer runat="server" ID="scLinkSignIn" FieldName="Sign In" Parameters="class=link-sign-in"/>
                    <%--<a href="REPLACE.html" class="link-sign-in">Sign In</a>--%>
                </div>

                <!-- END PARTIAL: user-state -->

                <div id="search-site">
                    <fieldset>
                        <legend><sc:FieldRenderer ID="frSearchLabel1" runat="server" FieldName="Link" /><%--Search--%></legend>
                        <span class="field">
                            <label for="search-term" class="visuallyhidden"><sc:FieldRenderer ID="frSearchLabel2" runat="server" FieldName="Link" /><%--Search--%></label>
                            <input type="text" id="search-term" placeholder="Enter Search Term">
                            <input type="submit" value="Go">
                        </span>
                    </fieldset>
                </div>
                <!-- #search-site -->

            </div>
            <!-- .l-bar -->

            <!-- BEGIN PARTIAL: nav-main -->
            <asp:Repeater runat="server" ID="rptMainNavigation" OnItemDataBound="rptMainNavigation_ItemDataBound">
                <HeaderTemplate>
                    <nav class="nav-main">
                        <ul role="menu">
                </HeaderTemplate>
                <ItemTemplate>
                    <li role="menuitem" aria-haspopup="true"><span>
                        <sc:FieldRenderer ID="frMainNavigationLink" runat="server" FieldName="Link" />
                    </span>
                        <asp:Repeater runat="server" ID="rptPrimaryNavigation" OnItemDataBound="rptPrimaryNavigation_ItemDataBound">
                            <HeaderTemplate>
                                <ul>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li role="menuitem"><span>
                                    <sc:FieldRenderer ID="frPrimaryNavigationLink" runat="server" FieldName="Link" />
                                </span></li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
            </nav>
                </FooterTemplate>
            </asp:Repeater>
            <%--            <nav class="nav-main">
                <ul role="menu">
                    <li role="menuitem" aria-haspopup="true"><span><a href="REPLACE.html">Learning &amp;<br>
                        Attention Issues</a></span>
                        <ul>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum dolor sit amet consectetuer</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum dolor</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum dolor sit</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum dolor sit amet</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum dolor</a></span></li>
                        </ul>
                    </li>
                    <li role="menuitem" aria-haspopup="true"><span><a href="REPLACE.html">School &amp;<br>
                        Learning</a></span>
                        <ul>
                            <li role="menuitem"><span><a href="REPLACE.html">Partnering with your child's school</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Evaluations</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Special Services</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Your child's rights</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Choosing or changing schools</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Learning at home</a></span></li>
                        </ul>
                    </li>
                    <li role="menuitem" aria-haspopup="true"><span><a href="REPLACE.html">Friends &amp;<br>
                        Feelings</a></span>
                        <ul>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum dolor sit amet consectetuer</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum dolor</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum dolor sit</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum dolor sit amet</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum dolor</a></span></li>
                        </ul>
                    </li>
                    <li role="menuitem" aria-haspopup="true"><span><a href="REPLACE.html">You &amp;<br>
                        Your Family</a></span>
                        <ul>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum dolor sit amet consectetuer</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum dolor</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum dolor sit</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum dolor sit amet</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum dolor</a></span></li>
                        </ul>
                    </li>
                    <li role="menuitem" aria-haspopup="true"><span><a href="REPLACE.html">Community &amp;<br>
                        Events</a></span>
                        <ul>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum dolor sit amet consectetuer</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum dolor</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum dolor sit</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum dolor sit amet</a></span></li>
                            <li role="menuitem"><span><a href="REPLACE.html">Lorem ipsum dolor</a></span></li>
                        </ul>
                    </li>
                </ul>
            </nav>--%>
            <!-- END PARTIAL: nav-main -->

            <div id="toolkit" aria-haspopup="true"><span><%--Your Parent Toolkit--%>
                <sc:FieldRenderer ID="frParentToolKitHeading" runat="server" FieldName="Heading" />
                                                   </span></div>

        </div>
        <!-- .col -->
    </div>
    <!-- .row -->

    <!-- toolkit header row -->
    <div class="row toolkit-row">
        <div class="col col-24">
            <!-- BEGIN PARTIAL: toolkit-header -->
            <div id="parent-toolkit-wrapper">
                <div class="parent-toolkit-header-container arrows-gray">

                    <h2>Your Parent Toolkit</h2>

                    <span class="button-close"><i class="icon-close-toolkit"></i>Close</span>
                    <asp:Repeater runat="server" ID="rptParentToolkit" OnItemDataBound="rptParentToolkit_ItemDataBound" >
                        <HeaderTemplate>
                             <div class="slides-container">
                        </HeaderTemplate>
                        <ItemTemplate>
                             <li>
                                    <asp:Panel runat="server" ID="pnlParentToolKit" CssClass="icon">
                                         <sc:FieldRenderer ID="frNavLink" runat="server" FieldName="Link" />
                                        <%--<a href="REPLACE.html">My Support Plan</a>--%>
                                        <%--<div class="coming-soon">Coming Soon</div>--%>
                                    </asp:Panel>
                                </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                    <%--<div class="slides-container">

                        <div class="slide">
                            <ul>
                                <li>
                                    <div class="icon support-plan">
                                        <a href="REPLACE.html">My Support Plan</a>
                                        <div class="coming-soon">Coming Soon</div>
                                    </div>
                                </li>
                                <li>
                                    <div class="icon observation-logs">
                                        <a href="REPLACE.html">Observation Log</a>
                                    </div>
                                </li>

                                <li>
                                    <div class="icon childs-world">
                                        <a href="REPLACE.html">A Childs World</a>
                                    </div>
                                </li>
                            </ul>
                        </div>
                        <!-- .slide -->

                        <div class="slide">
                            <ul>
                                <li>
                                    <div class="icon find">
                                        <a href="REPLACE.html">Find Technology</a>
                                    </div>
                                </li>
                                <li>
                                    <div class="icon decisions">
                                        <a href="REPLACE.html">My Decisions</a>
                                    </div>
                                </li>

                                <li>
                                    <div class="icon rate-schools">
                                        <a href="REPLACE.html">Rate Schools</a>
                                    </div>
                                </li>
                            </ul>
                        </div>
                        <!-- .slide -->
                        <div class="slide">
                            <ul>
                                <li>
                                    <div class="icon observation-logs">
                                        <a href="REPLACE.html">Icon Title Here</a>
                                    </div>
                                </li>
                                <li>
                                    <div class="icon find">
                                        <a href="REPLACE.html">Icon Title Here</a>
                                    </div>
                                </li>
                            </ul>
                        </div>
                        <!-- .slide -->
                    </div>--%>
                    <!-- .slides-container -->

                </div>
                <!-- .parent-toolkit-header-container -->
            </div>
            <!-- #parent-toolkit-wrapper -->
            <!-- END PARTIAL: toolkit-header -->
        </div>
    </div>

</header>
<!-- #header-page -->
<!-- END PARTIAL: header -->
