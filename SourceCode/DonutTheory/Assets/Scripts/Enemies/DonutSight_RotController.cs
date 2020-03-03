using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutSight_RotController : MonoBehaviour
{
    public Quaternion m_Rot;
    public Vector3 m_Pos, m_LocPos;

    public bool m_Right = true;

    // Start is called before the first frame update
    void Start()
    {
        m_Rot = transform.rotation;
        m_Pos = transform.position;
        m_LocPos = transform.localPosition;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = m_Rot;
        if(m_Right)
            transform.position = new Vector3(gameObject.transform.parent.transform.localPosition.x + m_LocPos.x / 4, m_Pos.y, m_Pos.z);
        else
            transform.position = new Vector3(gameObject.transform.parent.transform.localPosition.x - m_LocPos.x / 4, m_Pos.y, m_Pos.z);
    }
}
