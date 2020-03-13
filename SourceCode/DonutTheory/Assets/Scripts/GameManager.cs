//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public Dictionary<string, Object> nPCSprites;

    public List<Object> m_DonutSounds, m_TVVideos;
    public List<GameObject> m_TVPrefabs;

    //Reference to mainCamera to edit the culling masks
    public Camera mainCamera;
    //The two main UI panels to interact with NPCs and Objects
    public GameObject objectInterationPanel, nPCInteractionPanel;

    //The two text references for the previous panels
    private Text objectInteratPopUpText, nPCInteractionText;

    public bool objectInteractionVisible, nPCInteractionVisible;

    //A boolean to control whether player can move their character
    private bool controls;

    private static GameManager Instance; //The instance of the GameManager that the user has access to.

    // Use this for initialization

    private void Awake()
    {
        m_DonutSounds = Resources.LoadAll("DonutSounds", typeof(AudioClip)).ToList();
        m_TVVideos = Resources.LoadAll("TVClips", typeof(VideoClip)).ToList();
    }

    void Start ()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        // Gray NPC sprites
        nPCSprites = new Dictionary<string, Object>();
        Object[] temp0 = Resources.LoadAll("NPCSprites", typeof(Sprite));
        foreach (Object o in temp0)
        {
            nPCSprites.Add(o.name, o);
        }

        // Bool for keyboard input
        controls = true;
    }

    public GameManager GetInstance()
    {
		if(Instance == null)
        {
			Instance = new GameManager();
		}
		return Instance;
	}

    // Update is called once per frame
    void Update ()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu" && SceneManager.GetActiveScene().name != "Credits")
        {
            if (mainCamera == null)
            {
                mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            }

            if (objectInterationPanel == null)
            {
                objectInterationPanel = GameObject.Find("ObjectInteractionPanel");
                objectInterationPanel.SetActive(false);
                objectInteratPopUpText = objectInterationPanel.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
            }

            if (nPCInteractionPanel == null)
            {
                nPCInteractionPanel = GameObject.Find("NPCPopupInteractionPanel");
                nPCInteractionPanel.SetActive(false);
                nPCInteractionText = nPCInteractionPanel.transform.GetChild(1).GetChild(0).GetComponent<Text>();
            }
        }
    }

    public void SetObjectInteractPopUpText(string str)
    {
        objectInteratPopUpText.text = str;
    }

    public void AcivateObjectInteractionPanel(bool set)
    {
        objectInterationPanel.SetActive(set);
    }

    public void SetNPCInteractPopUpText(string str)
    {
        nPCInteractionText.GetComponent<DialogueController>().fullText = str;
        nPCInteractionText.text = str;
    }

    public void AcivateNPCInteractionPanel(bool set)
    {
        nPCInteractionPanel.SetActive(set);
    }

    public void StartNPCInteractEffect()
    {
        nPCInteractionText.GetComponent<DialogueController>().StartEffect();
    }

    public void StopNPCInteractEffect()
    {
        nPCInteractionText.GetComponent<DialogueController>().StopEffect();
    }

    public bool CheckNPCInteractEffect()
    {
        return nPCInteractionText.GetComponent<DialogueController>().TextEffectDone();
    }

    public void SetNPCImage(string spriteName)
    {
        nPCInteractionPanel.transform.GetChild(0).GetComponent<Image>().sprite = (Sprite)nPCSprites[spriteName];
        nPCInteractionPanel.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = spriteName;
    }

    public void EnableControlls(bool set) { controls = set; }
    public bool GetControls() { return controls; }

    public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}