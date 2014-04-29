(function($){

  $(document).ready(function() {
    new U.decisionQuiz();
  });

  U.decisionQuiz = function() {
    var self = this;

    self.init = function() {
      var uniform_elements = $('.dl-quiz input[type=radio]');

      uniform_elements.uniform();
    };

    self.init();
  };


})(jQuery);


