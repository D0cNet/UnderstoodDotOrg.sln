<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DidYouFindThisHelpful.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.DidYouFindThisHelpful" %>

<div class="container">
    <div class="row">
        <!-- article -->
        <div class="col col-19 offset-2">
            <!-- BEGIN PARTIAL: find-helpful -->
            <div class="find-this-helpful content" id="count-helpful-content rs_read_this">




                <h4><asp:Literal ID="ltlDidYouFindThisHelpful" runat="server"></asp:Literal></h4>
                <ul>
                    <li>
                        <button class="helpful-yes"><asp:Literal ID="ltlYes" runat="server"></asp:Literal></button>
                    </li>
                    <li>
                        <button class="helpful-no"><asp:Literal ID="ltlNo" runat="server"></asp:Literal></button>
                    </li>
                </ul>
                <div class="clearfix"></div>

            </div>

            <!-- END PARTIAL: find-helpful -->
            <div class="find-this-helpful-small">
                <!-- Module within only appears in under 650px window width-->
                <!-- BEGIN PARTIAL: find-helpful -->
                <div class="find-this-helpful sidebar no-margin" id="count-helpful-sidebar rs_read_this">




                    <h4><asp:Literal ID="ltlDidYouFindThisHelpfulSmall" runat="server"></asp:Literal></h4>
                    <ul>
                        <li>
                            <button class="helpful-yes button yes rs_skip"><asp:Literal ID="ltlYesSmall" runat="server"></asp:Literal></button>
                        </li>
                        <li>
                            <button class="helpful-no button no gray rs_skip"><asp:Literal ID="ltlNoSmall" runat="server"></asp:Literal></button>
                        </li>
                    </ul>
                    <div class="clearfix"></div>

                </div>

                <!-- END PARTIAL: find-helpful -->
            </div>
            <div class="find-this-helpful-large" style="display: none;">
                <!-- Module within only appears in over 650px window width-->
            </div>
        </div>
    </div>
</div>
<!-- .container -->
