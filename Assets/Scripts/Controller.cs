using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Columna
{
    public List<Celda> filas;
}

[System.Serializable]
public class Tablero
{
    public List<Columna> columnas;
}

public enum Turno
{
    Jugador1,
    Jugador2
}

public class Controller : MonoBehaviour
{
    [SerializeField] private List<ChessPiece> PrefabsPiezas = new List<ChessPiece>();

    public Tablero board = new Tablero();

    int cantidadPiezas = 10;
    public List<Celda> OpcionesPlayer1;
    public List<Celda> OpcionesPlayer2;

    private List<ChessPiece> piezasJugador1 = new List<ChessPiece>();
    private List<ChessPiece> piezasJugador2 = new List<ChessPiece>();

    public static Controller Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Debug.Log("Comienza Jugador 1");

        GenerarPiezasIniciales(true);
        GenerarPiezasIniciales(false);
    }

    public Celda FindObject(int i, int j)
    {
        return board.columnas[i].filas[j];
    }

    // Método llamado al colocar una pieza en el tablero
    public void PiezaColocada(GameObject piezaGO)
    {
        ChessPiece pieza = piezaGO.GetComponent<ChessPiece>();

        if (pieza.esDelJugador1 && !piezasJugador1.Contains(pieza))
        {
            piezasJugador1.Add(pieza);
        }
        else if (!pieza.esDelJugador1 && !piezasJugador2.Contains(pieza))
        {
            piezasJugador2.Add(pieza);
        }

        Debug.Log("Pieza colocada - moviendo todas las piezas simple");

        // Mueve las piezas blancas hacia arriba (+1 en y)
        foreach (ChessPiece p in piezasJugador1.ToList())
        {
            MoverUnaCasillaAdelante(p, +1);
        }

        // Mueve las piezas negras hacia abajo (-1 en y)
        foreach (ChessPiece p in piezasJugador2.ToList())
        {
            MoverUnaCasillaAdelante(p, -1);
        }
    }

    // Mueve una pieza una casilla adelante en la dirección indicada, si está libre
    private void MoverUnaCasillaAdelante(ChessPiece pieza, int direccionFila)
    {
        Vector2Int pos = pieza.posicionActual;
        int nuevaFila = pos.y + direccionFila;

        // Validar que no se salga del tablero
        if (nuevaFila < 0 || nuevaFila >= board.columnas[0].filas.Count)
        {
            Debug.Log($"{pieza.name} no puede avanzar más");
            return;
        }

        Celda origen = FindObject(pos.x, pos.y);
        Celda destinoCelda = FindObject(pos.x, nuevaFila);

        if (destinoCelda.ocupante == null)
        {
            origen.VaciarCelda();
            destinoCelda.OcupaCelda(pieza);

            pieza.transform.position = destinoCelda.transform.position;
            pieza.posicionActual = new Vector2Int(pos.x, nuevaFila);

            Debug.Log($"{pieza.name} avanzó una casilla a ({pos.x}, {nuevaFila})");
        }
        else
        {
            Debug.Log($"{pieza.name} no puede avanzar a casilla ocupada ({pos.x}, {nuevaFila})");
        }
    }

    // Método para instanciar piezas al inicio
    public void GenerarPiezasIniciales(bool esJugador1)
    {
        List<Celda> listaDeCeldas = esJugador1 ? OpcionesPlayer1 : OpcionesPlayer2;

        for (int i = 0; i < cantidadPiezas; i++)
        {
            ChessPiece prefabRandom = PrefabsPiezas[Random.Range(0, PrefabsPiezas.Count)];

            Celda celdaDisponible = listaDeCeldas.Find(c => c.EstaVacia());

            if (celdaDisponible != null)
            {
                ChessPiece nuevaPieza = Instantiate(prefabRandom, celdaDisponible.transform.position, Quaternion.identity);
                nuevaPieza.transform.SetParent(celdaDisponible.transform);
                nuevaPieza.ActualizarPieza(esJugador1);
                celdaDisponible.OcupaCelda(nuevaPieza);

                // Asignar posición actual correctamente
                nuevaPieza.posicionActual = new Vector2Int(celdaDisponible.GetIndiceColumna(), celdaDisponible.GetIndiceFila());

                if (esJugador1)
                    piezasJugador1.Add(nuevaPieza);
                else
                    piezasJugador2.Add(nuevaPieza);
            }
            else
            {
                Debug.LogWarning($"No hay más celdas libres para jugador {(esJugador1 ? "1" : "2")}");
                break;
            }
        }
    }
}