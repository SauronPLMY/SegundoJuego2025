using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    public static Tablero Instance;

    public int filas = 8;
    public int columnas = 8;
    public float tamañoCasilla = 1f;
    public Vector2 origenTablero = new Vector2(-3.5f, -3.5f);

    public GameObject[,] tablero = new GameObject[8,8];

    public Vector2Int meta;

    private void Awake()
    {
        Instance = this;
    }

    public Vector2Int GetCasillaDesdePosicion(Vector2 posicion)
    {
        int x = Mathf.FloorToInt((posicion.x - origenTablero.x) / tamañoCasilla);
        int y = Mathf.FloorToInt((posicion.y - origenTablero.y) / tamañoCasilla);
        return new Vector2Int(x, y);
    }

    public Vector3 GetPosicionDesdeCasilla(Vector2Int casilla)
    {
        float x = origenTablero.x + casilla.x * tamañoCasilla + tamañoCasilla / 2;
        float y = origenTablero.y + casilla.y * tamañoCasilla + tamañoCasilla / 2;
        return new Vector3(x, y, 0);
    }

    public bool EsMovimientoValido(Vector2 posicionActual, Vector2Int destino, TipoPieza tipo)
    {
        Vector2Int origen = GetCasillaDesdePosicion(posicionActual);

        int dx = destino.x - origen.x;
        int dy = destino.y - origen.y;

        switch (tipo)
        {
            case TipoPieza.Peon:
                return dx == 0 && dy == 1;
            case TipoPieza.Caballo:
                return (Mathf.Abs(dx) == 1 && Mathf.Abs(dy) == 2) || (Mathf.Abs(dx) == 2 && Mathf.Abs(dy) == 1);
            case TipoPieza.Alfil:
                return Mathf.Abs(dx) == Mathf.Abs(dy);
            case TipoPieza.Torre:
                return dx == 0 || dy == 0;
            case TipoPieza.Reina:
                return dx == 0 || dy == 0 || Mathf.Abs(dx) == Mathf.Abs(dy);
        }
        return false;
    }

    public bool CasillaAmenazada(Vector2Int casilla)
    {
        for (int x = 0; x < filas; x++)
        {
            for (int y = 0; y < columnas; y++)
            {
                GameObject piezaEnemiga = tablero[x, y];
                if (piezaEnemiga != null)
                {
                    TipoPieza tipo = piezaEnemiga.GetComponent<Pieza>().tipo;
                    Vector2Int posPieza = new Vector2Int(x, y);
                    if (AmenazaDesde(posPieza, casilla, tipo))
                        return true;
                }
            }
        }
        return false;
    }

    private bool AmenazaDesde(Vector2Int origen, Vector2Int destino, TipoPieza tipo)
    {
        int dx = destino.x - origen.x;
        int dy = destino.y - origen.y;

        switch (tipo)
        {
            case TipoPieza.Peon:
                return (Mathf.Abs(dx) == 1 && dy == 1); // Peón amenaza diagonal adelante
            case TipoPieza.Caballo:
                return (Mathf.Abs(dx) == 1 && Mathf.Abs(dy) == 2) || (Mathf.Abs(dx) == 2 && Mathf.Abs(dy) == 1);
            case TipoPieza.Alfil:
                if (Mathf.Abs(dx) == Mathf.Abs(dy))
                    return !HayObstaculoEntre(origen, destino);
                return false;
            case TipoPieza.Torre:
                if (dx == 0 || dy == 0)
                    return !HayObstaculoEntre(origen, destino);
                return false;
            case TipoPieza.Reina:
                if (dx == 0 || dy == 0 || Mathf.Abs(dx) == Mathf.Abs(dy))
                    return !HayObstaculoEntre(origen, destino);
                return false;
        }
        return false;
    }

    private bool HayObstaculoEntre(Vector2Int origen, Vector2Int destino)
    {
        int dx = destino.x - origen.x;
        int dy = destino.y - origen.y;

        int stepX = dx == 0 ? 0 : dx / Mathf.Abs(dx);
        int stepY = dy == 0 ? 0 : dy / Mathf.Abs(dy);

        int x = origen.x + stepX;
        int y = origen.y + stepY;

        while (x != destino.x || y != destino.y)
        {
            if (tablero[x, y] != null)
                return true;

            x += stepX;
            y += stepY;
        }
        return false;
    }

    public bool EsCasillaMeta(Vector2Int casilla)
    {
        return casilla == meta;
    }
}