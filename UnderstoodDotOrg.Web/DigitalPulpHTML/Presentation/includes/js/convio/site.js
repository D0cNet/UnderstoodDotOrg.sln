var U = {};

/**
 * Sets the styling (adds/removes classes) for elements in uniform
 * Styling for selects
 */
U.uniformStyling = function () {

  //for select
  new U.keyboard_access({
    focusElements: 'select',
    blurElements: 'select',
    focusHandler: function(e) {
      var $current = $(e.currentTarget);
      $current.parent().addClass('focused');
    },
    blurHandler: function(e, newTarget) {
      var $current = $(e.currentTarget);
      $current.parent().removeClass('focused');
    }
  });

  new U.keyboard_access({
    focusElements: 'input[type=radio], input[type=checkbox]',
    blurElements: 'input[type=radio], input[type=checkbox]',
    forceBlur: true,
    focusHandler: function(e) {
      var $current = $(e.currentTarget);
      $current.parent().addClass('focused');
    },
    blurHandler: function(e, newTarget) {
      var $current = $(e.currentTarget);
      $current.parent().removeClass('focused');
    }
  });
};

$(document).ready(function() {

  new U.uniformStyling();

  // input placeholder fix for IE
  $('input:text').placeholder();
  $('textarea').placeholder();

  // event handler for FPO URLs to prevent navigating to 404s
  // FIXME: this is temporary and needs to be removed during integration
  jQuery('a[href=REPLACE]').on('click', function(){ return false; });

  
});



