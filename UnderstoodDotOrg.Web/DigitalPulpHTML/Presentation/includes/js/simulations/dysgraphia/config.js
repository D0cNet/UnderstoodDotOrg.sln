(function() {
    //Reminder: the last element can't have a comma at the end!
    //Learn more about how to help your child
    DysgraphiaGameConfig = {
        timeInSeconds: 90,
        introDurationInSeconds: 0, //0=open until closed
        introText: [
            'Type exactly what you see. Be sure to fix mistakes. Ready?'
            
        ].join("\n"),
        finalText: {
            onComplete: {
                en: 'Congrats!'
            },
            onTimeout: {
                en: [
                    'Time\'s up!'
                ].join("\n")
            }
        },
        title: {
            en: 'Typing Test'
        },
        maxLength: {
            phone: 48,
            tablet: 74,
            desktop: 96
        },
        tweaks: {
            initial: {
                minimumCharacters: 15,
                maximumCharacters: 19
            },
            chances: [
                //lv1 (special)
                {},
                //lv2
                {
                    replaceRandomly: 5,
                    extraRandom: 0,
                    ignoreInput: 0,
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
        prompts: [
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
       ]
    };
})();

                                                                                                                                
                                
                                                                                
                                                                                                                                                                                                                                                                                                                                
                                                                                                                                                                                                                
                
