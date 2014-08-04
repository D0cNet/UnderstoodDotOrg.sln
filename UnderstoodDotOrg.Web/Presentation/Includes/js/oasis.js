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

$(function () {
    //plugin for generating mobile versions of responsive tables added to RTE
    $.fn.responsiveTable = function () {
        //options?
        return this.each(function () {
            var $this = $(this);
            var rows = [];
            var columnCount = 0;

            var addToRows = function ($tdCollection) {
                var isHeader = !columnCount;

                $tdCollection.each(function (i) {
                    if (isHeader) {
                        rows[i] = ["<tr>" + this.outerHTML + "</tr>"];
                        columnCount++;
                    } else {
                        rows[i].push("<tr>" + this.outerHTML + "</tr>");
                    }
                });
            };

            var $thead = $this.children("thead").first();
            if ($thead.length) {
                var $headers = $thead.children("tr").first().children("td");
                addToRows($headers);
            }

            var $tbody = $this.children("tbody").first();
            if ($tbody.length) {
                var $bodyRows = $tbody.children("tr");
                $bodyRows.each(function (i) {
                    addToRows($(this).children("td"));
                });
            }
            console.log(rows);
            if (rows.length) {
                var tables = [];
                for (var i = 0; i < rows.length; i++) {
                    var cap = "";
                    if (i == 0) {
                        $caption = $this.children("caption").first();
                        if ($caption.length) {
                            cap = $caption[0].outerHTML;
                        }
                    }
                    tables[i] = "<table class='mobile-only'>" + cap + rows[i].join("") + "</table>";
                }

                $this.after(tables);
            }
        });
    };
}(jQuery));

$(document).ready(function () {
    $("table.original.responsive-enabled").responsiveTable();
});

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
(function ($) {
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

// Topic Landing Page Articles
(function ($) {
	var currentPage = 1;
	var inProgress = false;
	var $trigger = $(".topic-subtopic-articles-show-more-link");
	var $container, $showMoreContainer, path, topic, lang;
	
	function init() {
		if ($trigger.length > 0) {
			path = $trigger.data('path');
			topic = $trigger.data('topic');
			lang = $trigger.data('lang');
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

        $('html,body').animate({ scrollTop: $showMoreContainer.offset().top - 40 }, 500);
		
		var data = {
            'topic': topic,
            'page': currentPage + 1,
            'lang': lang
		};
		
		$.ajax({
			url: path,
			data: data,
			method: 'GET'
		}).done(function (data) {
			currentPage++;
            if ($(data).filter('input[type="hidden"]').length == 0) {
				$showMoreContainer.hide();
			}
			$container.append(data);
        }).always(function () {
			inProgress = false;
		});
	}
	
	$(document).ready(init);
	
	
})(jQuery);

// Subtopic Landing Page Articles
(function ($) {
    var currentPage = 1;
    var inProgress = false;
    var $trigger = $(".subtopic-articles-show-more-link");
    var $container, $showMoreContainer, path, topic, lang, type, featured;

    function init() {
        // ajax paging
        if ($trigger.length > 0) {
            path = $trigger.data('path');
            topic = $trigger.data('topic');
            lang = $trigger.data('lang');
            type = '';
            featured = $trigger.data('featured');
            $container = $("#" + $trigger.data('container'));
            $showMoreContainer = $trigger.closest(".show-more");

            $trigger.on("click", showMore_clickHandler);
        }

        // filter nav
        $("#subtopic-nav-filter a").click(navFilter_clickHandler);
    }

    function navFilter_clickHandler(e) {
        e.preventDefault();

        // Set selected state
        $("#subtopic-nav-filter ul.menu a").removeClass("selected");
        $(this).addClass("selected");

        type = $(this).data('filter');
        currentPage = 0;

        loadNextArticles(false);
    }

    function showMore_clickHandler(e) {
        e.preventDefault();

        loadNextArticles(true);
    }

    function loadNextArticles(displayAnimation) {
        if (inProgress) {
            return;
        }

        // if current page is 0, reset content area
        if (currentPage == 0) {
            $container.html('');
            $showMoreContainer.hide();
        }

        inProgress = true;

        if (displayAnimation) {
            $('html,body').animate({ scrollTop: $showMoreContainer.offset().top - 40 }, 500);
        }

        var data = {
            'topic': topic,
            'page': currentPage + 1,
            'lang': lang,
            'featured': featured,
            'type': type
        };

        $.ajax({
            url: path,
            data: data,
            method: 'GET'
        }).done(function (data) {
            currentPage++;
            if ($(data).filter('input[type="hidden"]').length == 0) {
                $showMoreContainer.hide();
            } else {
                $showMoreContainer.show();
            }

            $container.append(data);
            ReadSpeaker.q(function () { rspkr.Toggle.createPlayer() });

        }).always(function () {
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

        $('html,body').animate({ scrollTop: $showMoreContainer.offset().top - 40 }, 500);
		
		var data = {
            'topic': topic,
            'grade': grade,
            'issue': issue,
            'page': currentPage + 1
		};
		
		$.ajax({
			url: path,
			data: data,
			method: 'GET'
		}).done(function (data) {
			currentPage++;
            if ($(data).filter('input[type="hidden"]').length == 0) {
				$showMoreContainer.hide();
			}
			$container.append(data);
        }).always(function () {
			inProgress = false;
		});
	}
	
	$(document).ready(init);
})(jQuery);

// Experts listing
(function ($) {
    var currentPage = 1;
	var inProgress = false;
	var $container, $showMoreContainer, path, lang;
	
	function init() {
		var $trigger = $("#experts-show-more-results");
		if ($trigger.length > 0) {
		    path = $trigger.data('path');
		    lang = $trigger.data('lang');
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

        $('html,body').animate({ scrollTop: $showMoreContainer.offset().top - 40 }, 500);
		
		var data = {
		    'page': currentPage + 1,
            'lang': lang
		};
		
		$.ajax({
			url: path,
			data: data,
			method: 'GET'
		}).done(function (data) {
			currentPage++;
            if ($(data).filter('input[type="hidden"]').length == 0) {
				$showMoreContainer.hide();
			}
			$container.append(data);
        }).always(function () {
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
	
    $(document).ready(function () {
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
    for (var i = showCount; i < showCount + 5; i++) {
        $(".repeater-item").eq(i).show();
    }
    showCount += 5;
    if ($(".repeater-item").length <= showCount) {
        $(".show-more-link").hide();
    }
})
$(".show-more-link-mycomments").click(function () {
    for (var i = showCount; i < showCount + 5; i++) {
        $(".repeater-item").eq(i).show();
    }
    $(".repeater-item").eq(showCount).focus();
    showCount += 5;
    if ($(".repeater-item").length <= showCount) {
        $(".show-more-link-mycomments").hide();
    }
})

//JS validation
markInvalid = function () {
    $.each(Page_Validators, function (index, validator) {
        if (!validator.isvalid) {
            $(validator).parents("label").addClass("error");
            $(validator).removeClass("valid").addClass("validationerror");
        }
    });
}

validate = function () {
    $("span.validationerror").removeClass("validationerror").addClass("valid");
    $("label.error").removeClass("error");

    var isValid = Page_ClientValidate("");
    if (!isValid) {
        markInvalid();
    }

    $(".sign-up-inputs input").change(validate);

    return isValid;
}

reviewMarkInvalid = function () {
    $.each(Page_Validators, function (index, validator) {
        if (!validator.isvalid) {
            $(validator).parents("label").addClass("error");
            $(validator).removeClass("valid").addClass("validationerror");
        }
    });
}

reviewValidate = function () {
    $("span.validationerror:not([id*='itIsGoodFor'])").removeClass("validationerror").addClass("valid");
    $("label.error").removeClass("error");

    var isValid = Page_ClientValidate("vlgReviewInputs");
    if (!isValid) {
        reviewMarkInvalid();
    }
    else{
        $(".review-submit").off("click");
    }

    //if ($("[id*='hfKeyValuePairs']").val() != "") {
    //    $("[id*='itIsGoodFor']").hide();
    //}
    //else {
    //    $("[id*='itIsGoodFor']").show();
    //}

    $(".rate-this-app input").change(validate);

    return isValid;
}

ValidateRadioButtons = function (sender, args) {
    args.IsValid = $("input[name*=" + sender.groupName + "]:checked").length > 0;
}

$(document).ready(function () {
    //$(".sign-up-inputs input").change(validate);

    //updates labels that contain checked radio buttons after page load
    $('input[type=radio]:checked').parents('label.button').addClass('checked');

    //update containing divs for dropdowns with selected values
    $('select').each(
        function () {
            if ($(this).val() != "") {
                $(this).parents('div.selector').addClass('selected')
            }
    });
});

// Assistive tool widget
(function($) {

	$(document).ready(function () {
        new U.assistiveToolWidget();
    });

    U.assistiveToolWidget = function () {
        var self = this;

        // cache selectors
        var $techTypeSelect = $("section.mini-tool select.tech-type-select");
        var $issueSelect = $("section.mini-tool select.issue-select");
        var $gradeSelect = $("section.mini-tool select.grade-select");
        var $platformSelects = $("section.mini-tool select.platform-select");
        var $uniformPlatformSelects = $platformSelects.parent();
        var $hfSelectedPlatform = $("section.mini-tool .hfSelectedPlatform");

        $techTypeSelect.on("change", function () {
            $uniformPlatformSelects.hide();
            $platformSelects.val("").removeClass("active").trigger("change");
            var typeId = $(this).val();
            if (typeId) {
                showPlatformSelect(typeId);
            }
        });

        function showPlatformSelect(typeId) {
            var $platformSelect = $platformSelects.filter("[data-type-id='" + typeId + "']").first();
            $platformSelect
                .show()
                .addClass("active")
                .parent().show();
            return $platformSelect;
        }

        $platformSelects.on("change", function () {
            $hfSelectedPlatform.val($(this).val()).trigger("change");
        });

        return this;
    };
})(jQuery);

// Behavior tool widget
(function($) {

	$(document).ready(function () {
        new U.behaviorToolWidget();
    });

    U.behaviorToolWidget = function () {
        var self = this;
		
		function validateSelections(container) {
			var isValid = true;
			var $container = $(container);
			var $submit = $container.find("input[type='submit']")
			
			$container.find("select").each(function() {
				if ($(this).val() == "") {
					isValid = false;
					return false;
				}
			});
			
			if (isValid) {
				$submit.removeAttr("disabled");
			} else {
				$submit.attr("disabled", "disabled");
			}
		}
		
		$(".behavior-tool-widget").each(function() {
			var formContainer = this;
			
			// init change handlers
			$(this).find("select").on("change", function() {
				validateSelections(formContainer);
			});
			
			validateSelections(formContainer);
		});
        
        return this;
    };
})(jQuery);

// Comments
(function ($) {
    var currentPage = 1;
    var inProgress = false;
    var helpfulInProgress = false;
    var flagInProgress = false;
	var $container, $showMoreContainer, $scrollContainer, $sortOption, path, blog, post;
	
	function init() {
	    initShowMore();
	    initCommentActions();
	}

	function initShowMore() {
	    var $trigger = $("#show-more-comments");
	    var $list = $("#comment-list");
	    path = $list.data('path');
	    blog = $list.data('blog');
	    post = $list.data('post');
	    $container = $("#" + $list.data('container'));

	    if ($trigger.length > 0) {
	        $showMoreContainer = $trigger.closest('.show-more');
	        $scrollContainer = $showMoreContainer;
	    } else {
	        $scrollContainer = $list;
	    }

	    $trigger.on("click", showMore_clickHandler);
		$sortOption = $("#comment-sort-option-dropdown");	
		$sortOption.on("change", sortOption_changeHandler);
	}
	
	function sortOption_changeHandler(e) {
	    if ($(this).prop('selectedIndex') > 0) {
	        currentPage = 0;
	        if (typeof $showMoreContainer != 'undefined') {
	            $showMoreContainer.hide();
	        }
	        $container.html('');
	        loadNextPage();
	    }
	}

	function initCommentActions() {
	    $("#comment-list").on("click", "a.comment-reply", function (e) {
	        e.preventDefault();
	        $("#comment-list textarea").focus();
	    });

	    $("#comment-list").on("click", "a.comment-like", helpful_clickHandler);
	    $("#comment-list").on("click", "a.comment-flag", flag_clickHandler);
	}

	function helpful_clickHandler(e) {
	    e.preventDefault();
		var self = this;

	    if (helpfulInProgress) {
	        return;
	    }

	    helpfulInProgress = true;

	    var data = {
	        'contentId' : $(this).closest(".comment-wrapper").data('comment-id'),
	        'contentTypeId' : $(this).data('content-type-id')
	    };

	    $.ajax({
	        url: $("#comment-list").data('endpoint') + 'FoundCommentHelpful',
	        dataType: 'json',
	        contentType: 'application/json; charset=utf-8',
	        data: JSON.stringify(data),
	        method: 'POST'
	    }).done(function (data) {

	        var result = data.d;

	        if (result.IsSuccessful) {
	            $(self).closest('.comment-wrapper').find('span.comment-like-count').html(result.HelpfulCount.toString());
			} else {
				// TODO: display error or redirect to login?
			}
	    }).always(function () {
	        helpfulInProgress = false;
	    });

	}

	function flag_clickHandler(e) {
	    e.preventDefault();
	    var self = this;

	    if (flagInProgress) {
	        return;
	    }

	    flagInProgress = true;

	    var data = {
	        'contentId': $(this).closest(".comment-wrapper").data('comment-id')
	    };

	    $.ajax({
	        url: $("#comment-list").data('endpoint') + 'FlagComment',
	        dataType: 'json',
	        contentType: 'application/json; charset=utf-8',
	        data: JSON.stringify(data),
	        method: 'POST'
	    }).done(function (data) {

	        var result = data.d;

	        if (result.IsSuccessful) {
	            $(self).closest('.comment-wrapper').find('span.comment-flag-label').html(result.Message);
	        } else {
	            // TODO: display error or redirect to login?
	        }
	    }).always(function () {
	        flagInProgress = false;
	    });

	}
	
	function showMore_clickHandler(e) {
		e.preventDefault();
		
		loadNextPage();
	}
	
	function loadNextPage() {
		if (inProgress) {
			return;
		}
		
		inProgress = true;

        $('html,body').animate({ scrollTop: $scrollContainer.offset().top - 40 }, 500);
		
		var data = {
            'page': currentPage + 1,
			'blog': blog,
			'post': post,
			'sortBy': parseInt($sortOption.prop('selectedIndex'), 10)
		};
		
		$.ajax({
			url: path,
			data: data,
			method: 'GET'
		}).done(function (data) {
		    currentPage++;

		    if (typeof $showMoreContainer != 'undefined') {
		        if ($(data).filter('input[type="hidden"]').length == 0) {
		            $showMoreContainer.hide();
		        } else {
		            $showMoreContainer.show();
		        }
		    }
			$container.append(data);
        }).always(function () {
			inProgress = false;
		});
	}
	
	$(document).ready(init);
})(jQuery);

// Share e-mail modal
(function($) {
	$(document).ready(function() {
		$(".icon-email,.thank-you-social .email-link").on("click", function(e) {
			e.preventDefault();
			$(".share-email-modal").modal("show");
		});
	});
})(jQuery);

// Public Profile Comments
(function ($) {
    var currentPage = 1;
    var inProgress = false;
    var $container, $showMoreContainer, path, lang, screenName;

    function init() {
        var $trigger = $("#profile-comment-activity-show-more");
        if ($trigger.length > 0) {
            path = $trigger.data('path');
            lang = $trigger.data('lang');
            screenName = $trigger.data('screenname');
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

        $('html,body').animate({ scrollTop: $showMoreContainer.offset().top - 40 }, 500);

        var data = {
            'page': currentPage + 1,
            'lang': lang,
            'screenName': screenName
        };

        $.ajax({
            url: path,
            data: data,
            method: 'GET'
        }).done(function (data) {
            currentPage++;
            if ($(data).filter('input[type="hidden"]').length == 0) {
                $showMoreContainer.hide();
            }
            $container.append(data);
        }).always(function () {
            inProgress = false;
        });
    }

    $(document).ready(init);
})(jQuery);

// Public Profile Connections
(function ($) {
    var currentPage = 1;
    var inProgress = false;
    var $container, $showMoreContainer, path, lang, screenName;

    function init() {
        var $trigger = $("#show-more-account-connections");
        if ($trigger.length > 0) {
            path = $trigger.data('path');
            lang = $trigger.data('lang');
            screenName = $trigger.data('screenname');
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

        $('html,body').animate({ scrollTop: $showMoreContainer.offset().top - 40 }, 500);

        var data = {
            'page': currentPage + 1,
            'lang': lang,
            'screenName': screenName
        };

        $.ajax({
            url: path,
            data: data,
            method: 'GET'
        }).done(function (data) {
            currentPage++;
            if ($(data).filter('input[type="hidden"]').length == 0) {
                $showMoreContainer.hide();
            }
            $container.append(data);
        }).always(function () {
            inProgress = false;
        });
    }

    $(document).ready(init);
})(jQuery);

// Likes button hook
(function ($) {
    var helpfulInProgress = false;
    function init() {
        $("button.groups-discussion-like-button").click(helpful_clickHandler);
    }
    function helpful_clickHandler(e) {
        e.preventDefault();
        var self = this;

        if (helpfulInProgress) {
            return;
        }

        helpfulInProgress = true;

        var data = {
            'contentId': $(this).data('content-id'),
            'contentTypeId': $(this).data('content-type-id')
        };

        $.ajax({
            url: $(self).data('endpoint') + 'FoundReplyHelpful',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(data),
            method: 'POST'
        }).done(function (data) {

            var result = data.d;

            if (result.IsSuccessful) {
                $(self).find('p').html(result.HelpfulCount.toString());
            } else {
                // TODO: display error or redirect to login?
            }
        }).always(function () {
            helpfulInProgress = false;
        });
        return false;
    }
    $(document).ready(init);
})(jQuery);

function getParameterByName(name) {
    var match = RegExp('[?&]' + name + '=([^&]*)').exec(window.location.search);
    return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
}

// Assistive tools AJAX
(function ($) {
    // path for data
    var $dataPath = '/Presentation/AjaxData/';

    var $body = $(document.body);

    // Initialize the module on page load.
    $(document).ready(function () {
        init();
    });

    // request more items
    function requestMore($link, $sort) {

        // show more button container
        var $showMoreContainer = $link.closest(".show-more");
        // show more button class

        var $showMore = $link;

        // data container class name to populate (from button data attribute)
        var $dataContainer = $("." + $showMore.data('container'));

        // data class name for each item (for counting) (from button data attribute)
        var $dataItem = $("." + $showMore.data('item'));

        // data file (from button data attribute)
        var $dataFile = $showMore.data('path');

        // data count (from button data attribute)
        var $dataCount = $showMore.attr('data-count');

        // data page id (from button data attribute)
        var $dataPageId = $showMore.data("page-id");

        // data category id (from button data attribute)
        var $dataCategoryId = $showMore.attr("data-category-id");

        // data max results (from button data attribute)
        var $dataMaxResults = $showMore.data("max-results");

        // data results per click (from button data attribute)
        var $dataResultsPerClick = $showMore.data("results-per-click");

        //number visible to user, reflecting number of displayed results
        var $categoryDisplayCount = $(".category-display-count").filter("[data-category-id='" + $dataCategoryId + "']");

        //search parameters
        var keyword = $("#hfAssistiveTechResultsKeyword").val();
        if (!keyword) {
            var issueId = $("#hfAssistiveTechResultsIssueId").val();
            var gradeId = $("#hfAssistiveTechResultsGradeId").val();
            var techTypeId = $("#hfAssistiveTechResultsTechTypeId").val();
            var platformId = $("#hfAssistiveTechResultsPlatformId").val();
        }

        var sortOption = $sort.val();

        // scroll to top of newly loaded items
        $('html,body').animate({ scrollTop: $showMoreContainer.offset().top - 40 }, 500);

        var qs = "?count=" + $dataCount +
            "&pageId=" + $dataPageId +
            "&categoryId=" + $dataCategoryId +
            "&sortOption=" + sortOption +
            (keyword ?
                "&keyword=" + keyword :
                "&issueId=" + issueId + "&gradeId=" + gradeId + "&techTypeId=" + techTypeId + "&platformId=" + platformId);

        var clickCount = parseInt($dataCount, 10) + 1;
        $showMore.attr("data-count", clickCount);

        var maxResults = parseInt($dataMaxResults, 10);
        var resultsPerClick = parseInt($dataResultsPerClick, 10);

        if (clickCount > 1) {
            toggleShowMore(clickCount, maxResults, resultsPerClick, $showMore);
        }

        // Ajax load items
        $.get($dataPath + $dataFile + '.aspx' + qs, function (data) {
            var newContent = $(data);
            $dataContainer.append(newContent);
            newContent.find(':focusable').eq(0).focus();

            // When sort filter resets, only display "show more" after first result set has loaded
            if (clickCount == 1) {
                toggleShowMore(clickCount, maxResults, resultsPerClick, $showMore);
            }

            $categoryDisplayCount.html(Math.min(resultsPerClick * clickCount, maxResults));

            /*
            creates a readspeaker play button for all elements that have a cass of rs_read_this (only for elements that
            do not have a play button)
            */
            ReadSpeaker.q(function () { rspkr.Toggle.createPlayer() });

        }, 'html');
    }

    function toggleShowMore(clickCount, maxResults, resultsPerClick, $link) {
        if (clickCount >= Math.ceil(maxResults / resultsPerClick)) {
            $link.parent().parent().hide();
        } else {
            $link.parent().parent().show();
        }
    }

    function init() {
        
        $(".tech-search-results").each(function () {
            var $sortSelect = $(this).find(".select-container select");
            var $link = $(this).find(".at-show-more-link");

            $link.on('click', function (e) {
                e.preventDefault();

                requestMore($(this), $sortSelect);
            });

            $sortSelect.on("change", function () {
                var $dataContainer = $("." + $link.data('container'));
                $dataContainer.html("");

                // reset page index
                $link.attr("data-count", "0");
                // Hide show more
                $link.parent().parent().hide();

                requestMore($link, $sortSelect);
            });
        });
    };

})(jQuery);