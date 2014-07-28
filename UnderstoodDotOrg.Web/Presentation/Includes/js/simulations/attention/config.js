(function() {
    //Reminder: the last element can't have a comma at the end!
    AttentionGameConfig = {
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
                en: 'Through Your Child\'s Eyes: <b>Attention Issues</b>',
              es: 'A través de los ojos de su hijo: <b>Dificultades de atención</b>'
            },
            standaloneText: {
                en: [
                    'Why do some kids have so much trouble staying focused?',
                    'This game should give you a sense of what it feels like to have attention issues.<br/><br/>(Please turn on your sound/use headphones.)'
                ].join('<pbr>'),
                es: [
                    '¿Por qué algunos niños tienen muchos problemas manteniéndose enfocados?',
                    'Este juego le debe de dar una idea de cómo se siente si tuviera una dificultad de atención.<br/><br/>(Por favor active el sonido/use audífonos.)'
                ].join('<pbr>')
              
              
              
            },
            gameTitle: {
                en: 'What a Zoo!',
              es: '¡Qué zoológico!'
            },
            gameText: {
                en: 'Follow the teacher’s instructions. (Sound required.) Ready?',
              es: 'Siga las instrucciones de la maestra. ¿Preparados?'
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
                en: 'Through Your Child\'s Eyes: <b>Attention Issues</b>',
              es: 'A través de los ojos de su hijo: <b>Dificultades de atención</b>'
            },
            gameText: {
                success: {
                    en: "Did you see the elephants?",
                  es: "¿Vieron los elefantes?"
                }
                //No failure here...
            },
            standaloneText: {
                                en: [
                    'How did it go? Not being able to filter out the distractions probably made it really hard to follow the teacher’s instructions.',
                  'Even though you wanted to follow them, you couldn’t focus on what the teacher was saying. That made it tough to complete the task.',
                  'Children and teens with attention issues experience this every single day—no matter how hard they try. Imagine how frustrating that can feel.',
				'The good news? You can work with your child to develop strategies that can help.'
                ].join('<pbr>'),
              
               es: [
                    '¿Cómo le fue? El no poder filtrar las distracciones, probablemente le hizo muy difícil el poder seguir las instrucciones de la maestra. Y complicó el poder completar la tarea.',
                  'Aún cuando usted quería seguir las instrucciones, no se pudo enfocar en lo que la maestra decía. Eso le complicó el poder completar la tarea.',
                  'Los niños y los preadolescentes con dificultades de atención pasan por esto todos los días–no importa cuánto se esfuercen. Imagine lo frustrados que se deben de sentir.',
				'¿Las buenas noticias? Puede trabajar con su hijo para desarrollar las estrategias que necesita.'
                ].join('<pbr>')
            }
        },
        timeInSeconds: 90,
        introDurationInSeconds: 0, //0=open until closed
        instructionLength: {
            en: 95,
            es: 94
        },
        timing: {
            pauseBeforeInstructions: 1000,
            pauseBeforeStopDialog: 5000
        }
    };
})();

                                
                
                                                                                                                
                                                                                                                                                                                                