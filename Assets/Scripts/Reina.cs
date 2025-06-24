using System.Collections.Generic;
using UnityEngine;

public class Reina : ChessPiece
{
    public override List<Vector2Int> ObtenerMovimientosValidos(Celda[,] celdas)
    {
        List<Vector2Int> movimientos = new List<Vector2Int>();
        int direccion = esDelJugador1 ? 1 : -1;

        // 5 casillas hacia adelante (vertical)
        for (int i = 1; i <= 5; i++)
        {
            Vector2Int adelante = new Vector2Int(posicionActual.x, posicionActual.y + direccion * i);
            if (EsDentroDelTablero(adelante))
            {
                if (celdas[adelante.x, adelante.y].pieza == null)
                    movimientos.Add(adelante);
                else
                {
                    if (HayPiezaEnemiga(celdas, adelante))
                        movimientos.Add(adelante);
                    break;
                }
            }
        }

        // 5 casillas diagonales (izquierda y derecha)
        for (int i = 1; i <= 5; i++)
        {
            Vector2Int diagIzq = new Vector2Int(posicionActual.x - i, posicionActual.y + direccion * i);
            if (EsDentroDelTablero(diagIzq))
            {
                if (celdas[diagIzq.x, diagIzq.y].pieza == null)
                    movimientos.Add(diagIzq);
                else
                {
                    if (HayPiezaEnemiga(celdas, diagIzq))
                        movimientos.Add(diagIzq);
                    break;
                }
            }

            Vector2Int diagDer = new Vector2Int(posicionActual.x + i, posicionActual.y + direccion * i);
            if (EsDentroDelTablero(diagDer))
            {
                if (celdas[diagDer.x, diagDer.y].pieza == null)
                    movimientos.Add(diagDer);
                else
                {
                    if (HayPiezaEnemiga(celdas, diagDer))
                        movimientos.Add(diagDer);
                    break;
                }
            }
        }

        return movimientos;
    }

}
