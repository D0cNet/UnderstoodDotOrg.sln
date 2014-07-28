(function() {
    //Reminder: the last element can't have a comma at the end!
    //Learn more about how to help your child
    DysgraphiaGameConfig = {
        timeInSeconds: 90,
        introDurationInSeconds: 0, //0=open until closed
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
                en: 'Through Your Child\'s Eyes: <b>Writing Issues</b>',
              es: 'A través de los ojos de suh hijo: <b>Dificultades con la escritura</b>'
            },
            standaloneText: {
                en: [
                    'Why is writing so difficult for some kids, no matter how hard they try?', 
                    'This game should give you a sense of what it feels like when your hand won’t write what your brain is telling it to write.'
                ].join('<pbr>'),
               es: [
                    '¿Por qué es tan difícil la escritura para algunos niños, sin importar cuánto se esfuercen?', 
                    'Este juego le debe de dar una idea de lo que se siente cuando su mano no escribe lo que su cerebro le dicta.'
                ].join('<pbr>')
            },
            gameTitle: {
                en: 'Typing Test',
              es: 'Prueba de tecleado'
            },
            gameText: {
                en: 'Type exactly what you see. Be sure to fix mistakes. Ready?',
              es: 'Teclee exactamente lo que ve. Asegúrese de corregir los errores. ¿Preparado?'
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
                en: 'Through Your Child\'s Eyes: <b>Writing Issues</b>',
              es: 'A través de los ojos de suh hijo: <b>Dificultades con la escritura</b>'
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
                    'Was that frustrating? Even though you knew what to write, you couldn’t get it out correctly.<br/><br/>Children who have writing issues deal with this daily.', 
                    'How would you feel if you experienced this frustration every day and nobody seemed to understand why?',
					'Kids won’t outgrow a writing issue. But you can help your child develop strategies to make writing easier.'

                ].join('<pbr>'),
              es: [
                    '¿Eso fue frustrante? Aún cuando sabía qué escribir no lo pudo hacer de manera correcta.',
                     'Los niños que tienen dificultades con la escritura se enfrentan a esto todos los días.', 
                    '¿Cómo se sentiría si usted experimentara esta frustración todos los días y nadie pareciera entender por qué?',
					'Los niños no superan las dificultades con la escritura. Pero usted puede ayudar a su hijo a desarrollar estrategias para hacer la escritura más fácil.'

                ].join('<pbr>')
            }
        },
        maxLength: {
            phone: 48,
            tablet: 74,
            desktop: 96
        },
        tweaks: {
            initial: [
                //Ranges in which a replacement happens
                [6,10],
                [12,16],
                [20,25]
            ],
            chances: [
                //lv1 (special)
                {},
                //lv2
                {
                    replaceRandomly: 7,
                    extraRandom: 0,
                    ignoreInput: 6,
                    changeCaps: 0,
                    repeatCharacters: 0
                },
                //lv3
                {
                    replaceRandomly: 5,
                    extraRandom: 2,
                    ignoreInput: 2,
                    changeCaps: 2,
                    repeatCharacters: 4
                },
                //lv4
                {
                    replaceRandomly: 0,
                    extraRandom: 0,
                    ignoreInput: 20,
                    changeCaps: 0,
                    repeatCharacters: 20
                },
                //lv5
                {
                    replaceRandomly: 2,
                    extraRandom: 2,
                    ignoreInput: 2,
                    changeCaps: 35,
                    repeatCharacters: 4

                },
              //lv6
                {
                    replaceRandomly: 11,
                    extraRandom: 7,
                    ignoreInput: 11,
                    changeCaps: 4,
                    repeatCharacters: 7                }
            ],
                
            rules: {
                repeatCharacters: {
                    countMin: 2,
                    countMax: 2
                }
            }
        },
        prompts: {
            en: [
                //lv1
                [
                'Everyone was waiting for the day.',
                'They had a party in the backyard.',
                'It was a hot day with a breeze.',
                'This story was about two friends.'

                ],
                //lv2
                [
                    'His little boy was born on a Wednesday.',
                    'Their friends brought a watermelon.',
                    'The family drove to the seashore.',
                    'The girl was a budding ballroom dancer.'
                ], 
               
                //lv3
                [
                    'The baby\'s sisters were totally ecstatic.',
                    'Twenty-five people came to celebrate.',
                    'Their cones dripped vanilla ice cream.',
                    'She was always practicing fancy steps.'
                ], 
                //lv4
                [
                    'They wanted to celebrate with balloons.',
                    'Emma was excited. It was her tenth birthday.',
                    'Madeline found seashells. She kept one.',
                    'The boy liked adventure. He had a boat.'
                ],
                //lv5
                [
                    'The cousins came too. They brought gifts.',
                    'Suddenly, everyone stopped and looked over.',
                    'They agreed all together to look for crabs.',
                    'Their cat\'s name was hard to pronounce.'
                ],
                //lv6
                [
                    'The aunts performed quick waltzes and jigs.',
                    'Chrissie was doing cartwheels across the grass.',
                    'Instead, they built an enormous sandcastle.',
                    'Together, the three of them traveled due north.'
                ]
            ],
            es: [
                //lv1
                [
                  'El tomate es un fruto.',
'A Elena le gusta anotar goles.',
'El tren de mi padre llega a las seis.',
'Me gustan los perros y los gatos.',

                ],
                //lv2
                [
                  'La ardilla trepa por el tronco.',         
'Los domingos juegan a la pelota.',
'Todos fueron a la playa de vacaciones.',                  
   'Todos mis amigos tienen mascotas.',               
                ], 
                //lv3
                [
                  'La planta tiene hojas grandes.',
                  'Todos juntos se fueron al parque.',
'Mis vecinos tomaron el tren cerca de su casa.',                  
'Mi madre me lleva los domingos al parque.',
                ], 
                //lv4
                [
                  'El cuadrado tiene cuatro lados.',
                  'Juan sale en su bicicleta por las tardes.',
                  'Los sobrinos de Sonia pidieron sentarse juntos.',
'Puedo tener un perro si yo lo saco a pasear.',
                ],
                //lv5
                [
                    'Los almendros no florecen en abril.',
                  'Lorena fue a encontrarse con sus amigas.',
                  'Estuvieron jugando a las cartas todo el viaje.',
                  'Todos fueron a la fiesta menos mi hermana.',
                ],
                 //lv6
                [
                    'Los almendros florecen en el invierno.',
                  'Los osos polares viven en el Polo Norte.',
                  'Mis primos, Beto y Boby, se va de vacaciones.',
                  'Mi hermano mayor juega al Monopolio conmigo.',
                ]
            ]
        }
    };
})();
                