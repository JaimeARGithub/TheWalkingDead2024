using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public int cantidad;    // Para poder asignarle la puntuación


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // cuando se colisione con él
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Jugador>().IncrementarPuntos(cantidad);
            // Para que el objeto se quite de la pantalla cuando lo toquemos:
            Destroy(gameObject);
        }
    }
}
