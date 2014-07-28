(function() {
    //Reminder: the last element can't have a comma at the end!
    DyslexiaGameConfig = {
        timeInSeconds: 75,
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
                en: 'Through Your Child\'s Eyes: <b>Reading Issues</b>',
               es: 'A través de los ojos de su hijo: <b>Dificultades con la lectura</b>'
            },
            standaloneText: {
                en: [
                    'Kids with reading issues often mix up the letters and words they’re trying to identify.<br/><br/>They have to work hard to sort out the confusion.',
                    'Play a game to see how this feels.'
                ].join('<pbr>'),
              es: [
                    'Los niños con dificultades con la lecura, a menudo mezclan las letras y las palabras que están tratando de identificar.',
                    'Ellos tienen que trabajar más para arreglar esa confusión.',
                    'Juegue este juego para que vea cómo se siente.'
                ].join('<pbr>')
              
            },
            gameTitle: {
                en: 'Scrambled Letters',
              es: 'Letras Revueltas'
            },
            gameText: {
                en: 'We\'ve switched some letters. Click to swap them back. Ready?',
              es: 'Cambiamos algunas letras. Haga clic sobre ellas para cambiarlas de vuelta.'
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
                en: 'Through Your Child\'s Eyes: <b>Reading Issues</b>',
              es: 'A través de los ojos de su hijo: <b>Dificultades con la lectura</b>'
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
                  'Confusing? That was the idea. Here’s why:',
                  'We switched some letters, so you had to slowly piece together the words by "decoding" them.',
                  'That’s what kids with reading issues experience every day. Imagine how frustrating this must feel.<br/><br/>But there is good news.',
				 'While kids won’t outgrow reading issues, you can work with your child to develop strategies that will help.'
                ].join('<pbr>'),
              es: [
                  '¿Confundido? Esa era la idea. Aquí está el porque.',
                  'Cambiamos algunas letras para que usted las "decodifique"  lentamente.',
                  'Eso es lo que los niños con dificultades con la lectura experimentan todos los días. Imagine la frustración que sienten.',
				  'Pero hay buenas noticias.',
                  'A pesar de que los niños no superan las dificultades con la lectura al crecer, usted puede trabajar con su hijo para que desarrolle estrategias que le ayudarán.'
                
                ].join('<pbr>')
            }
        },
        display: {
            letterStates: {
                unknown: {
                    backgroundColor: '#EBEBEB',
                    color: '#7A4182'
                },
                correct: {
                    backgroundColor: '#8FAD15',
                    color: '#FFFFFF',
                },
                wrong: {
                    backgroundColor: '#E84646',
                    color: '#FFFFFF',
                },
                hover: {
                    backgroundColor: '#7A4182',
                    color: '#FFFFFF',
                }
            },
            clickFadeInDuration: 250,
            sentenceDoneFadeDuration: 800,
            sentenceDonePauseDuration: 400
        },
        ignoredLetters: [], //Was i/o/h
        //CAREFUL OF TRAILING COMMAS!!!
        sentences: {
            en: [
                //Batch 1
                [{
                    text: 'I have a dog and his name is Mutt.',
                    rules: {
                        e: 'a'
                    }
                }, {
                    text: 'My young son has been waiting.',
                    rules: {
                        e: 'a',
                        w: 'm'
                    }
                }, {
                    text: 'Will you pass the butter, please?',
                    rules: {
                        u: 'n',
                        ease: 'ees',
                        p: 'b',
                        t: 'l'
                    }
                }, {
                    text: 'Where did you put my funny picture?',
                    rules: {
                        n: 'u',
                        q: 'p',
                        were: 'where',
                        b: 'd'
                    }
                }, {
                    text: 'Go through the second door from the right.',
                    rules: {
                        u: 'ou',
                        from: 'for',
                        f: 'gh',
                        b: 'd'
                    }
                }, {
                    text: 'We’ll play in the middle with Maggie.',
                    rules: {
                        m: 'w',
                        i: 'l',
                        b: 'p',
                        q: 'g'
                    }
                }],
                //Batch 2
                [{
                    text: 'The boy was one of five sons.',
                    rules: {
                        a: 'o'
                    }
                }, {
                    text: 'My mom is the best and my dad is too.',
                    rules: {
                        w: 'm',
                        a: 'e',
                        d: 'b'
                    }
                }, {
                    text: 'My big girl is getting her gold star.',
                    rules: {
                        q: 'g',
                        her: 'his',
                        l: 't',
                        d: 'b'
                    }
                }, {
                    text: 'He played happily with his dog.',
                    rules: {
                        b: 'h',
                        when: 'with',
                        d: 'p',
                        o: 'e'
                    }
                }, {
                    text: 'The middle child lay down to sleep.',
                    rules: {
                        b: 'd',
                        l: 'i',
                        o: 'e'
                    }
                } , {
                    text: 'The snow will melt when the sun shines.',
                    rules: {                    
                        l: 'i',
                        m: 'w',
                        u: 'n',
                        z: 's'
                    }
                }],
               //Batch 3
                [{
                    text: 'The boy had two big dogs.',
                    rules: {
                        a: 'o'
                    }
                }, {
                    text: 'She plays well with her sister.',
                    rules: {
                        z: 's',
                        o: 'e' ,
                      m: 'w' 
                    }
                }, {
                    text: 'Did you pass the cheese?',
                    rules: {
                        i: 't',
                        e: 'a',
                        b: 'p',
                        u: 'ou'
                    }
                }, {
                    text: 'That was a very special day for me.',
                    rules: {
                        from: 'for',
                        is: 'was',
                        e: 'a'
                    }
                }, {
                    text: 'How did you make the cake so good?',
                    rules: {
                        o: 'a',
                        h: 'k',
                        b: 'd'
                    }
                }, {
                    text: 'Two happy pups played in the park today.',
                    rules: {
                        b: 'p',
                        t: 'l',
                        too: 'two',
                        g: 'y'
                    }
                }],
                //Batch 4
                [{
                    text: 'He saw a big brown bear.',
                    rules: {
                        e: 'a'
                    }
                }, {
                    text: 'This is Phil’s sunny phase.',
                    rules: {
                      f: 'ph',
                        n: 'u',
                        l: 'i'
                    }
                }, {
                    text: 'Where in the world is she now?',
                    rules: {
                        a: 'o',
                        the: 'then',
                        is: 'as',
                        w: 'm'
                    }
                }, {
                    text: 'We thought the day would be wet.',
                    rules: {
                        o: 'ou',
                        i: 't',
                        ld: 'd',
                        m: 'w'
                    }
                }, {
                    text: 'It was in the middle of the night.',
                    rules: {
                        t: 'i',
                        p: 'd',
                        of: 'for',
                        b: 'h'
                    }
                }, {
                    text: 'I really like the color blue best of all.',
                    rules: {
                        t: 'l',
                        p: 'b',
                        o: 'e'
                    }
                }]
            ],
              
              es: [
                //Batch 1
                [{
                    text: 'La nena sabe cuando es de noche.',
                    rules: {
                        u: 'n'
                    }
                }, {
                    text: 'El pan y el queso saben muy bien.',
                    rules: {
                        u: 'o',
                        b: 'd',
                        s: 'c',
                        ta: 'at'
                    }
                }, {
                    text: 'El gato brinca asustado cuando silbo.',
                    rules: {
                      u: 'o',
                        b: 'd',
                        s: 'c',
                        ta: 'at'
                        
                    }
                }, {
                    text: 'Mi madre se puso mal por tanto dulce.',
                    rules: {
						i: 'l',
                        t: 'p',
                        u: 'o',
                        mad: 'dam'
                    }
                }, {
                    text: 'El ciclista siempre debe usar casco.',
                    rules: {
                        l: 'm',
                        i: 'o',
                        de: 'pe',
                        usar: 'rusa'
                    }
                }, {
                    text: 'Los tulipanes son de Holanda.',
                    rules: {
                        i: 'o',
                        l: 'd',
                        es: 'se',
                        an: 'na'
                    }
                }],
                //Batch 2
                [{
                    text: 'Mi hijo no se va a la cama.',
                    rules: {
                        a: 'e'
                    }
                }, {
                    text: 'En la escuela juego al gato.',
                    rules: {
                        g: 'p',
                        a: 'o',
                        u: 'n'
                    }
                }, {
                    text: 'Laura pide la bola y es la que anota.',
                    rules: {
                        i: 'u',
                        p: 'd',
                        se: 'es',
                        la: 'al'
                    }
                }, {
                    text: 'Le gusta jugar a la pelota, y la bota bien.',
                    rules: {
                        a: 'e',
                        b: 'p',
                        o: 'i',
                        gus: 'sug'
                    }
                }, {
                    text: 'El padre le pide a su hijo que estudie.',
                    rules: {
                        e: 'c',
                        p: 'b',
                        u: 'a',
                      hijo:'jiho'
                    }
                } , {
                    text: 'David tiene la cabeza rasurada.',
                    rules: {                    
                        a: 'o',
                        r: 'd',
                        b: 'z',
                        tiene: 'netie'
                    }
                }],
               //Batch 3
                [{
                    text: 'Nunca corro por la noche.',
                    rules: {
                        u: 'n'
                    }
                }, {
                    text: 'Don Daniel es el nuevo zapatero.',
                    rules: {
                        b: 'd',
                        e: 'a' ,
                      s: 'z' 
                    }
                }, {
                    text: 'Marta sube de a dos escalones a la vez.',
                    rules: {
                        a: 'o',
                        u: 'n',
                        b: 'd',
                        ez: 'ze'
                    }
                }, {
                    text: 'Mi prima Irene no se pone los zapatos.',
                    rules: {
                        i: 'a',
                        m: 'z',
                        n: 'p',
                      los: 'sol'
                    }
                }, {
                    text: 'Mario quiere una casa nueva.',
                    rules: {
                        m: 'q',
                        i: 'e',
                        un: 'nu',
                        casa: 'saca'
                    }
                }, {
                    text: '¿Disculpe, la cocina sigue abierta?',
                    rules: {
                        d: 'q',
                        abierta: 'tabiera',
                        s: 'z'
                    }
                }],
                //Batch 4
                [{
                    text: 'Mi abuela me quiere mucho.',
                    rules: {
                        e: 'a'
                    }
                }, {
                    text: 'El nene se parece al padre.',
                    rules: {
                      e: 'a',
                        g: 'p',
                        s: 'z'
                    }
                }, {
                    text: 'Tres tristes tigres comen trigo.',
                    rules: {
                        tri: 'rit',
                        es: 'se',
                        g: 'b'
                    }
                }, {
                    text: 'Liliana busca su punto en el juego.',
                    rules: {
                        b: 'p',
                        q: 'g',
                        u: 'o',
                        lili: 'illi'
                    }
                }, {
                    text: 'Jugamos a los quemados en la fiesta.',
                    rule: {
                        j: 'f',
                        g: 'd',
                        am: 'ma',
                        os: 'so'
                    }
                }, {
                    text: 'I really like the color blue best of all.',
                    rules: {
                        t: 'l',
                        p: 'b',
                        o: 'e'
                    }
                }]
            ]
        }
    };
})();
                
                                                                
                                                
                                                                                                                                                                                                                                                                                                                
                                 
                                                                                                                                                                                