(function($) {
	var nextPage = 2;
	var inProgress = false;
	
	$(document).ready(function() {
		init();
	});
	
	function init() {
		$("a.show-more-search-results-link").on("click", searchResults_clickHandler);
    }
	
	function searchResults_clickHandler(e) {
		e.preventDefault();
		
		if (inProgress) {
			return;
		}
		
		// show more button container
		var $showMoreContainer = $(this);
		
		// show more button class

		var $showMore = $(e.currentTarget);

		// data container class name to populate (from button data attribute)
		var $dataContainer = $("." + $showMore.data('container'));

		// data file (from button data attribute)
		var $dataFile = $showMore.data('path');
		
		var $dataType = $showMore.data('type');
		
		var $dataTerm = $showMore.data('term');
		$dataTerm = $('<div/>').html($dataTerm).text();

		// scroll to top of newly loaded items
		$('html,body').animate({scrollTop: $showMoreContainer.offset().top - 40}, 500);

		var data = {
			terms: $dataTerm,
			type: $dataType,
			page: nextPage
		};

		var templateSource = $("#search-result-entry").html();
		var template = Handlebars.compile(templateSource);

		inProgress = true;
		
		$.ajax({
			url: $dataFile,
			dataType: 'json',
			contentType: 'application/json; charset=utf-8',
			data: JSON.stringify(data),
			method: 'POST'
		}).done(function (data) {
			
			nextPage++;
			
			var result = data.d;
			
			if (!result.HasMoreResults) {
				$showMore.hide();
			}
			
			var entries = result.Articles;
			
			for (var i = 0, j = entries.length; i < j; i++) {
				$dataContainer.append(template(entries[i]));
			}

			/*
			creates a readspeaker play button for all elements that have a cass of rs_read_this (only for elements that
			do not have a play button)
			*/
			//ReadSpeaker.q(function(){rspkr.Toggle.createPlayer()});
		}).always(function() {
			inProgress = false;
		});
	  
	  


	}

})(jQuery);