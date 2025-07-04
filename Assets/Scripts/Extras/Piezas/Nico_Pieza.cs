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

public class Nico_Pieza : MonoBehaviour
{
    public Type m_type;

    public DragAndDrop m_controller;

    public Nico_Celda m_celda;

    bool m_onCelda = false;

    void OnEnable()
    {
        Debug.Log("Iniciamos");
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

    }

    
    void OnDrop()
    {
        Debug.Log("Dropeamos");
        if (!m_onCelda)
        {
            transform.localPosition = Vector2.zero;
        }
        else
        {
            if (m_celda)
            {
                transform.parent = m_celda.transform;
                transform.localPosition = Vector2.zero;

                m_celda.Occuped(gameObject, true);
            }
            else
            {
                transform.localPosition = Vector2.zero;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Celda"))
        {
            Debug.Log("Entramos");
            m_onCelda = !other.gameObject.GetComponent<Nico_Celda>().m_isOccuped;

            if (m_onCelda)
            {
                Debug.Log("Esta está libre");
                m_celda = other.gameObject.GetComponent<Nico_Celda>();
            }
            else
            {
                Debug.Log("Esta está ocupa");
            }
        }
    }
}
