using System.Collections;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public GameObject m_spawn;
    public float m_speedMovement;

    [Space(30)]
    private Camera camara;
    public Tablero tablero;
    public TipoPieza tipoPieza;

    void Start()
    {
        camara = Camera.main;

        transform.localPosition = m_spawn.transform.position;
    }

    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Vector2 mousePos = camara.ScreenToWorldPoint(Input.mousePosition);
        //     Vector2Int casillaDestino = tablero.GetCasillaDesdePosicion(mousePos);

        //     if (casillaDestino.x < 0 || casillaDestino.x >= tablero.columnas || casillaDestino.y < 0 || casillaDestino.y >= tablero.filas)
        //         return;

        //     if (tablero.tablero[casillaDestino.x, casillaDestino.y] != null)
        //     {
        //         Debug.Log("Casilla ocupada por enemigo, movimiento inválido");
        //         return;
        //     }

        //     if (tablero.EsMovimientoValido(transform.position, casillaDestino, tipoPieza))
        //     {
        //         Vector3 nuevaPos = tablero.GetPosicionDesdeCasilla(casillaDestino);
        //         transform.position = nuevaPos;

        //         if (tablero.CasillaAmenazada(casillaDestino))
        //         {
        //             // GameManager.Instance.PerderNivel();
        //         }
        //         else if (tablero.EsCasillaMeta(casillaDestino))
        //         {
        //             // GameManager.Instance.GanarNivel();
        //         }
        //     }
        //     else
        //     {
        //         Debug.Log("Movimiento inválido para este tipo de pieza");
        //     }
        // }
    }

    public void MoveTo(Vector2 posiion)
    {
        StartCoroutine(Move(posiion));
    }
    
    IEnumerator Move(Vector2 target)
    {
        Vector2 initial = transform.position;
        Vector2 desired = target;

        for (float i = 0; i < m_speedMovement; i += Time.deltaTime)
        {
            float time = i / m_speedMovement;
            transform.position = Vector2.Lerp(initial, desired, time);
            yield return null;
        }

        transform.position = desired;
    }
}