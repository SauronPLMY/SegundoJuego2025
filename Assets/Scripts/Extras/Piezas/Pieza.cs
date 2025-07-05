using System;
using System.Collections.Generic;
using Unity.Burst;
using Unity.VisualScripting;
using UnityEngine;

public enum Type
{
    Peon,
    Caballo,
    Reina,
    Alfil,
    Torre
}

public class Pieza : MonoBehaviour
{
    public Type m_type;
    public float m_dir;
    public DragAndDrop m_controller;
    public Celda m_celda;

    public bool m_isStarted;

    public event Action OnPlay;

    [HideInInspector] public SpriteRenderer m_rendered;

    //-> Privates
    bool m_canDrop;

    void OnEnable()
    {
        m_rendered = GetComponent<SpriteRenderer>();

        m_controller.OnTakePiece += OnTake;
        m_controller.OnDropPiece += OnDrop;
    }

    void OnDisable()
    {
        m_controller.OnTakePiece -= OnTake;
        m_controller.OnDropPiece -= OnDrop;
    }

    void OnTake()
    {
        if (m_isStarted) return;

        Debug.Log("Tomamos");
    }

    void OnDrop()
    {
        if (m_canDrop)
        {   
            transform.parent = m_celda.transform;
            transform.localPosition = Vector2.zero;

            // m_isStarted = true;
            // m_celda.m_isOccuped = true;

            if (m_dir == 1)
            {
                if (!Tablero.Instance.m_leftPiecesOnPlay.Contains(this)) Tablero.Instance.m_leftPiecesOnPlay.Add(this);
            }
            else
            {
                if (!Tablero.Instance.m_rightPiecesOnPlay.Contains(this)) Tablero.Instance.m_rightPiecesOnPlay.Add(this);
            }

            // FindNextMovement();
            OnPlay?.Invoke();
        }
        else
        {
            transform.localPosition = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Celda"))
        {
            m_celda = other.gameObject.GetComponent<Celda>();

            if (m_celda.m_column.m_ID == "H" && m_dir == -1) m_canDrop = true;
            else if (m_celda.m_column.m_ID == "A" && m_dir == 1) m_canDrop = true;
            else m_canDrop = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Celda"))
        {
            if (m_celda)
            {
                if (m_celda.m_currentPiece)
                {
                    m_celda.m_currentPiece = null;
                    m_celda.m_isOccuped = false;
                }
            }
        }
    }

    public virtual void FindNextMovement()
    {

    }

    public virtual void Move()
    {
        
    }
}
