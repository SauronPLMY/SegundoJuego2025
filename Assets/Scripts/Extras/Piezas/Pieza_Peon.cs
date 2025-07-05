using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pieza_Peon : Pieza
{
    [Space(30)]

    [Header("-> PEON VARIABLES")]
    public Detector m_detector;

    void Start()
    {
        m_rendered.sprite = Tablero.Instance.m_piecesSO[m_dir == 1 ? 0 : 1].m_peon;
        m_detector.transform.localScale = new Vector2(-m_dir, 1);
    }

    public override void Move()
    {
        transform.parent = m_detector.m_mostInteresting.transform;
        transform.localPosition = Vector2.zero;
    }
}
