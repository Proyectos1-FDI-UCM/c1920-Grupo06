using UnityEngine;

public static class Metodos
{
    //Clase estática para métodos que puedan ser usados en varios scripts y que no haya necesidad de copiar el código varias veces

    /// <summary>
    /// Convierte un vector de vector 3 a vector 2 ignorando la z
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
        float angulo = Mathf.Atan(direccion.y / direccion.x) / Mathf.PI * 180;
        if (fin.x - inicio.x < 0)
            angulo += 180;
        return angulo;
    }
    /// <summary>
    /// Angulo en grados entre un punto y el cursor
    /// </summary>
    /// <param name="posicion"></param>
    /// <returns></returns>
    public static float Angulo_Posicion_Mouse(Vector2 posicion)
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direccion = Vector3toVector2(mouse) - posicion;
        float angulo = Mathf.Atan(direccion.y / direccion.x) / Mathf.PI * 180;
        if (mouse.x - posicion.x < 0)
            angulo += 180;
        return angulo;
    }

    /// <summary>
    /// Direccion en Vector3 entre el punto dado y el ratón
    /// </summary>
    /// <param name="posicion"></param>
    /// <returns></returns>
    public static Vector3 Direccion_Punto_Mouse(Vector3 posicion)
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direccion = mouse - posicion;
        return direccion;
    }
    public static float anguloConMando(out bool cambio)
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
    public static Vector3 DireccionMando()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        return new Vector3(horizontal, vertical); ;
    }

}
