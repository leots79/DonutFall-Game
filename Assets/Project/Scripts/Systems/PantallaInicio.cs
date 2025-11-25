using UnityEngine;

public class PantallaInicio : MonoBehaviour
{
    public GameObject pantallaInicio;      // El panel o canvas de inicio
    public GameObject hudOctavioCorrelon;  // Tu HUD que debe ocultarse

    void Start()
    {
        Time.timeScale = 0f;

        pantallaInicio.SetActive(true);

        hudOctavioCorrelon.SetActive(false);
    }

    public void IniciarJuego()
    {
        // Ocultar pantalla de inicio
        pantallaInicio.SetActive(false);

        // Activar HUD
        hudOctavioCorrelon.SetActive(true);

        // Reactivar el tiempo del juego
        Time.timeScale = 1f;
    }
}
