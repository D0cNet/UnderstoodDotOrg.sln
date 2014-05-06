(function() {
    //Reminder: the last element can't have a comma at the end!
    DyslexiaGameConfig = {
        timeInSeconds: 90,
        introDurationInSeconds: 0, //0=open until closed
        introText: [
            'Some letters, letter pairs and whole words have been mixed up.\nUsing the key, click what\'s wrong to make it right.\n\nFix all the sentences before time runs out.'
        ].join("\n"),
        finalText: [
            'Time\'s up!',
        ].join("\n"),
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
        //CAREFUL OF TRAINING COMMAS!!!
        sentences: [
            //Level 1
            [{
                text: 'I have a dog and his name is Mutt.',
                rules: {
                    b: 'd',
                    w: 'm',
                    n: 'u',
                    e: 'a',
                    q: 'g'
                }
            }, {
                text: 'My young son has been waiting.',
                rules: {
                    u: 'ou',
                    w: 'm',
                    q: 'g',
                    e: 'a'
                }
            }],
            //Level 2
            [{
                text: 'Pass the butter please.',
                rules: {                
                    n: 'u',
                    ees: 'ease',                
                    b: 'p',
                    l: 't'
                }
            }, {
                text: 'Where did you put my funny picture?',
                rules: {
                    n: 'u',
                    q: 'p',
                    were: 'where',
                    b: 'd'
                }
            }],
            //Level 3
            [{
                text: 'Go through the fourth door from the right.',
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
            }]
 ,
            //Level 4
            [{
                text: 'Go through the fourth door from the right.',
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
            }]
 ,
            //Level 5
            [{
                text: 'Go through the fourth door from the right.',
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
            }]
 ,
            //Level 6
            [{
                text: 'Go through the fourth door from the right.',
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
            }]
        ]
    };
})();
                                                                                                                
                
