using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
    Jugador1,  // Blancos
    Jugador2   // Negros
}

public class Controller : MonoBehaviour
{

    [SerializeField] private List<ChessPiece> PrefabsPiezas = new List<ChessPiece>();

    public Tablero board;
    public List<Celda> OpcionesPlayer1;

    public List<Celda> OpcionesPlayer2;

    private Turno turnoActual;

    public static Controller Instance;

    // Singleton
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Opcional: si quieres que persista entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        turnoActual = Turno.Jugador1;
        Debug.Log("Comienza Jugador 1");

        // Generamos las piezas random al inicio
        GenerarPiezasIniciales(true);  // Jugador 1
        GenerarPiezasIniciales(false); // Jugador 2
    }

    public Celda FindObject(int i, int j)
    {
        return board.columnas[i].filas[j];
    }

    public bool EsTurnoDelJugador(Turno jugador)
    {
        return turnoActual == jugador;
    }

    // Logica cuando el jugador coloca una pieza
    public void PiezaColocada(GameObject pieza)
    {
        Debug.Log("Pieza colocada por " + turnoActual);
        AvanzarPiezas(); // (Por ahora solo testing, despues implementar avance real)
        CambiarTurno();
    }

    private void CambiarTurno()
    {
        if (turnoActual == Turno.Jugador1)
        {
            turnoActual = Turno.Jugador2;
            Debug.Log("Turno de Jugador 2 (Negros)");
        }
        else
        {
            turnoActual = Turno.Jugador1;
            Debug.Log("Turno de Jugador 1 (Blancos)");
        }
    }

    private void AvanzarPiezas()
    {
        Debug.Log("Las piezas avanzan y revisan si pueden comer.");
    }

    public Turno GetTurnoActual()
    {
        return turnoActual;
    }

    public void InstanciarPiezas(bool isPlayer1)
    {
        int tamano = 10;  // según la regla de 10 piezas por jugador

        for (int i = 0; i < tamano; i++)
        {
            // Escoger una pieza aleatoria de la lista de prefabs
            ChessPiece prefab = PrefabsPiezas[Random.Range(0, PrefabsPiezas.Count)];

            // Obtener la celda libre en la primera fila correspondiente
            Celda celda = null;
            if (isPlayer1)
            {
                celda = OpcionesPlayer1.FirstOrDefault(x => x.ocupante == null);
            }
            else
            {
                celda = OpcionesPlayer2.FirstOrDefault(x => x.ocupante == null);
            }

            if (celda == null)
            {
                Debug.LogWarning("No hay más celdas libres para colocar piezas.");
                break;
            }

            // Instanciar la pieza dentro de la celda (para que quede ubicada correctamente)
            ChessPiece instancia = Instantiate(prefab, celda.transform.position, Quaternion.identity);

            // Actualizar si es jugador 1 o 2 (esto asigna el sprite)
            instancia.ActualizarPieza(isPlayer1);

            // Registrar la pieza en la celda y posición
            celda.OcupaCelda(instancia);
            instancia.posicionActual = new Vector2Int(celda.GetIndiceColumna(), celda.GetIndiceFila());
        }
    }

    public void GenerarPiezasIniciales(bool esJugador1)
    {
        int cantidadPiezas = 10;

        List<Celda> listaDeCeldas = esJugador1 ? OpcionesPlayer1 : OpcionesPlayer2;

        for (int i = 0; i < cantidadPiezas; i++)
        {
            ChessPiece prefabRandom = PrefabsPiezas[Random.Range(0, PrefabsPiezas.Count)];

            // Buscamos la primera celda vacía en su respectivo panel
            Celda celdaDisponible = listaDeCeldas.Find(c => c.EstaVacia());

            if (celdaDisponible != null)
            {
                // Instanciamos la pieza
                ChessPiece nuevaPieza = Instantiate(prefabRandom, celdaDisponible.transform.position, Quaternion.identity);
                nuevaPieza.transform.SetParent(celdaDisponible.transform);
                nuevaPieza.ActualizarPieza(esJugador1);
                celdaDisponible.OcupaCelda(nuevaPieza);
            }
        }

    }
}
