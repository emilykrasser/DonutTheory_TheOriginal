using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutEnemy_Controller : MonoBehaviour
{
    public float m_Velocity = 5f;

    public Transform m_SightStart, m_SightEnd;

    public bool m_Colliding;

    public AudioClip m_Clip;

    // Start is called before the first frame update
    void Start()
    {
        System.Random rand = new System.Random();
        List<Object> tempDonutSounds = GameObject.Find("GameManager").GetComponent<GameManager>().m_DonutSounds;
        int index = rand.Next(0, tempDonutSounds.Count);
        m_Clip = (AudioClip)tempDonutSounds[index];

        gameObject.GetComponent<AudioSource>().clip = m_Clip;
        gameObject.GetComponent<AudioSource>().Play();

        transform.GetChild(2).gameObject.SetActive(false);
        StartCoroutine(WaitEnableKillCollider());
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(m_Velocity, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        m_Colliding = Physics2D.Linecast(m_SightStart.position, m_SightEnd.position);

        if (m_Colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * (-1), transform.localScale.y);
            m_Velocity *= -1;
            m_SightStart.GetComponent<DonutSight_RotController>().m_Right = !m_SightStart.GetComponent<DonutSight_RotController>().m_Right;
            m_SightEnd.GetComponent<DonutSight_RotController>().m_Right = !m_SightEnd.GetComponent<DonutSight_RotController>().m_Right;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(m_SightStart.position, m_SightEnd.position);
    }

    IEnumerator WaitEnableKillCollider()
    {
        yield return new WaitForSeconds(1f);
        transform.GetChild(2).gameObject.SetActive(true);
    }
}
