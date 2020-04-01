using UnityEngine;

//Clase estática para métodos que puedan ser usados en varios scripts

public static class Metodos
{

    /// <summary>
    /// Convierte un vector de Vector3 a Vector2 ignorando la 'z'
    /// </summary>
    /// <param name="vectorOriginal"></param>
    /// <returns></returns>
    public static Vector2 Vector3toVector2(Vector3 vectorOriginal)
    {
        return new Vector2(vectorOriginal.x, vectorOriginal.y);
    }

    /// <summary>
    /// Angulo en grados entre dos puntos
    /// </summary>
    /// <param name="inicio"></param>
    /// <param name="fin"></param>
    /// <returns></returns>
    public static float AnguloPuntos(Vector2 inicio, Vector2 fin)
    {
        Vector2 direccion = fin - inicio;
        //calculamos el ángulo en base a la dirección del vector
        float angulo = Mathf.Atan(direccion.y / direccion.x) / Mathf.PI * 180;
        if (fin.x - inicio.x < 0) //si el ángulo es mayor de 180º, lo añadimos
            angulo += 180;
        return angulo;
    }

    /// <summary>
    /// Angulo en grados entre un punto y el cursor
    /// </summary>
    /// <param name="posicion"></param>
    /// <returns></returns>
    public static float AnguloPosicionRaton(Vector2 posicion)
    {
        Vector3 raton = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //calculamos la direccion con respecto al jugador y el punto presionado
        Vector2 direccion = Vector3toVector2(raton) - posicion;
        float angulo = Mathf.Atan(direccion.y / direccion.x) / Mathf.PI * 180;
        if (raton.x - posicion.x < 0) //si el ángulo es mayor de 180º, lo añadimos
            angulo += 180;
        return angulo;
    }

    /// <summary>
    /// Direccion en Vector3 entre el punto dado y el ratón
    /// </summary>
    /// <param name="posicion"></param>
    /// <returns></returns>
    public static Vector3 DireccionPuntoRaton(Vector3 posicion)
    {
        Vector3 raton = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direccion = raton - posicion;
        return direccion;
    }

    //calculo del ángulo al utilizar el mando
    public static float AnguloConMando(out bool cambio)
    {
        cambio = true;
        float angulo = 0;
        float vertical = Input.GetAxis("VerticalMando");
        float horizontal = Input.GetAxis("HorizontalMando");

        if (horizontal != 0 || vertical != 0)
            angulo = Mathf.Atan(vertical / horizontal) * 180 / Mathf.PI;
        else cambio = false;
        if (horizontal < 0) angulo += 180;
        return angulo;
    }

    //vector dirección de apuntado del mando
    public static Vector3 DireccionMando()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        return new Vector3(horizontal, vertical);
    }
}
