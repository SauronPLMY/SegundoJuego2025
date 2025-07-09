using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

//     public Tablero tablero;
//     public MovimientoJugador jugador;

//     private void Awake()
//     {
//         if (Instance == null) Instance = this;
//         else Destroy(gameObject);
//     }

//     private void Start()
//     {
//         IniciarNivel(0);
//     }

//     public void IniciarNivel(int nivel)
//     {
//         // Ejemplo estático - ajustar según niveles que diseñes
//         Vector2Int posJugador = new Vector2Int(0, 1);
//         Vector2Int posMeta = new Vector2Int(7, 7);
//         tablero.meta = posMeta;

//         LimpiarTablero();

//         // Colocar jugador en posición inicial
//         jugador.transform.position = tablero.GetPosicionDesdeCasilla(posJugador);

//         // Crear enemigos ejemplo:
//         // Primero limpia enemigos antiguos y luego instancia enemigos
//         // Aquí creamos un ejemplo estático, puedes mejorar luego con datos por nivel
//         CrearEnemigo(TipoPieza.Alfil, new Vector2Int(3, 3));
//         CrearEnemigo(TipoPieza.Torre, new Vector2Int(5, 5));
//     }

//     void CrearEnemigo(TipoPieza tipo, Vector2Int posicion)
//     {
//         // Prefab con componente Pieza y SpriteRenderer
//         GameObject prefabEnemigo = Resources.Load<GameObject>("Prefabs/Enemigo");
//         if (prefabEnemigo == null)
//         {
//             Debug.LogError("No se encontró el prefab Enemigo en Resources/Prefabs/");
//             return;
//         }

//         GameObject enemigo = Instantiate(prefabEnemigo, tablero.GetPosicionDesdeCasilla(posicion), Quaternion.identity);
//         enemigo.GetComponent<Pieza>().SetTipo(tipo, Resources.Load<SO_Pieces>("SO_Pieces")); // Asume que tienes SO_Pieces en Resources
//         tablero.tablero[posicion.x, posicion.y] = enemigo;
//     }

//     void LimpiarTablero()
//     {
//         for (int x = 0; x < tablero.columnas; x++)
//         {
//             for (int y = 0; y < tablero.filas; y++)
//             {
//                 if (tablero.tablero[x, y] != null)
//                 {
//                     Destroy(tablero.tablero[x, y]);
//                     tablero.tablero[x, y] = null;
//                 }
//             }
//         }
//     }

//     public void ReiniciarNivel()
//     {
//         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//     }

//     public void GanarNivel()
//     {
//         Debug.Log("¡Ganaste el nivel!");
//         // Aquí puedes cargar siguiente nivel o mostrar UI
//     }

//     public void PerderNivel()
//     {
//         Debug.Log("¡Perdiste el nivel!");
//         // Aquí puedes mostrar UI de derrota y botón para reiniciar
//     }
}