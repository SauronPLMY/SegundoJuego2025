using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Columna{

    public List<GameObject> filas; 
}

[System.Serializable]
public class Tablero{
    public List<Columna> columnas;
}

public class Controller : MonoBehaviour
{

    public Tablero board;
    public GameObject FindObject(int i, int j){
        return board.columnas[i].filas[j];
    }
}
