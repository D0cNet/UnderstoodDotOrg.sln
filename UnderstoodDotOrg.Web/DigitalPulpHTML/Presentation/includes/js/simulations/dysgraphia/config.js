(function() {
    //Reminder: the last element can't have a comma at the end!
    //Learn more about how to help your child
    DysgraphiaGameConfig = {
        timeInSeconds: 90,
        introDurationInSeconds: 0, //0=open until closed
        introText: [
            'Simply type each sentence exactly as you see it.',
            '',
            'Type 4 sentences before time runs out.'
        ].join("\n"),
        finalText: [
            'Sorry, time\'s up!'
        ].join("\n"),
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
                    replaceRandomly: 7,
                    extraRandom: 0,
                    ignoreInput: 0,
                    changeCaps: 0,
                    repeatCharacters: 0
                },
                //lv3
                {
                    replaceRandomly: 6,
                    extraRandom: 3,
                    ignoreInput: 3,
                    changeCaps: 3,
                    repeatCharacters: 6
                },
                //lv4
                {
                    replaceRandomly: 10,
                    extraRandom: 6,
                    ignoreInput: 10,
                    changeCaps: 3,
                    repeatCharacters: 6
                }
            ],
                
            rules: {
                repeatCharacters: {
                    countMin: 2,
                    countMax: 3
                }
            }
        },
        prompts: [
            //lv1
            [
                'Together, the three of them traveled due north.'
            ],
            //lv2
            [
                'Her brother Cranshaw was sweeter and apparently preferred Cincinnati.',
                'His little boy was born on the eighth. The baby\'s three sisters were totally ecstatic.'
            ], 
            //lv3
            [
                'Great minds think alike.',
                'Every cloud has a silver lining.'
            ], 
            //lv4
            [
                'A bird in the hand is worth two in the bush.',
                'Give a child a fish and you feed him for a day. Teach a child to fish and you feed him for a lifetime.'
            ]
        ]
    };
})();

                                                                                                                                
                                
                                                                                
                                                                                                                                                                                                                                                                                                                
