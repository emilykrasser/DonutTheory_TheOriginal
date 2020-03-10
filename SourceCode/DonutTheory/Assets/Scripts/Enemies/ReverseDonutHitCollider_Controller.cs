using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReverseDonutHitCollider_Controller : MonoBehaviour
{
    public bool m_PlayerCollide, m_PlayerKillBox;

    public bool m_Image;

    public GameObject m_Modify;
    public Sprite m_Sprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && m_PlayerCollide && !m_PlayerKillBox)
        {
            if (m_Modify != null && m_Sprite != null)
            {
                if (m_Image)
                    m_Modify.GetComponent<Image>().sprite = m_Sprite;
                else
                    m_Modify.GetComponent<SpriteRenderer>().sprite = m_Sprite;
            }
            Destroy(gameObject.transform.parent.gameObject);
        }
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
