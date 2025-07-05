using System.Collections.Generic;
using UnityEngine;

public class Jugadores : MonoBehaviour
{
    public List<Pieza> m_prefabs;

    int m_piecesCount = 10;

    public void GeneratePieces(List<Celda> celdas, float dir, List<Pieza> piezas)
    {
        for (int i = 0; i < m_piecesCount; i++)
        {
            Pieza prefabRandom = m_prefabs[Random.Range(0, m_prefabs.Count)];

            Celda celdaDisponible = celdas.Find(c => !c.m_isOccuped);

            if (celdaDisponible != null)
            {
                Pieza nuevaPieza = Instantiate(prefabRandom, celdaDisponible.transform.position, Quaternion.identity);
                nuevaPieza.transform.SetParent(celdaDisponible.transform);
                nuevaPieza.transform.localPosition = Vector2.zero;

                piezas.Add(nuevaPieza);

                celdaDisponible.m_isOccuped = true;

                nuevaPieza.m_dir = dir;
            }
        }
    }
}