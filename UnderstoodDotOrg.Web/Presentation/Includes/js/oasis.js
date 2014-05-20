function updateCommunityProperties(zipcode) {
	//$.ajax({
	//	type: "POST",
	//	contentType: "application/json; charset=utf-8",
	//	data: "{ zipcode: '" + zipcode + "' }",
	//	url: "/handlers/MembershipHandler.ashx/Test",
	//	dataType: "json",
	//	success: function (data) {
	//		alert(data);
	//	}
	//});

	$.post('/handlers/MembershipHandler.aspx?zipcode=' + zipcode, {}, function (data) {
		alert(data);
	});
}

function scrollToSelector(selector) {
	jQuery(function () {
		$('html, body').animate({
			scrollTop: $(selector).offset().top
		}, 2000);
	});
}

jQuery(function () {
	$('.btnEdit').click(function (e) {
		e.preventDefault();
		$(this).parent().parent().parent().addClass('editMode');
	});

	$('.btnCancel').click(function (e) {
		e.preventDefault();
		$(this).parent().parent().parent().removeClass('editMode');
	});

	$('.btnSave').click(function (e) {
		e.preventDefault();

		var $this = $(this);

		if ($this.hasClass('community')) {
			var sectionWrapper = $this.parent().parent().parent();

			var txtZipcode = sectionWrapper.find('.txtZipcode');

			if (txtZipcode.length > 0) {
				updateCommunityProperties(txtZipcode.val());
			}
		}
	});
});

// Footer email
(function($) {
	function email_clickHandler(e) {
		e.preventDefault();
		$input = $(".personalized-email-form input[type='text']");
		
		if ($.trim($input.val()) !== "") {
			location.href = $(this).data("path") + "?email=" + $input.val();
		}
	}
	
	$(document).ready(function() {
		$(".personalized-email-form input[type='submit']").on("click", email_clickHandler);
	});
})(jQuery);