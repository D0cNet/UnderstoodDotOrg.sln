require(["jasmineEnv", "/-/speak/v1/controls/ProgressIndicator.js"], function (jasmineEnv) {

  var setupTests = function () {
    var descriptor = {
      attributes: [
        { name: "targetControl", defaultValue: "", which: "which indicator the control to overlay" },
        { name: "isBusy", defaultValue: false, which: "which indicates if the progress indicator is visible or not" },
        { name: "isFullscreen", defaultValue: false, which: "which covers the whole screen" },
        { name: "delay", defaultValue: 200, which: "which contains the number of milliseconds before the indicator appears" },
        { name: "width", defaultValue: 0, which: "which holds the width" },
        { name: "height", defaultValue: 0, which: "which holds the height" },
        { name: "left", defaultValue: 0, which: "which holds the left position" },
        { name: "position", defaultValue: 0, which: "which holds the position" },
        { name: "top", defaultValue: 0, which: "which holds the top position" }
      ]
    };

    runComponentTests("ProgressIndicator", descriptor, "Control1");
  };
  
  runTests(jasmineEnv, setupTests);
});