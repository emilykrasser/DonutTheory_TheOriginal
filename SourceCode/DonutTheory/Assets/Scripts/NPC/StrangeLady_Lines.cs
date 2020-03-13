using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangeLady_Lines : NPCLines
{
    // Start is called before the first frame update
    void Start()
    {
        characterLines = new List<List<string>>();

        // First block
        characterLines.Add(new List<string> { "Oh please don't attack!",
                                            "I'm afraid that there's a strange virus going around,",
                                            "and it has mutated me into a strange donut... person...",
                                            "...",
                                            "Which is fine... I guess...",
                                            "Maybe theres a cure; I've seen some strange looking donuts around here. A lot of them, actually.",
                                            "But the ones I'm talking about are very interesting. Maybe try colecting them and coming back to me.",
                                            "I've seen 3 around so far. >:]"});
        characterLines.Add(new List<string> { "Why don't you collect all those strange, magical donuts and come back here." });
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
