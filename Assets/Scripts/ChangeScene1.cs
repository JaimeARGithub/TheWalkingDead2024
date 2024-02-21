using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene1 : MonoBehaviour
{
    // Siguiente escena a la que ir
    public string nextScene;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Para que al llegar al objeto salte el método
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si colisionamos con el jugador
        if (collision.CompareTag("Player"))
        {
            gameManager.cambiarEscena(nextScene);
            Destroy(gameObject);
        }
    }
}
