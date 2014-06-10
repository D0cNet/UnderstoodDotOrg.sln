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
	var path;
	
	function redirectToSignUp() {
		var $input = $(".personalized-email-form input[type='text']");
		var email = $input.val();
		
		location.href = path + "?email=" + email;
	}
	
	$(document).ready(function() {
		var $submit = $(".personalized-email-form input[type='submit']");
		if ($submit.length == 0) {
			return;
		}
		
		path = $submit.data('path');
		
		$submit.on("click", function(e) {
			e.preventDefault();		
			redirectToSignUp();
		});
		$(".personalized-email-form input[type='text']").on("keypress", function (e) {
            if (e.which == 13) {
                e.preventDefault();
                redirectToSignUp();
            }
        });
	});
})(jQuery);

// Topic/Subtopic Landing Page Articles
(function($) {
	var currentPage = 1;
	var inProgress = false;
	var $trigger = $(".topic-subtopic-articles-show-more-link");
	var $container, $showMoreContainer, path, topic;
	
	function init() {
		if ($trigger.length > 0) {
			path = $trigger.data('path');
			topic = $trigger.data('topic');
			$container = $("#" + $trigger.data('container'));
			$showMoreContainer = $trigger.closest(".show-more");
			
			$trigger.on("click", showMore_clickHandler);
		}
	}
	
	function showMore_clickHandler(e) {
		e.preventDefault();
		
		if (inProgress) {
			return;
		}
		
		inProgress = true;

		$('html,body').animate({scrollTop: $showMoreContainer.offset().top - 40}, 500);
		
		var data = {
			'topic' : topic,
			'page' : currentPage + 1
		};
		
		$.ajax({
			url: path,
			data: data,
			method: 'GET'
		}).done(function (data) {
			currentPage++;
			if ($(data).filter('input[type="hidden"]').length == 0) 
			{
				$showMoreContainer.hide();
			}
			$container.append(data);
		}).always(function() {
			inProgress = false;
		});
	}
	
	$(document).ready(init);
	
	
})(jQuery);

// Event archive
(function ($) {
    var currentPage = 1;
	var inProgress = false;
	var $trigger = $("#event-archive-show-more");
	var $container, $showMoreContainer, path, topic, grade, issue;
	
	function init() {
		if ($trigger.length > 0) {
			path = $trigger.data('path');
			topic = $trigger.data('topic');
			grade = $trigger.data('grade');
			issue = $trigger.data('issue');
			$container = $("#" + $trigger.data('container'));
			$showMoreContainer = $trigger.closest(".show-more");
			
			$trigger.on("click", showMore_clickHandler);
		}
	}
	
	function showMore_clickHandler(e) {
		e.preventDefault();
		
		if (inProgress) {
			return;
		}
		
		inProgress = true;

		$('html,body').animate({scrollTop: $showMoreContainer.offset().top - 40}, 500);
		
		var data = {
			'topic' : topic,
			'grade' : grade,
			'issue' : issue,
			'page' : currentPage + 1
		};
		
		$.ajax({
			url: path,
			data: data,
			method: 'GET'
		}).done(function (data) {
			currentPage++;
			if ($(data).filter('input[type="hidden"]').length == 0) 
			{
				$showMoreContainer.hide();
			}
			$container.append(data);
		}).always(function() {
			inProgress = false;
		});
	}
	
	$(document).ready(init);
})(jQuery);

// Experts listing
(function ($) {
    var currentPage = 1;
	var inProgress = false;
	var $trigger = $("#experts-show-more-results");
	var $container, $showMoreContainer, path, topic, grade, issue;
	
	function init() {
		if ($trigger.length > 0) {
			path = $trigger.data('path');
			$container = $("#" + $trigger.data('container'));
			$showMoreContainer = $trigger.closest(".show-more");
			
			$trigger.on("click", showMore_clickHandler);
		}
	}
	
	function showMore_clickHandler(e) {
		e.preventDefault();
		
		if (inProgress) {
			return;
		}
		
		inProgress = true;

		$('html,body').animate({scrollTop: $showMoreContainer.offset().top - 40}, 500);
		
		var data = {
			'page' : currentPage + 1
		};
		
		$.ajax({
			url: path,
			data: data,
			method: 'GET'
		}).done(function (data) {
			currentPage++;
			if ($(data).filter('input[type="hidden"]').length == 0) 
			{
				$showMoreContainer.hide();
			}
			$container.append(data);
		}).always(function() {
			inProgress = false;
		});
	}
	
	$(document).ready(init);
})(jQuery);


// Homepage module
(function ($) {
	var $gradeInput = $("#hfGradeChoice");
	
	function gradeButton_clickHandler(e) {
		$gradeInput.val($(this).data('value'));
	}
	
	$(document).ready(function() {
		if ($(".container-guide-me-overlay").length == 0) {
			return;
		}
		$(".container-guide-me-overlay nav button").on("click", gradeButton_clickHandler);
	});
	
})(jQuery);

//"Show More" functionality for repeaters
var showCount = 5;
$(document).ready(function () {
    for (var i = showCount; i < $(".repeater-item").length; i++) {
        $(".repeater-item").eq(i).hide();
    }
});
$(".show-more-link").click(function () {
    for (var i = showCount; i < showCount + 3; i++) {
        $(".repeater-item").eq(i).show();
    }
    showCount += 3;
})