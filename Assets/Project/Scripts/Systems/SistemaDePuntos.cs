using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Necesario para recargar la escena

public class SistemaDePuntosYVida : MonoBehaviour
{
    [Header("Puntuación")]
    public float puntosPorSegundo = 1000f;
    public Text textoPuntuacion;
    private float puntos;

    [Header("Pantalla de Muerte")]
    public GameObject pantallaMuerte;
    public Text textoPuntuacionFinal;

    [Header("Audio del Juego")]
    public AudioSource musicaFondo;

    private bool jugadorMuerto = false;
    private bool juegoPausado = false;
    private bool muteManual = false;

    void Start()
    {
        if (pantallaMuerte != null)
            pantallaMuerte.SetActive(false);

        // Aseguramos que el tiempo corra al empezar (por seguridad)
        Time.timeScale = 1f;
    }

    void Update()
    {
        // --- Pausar/Reanudar ---
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!juegoPausado) PausarJuego();
            else ReanudarJuego();
        }

        // --- Mutear/Desmutear ---
        if (Input.GetKeyDown(KeyCode.M))
        {
            muteManual = !muteManual;
            if (!juegoPausado && !jugadorMuerto)
                AudioListener.volume = muteManual ? 0f : 1f;
        }

        if (juegoPausado || jugadorMuerto)
            return;

        puntos += puntosPorSegundo * Time.deltaTime;

        if (textoPuntuacion != null)
            textoPuntuacion.text = "Metros: " + Mathf.FloorToInt(puntos).ToString("N0");

        if (puntos >= 1000f)
        {
            SceneManager.LoadScene(2);
        }
    }

    // --------------------------------------------------------------------
    //  MUERTE DEL JUGADOR
    // --------------------------------------------------------------------
    public void MatarJugador()
    {
        if (jugadorMuerto) return;

        jugadorMuerto = true;

        // Detener tiempo
        Time.timeScale = 0f;

        // Detener música
        if (musicaFondo != null)
            musicaFondo.Pause();

        // Silenciar todo
        AudioListener.volume = 0f;

        // Mostrar UI
        if (pantallaMuerte)
            pantallaMuerte.SetActive(true);

        if (textoPuntuacionFinal)
            textoPuntuacionFinal.text = "Puntaje final: " + Mathf.FloorToInt(puntos).ToString("N0");
    }

    // --------------------------------------------------------------------
    //  PAUSAR / REANUDAR
    // --------------------------------------------------------------------
    void PausarJuego()
    {
        juegoPausado = true;
        Time.timeScale = 0f;

        if (musicaFondo != null) musicaFondo.Pause();
        AudioListener.volume = 0f;
    }

    void ReanudarJuego()
    {
        juegoPausado = false;
        Time.timeScale = 1f;

        if (musicaFondo != null) musicaFondo.UnPause();

        // Restauramos el volumen según si el usuario lo tenía muteado o no
        AudioListener.volume = muteManual ? 0f : 1f;
    }

    // --------------------------------------------------------------------
    //  REINICIAR LA PARTIDA (CARGAR ESCENA DE NUEVO)
    // --------------------------------------------------------------------
    public void ReiniciarPartida()
    {
        Time.timeScale = 1f;

        AudioListener.volume = muteManual ? 0f : 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}