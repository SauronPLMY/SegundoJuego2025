using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Panel : MonoBehaviour
{
    public string m_name;

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
