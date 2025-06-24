using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 startPosition;
    private bool estaArrastrando = false;

    private ChessPiece pieza;
    private Camera camara;

    private void Start()
    {
        pieza = GetComponent<ChessPiece>();
        camara = Camera.main;
    }

    private void OnMouseDown()
    {
        startPosition = transform.position;
        Vector3 mousePos = camara.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mousePos.x, mousePos.y, transform.position.z);
        estaArrastrando = true;
    }

    private void OnMouseDrag()
    {
        if (!estaArrastrando) return;

        gameObject.layer = 2;
        Vector3 mousePos = camara.ScreenToWorldPoint(Input.mousePosition);
        Vector3 nuevaPos = new Vector3(mousePos.x, mousePos.y, transform.position.z) + offset;
        transform.position = nuevaPos;
    }

    private void OnMouseUp()
    {
        estaArrastrando = false;
        // Hacemos el raycast 2D hacia abajo desde la posición actual
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
        gameObject.layer = 0;

        Debug.Log(hit.transform.name);

        if (hit.collider != null && hit.collider.TryGetComponent<Celda>(out Celda celda))
        {
            int fila = celda.GetIndiceFila();

            // Validamos si es su primera fila según el jugador
            if ((pieza.esDelJugador1 && fila == 0) || (!pieza.esDelJugador1 && fila == 7))
            {
                // Correcto: lo asignamos a la celda
                transform.position = celda.transform.position;
                celda.OcupaCelda(pieza);
                Debug.Log("Pieza colocada correctamente");
            }
            else
            {
                Debug.Log("Solo puedes colocar la pieza en tu primera fila");
                transform.position = startPosition;
            }
        }
        else
        {
            Debug.Log("No soltaste la pieza sobre ninguna celda");
            transform.position = startPosition;
        }
    }
}
