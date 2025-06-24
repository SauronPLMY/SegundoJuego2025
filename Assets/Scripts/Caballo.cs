using System.Collections.Generic;
using UnityEngine;

public class Caballo : ChessPiece
{
    public override List<Vector2Int> ObtenerMovimientosValidos(Celda[,] celdas)
    {
        List<Vector2Int> movimientos = new List<Vector2Int>();
        int direccion = esDelJugador1 ? 1 : -1;

        // Movimiento en L: dos hacia adelante + una a los costados
        Vector2Int izquierda = new Vector2Int(posicionActual.x - 1, posicionActual.y + direccion * 2);
        Vector2Int derecha = new Vector2Int(posicionActual.x + 1, posicionActual.y + direccion * 2);

        if (EsDentroDelTablero(izquierda))
        {
            if (celdas[izquierda.x, izquierda.y].pieza == null || HayPiezaEnemiga(celdas, izquierda))
                movimientos.Add(izquierda);
        }

        if (EsDentroDelTablero(derecha))
        {
            if (celdas[derecha.x, derecha.y].pieza == null || HayPiezaEnemiga(celdas, derecha))
                movimientos.Add(derecha);
        }

        return movimientos;
    }


}
