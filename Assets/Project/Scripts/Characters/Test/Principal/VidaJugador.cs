using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    [Header("Configuración de Vida")]
    public int vidasMaximas = 3;
    private int vidasActuales;

    private bool estaMuerto = false;

    private void Start()
    {
        vidasActuales = vidasMaximas;
    }

    private void Update()
    {
        // Detectar si el jugador cayó fuera del área segura (por ejemplo, fue empujado)
        if (transform.position.x <= -1f && !estaMuerto)
        {
            Morir();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detectar colisión con obstáculo
        if (other.CompareTag("Obstaculo"))
        {
            PerderVida();
        }
    }

    private void PerderVida()
    {
        vidasActuales--;

        Debug.Log("Jugador perdió una vida. Vidas restantes: " + vidasActuales);

        if (vidasActuales <= 0)
        {
            Morir();
        }
        else
        {

        }
    }

    private void Morir()
    {
        estaMuerto = true;
        vidasActuales = 0;
        Debug.Log("💀 Jugador ha muerto");
    }
    public int ObtenerVidas()
    {
        return vidasActuales;
    }
}
