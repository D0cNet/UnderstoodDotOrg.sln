(function($){

  $(document).ready(function() {
      new U.decisionQuiz();

      var $hfAnswerIndex = $(".hfAnswerIndex");
      var $nextQuestion = $(".next-question");

      var $answerWrapper = $(".answer-wrapper");
      var $answerControl = $answerWrapper.find("button, input[type='radio']");

      $answerControl.on("click", function () {
          var $this = $(this);
          $hfAnswerIndex.val($this.attr("data-answer-index"));
          $answerWrapper.hide();
          $("." + $this.attr("data-indication-answer-id")).show();
          $nextQuestion.show();
      });
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


