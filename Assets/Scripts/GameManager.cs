using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Empezamos importando una librer�a que necesitamos
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private GameObject gameManager;


    // Variable que controla n� vidas: conservarla entre niveles o no, posibilidad de cambiarla con power-ups
    public int vidasGlobal; // Y me hago dos m�todos, uno para subir y otro para bajar vidas



    // Start is called before the first frame update
    void Start()
    {
        // Le pido que me busque el objeto que me he creado en la jerarqu�a
        gameManager = GameObject.Find("GameManager");

        // Al pasar de una escena a otra, todos los objetos de la escena se destruyen.
        // Tengo que indicarle que, al cambiar de escena, �ste no se destruya.
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
        // nombre de la escena que se pasa por par�metro
        SceneManager.LoadScene(siguienteEscena);
    }


    // M�todos que controlan la vida
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
