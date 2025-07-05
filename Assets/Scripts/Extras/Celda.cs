using UnityEngine;

public class Celda : MonoBehaviour
{
    //-> Read Only
    public Columna m_column;
    public Pieza m_currentPiece;
    public bool m_isOccuped;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_currentPiece = collision.gameObject.GetComponent<Pieza>();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_currentPiece = null;
        }
    }
}
