using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Empezamos importando una librería que necesitamos
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private GameObject gameManager;


    // Variable que controla nº vidas: conservarla entre niveles o no, posibilidad de cambiarla con power-ups
    public int vidasGlobal; // Y me hago dos métodos, uno para subir y otro para bajar vidas



    // Start is called before the first frame update
    void Start()
    {
        // Le pido que me busque el objeto que me he creado en la jerarquía
        gameManager = GameObject.Find("GameManager");

        // Al pasar de una escena a otra, todos los objetos de la escena se destruyen.
        // Tengo que indicarle que, al cambiar de escena, éste no se destruya.
        DontDestroyOnLoad(gameManager);

        // Y cargo mi escena, que normalmente va a ser la primera
        cambiarEscena("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiarEscena(string siguienteEscena)
    {
        // A este script se lo puede llamar desde cualquier parte, cambiando el
        // nombre de la escena que se pasa por parámetro
        SceneManager.LoadScene(siguienteEscena);
    }


    // Métodos que controlan la vida
    public int getVidas()
    {
        return vidasGlobal;
    }

    public void decrementarVidas()
    {
        vidasGlobal--;
    }

    public void aumentarVidas()
    {
        vidasGlobal++;
    }
}
