using UnityEngine;

public class CeldaLogic
{
    public int fila;
    public int columna;
    public bool estaAmenazada;
    public bool tieneEnemigo;
    public bool esMeta;

    public CeldaLogic(int fila, int columna)
    {
        this.fila = fila;
        this.columna = columna;
        estaAmenazada = false;
        tieneEnemigo = false;
        esMeta = false;
    }
}