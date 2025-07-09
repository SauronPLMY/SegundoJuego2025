using UnityEngine;

public class UI_FollowObject : MonoBehaviour
{
    public GameObject m_target;
    public float m_speed = 20;

    void Update()
    {
        Vector2 targetPosition = Camera.main.WorldToScreenPoint(m_target.transform.position);
        transform.position = Vector2.Lerp(transform.position, targetPosition, m_speed * Time.deltaTime);
    }

    public void Move(Detector detector)
    {
        if (detector.m_currentHit)
        {
            m_target.GetComponent<MovimientoJugador>().MoveTo(detector.m_currentHit.transform.position);
        }
    }
}
