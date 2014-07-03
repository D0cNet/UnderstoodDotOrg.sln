(function() {
    //Reminder: the last element can't have a comma at the end!
    AttentionGameConfig = {
        intro: {
            buttons: {
                go: {
                    en: 'Begin'
                },
                next: {
                    en: 'Next'
                }
            },
            standaloneTitle: {
                en: 'Through Your Child\'s Eyes: <b>Attention Issues</b>'
            },
            standaloneText: {
                en: [
                    'Why do some kids have so much trouble staying focused?',
                    'This game should give you a sense of what it feels like to have attention issues.<br/><br/>(Please turn on your sound/use headphones.)'
                ].join('<pbr>')
            },
            gameTitle: {
                en: 'What a Zoo!'
            },
            gameText: {
                en: 'Follow the teacher’s instructions. (Sound required.) Ready?'
            }
        },
        outro: {
            buttons: {
                restart: {
                    en: 'Try again'
                },
                continue: {
                    en: 'Continue'
                },
                next: {
                    en: 'Next'
                },
                learn: {
                    en: 'Learn How'
                },
                beginning: {
                    en: 'Go back to the beginning'
                }
            },
            standaloneLinks: {
                learn: 'http://wolframalpha.com',
                beginning: 'http://archive.org'
            },
            standaloneTitle: {
                en: 'Through Your Child\'s Eyes: <b>Attention Issues</b>'
            },
            gameText: {
                success: {
                    en: "Did you see the elephants?"
                }
                //No failure here...
            },
            standaloneText: {
                                en: [
                    'How did it go? Not being able to filter out the distractions probably made it really hard to follow the teacher’s instructions.',
                  'Even though you wanted to follow them, you couldn’t focus on what the teacher was saying. That made it tough to complete the task.',
                  'Children and teens with attention issues experience this every single day—no matter how hard they try. Imagine how frustrating that can feel.',
				'The good news? You can work with your child to develop strategies that can help.'
                ].join('<pbr>')
            }
        },
        timeInSeconds: 90,
        introDurationInSeconds: 0, //0=open until closed
        instructionLength: {
            en: 99
        },
        timing: {
            pauseBeforeInstructions: 1000,
            pauseBeforeStopDialog: 2000
        }
    };
})();

                                
                
                                                                                                                
