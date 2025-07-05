using UnityEngine;

public class Pieza_Alfil : Pieza
{
    void Start()
    {
        m_rendered.sprite = Tablero.Instance.m_piecesSO[m_dir == 1 ? 0 : 1].m_alfil;
    }
}
