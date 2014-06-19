<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MostRecentBlogsPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.MostRecentBlogsPage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div id="community-page" class="community-my-blogs community-blog-post-list author-specific ">
    <!-- BEGIN PARTIAL: community/main_header -->
    <sc:Placeholder ID="Placeholder1" Key="BlogHeader" runat="server" />
    <!-- END PARTIAL: community/main_header -->

    <div class="container">
        <sc:Placeholder Key="FeaturePost" runat="server" />
        <div class="container">
            <div class="row">
                <div class="col blog-filter-wrapper col-24">
                    <!-- BEGIN PARTIAL: community/blog_filter -->
                    <div class="blog-filter clearfix skiplink-toolbar">
                        <div class="mobile-search-box">
                            <fieldset class="group-search-form mobile-group-search-form">
                                <label for="blog-group-search-text" class="visuallyhidden" aria-hidden="true">Search this blog</label>
                                <input type="text" class="group-search" id="blog-group-search-text" name="group-search" placeholder="Search this blog"></input>
                                <input class="group-search-button" type="submit" value="Go"></input>
                            </fieldset>
                        </div>
                        <div class="filters">
                            <div class="dropdown">
                                <a class="dropdown-toggle" role="button" data-toggle="dropdown" href="#">
                                    <span class="current-filter">Most recent</span>
                                    <span class="dropdown-title">Sort by</span>
                                </a>
                                <ul class="dropdown-menu" role="menu">

                                    <li id="Recent" role="presentation" class="filter selected" data-sort-by="date"><a role="menuitem" onclick="showRecent();" runat="server">Most recent</a></li>

                                    <li id="Read" role="presentation" class="filter " data-sort-by="read"><a role="menuitem" onclick="" runat="server">Most read</a></li>

                                    <li id="Shared" role="presentation" class="filter " data-sort-by="shared"><a role="menuitem" onclick="" runat="server">Most shared</a></li>

                                    <li id="TalkedAbout" role="presentation" class="filter " data-sort-by="talkedabout"><a role="menuitem" onclick="showTalkedAbout();" runat="server">Most talked about</a></li>

                                </ul>
                            </div>
                        </div>
                    </div>

                    <!-- END PARTIAL: community/blog_filter -->
                </div>
            </div>
        </div>

        <div id="sort" class="col-23 clearfix blog-post-list-wrapper">
            <div id="sbMostRecent" class="col blog-post-list skiplink-content" aria-role="main">
                <div class="blog-post-list-inner">
                    <asp:Repeater ID="rptRecentBlogInfo" runat="server" ItemType="UnderstoodDotOrg.Domain.TelligentCommunity.BlogPost">
                        <ItemTemplate>
                            <!-- BEGIN PARTIAL: community/blog_post -->
                            <div class="blog-post">
                                <div class="blog-card-image blog-card-total-comments">
                                    <a>
                                        <img alt="230x129 Placeholder" src="http://placehold.it/230x129" /></a>

                                    <p class="blog-card-comments"><b class="number-of-comments"><%# Item.CommentCount %></b>Comments</p>

                                </div>
                                <div class="blog-card-info group">
                                    <h3 class="blog-card-title"><a href="<%# Item.Url %>"><%# Item.Title %></a></h3>


                                    <div class="blog-card-post-info">
                                        <p class="blog-posted">Posted</p>
                                        <p class="blog-post-date"><%# Item.PublishedDate %></p>
                                        <p class="blog-by">
                                            by
          <a href="<%# Item.AuthorUrl %>" class="author"><%# Item.Author %></a>
                                        </p>
                                    </div>


                                    <p class="blog-card-post-excerpt"><%# Item.Body %></p>
                                    <span class="children-key">
                                        <ul>
                                            <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                            <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                            <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                        </ul>
                                    </span>
                                </div>

                            </div>
                            <!-- END PARTIAL: community/blog_post -->
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

            <%--<sc:Sublayout CssStyle="display: none" ID="sbMostRead" runat="server" Path="~/Presentation/SubLayouts/Blogs/SortBlogsRecent.ascx" />
            <sc:Sublayout CssStyle="display: none" ID="sbMostShared" runat="server" Path="~/Presentation/SubLayouts/Blogs/SortBlogsRecent.ascx" />--%>

            <div style="display: none" id="sbMostTalkedAbout" class="col blog-post-list skiplink-content" aria-role="main">
                <div class="blog-post-list-inner">
                    <asp:Repeater ID="rptMostTalkedBlogInfo" runat="server" ItemType="UnderstoodDotOrg.Domain.TelligentCommunity.BlogPost">
                        <ItemTemplate>
                            <!-- BEGIN PARTIAL: community/blog_post -->
                            <div class="blog-post">
                                <div class="blog-card-image blog-card-total-comments">
                                    <a>
                                        <img alt="230x129 Placeholder" src="http://placehold.it/230x129" /></a>

                                    <p class="blog-card-comments"><b class="number-of-comments"><%# Item.CommentCount %></b>Comments</p>

                                </div>
                                <div class="blog-card-info group">
                                    <h3 class="blog-card-title"><a href="<%# Item.Url %>"><%# Item.Title %></a></h3>


                                    <div class="blog-card-post-info">
                                        <p class="blog-posted">Posted</p>
                                        <p class="blog-post-date"><%# Item.PublishedDate %></p>
                                        <p class="blog-by">
                                            by
          <a href="<%# Item.AuthorUrl %>" class="author"><%# Item.Author %></a>
                                        </p>
                                    </div>


                                    <p class="blog-card-post-excerpt"><%# Item.Body %></p>
                                    <span class="children-key">
                                        <ul>
                                            <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                            <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                            <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                        </ul>
                                    </span>
                                </div>

                            </div>
                            <!-- END PARTIAL: community/blog_post -->
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <!-- Show More -->
                <!-- BEGIN PARTIAL: community/show_more -->
                <!--Show More-->
                <div class="container show-more">
                    <div class="row">
                        <div class="col col-24">
                            <a class="show-more-link " href="#" data-path="blog/posts" data-container="blog-post-list-inner" data-item="blog-list" data-count="2">Show More<i class="icon-arrow-down-blue"></i></a>
                        </div>
                    </div>
                </div>
                <!-- .show-more -->
                <!-- END PARTIAL: community/show_more -->
                <!-- .show-more -->

            </div>
            <!-- BEGIN PARTIAL: community/blog_sidebar -->
            <div id="skipLinkSidebar" class="blog-post-list-sidebar skiplink-sidebar">
                <sc:Placeholder ID="Sidebar" Key="Blogs-Sidebar" runat="server" />
            </div>

            <!-- END PARTIAL: community/blog_sidebar -->
        </div>
    </div>

    <%--<!-- BEGIN PARTIAL: children-key -->
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
                </div>
                <!-- .children-key -->
            </div>
            <!-- .col -->
        </div>
        <!-- .row -->
    </div>
    <!-- .child-content-indicator -->
    <!-- END PARTIAL: children-key -->--%>
    <sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/Recommendation/Recommendation Icons.ascx" />
</div>
<div style="display:none" id="hide"></div>
<%--<script type="text/javascript">
    var recent = document.getElementById("sbMostRecent");
    <%--var read = document.getElementById("<%=sbMostRead.ClientID%>");
    var shared = document.getElementById("<%=sbMostShared.ClientID%>");-->
    var talked = document.getElementById("sbMostTalkedAbout");
    var recentSelect = document.getElementById("Recent");
    var readSelect = document.getElementById("Read");
    var sharedSelect = document.getElementById("Shared");
    var talkedSelect = document.getElementById("TalkedAbout");
    function ShowMostRecent() {
        if (recent.style.display = "none") {
            recent.style.display = "block";
            //read.setAttribute("Visible", "false");
            //shared.setAttribute("Visible", "false");
            talked.style.display = "none";
            recentSelect.className = "filter selected";
            readSelect.className = "filter ";
            sharedSelect.className = "filter ";
            talkedSelect.className = "filter ";
        }
    }
    //function ShowMostRead() {
    //    if (read.getAttribute("Visible") == "false") {
    //        recent.setAttribute("Visible", "false");
    //        //read.setAttribute("Visible", "true");
    //        //shared.setAttribute("Visible", "false");
    //        talked.setAttribute("Visible", "false");
    //        recentSelect.className = "filter ";
    //        readSelect.className = "filter selected";
    //        sharedSelect.className = "filter ";
    //        talkedSelect.className = "filter ";
    //    }
    //}
    //function ShowMostShared() {
    //    if (shared.getAttribute("Visible") == "false") {
    //        recent.setAttribute("Visible", "false");
    //        //read.setAttribute("Visible", "false");
    //        //shared.setAttribute("Visible", "false");
    //        talked.setAttribute("Visible", "false");
    //        recentSelect.className = "filter ";
    //        readSelect.className = "filter ";
    //        sharedSelect.className = "filter selected";
    //        talkedSelect.className = "filter ";
    //    }
    //}
    function ShowMostTalkedAbout() {
        if (talked.style.display = "none") {
            recent.style.display = "none";
            //read.setAttribute("Visible", "false");
            //shared.setAttribute("Visible", "false");
            talked.style.display = "block";
            recentSelect.className = "filter ";
            readSelect.className = "filter ";
            sharedSelect.className = "filter ";
            talkedSelect.className = "filter selected";
        }
    }
</script>--%>

<script type="text/javascript">
    function showRecent() {
        $('#sbMostTalkedAbout').detach().appendTo('#hide');
        $('#sbMostRecent').detach().prependTo('#sort');
    }
    function showTalkedAbout() {
        $('#sbMostRecent').detach().appendTo('#hide');
        $('#sbMostTalkedAbout').detach().prependTo('#sort');
    }
</script>

<script type="text/javascript">
    var Konami = function (callback) {
        var konami = {
            addEvent: function (obj, type, fn, ref_obj) {
                if (obj.addEventListener)
                    obj.addEventListener(type, fn, false);
                else if (obj.attachEvent) {
                    // IE
                    obj["e" + type + fn] = fn;
                    obj[type + fn] = function () {
                        obj["e" + type + fn](window.event, ref_obj);
                    }
                    obj.attachEvent("on" + type, obj[type + fn]);
                }
            },
            input: "",
            pattern: "38384040373937396665",
            load: function (link) {
                this.addEvent(document, "keydown", function (e, ref_obj) {
                    if (ref_obj) konami = ref_obj; // IE
                    konami.input += e ? e.keyCode : event.keyCode;
                    if (konami.input.length > konami.pattern.length)
                        konami.input = konami.input.substr((konami.input.length - konami.pattern.length));
                    if (konami.input == konami.pattern) {
                        konami.code(link);
                        konami.input = "";
                        e.preventDefault();
                        return false;
                    }
                }, this);
                this.iphone.load(link);
            },
            code: function (link) {
                window.location = link
            },
            iphone: {
                start_x: 0,
                start_y: 0,
                stop_x: 0,
                stop_y: 0,
                tap: false,
                capture: false,
                orig_keys: "",
                keys: ["UP", "UP", "DOWN", "DOWN", "LEFT", "RIGHT", "LEFT", "RIGHT", "TAP", "TAP"],
                code: function (link) {
                    konami.code(link);
                },
                load: function (link) {
                    this.orig_keys = this.keys;
                    konami.addEvent(document, "touchmove", function (e) {
                        if (e.touches.length == 1 && konami.iphone.capture == true) {
                            var touch = e.touches[0];
                            konami.iphone.stop_x = touch.pageX;
                            konami.iphone.stop_y = touch.pageY;
                            konami.iphone.tap = false;
                            konami.iphone.capture = false;
                            konami.iphone.check_direction();
                        }
                    });
                    konami.addEvent(document, "touchend", function (evt) {
                        if (konami.iphone.tap == true) konami.iphone.check_direction(link);
                    }, false);
                    konami.addEvent(document, "touchstart", function (evt) {
                        konami.iphone.start_x = evt.changedTouches[0].pageX;
                        konami.iphone.start_y = evt.changedTouches[0].pageY;
                        konami.iphone.tap = true;
                        konami.iphone.capture = true;
                    });
                },
                check_direction: function (link) {
                    x_magnitude = Math.abs(this.start_x - this.stop_x);
                    y_magnitude = Math.abs(this.start_y - this.stop_y);
                    x = ((this.start_x - this.stop_x) < 0) ? "RIGHT" : "LEFT";
                    y = ((this.start_y - this.stop_y) < 0) ? "DOWN" : "UP";
                    result = (x_magnitude > y_magnitude) ? x : y;
                    result = (this.tap == true) ? "TAP" : result;

                    if (result == this.keys[0]) this.keys = this.keys.slice(1, this.keys.length);
                    if (this.keys.length == 0) {
                        this.keys = this.orig_keys;
                        this.code(link);
                    }
                }
            }
        }

        typeof callback === "string" && konami.load(callback);
        if (typeof callback === "function") {
            konami.code = callback;
            konami.load();
        }

        return konami;
    };

    var easter_egg = new Konami(function () {
        R = 0; x1 = .1; y1 = .05; x2 = .25; y2 = .24; x3 = 1.6; y3 = .24; x4 = 300; y4 = 200; x5 = 300; y5 = 200; DI = document.getElementsByTagName("img"); DIL = DI.length; function A() { for (i = 0; i - DIL; i++) { DIS = DI[i].style; DIS.position = 'absolute'; DIS.left = (Math.sin(R * x1 + i * x2 + x3) * x4 + x5) + "px"; DIS.top = (Math.cos(R * y1 + i * y2 + y3) * y4 + y5) + "px" } R++ } setInterval('A()', 5); void (o);
    });
</script>