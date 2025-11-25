using UnityEngine;

public class ControladorPantallaControles : MonoBehaviour
{
    public float tiempoVisible = 4f;        // Tiempo antes de empezar a desvanecer
    public float duracionFade = 1.5f;       // Duración del fade-out

    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            Debug.LogError("❌ Este objeto necesita un CanvasGroup para el fade-out.");
            return;
        }

        // Iniciar el proceso
        StartCoroutine(FadeOutControles());
    }

    private System.Collections.IEnumerator FadeOutControles()
    {
        // 1. Esperar los segundos visibles
        yield return new WaitForSeconds(tiempoVisible);

        // 2. Animar la opacidad
        float t = 0f;

        while (t < duracionFade)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t / duracionFade);
            yield return null;
        }

        canvasGroup.alpha = 0f;

        // 3. Desactivar el objeto para limpiar pantalla
        gameObject.SetActive(false);
    }
}
