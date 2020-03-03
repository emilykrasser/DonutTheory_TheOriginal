using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsTitle_Controller : MonoBehaviour
{
    public float m_Transform = 4f;
    public Vector3 m_OriginalScale, m_OpenScale;

    bool m_StartOminousApproach;

    // Start is called before the first frame update
    void Start()
    {
        m_OriginalScale = gameObject.transform.localScale;
        m_OpenScale = new Vector3(gameObject.transform.localScale.x * m_Transform, gameObject.transform.localScale.y * m_Transform, gameObject.transform.localScale.z);
        m_StartOminousApproach = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_StartOminousApproach)
        {
            gameObject.transform.localScale =
                    new Vector3(Vector3.Slerp(gameObject.transform.localScale, m_OpenScale, Time.deltaTime / 20).x,
                    Vector3.Slerp(gameObject.transform.localScale, m_OpenScale, Time.deltaTime / 20).y, gameObject.transform.localScale.z);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
        m_StartOminousApproach = true;
    }
}
