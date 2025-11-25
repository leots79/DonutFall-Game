using UnityEngine;

public class GeneradorEscenario : MonoBehaviour
{
    [Header("Configuración del escenario")]
    public GameObject prefabEscenario;
    public float puntoInstanciaX = -21f;          // cuando el escenario llegue aquí, se crea otro
    public float posicionAparicionX = 96.9f;      // aquí aparecerán todos los nuevos escenarios

    private GameObject ultimoEscenario;

    void Start()
    {
        // Primer escenario colocado manualmente en escena con la tag "Escenario"
        ultimoEscenario = GameObject.FindWithTag("Escenario");
    }

    void Update()
    {
        if (ultimoEscenario == null)
            return;

        // Detecta cuando debe crearse el siguiente
        if (ultimoEscenario.transform.position.x <= puntoInstanciaX)
        {
            CrearNuevoEscenario();
        }
    }

    private void CrearNuevoEscenario()
    {
        // Usamos la misma Y y Z del último escenario,
        // pero lo colocamos en X = 96.9
        Vector3 nuevaPosicion = new Vector3(posicionAparicionX, ultimoEscenario.transform.position.y, ultimoEscenario.transform.position.z
        );

        GameObject nuevo = Instantiate(prefabEscenario, nuevaPosicion, Quaternion.Euler(0, -90, 0)
        );

        ultimoEscenario = nuevo;
    }
}
