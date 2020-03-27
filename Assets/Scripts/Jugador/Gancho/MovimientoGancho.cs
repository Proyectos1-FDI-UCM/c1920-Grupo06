using UnityEngine;

public class MovimientoGancho : MonoBehaviour
{
    /*Este script ocurre cuando el jugador avanza en la direccion del gancho cuando este ha colisionado */
     
    [SerializeField] [Range(1, 100)] float velocidad_movimientoGancho = 10; //Velocidad del movimiento

    Estados estadoJugador = null;
    Rigidbody2D rb = null;
    GameObject gancho;
    Vector3 direccion = Vector3.zero; //Direccion en la que se mueve
    Jugador jugador = null;
    Impulso impulso = null;

    private void Awake() //Nada más crearse recibe las referencias y se desactiva a si mismo
    {
        rb = GetComponent<Rigidbody2D>();
        jugador = GetComponent<Jugador>();
        estadoJugador = GetComponent<Estados>();
        impulso = GetComponent<Impulso>();
        enabled = false;
    }
    private void OnEnable()//Cuando es activado se calcula la direccion del movimiento 
    {
        gancho = jugador.Gancho();
        direccion = gancho.transform.position - transform.position;
        jugador.DireccionImpulso(direccion); //Se guarda en "Jugador" esta dirección para ser usada por el impulso
        rb.velocity = direccion.normalized * velocidad_movimientoGancho; //Se asigna la velocidad
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))//Si se pulsa la tecla de salto se llama a impulso
            Impulso();
    }
    void Impulso()
    {
        Destroy(gancho); //El gancho se destruye
        estadoJugador.CambioEstado(estado.Defecto); //Se cambia el estado a defecto
        impulso.ImpulsoGancho(); //Se llama al script encargado del impulso
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enabled) //Por algún motivo aunque el script esté desactivado en collision si que se ejecuta asi que comprobamos que esté activado
        {
            Impulso(); //Igual que si se pulsara el espacio
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (enabled) //Igual que en el collision enter
        {
            if (collision.gameObject == gancho) //Si el trigger es el gancho el impulso es distinto hacia arriba para evitar un impulso inútil hacia una pared
            {
                Destroy(gancho); //Se destruye el gancho
                jugador.DireccionImpulso(Vector3.up); //La nueva dirección es completamente vertical
                estadoJugador.CambioEstado(estado.Defecto); //Estado por defecto de nuevo
                impulso.ImpulsoGancho();//Llamamos al script encargado del impulso
            }
        }
    }

}
