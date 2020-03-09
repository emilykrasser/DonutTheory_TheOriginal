using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMan_Lines : NPCLines
{
    // Start is called before the first frame update
    void Start()
    {
        characterLines = new List<List<string>>();

        // First block
        characterLines.Add(new List<string> { "Dr. Satellite!! Your calculations were off!",
                                            "Instead of creating an infinite supply of donuts for our weekly team meetings,",
                                            "you opened up a donut portal to a donut dimension!!1!!",
                                            "The donuts seem... harmless... but they emit strange noises",
                                            "and modify the environment when *eliminated*.",
                                            "They're also delicious...",
                                            "I'm not sure what to do..." });
        characterLines.Add(new List<string> { "Is this a good or a bad thing???" });
        // Second block
        characterLines.Add(new List<string> { "Oh... You found my time capsule...",
                                            "... It has a passcode and... I can't remember..." });
        characterLines.Add(new List<string> { "Do you have any idea what it could be? I remember it was four digits?" });
        // Third block
        characterLines.Add(new List<string> { "Hahaha..." });
        characterLines.Add(new List<string> { "Thank you so much. I don't feel as sad now." });

        numInteractions = 3;
    }
}
