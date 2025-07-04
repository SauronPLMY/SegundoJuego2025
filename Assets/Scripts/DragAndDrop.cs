using System;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 startPosition;
    private bool estaArrastrando = false;

    private ChessPiece pieza;
    private Camera camara;


    public event Action OnTakePiece;
    public event Action OnDropPiece;

    private void Start()
    {
        pieza = GetComponent<ChessPiece>();
        camara = Camera.main;
    }

    private void OnMouseDown()
    {
        OnTakePiece?.Invoke();
        startPosition = transform.position;

        Vector3 mousePos = camara.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mousePos.x, mousePos.y, transform.position.z);

        // Ignorar raycast para no chocar consigo misma
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        estaArrastrando = true;
    }

    private void OnMouseDrag()
    {
        if (!estaArrastrando) return;

        Vector3 mousePos = camara.ScreenToWorldPoint(Input.mousePosition);
        Vector3 nuevaPos = new Vector3(mousePos.x, mousePos.y, transform.position.z) + offset;
        transform.position = nuevaPos;
    }

    private void OnMouseUp()
    {
        OnDropPiece?.Invoke();
        
        // estaArrastrando = false;
        // gameObject.layer = LayerMask.NameToLayer("Default");

        // // Dibuja el raycast para ver que se lanza desde la pieza
        // Debug.DrawRay(transform.position, Vector3.forward * 0.1f, Color.red, 2f);

        // // Usa raycast sin filtro de Layer, para detectar cualquier cosa
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);

        // if (hit.collider != null)
        // {
        //     Debug.Log("Raycast golpeó: " + hit.collider.name + " (Layer: " + LayerMask.LayerToName(hit.collider.gameObject.layer) + ")");
        // }
        // else
        // {
        //     Debug.Log("Raycast NO golpeó nada.");
        // }

        // // El resto lo puedes dejar comentado por ahora mientras probamos
    }

}