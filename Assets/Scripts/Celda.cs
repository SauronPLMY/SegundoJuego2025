using UnityEngine;

public class Celda : MonoBehaviour
{
    public ChessPiece ocupante;                
    public Vector2Int posicion;                
    public ChessPiece pieza;                   

    // ¿Está vacía la celda?
    public bool EstaVacia()
    {
        return ocupante == null;
    }

    // ¿Hay una pieza enemiga en la celda?
    public bool TienePiezaEnemiga(bool soyJugador1)
    {
       
        return false;
    }

    // Asignar una pieza a esta celda
    public void OcupaCelda(ChessPiece pieza)
    {
        ocupante = pieza;
        pieza.posicionActual = new Vector2Int(GetIndiceColumna(), GetIndiceFila());
    }

    // Vaciar esta celda
    public void VaciarCelda()
    {
        ocupante = null;
    }

    // Obtener el índice de columna de esta celda (posición horizontal)
    public int GetIndiceColumna()
    {
        return transform.GetSiblingIndex();
    }

    // Obtener el índice de fila de esta celda (posición vertical)
    public int GetIndiceFila()
    {
        return transform.parent.GetSiblingIndex();
    }
}

