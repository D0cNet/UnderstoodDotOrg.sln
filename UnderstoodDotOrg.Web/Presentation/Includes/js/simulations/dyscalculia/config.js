(function() {
    //Reminder: the last element can't have a comma at the end!
    //
    //If you use an array for a property, a random value will be selected.  A static value will be used as-is.
    //Item name & color and coin color, value, and size arrays are lists of options and won't be duplicated 
    //Item value and coin count arrays are ranges and can be duplicated
  // old values: [1, 4, 9, 17]
    DyscalculiaGameConfig = {
        intro: {
            buttons: {
                go: {
                    en: 'Start',
                  es: 'Comenzar'
                },
                next: {
                    en: 'Next',
                  es: 'Próximo'
                }
            },
            standaloneTitle: {
                en: 'Through Your Child\'s Eyes: <b>Math Issues</b>',
                es: 'A través de los ojos de su hijo: <b>Dificultades con las matemáticas</b>'
            },
            standaloneText: {
                en: [
                    'Have you ever wondered why it’s so hard for some kids to work with numbers?',
                    'Try this game to see what it feels like when you have to rely on memory instead of a solid understanding of math.'
                ].join('<pbr>'),
              
              es: ['¿Se ha preguntado alguna vez por qué es tan difícil para algunos niños trabajar con números?',
                   'Pruebe este juego para ver cómo se siente tener que depender de la memoria en lugar de su entendimiento sólido de las matemáticas.'
                   ].join('<pbr>')
            },
            gameTitle: {
                en: 'Exact Change',
              es: 'Cambio Exacto'
            },
            gameText: {
                en: 'Click on coins to pay for goodies. When you have the exact change, hit Buy.\n\nReady?',
                es: 'Haga clic en las monedas para pagar. Cuando tenga el cambio exacto, haga click en Comprar.\n\n¿Preparado?'
            }
        },
        outro: {
            buttons: {
                restart: {
                    en: 'Try again',
                  es: 'Intente de nuevo'
                },
                continue: {
                    en: 'Continue',
              es: 'Continuar'
                },
                next: {
                    en: 'Next',
                  es: 'Próximo',
                },
                learn: {
                    en: 'Learn How',
                  es: 'Aprenda cómo'
                },
                beginning: {
                    en: 'Go back to the beginning',
                  es: 'O vuelva al principio'
                }
            },
            standaloneLinks: {
                learn: 'http://wolframalpha.com',
                beginning: 'http://archive.org'
            },
            standaloneTitle: {
                en: 'Through Your Child\'s Eyes: <b>Math Issues</b>',
              	es: 'A través de los ojos de su hijo: <b>Dificultades con las matemáticas</b>'
            },
            gameText: {
                success: {
                    en: 'Well done—you beat the clock!',
                  es: '¡Bien hecho-venció al reloj!'
                },
                failure: {
                    en: 'Time\'s up!',
                  es: '¡Se acabó el tiempo!'
                }
            },
            standaloneText: {
                en: [
                  'You probably just experienced what kids with math issues feel every day: confusion and frustration. Here\'s why:',
                    'The coins didn’t have the “right” values, so you had to calculate each purchase instead of being able to select the coins automatically.',
                    'That’s how having a math issue can feel for a child or teen. And just when kids get the hang of it, the tasks get harder.',
                    'Children don’t grow out of math issues. But here’s the good news: you can work with your child to develop strategies that will help.'

                ].join('<pbr>')
              ,
              es: [
                'Probablemente acaba de experimentar lo que los niños con dificultades con las matemáticas siente todos los días: confusión y frustración. Aquí está el porque.',
                'Las monedas no tenían los valores "correctos", así que usted tuvo que calcular cada compra en lugar de seleccionar las monedas de manera automática.',
                'Así es como se sienten los niños y preadolescentes que tienen una dificultad con las matemáticas. Y cuando ellos creen que lo están dominando, la tarea se vuelve más difícil.',
                'Los niños no superan las dificultades con las matemáticas cuando crecen. Pero hay buenas noticias: usted puede trabajar con su hijo para que desarrolle estrategias que le ayudarán.'
                ].join('<pbr>')
            }
        },
        keyDisplayTimeInMilliseconds: 3000,
        warningDisplayTimeInMilliseconds: 1000,
        timeInSeconds: 90,
        itemSize: 50,
        permakey: true,
        introDurationInSeconds: 0, //0=open until closed
        uiCopy: {
            buy: {
                en: 'Buy',
                es: 'Comprar'
            },
            key: {
                en: 'Key',
                  es: ' '
            },
            trayTitle: {
                en: 'Coin Tray',
                  es: 'Monedero'
            },
            trayDesc: {
                desktop: {
                    en: 'Click coins to move them',
                      es: 'Haga clic en las monedas para moverlas'
                },
                tablet: {
                    en: 'Tap coins to move them',
                      es: 'Haga clic en las monedas para moverlas'
                },
                phone: {
                    en: 'Tap coins to move them',
                      es: 'Haga clic en las monedas para moverlas'
                }
            }
        },
        coinUI: {
            desktop: {
                scatterGrid: [4,3], //[columns,rows]
                jumpDuration: 750,
                jumpFlips: 2,
                stopFlippingAt: 65,//%
                scatterAmount: 0.07,
                padding: 0.0
            },
            phone: {
                scatterGrid: [4,3], //[columns,rows]
                jumpDuration: 500,
                jumpFlips: 1,
                stopFlippingAt: 60,//%
                scatterAmount: 0.01,
                padding: -0.05
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
        noTallyText: 'Counter out of order!',
        penalties: {
            wrongAnswer: 5,
            showKey: 5
        },
        items: [
            {  // 7
                name: {
                    en: 'Apple',
                    es: 'Manzana'
                },
                value: [7, 7],
                cls: 'apple',
                showTally: true
            }, { // 29 + 13
                name: {
                    en: 'Banana',
                    es: 'Plátano'
                },
                value: [42, 42],
                cls: 'banana',
                showTally: true
            }, { // 7 + 13 + 29 + 34
                name: {
                    en: 'Milk',
                    es: 'Leche'
                },
                value: [83, 83],
                cls: 'milk',
                showTally: true
            }, { // 13 + 13 + 13 +7 + 29 + 34
                name: {
                    en: 'Pretzel',
                    es: 'Pretzel'
                },
                value: [109, 109],
                cls: 'pretzel',
                showTally: false
            }, { //7 + 13 + 13 + 13 +29 +29 + 34
                name: {
                    en: 'Ice cream',
                    es: 'Helado'
                },
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
                                                                                                
                                                                                                                                
                