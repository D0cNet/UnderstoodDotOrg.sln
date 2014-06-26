(function() {
    //Reminder: the last element can't have a comma at the end!
    ExecutiveGameConfig = {
        timeInSeconds: 140,
        introDurationInSeconds: 0, //0=open until closed
        introText: [
            'Catch the falling shapes in the bucket. Click once in any column to move the bucket there. Ready?'
        ].join("\n"),
        finalText: [
            'Time\'s up!'
        ].join("\n"),
        title: {
            en: 'Catch Up'
        },
        ruleChangePauseInSeconds: 2,
        resourcePath: '/img/simulations/executive/desktop',
        maxQueue: 2,
        promptDuration: 2000,
        trap: {
            moveCapturePadding: 50, //How tolerant our hover area should be to move the trap
            touchOverlapNeeded: 5,
            clickReactionSpeed: 3500 //How fast the trap moves when in click UI (higher == slower)
        },
        channelText: {
            startBelow: 0,
            endAbove: 75,
            moveDuration: 500,
            pauseBeforeRemoval: 100,
            copy: {
                en: {
                    right: 'Okay.',
                    wrong: 'Wrong!',
                    miss: 'Miss!'
                }
            }
        },
        errorShakeConfig: {
            amount: 10,
            times: 2,
            stayRedDuration: 200,
            fadeBackDuration: 400
        },
        ballBounceConfig: {
            horizontalDistance: 100,
            rotationAmount: 180,
            duration: 500,
            verticalHeightMultiplier: 1.25 //this * height of ball = vertical height, <1.5 looks weird
        },
        trapFade: {
            red: {
                fadeIn: 0,
                pause: 500,
                fadeOut: 500
            },
            green: {
                fadeIn: 500,
                pause: 0,
                fadeOut: 500
            }
        },
        rules: {
            rates: [
                //Start/stop in seconds, rate in time between drops in milliseconds
                //Overlaps will choose the rate that started latest
                //  bigger == slower
                
                { start: 0, stop: 2, rate: [ 5000, 6000 ] },
                { start: 3, stop: 7, rate: [ 3000, 4000 ] },
                { start: 8, stop: 19, rate: [ 2500, 3500 ] },
                { start: 20, stop: 39, rate: [ 500, 4000 ] },
                { start: 40, stop: 59, rate: [ 400, 3500 ] },
                { start: 60, stop: 74, rate: [ 300, 3000 ] },
                { start: 75, stop: 84, rate: [ 300, 2000 ] },
                { start: 85, stop: 140, rate: [ 200, 1000 ] },
                 
            ],
            speeds: [
                //Start/stop in seconds, speed range in ms to cross the screen
                //Overlaps will choose the speed that started latest
                // bigger == slower
                { start: 0, stop: 2, speed: [  8000, 8000 ] },
                { start: 3, stop: 12, speed: [ 8000, 10000 ] },
                { start: 13, stop: 19, speed: [ 6000, 9000 ] },
                { start: 20, stop: 39, speed: [ 5500, 8000 ] },
                { start: 40, stop: 59, speed: [ 5000, 7000 ] },
                { start: 60, stop: 140, speed: [ 4500, 6500 ] }
              
            ],
            drops: [
                //Start/stop in seconds, weight is relative chance to drop when active
                //All balls active in a range will be placed in a pool for drop randomization at each tick.
                //IDs are required and must be unique
                { id: 'circle', start: 0, stop: 9, cls: 'executive_circle', radius: [40,25], weight: 1, sprites: [0,1,2] },
                { id: 'circle', start: 10, stop: 140, cls: 'executive_circle', radius: [40,25], weight: 1, sprites: [0,1,2] },
                { id: 'square', start: 12, stop: 140, cls: 'executive_square', radius: [40,25], weight: 1, sprites: [0,1,2] },
                { id: 'triangle', start: 38, stop: 140, cls: 'executive_triangle', radius: [40,25], weight: 1, sprites: [0,1,2] },
                { id: 'heart', start: 64, stop: 140, cls: 'executive_star', radius: [48,30], weight: 1, sprites: [0,1,2] },
            ],
            scoring: [
                //Start/stop in seconds - overlaps could be ugly.
                //promptMethod is either "random" or "both", defaults to "random" (meaning just text, just audio, or both)
                { start: 0, stop: 19, valid: [ 'circle', 'square' ],
                    text: {
                        en: 'Are you ready? Use the bucket to catch the falling shapes',
                        es: 'Está Listo? Use el cubo para atrapar las formas que caen…'
                    }, audio: 'catchAllShapes', promptMethod: 'both' },
                { start: 20, stop: 34, valid: [ 'circle' ],
                    text: {
                        en: 'Now catch only circles',
                        es: 'Ahora atrape sólo círculos'
                    }, audio: 'catchOnlyCircles', promptMethod: 'both' },
                { start: 35, stop: 44, valid: [ 'square' ],
                    text: {
                        en: 'Now catch only squares',
 es: 'Ahora atrape sólo cuadrados'
                    }, audio: 'catchOnlySquares', promptMethod: 'both' },
                { start: 45, stop: 59, valid: [ 'circle', 'square' ],
                    text: {
                        en: 'Catch circles and squares',
 es: 'Atrape círculos y cuadrados'
                    }, audio: 'catchOnlyCirclesAndSquares', promptMethod: 'both' },
                { start: 60, stop: 69, valid: [ 'triangle', 'circle' ],
                    text: {
                        en: 'Catch circles and triangles',
 es: 'Atrape círculos y triángulos'
                    }, audio: 'catchOnlyCirclesAndTriangles', promptMethod: 'both' },
                { start: 70, stop: 79, valid: [ 'square', 'circle' ],
                    text: {
                        en: 'Catch circles and squares',
 es: 'Atrape círculos y cuadrados'
                    }, audio: 'catchOnlyCirclesAndSquares', promptMethod: 'both' },
                { start: 80, stop: 89, valid: [ 'triangle' ],
                    text: {
                        en: 'Now catch only triangles',
 es: 'Ahora atrape sólo triángulos'
                    }, audio: 'catchOnlyTriangles', promptMethod: 'both' },
                { start: 90, stop: 94, valid: [ 'triangle', 'circle', 'square', 'star' ],
                    text: {
                        en: 'Now catch everything',
 es: 'Ahora atrape todo'
                    }, audio: 'catchEverything', promptMethod: 'both' },
                { start: 95, stop: 99, valid: [ ], 
                    text: {
                        en: 'Now avoid everything',
 es: 'Ahora evite atrapar algo'
                    }, audio: 'avoidEverything', promptMethod: 'both' },
                { start: 100, stop: 104, valid: [ 'circle' ], 
                    text: {
                        en: 'Now catch only circles',
 es: 'Ahora atrape sólo círculos'
                    }, audio: 'catchOnlyCircles', promptMethod: 'both' },
                { start: 105, stop: 114, valid: [ 'square' ], 
                    text: {
                        en: 'Now catch only squares',
 es: 'Ahora atrape sólo cuadrados'
                    }, audio: 'catchOnlySquares', promptMethod: 'both' },
                { start: 115, stop: 140, valid: [ 'triangle' ], everyOther: true, 
                    text: {
                        en: 'Catch every other triangle',
 es: 'Atrape un triángulo si y uno no'
                    }, audio: 'catchEveryOtherTriangle', promptMethod: 'both' }
            ]
        }
    };
})();
                                                                                                                                                
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
                                                
                                                                                                                                                                                                
                                                                
                                
                
                
                                                                                                                                                                                                                                
                                                                                                                                
                                                                
