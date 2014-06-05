(function() {
    //Reminder: the last element can't have a comma at the end!
    DyslexiaGameConfig = {
        timeInSeconds: 90,
        introDurationInSeconds: 0, //0=open until closed
        introText: [
            'We\'ve switched some letters. Press them to swap back. Ready?'
        ].join("\n"),
        finalText: [
            'Time\'s up!',
        ].join("\n"),
        title: {
            en: 'Scrambled Letters'
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
                    for: 'from',
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
                    a: 'e'                }
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
            }, {
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
                    o: 'e'                }
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
                    for: 'of',
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
