using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{

    private SpriteRenderer sprite;
    private float posicionXAnterior;

    // Start is called before the first frame update
    void Start()
    {
        // Pillo la posición X y el sprite
        posicionXAnterior = transform.position.x;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // FIXED UPDATE: el update se ejecuta en frame por segundo
        // el fixed update se ejecuta en tiempo; distribuye la tarea del método entre los frames que haya por segundo
        // se usa cuando se quiere que algo se vea más rápido
        // va independiente; si tenemos una tarea que dura un minuto y tenemos 50fps, la distribuye entre los 50fps; movimiento más fluido

        // se ejecutan en orden; primero se verifica si se hace o no el flip x, Y DESPUÉS se reasigna la posición anterior al valor actual
        // cuando la posición anterior sea MAYOR que la posición actual (eje X), se hace el flip
        sprite.flipX = posicionXAnterior > transform.position.x;
        posicionXAnterior = transform.position.x;
    }
}
