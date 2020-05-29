using UnityEngine;

/* Máquina de estados del jugador 
 * Maneja la lógica y como se comportan todos los scripts
 * Los activa y desactiva según sea necesario
 */

//enum que marca los estados posibles del jugador
public enum estado { Defecto, SlowMotion, LanzamientoGancho, MovimientoGancho, Dash, Muerte, Inactivo, Knockback }
public class Estados : MonoBehaviour
{
    //referencias de los componentes que van a ser modificados según el estado
    Rigidbody2D rb;
    BoxCollider2D deathzone;
    CrearGancho creaGancho;
    Movimiento movimiento;
    MovimientoGancho movimientoGancho;
    Salto salto;
    CrearDash crearDash;
    Dash dash;
    AnimacionesJugador animator;
    estado estado_actual = estado.Defecto; //enum que controla el estado
    float gravedad; //valor para saber cual es la gravedad original y no perder el valor

    void Awake()
    {
        //inicialización de componentes
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

        ActualizaComponentes(); //inicializamos los scripts para estar preparados para el juego
    }

    public estado Estado() //Permite a otros métodos conocer el estado actual del jugador
    {
        return estado_actual;
    }

    public void CambioEstado(estado NuevoEstado) //método que permite cambiar el estado del jugador
    {
        estado_actual = NuevoEstado;
        ActualizaComponentes(); //actualizamos los componentes con respecto al nuevo estado
        animator.CambioAnimacion(estado_actual); //cambiamos la animación con respecto al nuevo estado
    }

    void ActualizaComponentes() //método que lleva la lógica de cada estado
    {
        switch (estado_actual)
        {
            case estado.Defecto: //estado por defecto 
                deathzone.enabled = true;
                rb.gravityScale = gravedad;
                creaGancho.enabled = true;
                movimiento.enabled = true;
                movimientoGancho.enabled = false;
                salto.enabled = true;
                crearDash.enabled = true;
                break;

            case estado.SlowMotion: //estado slowMotion (cuando se está apuntando para lanzar el gancho)
                deathzone.enabled = true;
                creaGancho.enabled = true;
                movimiento.enabled = false;
                movimientoGancho.enabled = false;
                salto.enabled = false;
                crearDash.enabled = false;
                break;

            case estado.LanzamientoGancho: //estado del propio lanzamiento de dicho gancho
                deathzone.enabled = true;
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0;
                creaGancho.enabled = false;
                movimiento.enabled = false;
                movimientoGancho.enabled = false;
                salto.enabled = false;
                crearDash.enabled = false;
                break;

            case estado.MovimientoGancho: //estdo del movimiento derivado de lanzar el gancho
                deathzone.enabled = true;
                creaGancho.enabled = false;
                movimiento.enabled = false;
                movimientoGancho.enabled = true;
                salto.enabled = false;
                crearDash.enabled = false;
                break;

            case estado.Dash: //estado de movimiento del dash
                deathzone.enabled = true;
                rb.gravityScale = 0;
                creaGancho.enabled = false;
                movimiento.enabled = false;
                movimientoGancho.enabled = false;
                salto.enabled = false;
                dash.enabled = true;
                crearDash.enabled = false;
                break;

            case estado.Muerte: //Estado de muerte
                deathzone.enabled = false;
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0;
                creaGancho.enabled = false;
                movimiento.enabled = false;
                movimientoGancho.enabled = false;
                salto.enabled = false;
                crearDash.enabled = false;
                break;

            case estado.Inactivo: //Estado inactivo
                deathzone.enabled = false;
                creaGancho.enabled = false;
                movimiento.enabled = false;
                movimientoGancho.enabled = false;
                salto.enabled = false;
                crearDash.enabled = false;
                break;

            case estado.Knockback:
                deathzone.enabled = true;
                movimiento.enabled = false;
                salto.enabled = false;
                crearDash.enabled = true;
                break;
        }
    }
}
