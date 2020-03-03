using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutHitCollider_Controller : MonoBehaviour
{
    public bool m_PlayerCollide, m_PlayerKillBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && m_PlayerCollide && !m_PlayerKillBox)
            Destroy(gameObject.transform.parent.gameObject);
        if (m_PlayerCollide && m_PlayerKillBox)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>().DepleatHelth();
            m_PlayerCollide = false;
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
