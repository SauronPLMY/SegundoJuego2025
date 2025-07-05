using System.Collections.Generic;

public class Jugador1 : Jugadores
{
    public List<Celda> m_celdas;
    public List<Pieza> m_pieces;
    public float m_dirPieces;

    void Awake() => GeneratePieces(m_celdas, m_dirPieces, m_pieces);
}