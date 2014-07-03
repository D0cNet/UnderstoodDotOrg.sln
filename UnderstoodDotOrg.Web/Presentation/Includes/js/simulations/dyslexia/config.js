(function() {
    //Reminder: the last element can't have a comma at the end!
    DyslexiaGameConfig = {
        timeInSeconds: 75,
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
                en: 'Through Your Child\'s Eyes: <b>Reading Issues</b>'
            },
            standaloneText: {
                en: [
                    'Kids with reading issues often mix up the letters and words they’re trying to identify.<br/><br/>They have to work hard to sort out the confusion.',
                    'Play a game to see how this feels.'
                ].join('<pbr>')
            },
            gameTitle: {
                en: 'Scrambled Letters'
            },
            gameText: {
                en: 'We\'ve switched some letters. Click to swap them back. Ready?'
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
                en: 'Through Your Child\'s Eyes: <b>Reading Issues</b>'
            },
            gameText: {
                success: {
                    en: 'Well done—you beat the clock!'
                },
                failure: {
                    en: 'Time\'s up!'
                }
            },
            standaloneText: {
                en: [
                  'Confusing? That was the idea. Here’s why:',
                  'We switched some letters, so you had to slowly piece together the words by "decoding" them.',
                  'That’s what kids with reading issues experience every day. Imagine how frustrating this must feel.<br/><br/>But there is good news.',
				 'While kids won’t outgrow reading issues, you can work with your child to develop strategies that will help.'
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
        ignoredLetters: ['i', 'o', 'h'],
        //CAREFUL OF TRAILING COMMAS!!!
        sentences: [
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
                    w: 'm'                }
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
            }
            ],
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
                    l: 'i'                }
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
        ]
    };
})();
                
                                                                
                                                
                                                                                                                                                                                                                                                                                                                
