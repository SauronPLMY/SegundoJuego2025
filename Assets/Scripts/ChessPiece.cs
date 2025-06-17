using UnityEngine;
using System.Collections.Generic;

public abstract class ChessPiece : MonoBehaviour
{
    public Vector2Int posicionActual;
    public bool esDelJugador1;

    public abstract List<Vector2Int> ObtenerMovimientosValidos(Celda[,] celdas);

    public virtual void MoverA(Vector2Int nuevaPos, Celda[,] celdas)
    {
        // Actualiza posicion
        celdas[posicionActual.x, posicionActual.y].pieza = null;
        posicionActual = nuevaPos;
        celdas[nuevaPos.x, nuevaPos.y].pieza = this;

        // Actualiza posicion en la escena
        transform.position = new Vector3(nuevaPos.x, nuevaPos.y, 0);
    }
}
