(function() {
    //Reminder: the last element can't have a comma at the end!
    AttentionGameConfig = {
        timeInSeconds: 90,
        introDurationInSeconds: 0, //0=open until closed
        introText: [
            'Follow the teacher’s instructions. (Sound required.) Ready?'
        ].join("\n"),
        finalText: {
            en: "Did you see the elephants?"
        },
        title: {
            en: 'What a Zoo!'
        },
        instructionLength: {
            en: 99
        },
        timing: {
            pauseBeforeInstructions: 1000,
            pauseBeforeStopDialog: 2000
        }
    };
})();

                                
