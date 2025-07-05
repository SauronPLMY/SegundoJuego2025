using UnityEngine;

public class Detector : MonoBehaviour
{
    public Celda m_mostInteresting; [Space]

    public Celda m_centerCelda;
    public Celda m_upperCelda;
    public Celda m_bottomCelda; [Space]

    public LayerMask m_layer;
    public float m_distance;
    public float m_xDistance;
    public Transform m_detector; [Space]

    public float m_yUpper;
    public float m_yBottom;

    bool m_enemyDetected;

    void Update()
    {
        Ray();
    }

    void Ray()
    {
        float xDistance = transform.localScale.x == 1 ? -m_xDistance : m_xDistance;

        Vector3 upperOffset = m_detector.position + new Vector3(xDistance, m_yUpper);
        Vector3 centerOffset = m_detector.position + new Vector3(xDistance, 0);
        Vector3 bottomOffset = m_detector.position + new Vector3(xDistance, m_yBottom);

        Vector3 direction = transform.localScale.x == 1 ? -m_detector.right : m_detector.right;

        RaycastHit2D upperHit = Physics2D.Raycast(upperOffset, direction, m_distance, m_layer);
        RaycastHit2D centerHit = Physics2D.Raycast(centerOffset, direction, m_distance, m_layer);
        RaycastHit2D bottomHit = Physics2D.Raycast(bottomOffset, direction, m_distance, m_layer);

        if (upperHit)
        {
            m_upperCelda = upperHit.collider.GetComponent<Celda>();

            if (m_upperCelda.m_currentPiece)
            {
                Debug.DrawRay(bottomOffset, direction * m_distance, Color.red);
                m_mostInteresting = m_upperCelda;
            }

            Debug.DrawRay(upperOffset, direction * m_distance, Color.blue);
        }
        else
        {
            Debug.DrawRay(upperOffset, direction * m_distance, Color.white);
        }

        if (centerHit)
        {
            m_centerCelda = centerHit.collider.GetComponent<Celda>();

            m_mostInteresting = m_centerCelda;

            Debug.DrawRay(centerOffset, direction * m_distance, Color.blue);
        }
        else
        {
            Debug.DrawRay(centerOffset, direction * m_distance, Color.white);
        }

        if (bottomHit)
        {
            m_bottomCelda = bottomHit.collider.GetComponent<Celda>();

            if (m_bottomCelda.m_currentPiece)
            {
                Debug.DrawRay(bottomOffset, direction * m_distance, Color.red);
                m_mostInteresting = m_bottomCelda;
            }

            Debug.DrawRay(bottomOffset, direction * m_distance, Color.blue);
        }
        else
        {
            Debug.DrawRay(bottomOffset, direction * m_distance, Color.white);
        }
    }
}
