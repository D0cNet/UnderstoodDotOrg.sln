<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Parent Groups.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Parent_Groups" %>
  <div class="container group-summary-wrapper skiplink-content ">
    <div class="row">
      <div class="container">
            <header class="groups-heading rs_read_this">
              <div class="col title">
                <h2>Parent Groups<span></span></h2>
              </div>
              <div class="col show-groups rs_skip">
                <a href="REPLACE">Show groups that match my profile</a>
              </div>
              <!-- BEGIN PARTIAL: community/groups_private_heading -->
<!--groups private partial-->
<div class="col groups-private">
  <p class="col">Groups are private - only a member of the group can see your conversations</p>
  <i class="icon"></i>
</div>
<!-- END PARTIAL: community/groups_private_heading -->
            </header>
            <div class="col-24 parentgroups-tool clearfix skiplink-toolbar">
              <div class="parentgroups-form rs_read_this">
                 <%-- <select name="parentgroupstool-issue" id="parentgroupstool-issue" aria-required="true">
                    <option value="">Child's issue</option>
                    <option>reading issues</option>
                    <option>math issues</option>
                    <option>writing issues</option>
                    <option>movement issues</option>
                    <option>attention issues</option>
                    <option>language issues</option>
                    <option>organization issues</option>
                    <option>sensory processing issues</option>
                    <option>auditory processing issues</option>
                    <option>visual processing issues</option>
                  </select>--%>
                   <asp:DropDownList name="parentgroupstool-issue"  AppendDataBoundItems="true" DataTextField="Name" DataValueField="Id" ID="ddlChildIssues" aria-required="true" runat="server">
                        <asp:ListItem  Value="">Child's Issue</asp:ListItem>
                       
                    </asp:DropDownList>

                 <%-- <select name="parentgroupstool-grade" id="parentgroupstool-grade" aria-required="true">
                    <option value="">Grade</option>
                    <option>Toddler/Preschool</option>
                    <option>Kindergarten</option>
                    <option>Grade 1</option>
                    <option>Grade 2</option>
                    <option>Grade 3</option>
                    <option>Grade 4</option>
                    <option>Grade 5</option>
                    <option>Grade 6</option>
                    <option>Grade 7</option>
                    <option>Grade 8</option>
                    <option>Grade 9</option>
                    <option>Grade 10</option>
                    <option>Grade 11</option>
                    <option>Grade 12</option>
                    <option>After High School</option>
                  </select>--%>
                  <asp:DropDownList name="parentgroupstool-grade"  AppendDataBoundItems="true" DataTextField="Name" DataValueField="Id" ID="ddlGrades" aria-required="true" runat="server">
                        <asp:ListItem  Value="" >Grade</asp:ListItem>
                       
                    </asp:DropDownList>


                 <%-- <select name="parentgroupstool-topics" id="parentgroupstool-topics" aria-required="true">
                    <option value="">Topics</option>
                    <option>Mamis y Papas</option>
                    <option>Parents of teens</option>
                    <option>Parents of young adults</option>
                    <option>Parents of kids in special ed</option>
                    <option>Single parents</option>
                    <option>Parents with learning disabilities</option>
                    <option>Parents with ADD</option>
                    <option>Parents as advocates</option>
                    <option>Homeschooling parents</option>
                    <option>Community newcomers</option>
                    <option>Grandparent</option>
                    <option>Father</option>
                  </select>--%>
                  <asp:DropDownList name="parentgroupstool-topics" DataTextField="Name" AppendDataBoundItems="true" DataValueField="Id" ID="ddlTopics" aria-required="true" runat="server">
                        <asp:ListItem Value="">Topic</asp:ListItem>
                       
                    </asp:DropDownList>

                  <%--<select name="parentgroupstool-state" id="parentgroupstool-state" aria-required="true">
                    <option value="">State</option>
                    <option>Alabama</option>
                    <option>Alaska</option>
                    <option>Arizona</option>
                    <option>Arkansas</option>
                    <option>California</option>
                    <option>Colorado</option>
                    <option>Connecticut</option>
                    <option>Delaware</option>
                    <option>Florida</option>
                    <option>Georgia</option>
                    <option>Hawaii</option>
                    <option>Idaho</option>
                    <option>Illinois</option>
                    <option>Indiana</option>
                    <option>Iowa</option>
                    <option>Kansas</option>
                    <option>Kentucky</option>
                    <option>Louisiana</option>
                    <option>Maine</option>
                    <option>Maryland</option>
                    <option>Massachusetts</option>
                    <option>Michigan</option>
                    <option>Minnesota</option>
                    <option>Mississippi</option>
                    <option>Missouri</option>
                    <option>Montana</option>
                    <option>Nebraska</option>
                    <option>Nevada</option>
                    <option>New Hampshire</option>
                    <option>New Jersey</option>
                    <option>New Mexico</option>
                    <option>New York</option>
                    <option>North Carolina</option>
                    <option>North Dakota</option>
                    <option>Ohio</option>
                    <option>Oklahoma</option>
                    <option>Oregon</option>
                    <option>Pennsylvania</option>
                    <option>Rhode Island</option>
                    <option>South Carolina</option>
                    <option>South Dakota</option>
                    <option>Tennessee</option>
                    <option>Texas</option>
                    <option>Utah</option>
                    <option>Vermont</option>
                    <option>Virginia</option>
                    <option>Washington</option>
                    <option>West Virginia</option>
                    <option>Wisconsin</option>
                    <option>Wyoming</option>
                  </select>--%>
                   <asp:DropDownList name="parentgroupstool-state" DataTextField="Name" AppendDataBoundItems="true" DataValueField="Id" ID="ddlStates" aria-required="true" runat="server">
                        <asp:ListItem Value="">State</asp:ListItem>
                       
                    </asp:DropDownList>
                  <%--<select name="parentgroupstool-partner" id="parentgroupstool-partner" aria-required="true">
                    <option value="">Partner</option>
                    <option>Benetech</option>
                    <option>CAST</option>
                    <option>Child Mind Institute</option>
                    <option>Common Sense Media</option>
                    <option>Eye to Eye</option>
                    <option>GreatSchools</option>
                    <option>Learning Disabilities Association of America (LDA)</option>
                    <option>WETA</option>
                    <option>National Center for Learning Disabilities (NCLD)</option>
                    <option>New Profit</option>
                    <option>Oak Foundation</option>
                    <option>Parent Education Network</option>
                    <option>Poses Family Foundation</option>
                    <option>Tremaine Foundation</option>
                    <option>Tower Foundation</option>
                  </select>--%>
                   <asp:DropDownList name="parentgroupstool-partner" DataTextField="Name" AppendDataBoundItems="true" DataValueField="Id" ID="ddlPartners" aria-required="true" runat="server">
                        <asp:ListItem Value="">Partner</asp:ListItem>
                       
                    </asp:DropDownList>
                  <div class="submit-button-wrap">
                    <%--<input class="button rs_skip" type="submit" value="Search">--%>
                      <asp:Button CssClass="button rs_skip" ID="bntSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
                  </div>

              </div>
            </div>
      </div>
    </div>

    <div class="group-summary-container">
      <div class="row skiplink-content">
        <!-- BEGIN PARTIAL: community/group_summary -->
          <asp:PlaceHolder ID="groupList" runat="server"></asp:PlaceHolder>
       </div>
<!-- END PARTIAL: community/group_summary -->
      </div>
          <!-- BEGIN PARTIAL: community/show_more -->
            <!--Show More-->
            <div class="container show-more rs_skip">
              <div class="row">
                <div class="col col-24">
                  <a class="show-more-link " href="#" data-path="community/group-summary" data-container="group-summary-container" data-item="row" data-count="6">Show More<i class="icon-arrow-down-blue"></i></a>
                </div>
              </div>
            </div><!-- .show-more -->
            <!-- END PARTIAL: community/show_more -->
    <!-- .show-more -->
    </div>

  <!-- BEGIN PARTIAL: children-key -->
<div class="container child-content-indicator ">
  <!-- Key -->
  <div class="row">
    <div class="col col-23 offset-1">
      <div class="children-key" aria-hidden="true">
        <ul>
          <li><i class="child-a"></i>for Michael</li>
          <li><i class="child-b"></i>for Elizabeth</li>
          <li><i class="child-c"></i>for Ethan</li>
          <li><i class="child-d"></i>for Jeremy</li>
          <li><i class="child-e"></i>for Franklin</li>
        </ul>
      </div><!-- .children-key --> 
    </div><!-- .col --> 
  </div><!-- .row --> 
</div><!-- .child-content-indicator --> 
<!-- END PARTIAL: children-key -->