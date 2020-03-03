using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    public List<GameObject> m_HeartIndicator = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform gO in GameObject.Find("Health").transform)
            m_HeartIndicator.Add(gO.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DepleatHelth()
    {
        int index = m_HeartIndicator.Count - 1;
        Destroy(m_HeartIndicator[index]);
        m_HeartIndicator.RemoveAt(index);

        if (m_HeartIndicator.Count == 0)
            SceneManager.LoadScene("GameOver");
    }
}
