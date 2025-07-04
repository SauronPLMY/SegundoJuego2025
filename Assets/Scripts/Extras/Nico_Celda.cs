using UnityEngine;

public class Nico_Celda : MonoBehaviour
{
    //-> Read Only
    public GameObject m_currentPiece;
    public bool m_isOccuped;

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Salió una pieza");
        if (collision.gameObject.CompareTag("Player"))
        {
            m_currentPiece = null;
            m_isOccuped = false;
        }
    }

    public void Occuped(GameObject piece = null, bool ocupped = false)
    {
        m_currentPiece = piece != null ? piece : null;
        m_isOccuped = ocupped;
    } 
}
