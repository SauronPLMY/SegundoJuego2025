using UnityEngine;

public class Pieza : MonoBehaviour
{
    public TipoPieza tipo;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetTipo(TipoPieza nuevoTipo, SO_Pieces piezasSO)
    {
        tipo = nuevoTipo;
        spriteRenderer.sprite = piezasSO.GetSpritePorTipo(tipo);
    }
}