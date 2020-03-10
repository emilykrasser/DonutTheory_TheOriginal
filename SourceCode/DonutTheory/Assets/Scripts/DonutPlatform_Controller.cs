using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutPlatform_Controller : MonoBehaviour
{
    public List<GameObject> m_ObjectsToShow;

    public bool m_HideWhenExit, enteredTrigger;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject gO in m_ObjectsToShow)
            gO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            enteredTrigger = true;
            foreach (GameObject gO in m_ObjectsToShow)
                gO.SetActive(true);
        }
    }

    protected void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            enteredTrigger = false;

            if (m_HideWhenExit)
                foreach (GameObject gO in m_ObjectsToShow)
                    gO.SetActive(false);
        }
    }
}
