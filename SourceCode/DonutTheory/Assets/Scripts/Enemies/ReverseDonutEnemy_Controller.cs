using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseDonutEnemy_Controller : MonoBehaviour
{
    public float m_Velocity = 5f;

    public Transform m_SightStart, m_SightEnd;

    public bool m_Colliding;

    public GameObject m_InstantiatedTV;

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> tempTVPrefabs = GameObject.Find("GameManager").GetComponent<GameManager>().m_TVPrefabs;
        GameObject[] tVSpawns = GameObject.FindGameObjectsWithTag("TVSpawn");

        System.Random rand = new System.Random();

        int index = rand.Next(0, tempTVPrefabs.Count);
        GameObject prefab = tempTVPrefabs[index];

        index = rand.Next(0, tVSpawns.Length - 1);
        Transform tVTransform = tVSpawns[index].transform;

        m_InstantiatedTV = Instantiate(prefab, tVTransform.position, tVTransform.rotation);
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
