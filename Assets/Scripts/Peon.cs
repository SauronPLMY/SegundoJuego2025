using System.Collections.Generic;
using UnityEngine;

public class Peon : ChessPiece
{
    public override List<Vector2Int> ObtenerMovimientosValidos(Celda[,] celdas)
    {
        List<Vector2Int> movimientos = new List<Vector2Int>();

        int direccion = esDelJugador1 ? 1 : -1;
        Vector2Int adelante = new Vector2Int(posicionActual.x, posicionActual.y + direccion);

        if (EsDentroDelTablero(adelante) && celdas[adelante.x, adelante.y].pieza == null)
        {
            movimientos.Add(adelante);
        }

        Vector2Int diagIzq = new Vector2Int(posicionActual.x - 1, posicionActual.y + direccion);
        Vector2Int diagDer = new Vector2Int(posicionActual.x + 1, posicionActual.y + direccion);

        if (EsDentroDelTablero(diagIzq) && HayPiezaEnemiga(celdas, diagIzq))
        {
            movimientos.Add(diagIzq);
        }

        if (EsDentroDelTablero(diagDer) && HayPiezaEnemiga(celdas, diagDer))
        {
            movimientos.Add(diagDer);
        }

        return movimientos;
    }


}

