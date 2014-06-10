require(["jasmineEnv", "/-/speak/v1/controls/panel.js"], function (jasmineEnv) {

  var setupTests = function () {
    var descriptor = {
      attributes: [
      ]
    };

    runComponentTests("Panel", descriptor, "Control1");
  };
  
  runTests(jasmineEnv, setupTests);
});