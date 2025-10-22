using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovimientoObstaculos : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Configuración del Movimiento")]
    public float velocidad = 10f;    // Velocidad de movimiento hacia el jugador (eje X)
    public float limiteX = 0f;      // Límite para destruir el obstáculo
    public bool destruirAlSalir = true; // Si true, destruye el obstáculo cuando pasa el límite

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Hacemos que el Rigidbody sea kinematic para moverlo manualmente
        rb.isKinematic = true;
        limiteX = -25f;
    }

    private void FixedUpdate()
    {
        // Movimiento constante hacia el jugador (eje X negativo)
        Vector3 movimiento = Vector3.left * velocidad * Time.fixedDeltaTime;

        // Movemos el Rigidbody usando MovePosition para mantener las colisiones
        rb.MovePosition(rb.position + movimiento);

        // Destruir el obstáculo si pasa el límite
        if (rb.position.x <= limiteX)
        {
            Destroy(gameObject);
        }
    }
}
