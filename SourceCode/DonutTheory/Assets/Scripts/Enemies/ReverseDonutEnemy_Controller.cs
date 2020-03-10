using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseDonutEnemy_Controller : MonoBehaviour
{
    public float m_Velocity = 5f;

    public Transform m_SightStart, m_SightEnd;

    public bool m_Colliding;

    // Start is called before the first frame update
    void Start()
    {

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
}
