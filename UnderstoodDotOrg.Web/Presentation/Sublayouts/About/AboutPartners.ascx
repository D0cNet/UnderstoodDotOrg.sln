<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AboutPartners.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.About.AboutPartners" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>



<div class="container">
    <div class="row">
        <div class="col col-24 skiplink-content" aria-role="main">
            <!-- BEGIN PARTIAL: about/about-partners -->
            <div class="col offset-1 our-partners-intro rs_read_this ourPartners">
                <h2><%--Our Partners--%>
                    <sc:FieldRenderer ID="frPartnerPageHeadline" runat="server" FieldName="Partner Page Headline" />
                </h2>
                <p>
                    <%--Earum perspiciatis quis magni repellat qui. enim praesentium aut voluptas quisquam magni quidem corporis nihil recusandae sit. est ut corporis occaecati cupiditate explicabo omnis perferendis qui quos. similique vitae explicabo omnis enim aut eveniet. ut temporibus officia maxime quasi quisquam vitae delectus. et doloribus sit reiciendis iure delectus dolorem consequatur sequi possimus vel consequatur consequatur. mollitia nam incidunt impedit cumque possimus consequatur reprehenderit non ut dolores voluptas--%>
                    <sc:FieldRenderer ID="frPartnerPageSummary" runat="server" FieldName="Partner Page Summary" />
                </p>
            </div>
            <div class="clearfix"></div>
            <hr>
            <!-- END PARTIAL: about/about-partners -->
            <!-- BEGIN PARTIAL: about/about-partners-list -->
            <div class="offset-1">
                <div class="about-partners-list">
                    <div class="rs_read_this partners-list-rs-wrapper">
                        <h2><%--Learn more about our partners--%>
                            <sc:FieldRenderer ID="frPartnerListHeadline" runat="server" FieldName="Partner List Headline" />
                        </h2>
                        <p>
                            <%--Dolor minima distinctio eos sequi quod dolorum earum non et. numquam quia esse quia reiciendis. sunt architecto quia ut quidem consequatur incidunt facere. iste assumenda non et et eos qui cumque veritatis accusamus necessitatibus quod. repellat magnam omnis et culpa et eaque occaecati tempora molestiae et. quibusdam nulla neque qui deleniti esse debitis--%>
                            <sc:FieldRenderer ID="frPartnerListSummary" runat="server" FieldName="Partner List Summary" />
                        </p>
                    </div>
                    <asp:Repeater ID="rptPartnerInfo" runat="server" OnItemDataBound="rptPartnerInfo_ItemDataBound">
                        <ItemTemplate>
                            <div class="partner-block rs_read_this">
                                <div class="col col-14 push-8 partner-head">
                                    <div class="partner-block-head">
                                        <h3>
                                            <asp:HyperLink ID="hlPartnerNameLink" runat="server">
                                                <sc:FieldRenderer ID="frPartnerName" runat="server" FieldName="Partner Name" />
                                            </asp:HyperLink>
                                        </h3>
                                    </div>
                                    <!-- end partner-block-head -->
                                </div>
                                <!-- end col col-14 push-8 -->
                                <div class="col col-1"></div>
                                <div class="col col-7 pull-15 partner-logo">
                                    <div class="partner-block-logo">
                                        <asp:HyperLink ID="hlPartnerLogo" runat="server">
                                            <sc:Image ID="imgPartnerLogo" runat="server" Field="Logo" Parameters="mw=271&mh=131" />
                                        </asp:HyperLink>
                                    </div>
                                    <!-- end partner-block-logo -->
                                </div>
                                <!-- end col col-7 pull-15 -->
                                <div class="col col-14 push-8 partner-intro">
                                    <div class="partner-block-text">
                                        <p>
                                            <%--eos sit eum tempora et sed quis illum omnis repellendus quidem voluptatum dolores maiores consequuntur--%>
                                            <sc:FieldRenderer ID="frPartnerDescription" runat="server" FieldName="Short Description" />
                                        </p>
                                        <span class="partner-block-read-more"><%--<a href="REPLACE">Read more</a>--%>
                                            <asp:HyperLink ID="hlPartnerSite" runat="server" Text="Read more"></asp:HyperLink>
                                        </span>
                                    </div>
                                    <!-- end partner-block-text -->
                                </div>
                                <!-- end col col-14 push-8 partner-intro-->
                            </div>
                            <!-- end partner-block -->
                            <div class="clearfix"></div>
                        </ItemTemplate>
                    </asp:Repeater>




                </div>
                <!-- end about-partner-list -->
            </div>
            <!-- end col offset-1 -->
            <!-- END PARTIAL: about/about-partners-list -->
        </div>
    </div>
    <!-- end .row -->
</div>
<!-- end .container -->

<!-- BEGIN PARTIAL: footer -->


