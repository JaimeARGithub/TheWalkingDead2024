using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//librerías a importar:
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBotonJugar()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnBotonCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void OnBotonSalir()
    {
        Application.Quit();
    }

    // Para hacer la vuelta al menú principal
    public void OnBotonMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
