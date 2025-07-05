using System;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 offset;
    private bool estaArrastrando = false;

    private Camera camara;
    private Pieza m_pieza;

    public event Action OnTakePiece;
    public event Action OnDropPiece;

    public bool m_canTake = true;

    private void Start()
    {
        camara = Camera.main;
        m_pieza = GetComponent<Pieza>();
    } 

    private void OnMouseDown()
    {
        if (!m_canTake) return;

        if (m_pieza.m_isStarted) return;

        OnTakePiece?.Invoke();

        Vector3 mousePos = camara.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mousePos.x, mousePos.y, transform.position.z);

        estaArrastrando = true;
    }

    private void OnMouseDrag()
    {
        if (!m_canTake) return;

        if (!estaArrastrando) return;

        Vector3 mousePos = camara.ScreenToWorldPoint(Input.mousePosition);
        Vector3 nuevaPos = new Vector3(mousePos.x, mousePos.y, transform.position.z) + offset;
        transform.position = nuevaPos;
    }

    private void OnMouseUp()
    {
        if (!m_canTake) return;

        OnDropPiece?.Invoke();
        estaArrastrando = false;
    }
}