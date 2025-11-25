using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    private bool estaMuerto = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstaculo") && !estaMuerto)
        {
            Morir();
        }
    }

    private void Morir()
    {
        estaMuerto = true;
        Debug.Log("💀 Jugador ha muerto");

        // PASO CLAVE:
        // Buscamos el script "SistemaDePuntosYVida" en la escena y le decimos "MatarJugador"
        // Como ese script ya tiene los puntos y la UI, él se encargará de mostrar el texto correcto.

        SistemaDePuntosYVida sistema = FindObjectOfType<SistemaDePuntosYVida>();

        if (sistema != null)
        {
            sistema.MatarJugador();
        }
        else
        {
            Debug.LogError("¡No encontré el script SistemaDePuntosYVida en la escena!");
        }
    }
}