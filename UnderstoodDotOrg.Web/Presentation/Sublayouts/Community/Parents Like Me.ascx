<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="Parents Like Me.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Parents" %>
<%@ Register tagPrefix="sc" namespace="Sitecore.Web.UI.WebControls" assembly="Sitecore.Kernel"   %>
<%--<link href="Presentation/includes/css/modules.css" rel="stylesheet" />--%>
<div id="community-page">
    <!-- BEGIN PARTIAL: community/main_header -->

<!-- END PARTIAL: community/main_header -->

    <div class="container community-parents">
        <div class="row">
            <div class="container">
                <div class="col col-24 skiplink-feature">
                    <h2>Featured</h2>
                    <a href="REPLACE" id="ref_allParents" runat="server" class="link-recommended">Show all members</a>
                    <div class="callout-featured">
                        <div class="callout-image">
                           <%-- <img alt="430x241 Placeholder" src="http://placehold.it/430x241" />--%>
                            <sc:FieldRenderer ID="scImage" runat="server"  FieldName="Callout Image"></sc:FieldRenderer>
                        </div>
                        <div class="callout-details">
                            <h3><sc:FieldRenderer ID="scCallOutTitle" FieldName="Callout Title" runat="server" /></h3>
                           <sc:FieldRenderer ID="scCallOutDetails" FieldName="Callout Details" runat="server" />
                            <asp:Button Text="Go" CssClass="button" ID="btnGo" OnClick="btnGo_Click" runat="server" />
                        </div>
                    </div>
                   <%-- <sc:Placeholder Key="Content" runat="server"></sc:Placeholder>--%>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col col-24 container community-parents-carousel">
                <h2>Community Moderators</h2>
                <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows members next-prev-menu arrows-gray">
    
    <a class="view-all" href="REPLACE">See all moderators</a>
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
                <div class="row member-cards">
                    <sc:PlaceHolder key="Sub_Content" runat="server"></sc:PlaceHolder>
                </div>
            <%--    <div class="row member-cards">
                    <!-- BEGIN PARTIAL: community/member_card -->
<div class="member-card-container">
    <div class="col member-card">
        <div class="member-card-info group">
            <div class="member-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                    <div class="image-label">Moderator</div>
                </a>
            </div><!-- end .member-card-image -->
            <div class="member-card-name hyphenate Moderator">
                
                    <a href="REPLACE" class="name-member">Colm85</a>
                    <p class="location">cumque</p>
                
            </div><!-- end .member-card-name -->
            
            <div class="card-buttons member">
                
                <button type="button" class="button">Connect</button>
                
            </div><!-- end .member.card-buttons -->
            
        </div><!-- end .member-card-info -->
        <div class="member-card-specialties">
            <ul>
              <span class="visuallyhidden">grade level</span>
                <li class='specialty '><span tabindex='0' data-tabbable='true'>7th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 7,
            Girl
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Illo Fuga</li>
            <li>Voluptas Repudiandae</li>
            <li>Nostrum Maiores</li>
            <li>Temporibus Sit</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li>

                <li class="specialty specialty-final">
                  <span class="visuallyhidden">additional information</span>
                  <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                </li>
            </ul>
        </div>
    </div><!-- end .member-card -->
</div><!-- end .member-card-container  -->
<!-- END PARTIAL: community/member_card -->
                    <!-- BEGIN PARTIAL: community/member_card -->
<div class="member-card-container">
    <div class="col member-card">
        <div class="member-card-info group">
            <div class="member-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                    <div class="image-label">Moderator</div>
                </a>
            </div><!-- end .member-card-image -->
            <div class="member-card-name hyphenate Moderator">
                
                    <a href="REPLACE" class="name-member">Tomas68</a>
                    <p class="location">quod</p>
                
            </div><!-- end .member-card-name -->
            
            <div class="card-buttons member">
                
                <button type="button" class="button">Connect</button>
                
            </div><!-- end .member.card-buttons -->
            
        </div><!-- end .member-card-info -->
        <div class="member-card-specialties">
            <ul>
              <span class="visuallyhidden">grade level</span>
                <li class='specialty '><span tabindex='0' data-tabbable='true'>5th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 5,
            Girl
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Rerum Et</li>
            <li>Ut Id</li>
            <li>Quia Et</li>
            <li>Et Et</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty '><span tabindex='0' data-tabbable='true'>10th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 10,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Ut Et</li>
            <li>Consequuntur Aspernatur</li>
            <li>Eum Eveniet</li>
            <li>Dignissimos Qui</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li>

                <li class="specialty specialty-final">
                  <span class="visuallyhidden">additional information</span>
                  <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                </li>
            </ul>
        </div>
    </div><!-- end .member-card -->
</div><!-- end .member-card-container  -->
<!-- END PARTIAL: community/member_card -->
                    <!-- BEGIN PARTIAL: community/member_card -->
<div class="member-card-container">
    <div class="col member-card">
        <div class="member-card-info group">
            <div class="member-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                    <div class="image-label">Moderator</div>
                </a>
            </div><!-- end .member-card-image -->
            <div class="member-card-name hyphenate Moderator">
                
                    <a href="REPLACE" class="name-member">Harvey46</a>
                    <p class="location">et</p>
                
            </div><!-- end .member-card-name -->
            
            <div class="card-buttons member">
                
                <button type="button" class="button">Connect</button>
                
            </div><!-- end .member.card-buttons -->
            
        </div><!-- end .member-card-info -->
        <div class="member-card-specialties">
            <ul>
              <span class="visuallyhidden">grade level</span>
                <li class='specialty '><span tabindex='0' data-tabbable='true'>7th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 7,
            Girl
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Magni Consequatur</li>
            <li>Non Et</li>
            <li>Ullam Excepturi</li>
            <li>Consequatur Ut</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty '><span tabindex='0' data-tabbable='true'>8th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 8,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Ex Nisi</li>
            <li>Est Molestiae</li>
            <li>Neque Quas</li>
            <li>Illum Aut</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty '><span tabindex='0' data-tabbable='true'>12th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 12,
            Girl
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Architecto Eveniet</li>
            <li>Nam Beatae</li>
            <li>Atque Ut</li>
            <li>Possimus Tenetur</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li>

                <li class="specialty specialty-final">
                  <span class="visuallyhidden">additional information</span>
                  <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                </li>
            </ul>
        </div>
    </div><!-- end .member-card -->
</div><!-- end .member-card-container  -->
<!-- END PARTIAL: community/member_card -->
                    <!-- BEGIN PARTIAL: community/member_card -->
<div class="member-card-container">
    <div class="col member-card">
        <div class="member-card-info group">
            <div class="member-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                    <div class="image-label">Moderator</div>
                </a>
            </div><!-- end .member-card-image -->
            <div class="member-card-name hyphenate Moderator">
                
                    <a href="REPLACE" class="name-member">Chris95</a>
                    <p class="location">non</p>
                
            </div><!-- end .member-card-name -->
            
            <div class="card-buttons member">
                
                <button type="button" class="button">Connect</button>
                
            </div><!-- end .member.card-buttons -->
            
        </div><!-- end .member-card-info -->
        <div class="member-card-specialties">
            <ul>
              <span class="visuallyhidden">grade level</span>
                <li class='specialty '><span tabindex='0' data-tabbable='true'>3rd</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 3,
            Girl
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Nesciunt Occaecati</li>
            <li>Quia Tenetur</li>
            <li>Rerum Deserunt</li>
            <li>Quisquam Sed</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty '><span tabindex='0' data-tabbable='true'>6th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 6,
            Girl
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Enim Tenetur</li>
            <li>Ex Aperiam</li>
            <li>Qui Perferendis</li>
            <li>Veritatis Voluptatem</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty '><span tabindex='0' data-tabbable='true'>11th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 11,
            Girl
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Maxime Sed</li>
            <li>Voluptas Nostrum</li>
            <li>Deserunt Et</li>
            <li>Et Qui</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty specialty-long'><span tabindex='0' data-tabbable='true'>Adult</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Adult,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Natus Nihil</li>
            <li>Doloremque Rem</li>
            <li>Ab Aut</li>
            <li>Voluptatem Voluptate</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li>

                <li class="specialty specialty-final">
                  <span class="visuallyhidden">additional information</span>
                  <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                </li>
            </ul>
        </div>
    </div><!-- end .member-card -->
</div><!-- end .member-card-container  -->
<!-- END PARTIAL: community/member_card -->
                    <!-- BEGIN PARTIAL: community/member_card -->
<div class="member-card-container">
    <div class="col member-card">
        <div class="member-card-info group">
            <div class="member-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                    <div class="image-label">Moderator</div>
                </a>
            </div><!-- end .member-card-image -->
            <div class="member-card-name hyphenate Moderator">
                
                    <a href="REPLACE" class="name-member">Lexi23</a>
                    <p class="location">non</p>
                
            </div><!-- end .member-card-name -->
            
            <div class="card-buttons member">
                
                <button type="button" class="button">Connect</button>
                
            </div><!-- end .member.card-buttons -->
            
        </div><!-- end .member-card-info -->
        <div class="member-card-specialties">
            <ul>
              <span class="visuallyhidden">grade level</span>
                <li class='specialty '><span tabindex='0' data-tabbable='true'>8th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 8,
            Girl
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Est Vel</li>
            <li>Odio Ut</li>
            <li>Quis Illum</li>
            <li>Harum Provident</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li>

                <li class="specialty specialty-final">
                  <span class="visuallyhidden">additional information</span>
                  <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                </li>
            </ul>
        </div>
    </div><!-- end .member-card -->
</div><!-- end .member-card-container  -->
<!-- END PARTIAL: community/member_card -->
                    <!-- BEGIN PARTIAL: community/member_card -->
<div class="member-card-container">
    <div class="col member-card">
        <div class="member-card-info group">
            <div class="member-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                    <div class="image-label">Moderator</div>
                </a>
            </div><!-- end .member-card-image -->
            <div class="member-card-name hyphenate Moderator">
                
                    <a href="REPLACE" class="name-member">Marianne17</a>
                    <p class="location">quibusdam</p>
                
            </div><!-- end .member-card-name -->
            
            <div class="card-buttons member">
                
                <button type="button" class="button">Connect</button>
                
            </div><!-- end .member.card-buttons -->
            
        </div><!-- end .member-card-info -->
        <div class="member-card-specialties">
            <ul>
              <span class="visuallyhidden">grade level</span>
                <li class='specialty specialty-long'><span tabindex='0' data-tabbable='true'>PreK</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>PreK,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Voluptatem Autem</li>
            <li>Eius Ipsam</li>
            <li>Consequuntur Provident</li>
            <li>Autem Modi</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty '><span tabindex='0' data-tabbable='true'>3rd</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 3,
            Girl
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Fuga Quas</li>
            <li>Atque Fugit</li>
            <li>Hic Rerum</li>
            <li>Quod Consequatur</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty '><span tabindex='0' data-tabbable='true'>5th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 5,
            Girl
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Repellendus Ea</li>
            <li>Consequatur Animi</li>
            <li>Rem Nemo</li>
            <li>Enim Quis</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty '><span tabindex='0' data-tabbable='true'>12th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 12,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Soluta Nihil</li>
            <li>Dolores Dolorem</li>
            <li>Ipsa Repellendus</li>
            <li>Dolores Aut</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li>

                <li class="specialty specialty-final">
                  <span class="visuallyhidden">additional information</span>
                  <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                </li>
            </ul>
        </div>
    </div><!-- end .member-card -->
</div><!-- end .member-card-container  -->
<!-- END PARTIAL: community/member_card -->
                    <!-- BEGIN PARTIAL: community/member_card -->
<div class="member-card-container">
    <div class="col member-card">
        <div class="member-card-info group">
            <div class="member-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                    <div class="image-label">Moderator</div>
                </a>
            </div><!-- end .member-card-image -->
            <div class="member-card-name hyphenate Moderator">
                
                    <a href="REPLACE" class="name-member">Ciara54</a>
                    <p class="location">totam</p>
                
            </div><!-- end .member-card-name -->
            
            <div class="card-buttons member">
                
                <button type="button" class="button">Connect</button>
                
            </div><!-- end .member.card-buttons -->
            
        </div><!-- end .member-card-info -->
        <div class="member-card-specialties">
            <ul>
              <span class="visuallyhidden">grade level</span>
                <li class='specialty specialty-long'><span tabindex='0' data-tabbable='true'>PreK</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>PreK,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Eaque Qui</li>
            <li>Animi Voluptate</li>
            <li>Earum Quos</li>
            <li>Tempora Dolorum</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty '><span tabindex='0' data-tabbable='true'>2nd</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 2,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>In Numquam</li>
            <li>Quasi Aut</li>
            <li>Molestiae Unde</li>
            <li>Qui Labore</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty '><span tabindex='0' data-tabbable='true'>12th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 12,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Dolorem Et</li>
            <li>Ipsa Iste</li>
            <li>Pariatur Dolores</li>
            <li>Nostrum Sit</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li><li class='specialty specialty-long'><span tabindex='0' data-tabbable='true'>Adult</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Adult,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Quia Mollitia</li>
            <li>Sint Ut</li>
            <li>Neque Provident</li>
            <li>Repudiandae Esse</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li>

                <li class="specialty specialty-final">
                  <span class="visuallyhidden">additional information</span>
                  <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                </li>
            </ul>
        </div>
    </div><!-- end .member-card -->
</div><!-- end .member-card-container  -->
<!-- END PARTIAL: community/member_card -->
                    <!-- BEGIN PARTIAL: community/member_card -->
<div class="member-card-container">
    <div class="col member-card">
        <div class="member-card-info group">
            <div class="member-card-image">
                <a href="REPLACE">
                    <img alt="150x150 Placeholder" src="http://placehold.it/150x150" />
                    <div class="image-label">Moderator</div>
                </a>
            </div><!-- end .member-card-image -->
            <div class="member-card-name hyphenate Moderator">
                
                    <a href="REPLACE" class="name-member">Quinn77</a>
                    <p class="location">aperiam</p>
                
            </div><!-- end .member-card-name -->
            
            <div class="card-buttons member">
                
                <button type="button" class="button">Connect</button>
                
            </div><!-- end .member.card-buttons -->
            
        </div><!-- end .member-card-info -->
        <div class="member-card-specialties">
            <ul>
              <span class="visuallyhidden">grade level</span>
                <li class='specialty '><span tabindex='0' data-tabbable='true'>8th</span><!-- BEGIN PARTIAL: community/child_info_card -->
 
 <div class="card-child-info popover">
    <div class="popover-content">
        <span class="caret"></span>
        <h3>Grade 8,
            Boy
        </h3>
        <!-- BEGIN PARTIAL: community/carousel_arrows -->
<div class="arrows child-info-next-prev-menu arrows-gray">
    
    <div class="rsArrow rsArrowLeft"><button class="rsArrowIcn"></button></div>
    <div class="rsArrow rsArrowRight"><button class="rsArrowIcn"></button></div>
</div><!-- end .arrows -->
<!-- END PARTIAL: community/carousel_arrows -->
        <ul>
            <li>Modi Impedit</li>
            <li>Quibusdam Et</li>
            <li>Dolor Laboriosam</li>
            <li>Doloribus Fuga</li>
        </ul>
        <div class="card-buttons">
            <button class="button gray">View Profile</button>
            <button class="button blue">See Activity</button>
        </div>
    </div>
</div>
<!-- END PARTIAL: community/child_info_card --></li>

                <li class="specialty specialty-final">
                  <span class="visuallyhidden">additional information</span>
                  <span tabindex='0' data-tabbable='true'>&nbsp;</span>
                </li>
            </ul>
        </div>
    </div><!-- end .member-card -->
</div><!-- end .member-card-container  -->
<!-- END PARTIAL: community/member_card -->
                </div><!-- end .member-cards -->--%>
            </div><!-- end .col.col-24.container -->
        </div><!-- end .row -->
    </div><!-- end .community-members -->
</div>