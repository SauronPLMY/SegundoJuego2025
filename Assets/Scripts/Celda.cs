using UnityEngine;
using UnityEngine.EventSystems;

public class Celda : MonoBehaviour, IDropHandler
{
    public ChessPiece ocupante;                
    public Vector2Int posicion;                
    public ChessPiece pieza;                   

    // Esta vacia la celda?
    public bool EstaVacia()
    {
        return ocupante == null;
    }

    // Hay una pieza enemiga en la celda?
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

    // Obtener el indice de columna de esta celda (posicion horizontal)
    public int GetIndiceColumna()
    {
         return transform.parent.GetSiblingIndex();
        
    }

    // Obtener el indice de fila de esta celda (posicion vertical)
    public int GetIndiceFila()
    {
       return transform.GetSiblingIndex();
    }

    public void OnDrop(PointerEventData eventData)
    {
        eventData.selectedObject.transform.parent = this.transform;
    }
}

