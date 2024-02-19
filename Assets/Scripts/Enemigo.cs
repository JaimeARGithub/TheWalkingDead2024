using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    public float velocidad;         // Velocidad de movimiento
    public Vector3 posicionFin;     // Posici�n a la que queremos que se desplace
    private Vector3 posicionInicio;  // Posici�n de partida
    private bool moviendoAFin;       // Para saber si vamos en direcci�n a la posici�n final o ya estamos de vuelta

    // Start is called before the first frame update
    void Start()
    {
        // Lo primero, a la posici�n de inicio le damos el transform position
        // Transform position nos da la posici�n en la que estamos, es una funci�n que nos devuelve el valor
        // Se va al transform del objeto (en el inspector) y coge la posici�n
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
        // El mu�eco empieza a moverse hacia la izquierda; destino = fin
        // Cuando el mu�eco se da la vuelta, destino = inicio
        // En cada frame debo comprobar si voy hacia un lado o hacia otro
        // (�sto es lo mismo que un if; si moviendoAFin es true, posicionDestino es posicionFin; si no, posicionInicio)
        Vector3 posicionDestino = (moviendoAFin) ? posicionFin : posicionInicio;


        // Ahora que s� el sentido del movimiento, hay que decirle que se mueva
        // a la funci�n de movimiento hay que pasarle la posici�n actual, la posici�n de destino y la velocidad

        // cosa mala de la velocidad: la velocidad va a ser m�s r�pida cuantos m�s fps tenga el juego
        // corregirlo: intentar distribuir la velocidad seg�n los fps que d� el juego, para que no sea ni muy r�pido ni muy lento
        // se multiplica la velocidad por esa variable del sistema para que el enemigo no vaya ni muy r�pido ni muy lento
        transform.position = Vector3.MoveTowards(transform.position, posicionDestino, velocidad * Time.deltaTime);

        // cuando lleguemos al final: si llego al final, ya no me estoy moviendo hacia el final 
        if (transform.position == posicionFin) moviendoAFin = false;
        if (transform.position == posicionInicio) moviendoAFin = true;
    }

    // M�TODO PARA LOCALIZAR QUE EL JUGADOR HA ENTRADO EN LA ZONA DEL ENEMIGO
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // ahora le pongo la etiqueta al player
        // "si ha habido colisi�n con el objeto cuya etiqueta es player:"
        if (collision.gameObject.CompareTag("Player"))
        {
            // llamo al m�todo P�BLICO del JUGADOR que le quita vida utilizando el NOMBRE DEL SCRIPT DEL JUGADOR
            collision.gameObject.GetComponent<Jugador>().QuitarVida();
        }
    }
}
