using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelsManager : MonoBehaviour
{
    public static PanelsManager Instance;

    public string m_initialPanel;
    public List<Panel> m_panels;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SwitchPanel(m_initialPanel);
    }

    public void SwitchPanel(string name)
    {
        m_panels.Where(c => c.gameObject.activeSelf).ToList().ForEach(z => z.Close());
        m_panels.Where(c => c.m_name == name).ToList().ForEach(z => z.Open());
    }
}
