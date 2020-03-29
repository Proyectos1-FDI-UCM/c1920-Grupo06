using UnityEngine;


/*Máquina de estados del jugador 
 * De los scripts más importantes de éste pues maneja la lógica y como se comportan todos los scripts
 * Los activa y desactiva según sea necesario
 */

//enum público que marca los estados posibles del jugador
public enum estado { Defecto, SlowMotion, LanzamientoGancho, MovimientoGancho, Dash, Muerte, Inactivo }
public class Estados : MonoBehaviour
{
    //Referencias de los componentes que van a ser modificados según el estado
    
    Rigidbody2D rb;
    BoxCollider2D deathzone;
    CrearGancho creaGancho;
    Movimiento movimiento;
    MovimientoGancho movimientoGancho;
    Salto salto;
    CrearDash crearDash;
    Dash dash;
    AnimacionesJugador animator;
    //enum que controla el estado
    estado estado_actual = estado.Defecto;

    
    float gravedad; //valor para saber cual es la gravedad original y no perder el valor
    private void Awake()
    {
        //Inicializar componentes
        rb = GetComponent<Rigidbody2D>();
        gravedad = rb.gravityScale;
        creaGancho = GetComponent<CrearGancho>();
        movimiento = GetComponent<Movimiento>();
        movimientoGancho = GetComponent<MovimientoGancho>();
        salto = GetComponent<Salto>();
        crearDash = GetComponent<CrearDash>();
        dash = GetComponent<Dash>();
        animator = GetComponent<AnimacionesJugador>();
        deathzone = Camera.main.GetComponentInChildren<BoxCollider2D>();

        ActualizaComponentes();//Inicializamos los scripts para estar preparados para el juego
    }
    public estado Estado() //Permite a otros métodos conocer el estado actual del jugador
    {
        return estado_actual;
    }

    public void CambioEstado(estado NuevoEstado) //Permite a otros métodos cambiar el estado del jugador
    {
        estado_actual = NuevoEstado;
        ActualizaComponentes();
        animator.CambioAnimacion(estado_actual);
    }
    private void ActualizaComponentes()
    {
        switch (estado_actual)
        {
            
            case estado.Defecto:
                deathzone.enabled = true;
                rb.gravityScale = gravedad;
                creaGancho.enabled = true;
                movimiento.enabled = true;
                movimientoGancho.enabled = false;
                salto.enabled = true;
                crearDash.enabled = true;

                break;
            case estado.SlowMotion:
                deathzone.enabled = true;
                creaGancho.enabled = true;
                movimiento.enabled = false;
                movimientoGancho.enabled = false;
                salto.enabled = false;
                crearDash.enabled = false;
                break;

            case estado.LanzamientoGancho:
                deathzone.enabled = true;
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0;
                creaGancho.enabled = false;
                movimiento.enabled = false;
                movimientoGancho.enabled = false;
                salto.enabled = false;
                crearDash.enabled = false;
                break;

            case estado.MovimientoGancho:
                deathzone.enabled = true;
                creaGancho.enabled = false;
                movimiento.enabled = false;
                movimientoGancho.enabled = true;
                salto.enabled = false;
                crearDash.enabled = false;
                break;
            case estado.Dash:
                deathzone.enabled = true;
                rb.gravityScale = 0;
                creaGancho.enabled = false;
                movimiento.enabled = false;
                movimientoGancho.enabled = false;
                salto.enabled = false;
                dash.enabled = true;
                crearDash.enabled = false;
                break;
            case estado.Muerte:
                deathzone.enabled = true;
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0;
                creaGancho.enabled = false;
                movimiento.enabled = false;
                movimientoGancho.enabled = false;
                salto.enabled = false;
                crearDash.enabled = false;
                break;
            case estado.Inactivo:
                deathzone.enabled = false;
                creaGancho.enabled = false;
                movimiento.enabled = false;
                movimientoGancho.enabled = false;
                salto.enabled = false;
                crearDash.enabled = false;
                break;
        }
    }
}
