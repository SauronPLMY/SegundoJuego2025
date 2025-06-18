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
        Debug.Log("Comienza Jugador 1 (Blancos)");
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
        int tamano = 12;
        for (int times = 0; times < tamano; times++)
        {
            // Escoger una pieza aleatoria
            ChessPiece prefab = PrefabsPiezas[Random.Range(0, PrefabsPiezas.Count)];
            Celda celda = null;
            if (isPlayer1)
            {
                // Recibir una celda... la primera vacia
                celda = OpcionesPlayer1.FirstOrDefault(x => x.ocupante == null);
            }
            else
            {
                // Recibir una celda... la primera vacia
                celda = OpcionesPlayer2.FirstOrDefault(x => x.ocupante == null);
            }
            //Instanciamos la pieza
            ChessPiece instancia = Instantiate(prefab, celda.transform);
            //Preparamos la pieza
            instancia.ActualizarPieza(isPlayer1);
            celda.ocupante = instancia;
    }  
    }
}
