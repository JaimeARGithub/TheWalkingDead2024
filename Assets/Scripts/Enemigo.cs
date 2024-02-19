using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    public float velocidad;         // Velocidad de movimiento
    public Vector3 posicionFin;     // Posición a la que queremos que se desplace
    private Vector3 posicionInicio;  // Posición de partida
    private bool moviendoAFin;       // Para saber si vamos en dirección a la posición final o ya estamos de vuelta

    // Start is called before the first frame update
    void Start()
    {
        // Lo primero, a la posición de inicio le damos el transform position
        // Transform position nos da la posición en la que estamos, es una función que nos devuelve el valor
        // Se va al transform del objeto (en el inspector) y coge la posición
        posicionInicio = transform.position;
        moviendoAFin = true;
    }

    // Update is called once per frame
    void Update()
    {
        // El update mueve al enemigo una vez por cada frame
        MoverEnemigo();
    }

    private void MoverEnemigo()
    {
        // El muñeco empieza a moverse hacia la izquierda; destino = fin
        // Cuando el muñeco se da la vuelta, destino = inicio
        // En cada frame debo comprobar si voy hacia un lado o hacia otro
        // (Ésto es lo mismo que un if; si moviendoAFin es true, posicionDestino es posicionFin; si no, posicionInicio)
        Vector3 posicionDestino = (moviendoAFin) ? posicionFin : posicionInicio;


        // Ahora que sé el sentido del movimiento, hay que decirle que se mueva
        // a la función de movimiento hay que pasarle la posición actual, la posición de destino y la velocidad

        // cosa mala de la velocidad: la velocidad va a ser más rápida cuantos más fps tenga el juego
        // corregirlo: intentar distribuir la velocidad según los fps que dé el juego, para que no sea ni muy rápido ni muy lento
        // se multiplica la velocidad por esa variable del sistema para que el enemigo no vaya ni muy rápido ni muy lento
        transform.position = Vector3.MoveTowards(transform.position, posicionDestino, velocidad * Time.deltaTime);

        // cuando lleguemos al final: si llego al final, ya no me estoy moviendo hacia el final 
        if (transform.position == posicionFin) moviendoAFin = false;
        if (transform.position == posicionInicio) moviendoAFin = true;
    }

    // MÉTODO PARA LOCALIZAR QUE EL JUGADOR HA ENTRADO EN LA ZONA DEL ENEMIGO
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // ahora le pongo la etiqueta al player
        // "si ha habido colisión con el objeto cuya etiqueta es player:"
        if (collision.gameObject.CompareTag("Player"))
        {
            // llamo al método PÚBLICO del JUGADOR que le quita vida utilizando el NOMBRE DEL SCRIPT DEL JUGADOR
            collision.gameObject.GetComponent<Jugador>().QuitarVida();
        }
    }
}
