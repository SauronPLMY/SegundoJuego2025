using System.Collections.Generic;
using UnityEngine;

public class Torre : ChessPiece
{
    public override List<Vector2Int> ObtenerMovimientosValidos(Celda[,] celdas)
    {
        List<Vector2Int> movimientos = new List<Vector2Int>();
        int direccion = esDelJugador1 ? 1 : -1;

        // 3 casillas hacia adelante
        for (int i = 1; i <= 3; i++)
        {
            Vector2Int pos = new Vector2Int(posicionActual.x, posicionActual.y + direccion * i);
            if (!EsDentroDelTablero(pos)) break;

            if (celdas[pos.x, pos.y].pieza == null)
                movimientos.Add(pos);
            else
            {
                if (HayPiezaEnemiga(celdas, pos))
                    movimientos.Add(pos);
                break;
            }
        }

        // 3 casillas hacia los lados (izquierda y derecha)
        for (int i = 1; i <= 3; i++)
        {
            Vector2Int izquierda = new Vector2Int(posicionActual.x - i, posicionActual.y);
            if (EsDentroDelTablero(izquierda))
            {
                if (HayPiezaEnemiga(celdas, izquierda))
                    movimientos.Add(izquierda);
            }

            Vector2Int derecha = new Vector2Int(posicionActual.x + i, posicionActual.y);
            if (EsDentroDelTablero(derecha))
            {
                if (HayPiezaEnemiga(celdas, derecha))
                    movimientos.Add(derecha);
            }
        }

        return movimientos;
    }

    
}
