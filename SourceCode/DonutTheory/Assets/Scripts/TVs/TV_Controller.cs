﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TV_Controller : MonoBehaviour
{
    bool m_PlayerCollide;

    public VideoClip m_Clip;

    // Start is called before the first frame update
    void Start()
    {
        System.Random rand = new System.Random();
        List<Object> tempDonutSounds = GameObject.Find("GameManager").GetComponent<GameManager>().m_TVVideos;
        int index = rand.Next(0, tempDonutSounds.Count);
        m_Clip = (VideoClip)tempDonutSounds[index];

        gameObject.transform.GetChild(0).GetComponent<VideoPlayer>().clip = m_Clip;
        gameObject.transform.GetChild(0).GetComponent<VideoPlayer>().Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
