using System.Collections.Generic;
using UnityEngine;

public class Nico_Jugador1 : Nico_Jugadores
{
    public List<Nico_Celda> m_celdas;

    void Awake()
    {
        GeneratePieces(m_celdas);
    }
}