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
        characterLines.Add(new List<string> { "Hello" });
        characterLines.Add(new List<string> { "Did you find my time capsule?" });
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
