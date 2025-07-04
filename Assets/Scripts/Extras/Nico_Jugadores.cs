using System.Collections.Generic;
using UnityEngine;

public class Nico_Jugadores : MonoBehaviour
{
    public List<Nico_Pieza> m_prefabs;
    
    int m_piecesCount = 10;

    public void GeneratePieces(List<Nico_Celda> celdas)
    {
        for (int i = 0; i < m_piecesCount; i++)
        {
            Nico_Pieza prefabRandom = m_prefabs[Random.Range(0, m_prefabs.Count)];

            Nico_Celda celdaDisponible = celdas.Find(c => !c.m_isOccuped);

            if (celdaDisponible != null)
            {
                Nico_Pieza nuevaPieza = Instantiate(prefabRandom, celdaDisponible.transform.position, Quaternion.identity);
                nuevaPieza.transform.SetParent(celdaDisponible.transform);
                nuevaPieza.transform.localPosition = Vector2.zero;

                celdaDisponible.Occuped(nuevaPieza.gameObject, true);
            }
        }
    }
}