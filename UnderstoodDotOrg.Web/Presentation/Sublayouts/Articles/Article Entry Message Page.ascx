<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Article Entry Message Page.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Article_Entry_Message_Page" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- BEGIN PARTIAL: personalize-checklist -->
<div class="personalize-checklist-modal modal fade">
    <div class="personalize-checklist modal-dialog">

        <div class="modal-content white-background">
            <i class="close-overlay" data-dismiss="modal"><sc:FieldRenderer id="frCloseLabel" runat="server" FieldName="Close Button Label"></sc:FieldRenderer></i>



            <div class="modal-body">

                <div class="part1 rs_read_this">

                    <div class="modal-header">
                        <div class="checklist-title"><sc:FieldRenderer id="frPersonalizeLabel" runat="server" FieldName="Personalize Experience Label"></sc:FieldRenderer></div>
                    </div>

                    <sc:FieldRenderer id="frContent" runat="server" FieldName="Content"></sc:FieldRenderer>
                    <div class="checklist-buttons">
                        <button type="button" class="button advance rs_skip"><sc:FieldRenderer id="frYesButtonLabel" runat="server" FieldName="Yes Button Label"></sc:FieldRenderer></button>
                        <button type="button" class="button gray close rs_skip"><sc:FieldRenderer id="frNoThanksButtonLabel" runat="server" FieldName="No Thanks Button Label"></sc:FieldRenderer></button>
                    </div>

                </div>
                <!-- .part1 -->


                <div class="part2 rs_read_this">

                    <div class="modal-header">
                        <div class="checklist-title"><sc:FieldRenderer id="frPersonalizeLabel2" runat="server" FieldName="Personalize Experience Label"></sc:FieldRenderer></div>
                    </div>

                    <div class="checklist-wrapper row">
                        <div class="col col-14">
                            <div class="checklist-question-wrapper">
                                <div class="checklist-question"><sc:FieldRenderer id="frChildNeedsHelpLabel" runat="server" FieldName="Child Needs Help With Label"></sc:FieldRenderer></div>

                                <asp:Repeater ID="rptChildIssues" runat="server" OnItemDataBound="rptChildIssues_ItemDataBound">
                                    <HeaderTemplate>
                                        <div class="checkboxes-wrapper">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="checkbox-wrapper">
                                            <label>
                                                <input id="inputIssue" runat="server" type="checkbox"></span>
                                                <span>
                                                    <asp:Literal ID="litIssueName" runat="server" /></span>
                                            </label>
                                        </div>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </div>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <asp:HiddenField ID="hfIssues" runat="server" />

                    <div class="col col-10">
                        <div class="checklist-question-wrapper">
                            <div class="checklist-question"><sc:FieldRenderer id="frChildEnrolledLabel" runat="server" FieldName="Child Is Enrolled In Label"></sc:FieldRenderer></div>
                            <asp:DropDownList ID="ddlGrade" runat="server"/>
                        </div>
                        <div class="checklist-question"><sc:FieldRenderer id="frChildsNameLabel" runat="server" FieldName="My Childs Name Label"></sc:FieldRenderer></div>
                        <asp:TextBox ID="txtChildName" runat="server" placeholder="Enter child's name"></asp:TextBox>
                        <p class="checklist-question-description">
                            <sc:FieldRenderer id="frChildsNameIs" runat="server" FieldName="Childs Name Is Private Text"></sc:FieldRenderer>
                        </p>
                    </div>
                </div>
                <!-- .checklist-wrapper -->


                <div class="modal-footer">

                    <div class="checklist-actions">
                        <button id="btnSubmit" runat="server" onserverclick="btnSubmit_Click" class="button"><sc:FieldRenderer id="frSubmitButtonLabel" runat="server" FieldName="Submit Button Text"></sc:FieldRenderer></button>
                    </div>

                </div>
            </div>
            <!-- .part2 -->

        </div>
        <!-- .modal-body -->

    </div>
    <!-- .modal-content -->
</div>
<!-- .personalize-checklist -->
</div><!-- .personalize-checklist-modal -->
<style>
    .modal-dialog {
        top: 20% !important;
        left: 20% !important;
    }
</style>
<script>
    $(function () {
        var hiddenField = $("[id*='hfIssues']");

        $(".checkbox-wrapper").click(function () {
            var values = "";
            var first = true;

            $(this).parent().parent().find(".checked").each(function () {
                if (first) {
                    values = $(this).find('input').data("id");
                    first = false;
                }
                else
                    values += "|" + $(this).find('input').data("id");
            })

            hiddenField.val(values);
        })

    })
</script>
