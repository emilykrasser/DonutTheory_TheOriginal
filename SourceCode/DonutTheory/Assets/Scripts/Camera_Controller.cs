using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    float m_CameraSize = 5;

    bool m_TriggerEntered;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_TriggerEntered)
        {
            m_CameraSize = Vector3.Slerp(new Vector3(m_CameraSize, m_CameraSize), new Vector3(10, 10), Time.deltaTime / 20).x;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize = m_CameraSize;
            if (m_CameraSize > 7.5)
                Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_TriggerEntered = true;
        }
    }
}
