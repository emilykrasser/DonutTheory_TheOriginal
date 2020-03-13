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
                                            "and create TVs only to make them dissapear when *eliminated*.",
                                            "They're also delicious...",
                                            "I'm not sure what to do..." });
        characterLines.Add(new List<string> { "Is this a good or a bad thing???",
                                            "I really want to eat some of these donuts..."});
        // Second block
        characterLines.Add(new List<string> { "You brought me donuts?!?!",
                                            "You're the best employee ever",
                                            "(even if you caused the donut destruction of this plane of reality)" });
        characterLines.Add(new List<string> { "Goodbye." });

        numInteractions = 3;
    }
}
