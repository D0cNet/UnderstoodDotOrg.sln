(function() {
    //Reminder: the last element can't have a comma at the end!
    //
    //If you use an array for a property, a random value will be selected.  A static value will be used as-is.
    //Item name & color and coin color, value, and size arrays are lists of options and won't be duplicated 
    //Item value and coin count arrays are ranges and can be duplicated
  // old values: [1, 4, 9, 17]
    DyscalculiaGameConfig = {
        keyDisplayTimeInMilliseconds: 3000,
        warningDisplayTimeInMilliseconds: 1000,
        timeInSeconds: 90,
        itemSize: 50,
        permakey: true,
        resourcePath: '/games/dyscalculia/resources',
        introDurationInSeconds: 0, //0=open until closed
        coinUI: {
            desktop: {
                scatterGrid: [4,3], //[columns,rows]
                jumpDuration: 750,
                jumpFlips: 2,
                stopFlippingAt: 65//%
            },
            phone: {
                scatterGrid: [4,3], //[columns,rows]
                jumpDuration: 500,
                jumpFlips: 1,
                stopFlippingAt: 60//%
            }
        },
        spinnerDurationNormal: 1000,
        spinnerDurationBroken: 2000,
        feedbackSpeed: {
            correct: {
                text: [200, 300],//[button fade speed, text appear speed]
                color: [200, 1000, 500]//[to green speed, pause, to blue speed]
            },
            incorrect: {
                text: [0, 0],//[button fade speed, text appear speed]
                color: [1000, 500]//[pause, to blue speed] (red appears instantaneously)
            }
        },
        introText: [
            'Click on coins to pay for goodies. When you have the exact change, hit Buy.\n\nReady?'
        ].join("\n"),
         finalText: {
            onComplete: {
                en: 'Well done--you beat the clock!'
            },
            onTimeout: {
                en: [
                    'Time\'s up!'
                ].join("\n")
            }
        },
        title: {
            en: 'Exact Change'
        },
        noTallyText: 'Counter out of order!',
        penalties: {
            wrongAnswer: 5,
            showKey: 5
        },
        items: [
            {  // 7
                name: 'Apple',
                value: [7, 7],
                cls: 'apple',
                showTally: true
            }, { // 29 + 13
                name: 'Banana',
                value: [42, 42],
                cls: 'banana',
                showTally: true
            }, { // 7 + 13 + 29 + 34
                name: 'Milk',
                value: [83, 83],
                cls: 'milk',
                showTally: true
            }, { // 13 + 13 + 13 +7 + 29 + 34
                name: 'Pretzel',
                value: [109, 109],
                cls: 'pretzel',
                showTally: false
            }, { //7 + 13 + 13 + 13 +29 +29 + 34
                name: 'Ice cream',
                value: [138, 138],
                cls: 'icecream',
                showTally: false
            }
            //Also cherry
        ],
        maxCoinSize: 60,
        coins: [
            {
                value: [7, 13, 29, 34],
                cls: 'dime',
                count: 3
            },
            {
                value: [7, 13, 29, 34],
                cls: 'nickel',
                count: 3
            },
            {
                value: [7, 13, 29, 34],
                cls: 'penny',
                count: 3
            },
            {
                value: [7, 13, 29, 34],
                cls: 'quarter',
                count: 3
            }
        ]
    };
})();
                                
                
                                                
                                                                                                                                                                                                                                                                                
                                                
                                                                                
                                                                                                                                                                                                                                                                
