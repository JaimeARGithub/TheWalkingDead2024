using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    // VARIABLES PARA EL MOVIMIENTO DEL JUGADOR

    // variable para la velocidad del mu�eco; me va a dejar elegir valores entre 1 y 10
    [Range(1, 10)] public float velocidad; 

    // estas dos no se pueden modificar desde el inspector
    Rigidbody2D rb2d;
    SpriteRenderer spRd;



    // VARIABLES PARA EL SALTO DEL JUGADOR
    // vble para averiguar si est� saltando; que mientras est� saltando no pueda saltar otra vez
    // manipulable para que exista el segundo salto
    bool isJumping = false;

    // vble que indica cu�nto salta por cada vez que le demos
    [Range(1, 500)] public float potenciaSalto;



    // Para la utilizaci�n del Animator del jugador
    private Animator animator;




    // Start is called before the first frame update
    void Start()
    {
        // Se usa para inicializar variables y obtener componentes
        rb2d = GetComponent<Rigidbody2D>(); // cojo el rigidbody de ESE componente
        spRd = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // en cada frame compruebo si me muevo a derecha (1), izquierda (-1) o estoy parado (0)
        // input -> lo que inserto para jugar

        float movimientoH = Input.GetAxisRaw("Horizontal");

        // vector2: dos componentes, eje x y eje y
        // mu�eco parado -> velocidad 0, movimiento 0; con la velocidad controlo cu�nto avanza el pj
        // la y por ahora no la quiero manipular

        // rb2d.velocity le indica al rigidbody3D la velocidad que queremos que tenga

        // Eje X:
        // -movimientoH: se usa para indicar la direcci�n del movimiento
        // Eje Y:
        // -obtengo la que ten�a antes mediante rb2d.velocity.y
        rb2d.velocity = new Vector2(movimientoH * velocidad, rb2d.velocity.y);


        // Si voy pa la izquierda, debe girar la direcci�n
        if (movimientoH > 0)
        {
            spRd.flipX = false;
        } else if (movimientoH < 0)
        {
            spRd.flipX = true;
        }


        // si se ha presionado el bot�n de salto Y no estoy ya saltando
        if (Input.GetButton("Jump") && !isJumping)
        {
            // a�ado una fuerza al rigidbody; vector de ascenso 2D multiplicado por la potencia de salto
            // en el vector 2D: la X se queda en 0, la Y pasa a 1; la potencia de salto se aplica a la Y
            rb2d.velocity = new Vector2(rb2d.velocity.x, potenciaSalto);

            // indico que estoy saltando, para que no se pueda saltar otra vez mientras se salta
            isJumping = true;


            // cuando el mo�eco toque el suelo (se detecte una colisi�n contra el suelo), se reasigna
            // la variable y se puede volver a saltar
        }


        if (movimientoH != 0)
        {
            animator.SetBool("isWalking", true);
        } else {
            animator.SetBool("isWalking", false);
        }
    }

    // M�TODO QUE SE EJECUTA SIEMPRE QUE HAY UNA COLISI�N
    // por par�metro entra el objeto con el que se ha colisionado
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.gameObject.CompareTag("Suelo"))
        {
            // si aquello con lo que se ha colisionado es el suelo:
            // -ya no se salta
            // -la velocidad Y pasa a ser cero
            isJumping = false;
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        }
    }
}