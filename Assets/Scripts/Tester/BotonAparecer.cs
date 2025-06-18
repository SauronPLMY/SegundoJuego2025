using UnityEngine;
using UnityEngine.UI;

public class BotonAparecer : MonoBehaviour
{
    public GameObject objetoAMostrar;

    void Start()
    {
        if (objetoAMostrar != null)
        {
            objetoAMostrar.SetActive(false);
        }
        Debug.Log("Aparecio");
    }


    public void MostrarOcultarObjeto()
    {
        if (objetoAMostrar != null)
        {
            objetoAMostrar.SetActive(!objetoAMostrar.activeSelf);
        }
        Debug.Log("Aparecio");
    }
}