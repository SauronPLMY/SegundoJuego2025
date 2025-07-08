using System;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    private Camera camara;
    public Tablero tablero;
    public TipoPieza tipoPieza;

    void Start()
    {
        camara = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = camara.ScreenToWorldPoint(Input.mousePosition);
            Vector2Int casillaDestino = tablero.GetCasillaDesdePosicion(mousePos);

            if (casillaDestino.x < 0 || casillaDestino.x >= tablero.columnas || casillaDestino.y < 0 || casillaDestino.y >= tablero.filas)
                return;

            if (tablero.tablero[casillaDestino.x, casillaDestino.y] != null)
            {
                Debug.Log("Casilla ocupada por enemigo, movimiento inválido");
                return;
            }

            if (tablero.EsMovimientoValido(transform.position, casillaDestino, tipoPieza))
            {
                Vector3 nuevaPos = tablero.GetPosicionDesdeCasilla(casillaDestino);
                transform.position = nuevaPos;

                if (tablero.CasillaAmenazada(casillaDestino))
                {
                    GameManager.Instance.PerderNivel();
                }
                else if (tablero.EsCasillaMeta(casillaDestino))
                {
                    GameManager.Instance.GanarNivel();
                }
            }
            else
            {
                Debug.Log("Movimiento inválido para este tipo de pieza");
            }
        }
    }
}