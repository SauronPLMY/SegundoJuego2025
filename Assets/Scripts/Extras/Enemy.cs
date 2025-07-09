using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject m_spawn;
    public List<GameObject> m_celdasDetecting;
    public float m_speedMovement; [Space(30)]

    public Transform m_hability;
    public Vector2 desiredScale;
    public float m_timePopup = 1f;

    void Start()
    {
        transform.localPosition = m_spawn.transform.position;

        if (m_hability) StartCoroutine(InfinityPopUp(desiredScale));
    }

    void OnEnable()
    {
        m_celdasDetecting.ForEach(c => c.GetComponent<Celda>().OnPlayerEnter += TryDetectPlayer);
    }

    void OnDisable()
    {
        m_celdasDetecting.Where(c => c != null && c.GetComponent<Celda>() != null).ToList().ForEach(c => c.GetComponent<Celda>().OnPlayerEnter -= TryDetectPlayer);
    }

    void TryDetectPlayer(Celda celda)
    {
        Attack(celda.transform);
    }

    public void Attack(Transform celda)
    {
        Debug.Log("Atacamos al rey");
        StopAllCoroutines();
        StartCoroutine(Move(celda));

        Invoke(nameof(DeadScreen), 1);
    }

    void DeadScreen()
    {
        PanelsManager.Instance.SwitchPanel("Game Over");
    }

    IEnumerator Move(Transform target)
    {
        Vector2 initial = transform.position;
        Vector2 desired = target.position;

        for (float i = 0; i < m_speedMovement; i += Time.deltaTime)
        {
            float time = i / m_speedMovement;
            transform.position = Vector2.Lerp(initial, desired, time);
            yield return null;
        }

        transform.position = desired;
    }

    IEnumerator InfinityPopUp(Vector3 target)
    {
        Vector2 initial = m_hability.localScale;
        Vector2 desired = m_hability.localScale + target;

        for (float i = 0; i < m_timePopup; i += Time.deltaTime)
        {
            float time = i / m_timePopup;
            m_hability.localScale = Vector2.Lerp(initial, desired, time);
            yield return null;
        }

        m_hability.localScale = desired;

        for (float i = 0; i < m_timePopup; i += Time.deltaTime)
        {
            float time = i / m_timePopup;
            m_hability.localScale = Vector2.Lerp(desired, initial, time);
            yield return null;
        }

        m_hability.localScale = initial;

        StartCoroutine(InfinityPopUp(target));
    }
}
