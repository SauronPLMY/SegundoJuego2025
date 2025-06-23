using UnityEngine;
using System.Collections.Generic;

public abstract class ChessPiece : MonoBehaviour
{
    public Vector2Int posicionActual;
    public bool esDelJugador1;

    // Lista de sprites, indice 0 = sprite jugador 1 (blanco), indice 1 = jugador 2 (negro)
    public List<Sprite> imagenes = new List<Sprite>();

    private SpriteRenderer spriteRenderer;

    // Metodo para asignar el sprite según el jugador
    public void ActualizarPieza(bool jugador)
    {
        esDelJugador1 = jugador;
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        if (imagenes != null && imagenes.Count >= 2)
        {
            spriteRenderer.sprite = jugador ? imagenes[0] : imagenes[1];
        }
        else
        {
            Debug.LogWarning("Faltan sprites en la lista 'imagenes' para ChessPiece " + gameObject.name);
        }
    }

    // El resto de metodos abstractos y virtuales
    public abstract List<Vector2Int> ObtenerMovimientosValidos(Celda[,] celdas);

    public virtual void MoverA(Vector2Int nuevaPos, Celda[,] celdas)
    {
        celdas[posicionActual.x, posicionActual.y].pieza = null;
        posicionActual = nuevaPos;
        celdas[nuevaPos.x, nuevaPos.y].pieza = this;
        transform.position = new Vector3(nuevaPos.x, nuevaPos.y, 0);
    }
}
