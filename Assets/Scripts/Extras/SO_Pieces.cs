using UnityEngine;

[CreateAssetMenu(fileName = "Pieces", menuName = "Scriptables/Pieces")]
public class SO_Pieces : ScriptableObject
{
    public Sprite m_caballo;
    public Sprite m_alfil;
    public Sprite m_torre;
    public Sprite m_reina;
    public Sprite m_peon;

    public Sprite GetSpritePorTipo(TipoPieza tipo)
    {
        switch (tipo)
        {
            case TipoPieza.Caballo: return m_caballo;
            case TipoPieza.Alfil: return m_alfil;
            case TipoPieza.Torre: return m_torre;
            case TipoPieza.Reina: return m_reina;
            case TipoPieza.Peon: return m_peon;
            default: return null;
        }
    }
}