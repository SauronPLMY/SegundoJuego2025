using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject munePausa;
    public void Pausa()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        munePausa.SetActive(true);
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        munePausa.SetActive(false);
    }

    public void Cerrar ()
    {
       //Application.Quit();
       SceneManager.LoadScene("Menu inicial");
        Debug.Log("Cerrando Juego");
    }
   
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Juego");
    }
}