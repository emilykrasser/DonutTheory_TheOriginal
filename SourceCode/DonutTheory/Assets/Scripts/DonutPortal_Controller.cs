using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutPortal_Controller : MonoBehaviour
{
    public Transform m_Prefab, m_Position;

    private bool enteredTrigger, m_FloatUp;
    private Vector3 m_UpPos, m_DownPos;

    // Start is called before the first frame update
    void Start()
    {
        m_FloatUp = true;
        m_UpPos = gameObject.transform.position + new Vector3(0, 1.5f);
        m_DownPos = gameObject.transform.position + new Vector3(0, -1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && enteredTrigger)
        {
            Instantiate(m_Prefab, m_Position.position, m_Position.rotation);
        }

        if (m_FloatUp)
        {
            gameObject.transform.position = Vector3.Slerp(transform.position, m_UpPos, Time.deltaTime * 0.5f);
        }
        else
        {
            gameObject.transform.position = Vector3.Slerp(transform.position, m_DownPos, Time.deltaTime * 0.5f);
        }

        if (gameObject.transform.position.y >= m_UpPos.y - 1f || gameObject.transform.position.y <= m_DownPos.y + 1f)
        {
            m_FloatUp = !m_FloatUp;
        }
    }

    protected void OnTriggerEnter2D(Collider2D col)
    {
        enteredTrigger = true;
    }

    protected void OnTriggerExit2D(Collider2D col)
    {
        enteredTrigger = false;
    }
}
