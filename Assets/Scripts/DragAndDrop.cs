using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 startPosition;
    private Turno miTurno;
    private int zonaPermitidaFila;  // La primera fila, donde se pueden colocar las piezas

    void Start()
    {
        
        /*
        // Aqui se determina a que jugador pertenece esta pieza según tag
        if (gameObject.tag == "Jugador1")
        {
            miTurno = Turno.Jugador1;
            zonaPermitidaFila = 0; // Primera fila para Jugador 1
        }
        else if (gameObject.tag == "Jugador2")
        {
            miTurno = Turno.Jugador2;
            zonaPermitidaFila = 7; // Primera fila para Jugador 2
        }
        else
        {
            Debug.LogError("La pieza no tiene tag de Jugador1 o Jugador2");
        }*/
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Intento");
        if (!Controller.Instance.EsTurnoDelJugador(miTurno))
        {
            Debug.Log("No es tu turno.");
            eventData.pointerDrag = null;  // Se cancela el drag
            return;
        }

        startPosition = transform.position;
    }

    public void OnMouseDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10; 
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    public void OnMouseUP(PointerEventData eventData)
    {
        Vector3 posicionFinal = transform.position;

        /// Tire un raycast para ver si hay una celda debajo
        /// rescate la celda => Celda celda =  Raycast // pedirle el componente GetComponent<Celda>();
        /// si eso es null ... no habia celda
        /// sino le hago las gestiones de decirle que esa celda es su nueva posicion
        ///     celda.ocupante = this
        ///     
        /// 


        /*
        // Asumimos que cada casilla tiene 1 unidad de distancia
        int fila = Mathf.RoundToInt(posicionFinal.y);  // Eje Y es filas
        int columna = Mathf.RoundToInt(posicionFinal.x);  // Eje X es columnas

        if (fila != zonaPermitidaFila)
        {
            Debug.Log("Solo puedes colocar en tu primera fila");
            transform.position = startPosition;  // Volver a posición inicial
            return;
        }

        // Solo para confirmar que se hizo bien  
        Debug.Log("Pieza colocada correctamente");
        Controller.Instance.PiezaColocada(gameObject);
        */
    }
}
