using UnityEngine;
using UnityEngine.SceneManagement;
    public class PantallaGanadora : MonoBehaviour
    {
        // Se ejecuta al iniciar la escena
        void Start()
        {
            Debug.Log("FixPantallaInicio listo. Esperando botón...");
        }

        // Esta función es llamada por el botón desde el OnClick()
        public void IniciarJuego()
        {
            Debug.Log("Botón presionado. Cargando escena 1...");

            // Cargar la escena con índice 1
            SceneManager.LoadScene(1);
        }
    }
