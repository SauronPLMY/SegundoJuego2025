using UnityEngine;

public class Detector : MonoBehaviour
{
    public float m_maxDistance = 1.2f;
    public GameObject m_currentHit;

    void Update()
    {
        Ray();
    }

    void Ray()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, m_maxDistance);

        if (hit)
        {
            m_currentHit = hit.collider.gameObject;
            Debug.DrawRay(transform.position, transform.forward * m_maxDistance, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * m_maxDistance, Color.white);
        }
    }
}
