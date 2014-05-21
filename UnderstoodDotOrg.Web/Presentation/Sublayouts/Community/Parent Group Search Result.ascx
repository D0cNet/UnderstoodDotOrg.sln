<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Parent Group Search Result.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Parent_Group_Search_Result" %>
<%--<div class="container">
    <!-- BEGIN PARTIAL: community/featured_group -->
    <!--featured group header -->

    <!-- END PARTIAL: community/featured_group -->
    <div class="row">
          <div class="col col-23 individual-group skiplink-content" aria-role="main">
            <header class="search-results  offset-1 rs_read_this">
              <span class="results-for">
                  <asp:Literal Text="" ID="litResultsCount" runat="server" /> Results for <h3>"<asp:Literal ID="litSearchCriteria" runat="server"></asp:Literal>"</h3>
              </span>
            </header><!-- end header -->
            <!-- BEGIN PARTIAL: community/groups_table -->
            <div class="discussion-box col col-23 offset-1">
                  <header class="rs_skip">

    
                    <h4 class="col summary">Discussion</h4>
                    <h4 class="col board">Board</h4>
                    <h4 class="col started-by">Started by</h4>
                    <h4 class="col replies">Replies</h4>
                    <h4 class="col latest-post-tabular">Latest Post</h4>
    

                </header>
                  <ul class="discussions table-discussions search-results rs_read_this">

    
                      <!-- BEGIN PARTIAL: community/conversation_list_item -->
                        <!--section.container.conversation-list-item-->

                        <li>
                          <div class="col summary">
                            <h4>Discussion:</h4>
                            <a href="REPLACE">Qui Qui Repudiandae Sapiente Distinctio Aut Quia Ut Accusamus. Accusamus Et Accusamus Excepturi Eveniet Est Optio Quod Voluptatibus Ullam Porro</a>
                          </div>
                          <div class="col latest-post rs_skip">
                            <h4>Latest Post:</h4>
                            <p class="mins-ago">47 mins ago</p>
                            <a href="REPLACE">Molestiae</a>
                            <p>Accusantium Asperiores Alias Eum Corrupti Vero Magnam Blanditiis Soluta</p>
                          </div>
                          <div class="col board">
                            <h4>Board:</h4>
                            <a href="REPLACE">Atque Quaerat</a>
                          </div>
                          <div class="col started-by">
                            <h4>Started by:</h4>
                            <a href="REPLACE">Et</a>
                          </div>

                          <div class="col replies">
                            <h4>Replies:</h4>
                            <p>93</p>
                          </div>
                          <div class="col latest-post-tabular">
                            <h4>Latest Post:</h4>
                            <p>44 mins ago</p>
                            <a href="REPLACE">Nisi</a>
                            <p>Sit Architecto Illum Earum</p>
                          </div>
                        </li>
                        <!-- END PARTIAL: community/conversation_list_item -->
                              <!-- BEGIN PARTIAL: community/conversation_list_item -->
                        <!--section.container.conversation-list-item-->

                        <li>
                          <div class="col summary">
                            <h4>Discussion:</h4>
                            <a href="REPLACE">Veniam Maxime Odio Non Rem Non Incidunt Ut Excepturi Officiis Temporibus Atque Voluptate A Autem. Impedit Quia Commodi Esse Ipsa Rerum Incidunt Qui Ad Nesciunt Perferendis Vel</a>
                          </div>
                          <div class="col latest-post rs_skip">
                            <h4>Latest Post:</h4>
                            <p class="mins-ago">23 mins ago</p>
                            <a href="REPLACE">In</a>
                            <p>Fugit Deserunt Iusto Nostrum Consequatur Quae Voluptatibus</p>
                          </div>
                          <div class="col board">
                            <h4>Board:</h4>
                            <a href="REPLACE">Sint Voluptas</a>
                          </div>
                          <div class="col started-by">
                            <h4>Started by:</h4>
                            <a href="REPLACE">Debitis</a>
                          </div>

                          <div class="col replies">
                            <h4>Replies:</h4>
                            <p>91</p>
                          </div>
                          <div class="col latest-post-tabular">
                            <h4>Latest Post:</h4>
                            <p>14 mins ago</p>
                            <a href="REPLACE">Hic</a>
                            <p>Aliquam Laboriosam Dolor Hic Soluta Excepturi Excepturi Commodi Fuga Quia Inventore Ut Minima Voluptatem Omnis</p>
                          </div>
                        </li>
                        <!-- END PARTIAL: community/conversation_list_item -->
                              <!-- BEGIN PARTIAL: community/conversation_list_item -->
                        <!--section.container.conversation-list-item-->

                        <li>
                          <div class="col summary">
                            <h4>Discussion:</h4>
                            <a href="REPLACE">Animi Corporis Nobis Et Omnis. Porro Similique Ullam Doloremque Esse Occaecati Autem</a>
                          </div>
                          <div class="col latest-post rs_skip">
                            <h4>Latest Post:</h4>
                            <p class="mins-ago">19 mins ago</p>
                            <a href="REPLACE">Repellat</a>
                            <p>Minima Quis Necessitatibus Eum Modi Iusto Sunt Ut Quia</p>
                          </div>
                          <div class="col board">
                            <h4>Board:</h4>
                            <a href="REPLACE">Rem Officia</a>
                          </div>
                          <div class="col started-by">
                            <h4>Started by:</h4>
                            <a href="REPLACE">Pariatur</a>
                          </div>

                          <div class="col replies">
                            <h4>Replies:</h4>
                            <p>6</p>
                          </div>
                          <div class="col latest-post-tabular">
                            <h4>Latest Post:</h4>
                            <p>27 mins ago</p>
                            <a href="REPLACE">Eum</a>
                            <p>Nam Veritatis Eveniet Ipsum Ipsum</p>
                          </div>
                        </li>
                        <!-- END PARTIAL: community/conversation_list_item -->
    

    

                  </ul> <!-- end .discussions -->
            </div>
            <!-- END PARTIAL: community/groups_table -->
          </div><!-- end .individual-group -->
    </div>
</div>--%>

#set($group = $core_v2_group.Current)

<div class="field-list-header"></div>
<fieldset class="field-list">
	<ul class="field-list">
		<li class="field-item">
			<label class="field-item-header query" for="$core_v2_widget.UniqueId('query')">$core_v2_language.GetResource('Core_SiteSearch_QueryLabel')</label>
			<span class="field-item-input"><input type="text" id="$core_v2_widget.UniqueId('query')" length="15" maxlength="64" class="search empty" /></span>
		</li>
		#if ($group.Id != $core_v2_group.Root.Id)
			<li class="field-item">
				<span class="field-item-input">
					<a class="internal-link search-options" id="$core_v2_widget.UniqueId('options')" title="$core_v2_language.GetResource('Search_ChangeSearchScope')">&nbsp;</a>
				</span>
			</li>
		#end
	</ul>
</fieldset>
<div class="field-list-footer"></div>

#if ($group.Id != $core_v2_group.Root.Id)
	<div id="$core_v2_widget.UniqueId('filter-options')" style="display: none;">
		<div class="field-list-header"></div>
		<fieldset class="field-list">
			<legend class="field-list-description">$core_v2_language.GetResource('Core_Header_SearchOptions')</legend>
			<ul class="field-list">
				<li class="field-item">
					<label class="field-item-header" for="$core_v2_widget.UniqueId('filter')">$core_v2_language.GetResource('CF_Search_SearchFilter_Everything')</label>
					<span class="field-item-input"><input type="radio" value="" name="$core_v2_widget.UniqueId('filter')" id="$core_v2_widget.UniqueId('filter')" /></span>
				</li>
				<li class="field-item">
					<label class="field-item-header" for="$core_v2_widget.UniqueId('filter')">$core_v2_language.FormatString($core_v2_language.GetResource('CF_Search_SearchFilter'), $group.Name)</label>
					<span class="field-item-input"><input type="radio" value="$group.Id" name="$core_v2_widget.UniqueId('filter')" id="Radio1" /></span>
				</li>
			</ul>
		</fieldset>
		<div class="field-list-footer"></div>
	</div>
#end

#registerEndOfPageHtml('telligent.evolution.widgets.siteSearch')
	<script type="text/javascript" src="$core_v2_encoding.HtmlAttributeEncode($core_v2_widget.GetFileUrl('ui.js'))"></script>
#end
#registerEndOfPageHtml()
	<script type="text/javascript">
	    jQuery(function(){
	        jQuery.telligent.evolution.widgets.siteSearch.register({
	            searchUrl: '$core_v2_encoding.JavascriptEncode($core_v2_widget.GetExecutedFileUrl('search.vm'))',
	            searchResultsUrl: '$core_v2_encoding.JavascriptEncode($core_v2_urls.Search("%{ QueryString = '{0}' }"))',
	        query: jQuery('#$core_v2_widget.UniqueId('query')'),
	        optionsLink: jQuery('#$core_v2_widget.UniqueId('options')'),
	        optionsContent: jQuery('#$core_v2_widget.UniqueId('filter-options')'),
	        filterName: '$core_v2_widget.UniqueId('filter')',
	        loading: '$core_v2_encoding.JavascriptEncode($core_v2_language.GetResource('CF_Search_Searching'))',
	        error: '$core_v2_encoding.JavascriptEncode($core_v2_language.GetResource('CF_Search_Error'))',
	        groupId: ''
	    });
	    });
	</script>
#end
			