<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShareContent.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared.ShareContent" %>

<div class="top">
	<!-- BEGIN PARTIAL: share-content-dropdown -->
	<!-- This file shared on multiple pages -->

	<div class="share-dropdown-menu rs_skip">
		<button class="social-share-button">Share <i class="icon-arrow"></i></button>
		<div class="share-menu">
			<span class="social-share">Share <i class="icon-arrow"></i></span>
			<ul>
				<li class="clearfix">
					<a class="icon-facebook share-icon" href="REPLACE"><i class="icon-facebook"></i>Facebook</a>
				</li>
				<li class="clearfix">
					<a class="icon-twitter share-icon" href="REPLACE"><i class="icon-twitter"></i>Twitter</a>
				</li>
				<li class="clearfix">
					<a class="icon-google share-icon" href="REPLACE"><i class="icon-google"></i>Google +</a>
				</li>
				<li class="clearfix">
					<a class="icon-pinterest share-icon" href="REPLACE"><i class="icon-pinterest"></i>Pinterest</a>
				</li>
			</ul>
		</div>
	</div>
	<!-- END PARTIAL: share-content-dropdown -->
	<!-- BEGIN PARTIAL: article-action-buttons -->
	<div class="article-actions buttons-container rs_skip clearfix">

		<button class="icon-email">email</button>

		<button class="icon-plus">save this</button>

		<button class="icon-print">print</button>

		<button class="icon-bell">remind me</button>

	</div>

	<!-- END PARTIAL: article-action-buttons -->
	<div class="clearfix"></div>
</div>