using System;
using UnityEngine;
using UnityEngine.Events;

public class Celda : MonoBehaviour
{
    public event Action<Celda> OnPlayerEnter;

    [Header("-> Goal Related")]
    public bool m_isGoal = false;
    public UnityEvent m_goalEvent;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!m_isGoal) OnPlayerEnter?.Invoke(this);
            else m_goalEvent?.Invoke();
        }
    }
}
