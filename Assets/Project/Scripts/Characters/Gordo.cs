using UnityEngine;
using System.Collections; // <--- Necesario para IEnumerator

[RequireComponent(typeof(Rigidbody))]
public class Gordo : MonoBehaviour
{
    public Transform objetivo;
    public float suavizado = 2f;

    [Header("Configuración de Carriles")]
    public float xNormal = -3.34f; // Posición de descanso
    public float xAtaque = -1f;     // Posición para molestar al jugador

    [Header("Tiempos")]
    public float tiempoEnNormal = 10f;
    public float tiempoEnAtaque = 4f;

    private float xObjetivoActual;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        xObjetivoActual = xNormal;

        StartCoroutine(RutinaDeAtaque());
    }

    // Esta es la corrutina que maneja los tiempos
    IEnumerator RutinaDeAtaque()
    {
        // while(true) crea un bucle infinito que durará mientras el objeto exista
        while (true)
        {
            xObjetivoActual = xNormal;
            yield return new WaitForSeconds(tiempoEnNormal);

            xObjetivoActual = xAtaque;
            yield return new WaitForSeconds(tiempoEnAtaque);

        }
    }

    void FixedUpdate()
    {
        if (objetivo == null) return;

        float destinoX = xObjetivoActual;

        float destinoY = objetivo.position.y;
        float destinoZ = objetivo.position.z;

        Vector3 posicionObjetivo = new Vector3(destinoX, destinoY, destinoZ);

        // El Lerp se encargará de suavizar la transición cuando xObjetivoActual cambie de golpe
        Vector3 siguientePosicion = Vector3.Lerp(
            rb.position,
            posicionObjetivo,
            Time.fixedDeltaTime * suavizado
        );

        rb.MovePosition(siguientePosicion);
    }
}