using UnityEngine;

public class ControlColorCielo : MonoBehaviour
{
    public MeshRenderer rendererCielo;

    public Gradient gradienteCielo;
    [Range(0f, 1f)]
    public float tiempoDelDia = 1f;
    public float intensidadHDR = 20.0f;

    private Material _materialCielo;

    void Start()
    {
        _materialCielo = rendererCielo.material;

        _materialCielo.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        //Debug.Log("Tiempo día: " + tiempoDelDia);

        Color colorCielo = gradienteCielo.Evaluate(tiempoDelDia);
        Color colorHDR = colorCielo * Mathf.Pow(2, intensidadHDR);

        _materialCielo.SetColor("_EmissionColor", colorHDR);
    }
}
