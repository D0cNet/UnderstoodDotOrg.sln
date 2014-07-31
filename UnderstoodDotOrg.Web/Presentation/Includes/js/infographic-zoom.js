(function($){

	$(document).ready(function(){
	  new U.zoom();
	});

	U.zoom = function(){

		var self = this;

		self.init = function(){


			self.container = $('.zoom-container');
			self.dimensions = {};

			// prevent default on the zooms which are anchors
			$('.infographic-zoom-icon-zoom-in, .infographic-zoom-icon-zoom-out').click(function(e){ e.preventDefault(); });
		
			// requires imagesLoaded plugin for cross browser detection of image being loaded.
			// this is so we can set the height of the container for the zoom
			// https://github.com/desandro/imagesloaded
			imagesLoaded(self.container, function(e){

				self.setDimensions(self.container);

				self.container.zoomer({
					controls: {
						zoomIn: '.infographic-zoom-icon-zoom-in',
						zoomOut: '.infographic-zoom-icon-zoom-out'
					},
					increment: 0.05,
					marginMin: 0,
					marginMax: 0
				});

			});

		};

		// get the dimensions and save them in the dimensions obj
		self.getDimensions = function(el){
			self.dimensions.width = $(el).parents('div').outerWidth();
			self.dimensions.height = $(el).parents('div').outerHeight();
		}

		// set the dimensions on the zoom container 
		self.setDimensions = function(el){

			self.getDimensions(el);

			self.container.css({
				'height' : self.dimensions.height,
				'width': self.dimensions.width
			});

		}

		self.init();

	};

})(jQuery);
