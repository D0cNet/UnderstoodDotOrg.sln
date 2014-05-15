<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PastChat.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve.PastChat" %>






<div class="container event">
    <header class="row">
        <div class="event-container">
            <ul class="breadcrumbs">
                <p>
                    <li><a href="REPLACE">Back to Blanditiis Aut</a></li>
            </ul>

            <h2 class="rs_read_this">Chat: <em>Eius Consequatur Ea</em></h2>
        </div>
    </header>

    <div class="row">
        <div class="event-container">
            <div class="col-18 col event-content skiplink-content" aria-role="main">
                <div class="rs_read_this">
                    <div class="event-image">
                        <div class="thumbnail">
                            <a href="REPLACE">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                <div class="image-label">
                                    Expert
                         
                                </div>
                            </a>
                        </div>

                        <!-- BEGIN PARTIAL: community/experts_recommended_for -->
                        <div class="recommended-for">
                            <p>Recommended for</p>
                            <span class="children-key">
                                <ul>
                                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                        <!-- END PARTIAL: community/experts_recommended_for -->
                    </div>
                    <!-- end .event-image -->

                    <p class="event-date-time">Thu Oct 31 at 12am EST</p>
                    <p class="event-host-name">Totam Possimus Perspiciatis</p>
                    <p class="event-host-title">Ducimus Qui Dolor Eligendi Est</p>
                    <p>Cupiditate non qui accusantium maiores asperiores unde facere ipsam. reiciendis quisquam magni eveniet nobis dolor fugiat nihil cumque nostrum. aspernatur id blanditiis deserunt magni repellat in rerum architecto et sed tempore eum sed quas</p>
                    <p>Dolorem excepturi sint excepturi aliquam ex ducimus. quas fuga minima nostrum numquam est dolore facere illo aut. et ut dolorem et. dolorem qui harum praesentium aut molestiae. aut quo officia facere quo necessitatibus quia nisi assumenda magni maxime quasi explicabo</p>
                </div>

                <asp:Repeater runat="server" ID="rptComments" OnItemDataBound="rptComments_ItemDataBound">
                    <ItemTemplate>
                        <div class="rs_read_this past-chat-rs-wrapper">
                            <h4 class="question"><%--Qui Corporis Amet--%>
                                <sc:FieldRenderer ID="frTitle" runat="server" FieldName="Comment Title" />
                            </h4>
                            <sc:FieldRenderer ID="frContent" runat="server" FieldName="Content" />
                            <%--<p>Sit quidem odio alias non. veritatis fuga aut eum nobis aut nulla facilis sapiente asperiores incidunt. magni nam quis voluptate reprehenderit id recusandae reiciendis nam sed est fugit quos est aliquid. autem dolores maxime ducimus qui. est porro consequatur quibusdam sit soluta quia eaque saepe et</p>--%>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <%--<div class="rs_read_this past-chat-rs-wrapper">
                            <h4 class="question">Tempore Adipisci Rerum</h4>
                            <p>Et et eum occaecati quae assumenda. repudiandae fugiat vel minus provident doloremque culpa id eum ducimus numquam vitae praesentium. tempore placeat beatae quaerat voluptatem quam. quas nobis molestias vel sunt et id omnis enim. alias aliquam harum rerum et dignissimos qui cupiditate optio</p>
                        </div>

                        <div class="rs_read_this past-chat-rs-wrapper">
                            <h4 class="answer">Qui Repudiandae</h4>
                            <p>Corporis eum est in corporis quidem repellat dolore nemo cumque et. temporibus assumenda ut saepe excepturi omnis corrupti voluptatem id. placeat cupiditate et enim velit quidem neque. sint repudiandae quo odit aspernatur doloribus. fuga natus vel itaque ut saepe officia similique vel sapiente enim. architecto doloremque veniam non excepturi quia quam temporibus minus nostrum aut sint. vel iure non praesentium voluptas praesentium assumenda aspernatur rerum odio adipisci ea et</p>
                        </div>

                        <div class="rs_read_this past-chat-rs-wrapper">
                            <h4 class="question">Adipisci Voluptatibus Soluta</h4>
                            <p>Dicta atque nihil soluta quibusdam aliquid minus aut ipsum optio sunt illo sit. rerum autem voluptatem quia consequatur reprehenderit facere mollitia eaque. exercitationem et asperiores dolorem in quod illum ab consequuntur. qui ducimus qui aut aut ipsam ut praesentium possimus velit est porro. quia ipsam voluptates aut totam odio ipsa consectetur. quia error iste aut possimus aut sint enim voluptatem culpa molestiae quo consequatur fugiat. saepe fugit suscipit quia cupiditate exercitationem sed est sint molestiae iusto aut quos delectus voluptatem</p>
                        </div>

                        <div class="rs_read_this past-chat-rs-wrapper">
                            <h4 class="answer">Aut Tempore</h4>
                            <p>Qui iure et inventore quia a reiciendis perferendis adipisci officia sunt sapiente asperiores minima. esse in molestias totam est excepturi. atque quia provident aut sed at ad provident nobis molestiae nam corporis et nesciunt sunt</p>
                        </div>--%>

                <!-- BEGIN PARTIAL: community/experts_was_this_helpful -->
                <div class="was-this-helpful clearfix" id="count-helpful">

                    <p class="helpful-count"><em>74</em>Found this helpful</p>


                    <h4>Did you find this helpful?</h4>
                    <a class="button yes rs_skip" href="REPLACE">Yes</a>
                    <a class="button gray no rs_skip" href="REPLACE">No</a>
                </div>
                <!-- END PARTIAL: community/experts_was_this_helpful -->
            </div>
            <!-- end .event-content -->
            <div class="col-5 col offset-1 event-sidebar skiplink-sidebar rs_read_this">
                <!-- BEGIN PARTIAL: community/experts_recommended_for -->
                <div class="recommended-for">
                    <p>Recommended for</p>
                    <span class="children-key">
                        <ul>
                            <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                            <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                        </ul>
                    </span>
                </div>
                <!-- END PARTIAL: community/experts_recommended_for -->
                <!-- BEGIN PARTIAL: community/experts_was_this_helpful -->
                <div class="was-this-helpful clearfix" id="Div1">

                    <p class="helpful-count"><em>75</em>Found this helpful</p>


                    <h4>Did you find this helpful?</h4>
                    <a class="button yes rs_skip" href="REPLACE">Yes</a>
                    <a class="button gray no rs_skip" href="REPLACE">No</a>
                </div>
                <!-- END PARTIAL: community/experts_was_this_helpful -->
            </div>
            <!-- end .event-sidebar -->
        </div>
    </div>
</div>

<div class="container live-chat">
    <div class="row">
        <header class="col col-24 live-chat-rs-wrapper rs_read_this">
            <h2>Upcoming Chats: Expert Office Hours</h2>
            <p class="subhead">Your chance to ask the expert in one of our daily online chats</p>

            <ul class="live-chat-navigation rs_skip">
                <li class="header"><a href="REPLACE">See All</a></li>
                <li class="rsArrow rsArrowLeft">
                    <button class="rsArrowIcn"></button>
                </li>
                <li class="rsArrow rsArrowRight">
                    <button class="rsArrowIcn"></button>
                </li>
            </ul>
        </header>
    </div>
    <div class="live-chat-content row">
        <div class="event-cards row">
            <!-- BEGIN PARTIAL: community/experts_live_chat_card -->
            <div class="col col-12 event-card rs_read_this">
                <div class="event-card-info group">
                    <div class="event-card-upper">
                        <div class="event-card-image">
                            <a href="REPLACE">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                <div class="image-label">
                                    Guest Expert
                   
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-details">
                            <p class="event-card-heading">et dicta quo</p>
                            <p class="event-card-title">Fugiat Similique Exercitationem</a></p>
                            <p>aut repellendus ab voluptate voluptatibus debitis</p>


                            <span class="children-key">
                                <ul>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>


                            <p class="event-card-info-link"><a href="REPLACE">omnis tenetur</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">porro repellat</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">labore ipsa</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">quo esse</a></p>
                </div>
                <!-- end .event-card-info -->
            </div>
            <!-- end .event-card -->
            <div class="col col-12 event-card rs_read_this">
                <div class="event-card-info group">
                    <div class="event-card-upper">
                        <div class="event-card-image">
                            <a href="REPLACE">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                <div class="image-label">
                                    Guest Expert
                   
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-details">
                            <p class="event-card-heading">animi sint autem</p>
                            <p class="event-card-title">Ut Omnis Qui</a></p>
                            <p>nisi iure voluptas labore consequatur culpa</p>


                            <span class="children-key">
                                <ul>
                                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>


                            <p class="event-card-info-link"><a href="REPLACE">totam nulla</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">nisi debitis</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">est et</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">voluptas molestias</a></p>
                </div>
                <!-- end .event-card-info -->
            </div>
            <!-- end .event-card -->
            <div class="col col-12 event-card rs_read_this">
                <div class="event-card-info group">
                    <div class="event-card-upper">
                        <div class="event-card-image">
                            <a href="REPLACE">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                <div class="image-label">
                                    Guest Expert
                   
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-details">
                            <p class="event-card-heading">consequuntur quis laboriosam</p>
                            <p class="event-card-title">Sapiente Sint Vero</a></p>
                            <p>perferendis autem et perferendis earum itaque</p>


                            <span class="children-key">
                                <ul>
                                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>


                            <p class="event-card-info-link"><a href="REPLACE">quisquam quia</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">veniam praesentium</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">dolor voluptatum</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">mollitia adipisci</a></p>
                </div>
                <!-- end .event-card-info -->
            </div>
            <!-- end .event-card -->
            <div class="col col-12 event-card rs_read_this">
                <div class="event-card-info group">
                    <div class="event-card-upper">
                        <div class="event-card-image">
                            <a href="REPLACE">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                <div class="image-label">
                                    Guest Expert
                   
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-details">
                            <p class="event-card-heading">autem omnis dignissimos</p>
                            <p class="event-card-title">Nulla Atque Et</a></p>
                            <p>non aut accusantium id perspiciatis rem</p>


                            <span class="children-key">
                                <ul>
                                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>


                            <p class="event-card-info-link"><a href="REPLACE">architecto quo</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">voluptatem est</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">iure asperiores</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">eos quod</a></p>
                </div>
                <!-- end .event-card-info -->
            </div>
            <!-- end .event-card -->
            <div class="col col-12 event-card rs_read_this">
                <div class="event-card-info group">
                    <div class="event-card-upper">
                        <div class="event-card-image">
                            <a href="REPLACE">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                <div class="image-label">
                                    Expert
                   
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-details">
                            <p class="event-card-heading">expedita occaecati accusantium</p>
                            <p class="event-card-title">Corporis Odio Quae</a></p>
                            <p>fuga explicabo eos nesciunt sint vel</p>


                            <span class="children-key">
                                <ul>
                                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-c' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>


                            <p class="event-card-info-link"><a href="REPLACE">sit enim</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">quia et</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">autem ea</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">rerum numquam</a></p>
                </div>
                <!-- end .event-card-info -->
            </div>
            <!-- end .event-card -->
            <div class="col col-12 event-card rs_read_this">
                <div class="event-card-info group">
                    <div class="event-card-upper">
                        <div class="event-card-image">
                            <a href="REPLACE">
                                <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                                <div class="image-label">
                                    Expert
                   
                                </div>
                            </a>
                        </div>
                        <!-- end .event-card-image -->
                        <div class="event-card-details">
                            <p class="event-card-heading">esse temporibus voluptatum</p>
                            <p class="event-card-title">Qui Eum Ut</a></p>
                            <p>voluptas sit fugit a rerum placeat</p>


                            <span class="children-key">
                                <ul>
                                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>


                            <p class="event-card-info-link"><a href="REPLACE">ipsam dolorem</a></p>
                            <p class="event-card-info-link"><a href="REPLACE">voluptates quidem</a></p>
                        </div>
                        <!-- end .event-card-details -->
                    </div>

                    <!-- Duplicate links for mobile to accomplish mobile layout -->
                    <p class="event-card-info-link"><a href="REPLACE">numquam eos</a></p>
                    <p class="event-card-info-link"><a href="REPLACE">soluta impedit</a></p>
                </div>
                <!-- end .event-card-info -->
            </div>
            <!-- end .event-card -->

            <!-- END PARTIAL: community/experts_live_chat_card -->
        </div>
        <!-- end .event-cards -->

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
                    </div>
                    <!-- .children-key -->
                </div>
                <!-- .col -->
            </div>
            <!-- .row -->
        </div>
        <!-- .child-content-indicator -->
        <!-- END PARTIAL: children-key -->
    </div>
</div>



