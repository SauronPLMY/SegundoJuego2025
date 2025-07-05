using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    public static Tablero Instance;

    public List<SO_Pieces> m_piecesSO;

    public Jugador1 m_jugador1;
    public Jugador2 m_jugador2;
    public ColumnasManager m_columnasManager;

    public List<Pieza> m_leftPiecesOnPlay;
    public List<Pieza> m_rightPiecesOnPlay;

    void Awake() => Instance = this;

    void Start()
    {
        m_jugador1.m_pieces.Where(c => c.m_dir == 1).ToList().ForEach(z => z.OnPlay += Player1Played);
        m_jugador2.m_pieces.Where(c => c.m_dir == -1).ToList().ForEach(z => z.OnPlay += Player2Played);
    }

    void OnDisable()
    {
        m_jugador1.m_pieces.Where(c => c.m_dir == 1).ToList().ForEach(z => z.OnPlay -= Player1Played);
        m_jugador2.m_pieces.Where(c => c.m_dir == -1).ToList().ForEach(z => z.OnPlay -= Player2Played);
    }

    void Player1Played()
    {
        Debug.Log("Jugó player 1");

        if (m_rightPiecesOnPlay != null)
        {
            m_rightPiecesOnPlay.ForEach(c => c.Move());
        }

        m_jugador1.m_pieces.ForEach(c => c.m_controller.m_canTake = false);
        m_jugador2.m_pieces.ForEach(c => c.m_controller.m_canTake = true);
    }

    void Player2Played()
    {
        Debug.Log("Jugó player 2");

        if (m_leftPiecesOnPlay != null)
        {
            m_leftPiecesOnPlay.ForEach(c => c.Move());
        }

        m_jugador1.m_pieces.ForEach(c => c.m_controller.m_canTake = true);
        m_jugador2.m_pieces.ForEach(c => c.m_controller.m_canTake = false);
    }
}
