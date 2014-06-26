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

// Topic/Subtopic Landing Page Articles
(function ($) {
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

        $('html,body').animate({ scrollTop: $showMoreContainer.offset().top - 40 }, 500);
		
		var data = {
            'topic': topic,
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
	var $container, $showMoreContainer, path, topic, grade, issue;
	
	function init() {
		var $trigger = $("#experts-show-more-results");
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

        $('html,body').animate({ scrollTop: $showMoreContainer.offset().top - 40 }, 500);
		
		var data = {
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
    for (var i = showCount; i < showCount + 3; i++) {
        $(".repeater-item").eq(i).show();
    }
    showCount += 3;
    if ($(".repeater-item").length <= showCount) {
        $(".show-more-link").hide();
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
    return isValid;
}

ValidateRadioButtons = function (sender, args) {
    args.IsValid = $("input[name*=" + sender.groupName + "]:checked").length > 0;
}

$(document).ready(function () {
    $(".sign-up-inputs input").change(validate);

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