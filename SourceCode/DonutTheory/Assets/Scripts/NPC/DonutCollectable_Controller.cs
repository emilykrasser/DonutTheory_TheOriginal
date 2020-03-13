using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutCollectable_Controller : MonoBehaviour
{
    bool m_PlayerCollide, m_FloatUp;
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
        if (m_PlayerCollide && Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().m_NumberOfDonutsCollected++;
            Destroy(gameObject);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            m_PlayerCollide = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            m_PlayerCollide = false;
    }
}
