using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Movimiento : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveDirection; // movimiento total (x, y, z)
    private Vector3 targetPosition; // posición objetivo para los carriles
    Vector3 posicionX;

    [Header("Configuración de Movimiento")]
    public float velocidadCarril = 10f; // velocidad de cambio de carril
    private int posicionLinea = 1; // 0 = Izquierda, 1 = Centro, 2 = Derecha

    // ------------------------
    private float[] posicionesZ = { 5f, 0f, -5f }; // posiciones de los carriles
    // ------------------------

    [Header("Configuración de Salto y Gravedad")]
    public float fuerzaSalto = 0f;
    public float gravedad = 0f;
    private float velocidadVertical; // almacena la velocidad en Y

    // ------------------------
    // Detección del suelo
    public Transform puntoChequeo; // punto desde donde lanzar el rayo (por ejemplo, entre los pies)
    public float distanciaChequeo = 0.5f;
    public LayerMask capaSuelo;
    public bool enSuelo;
    // ------------------------

    private bool enRampa;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        gravedad = 100f;
        fuerzaSalto = 28;
        targetPosition = transform.position;
        velocidadVertical = -1f;

        enRampa = false;

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(puntoChequeo.position, puntoChequeo.position + Vector3.down * distanciaChequeo);
    }


    private void Update()
    {
        //velocidadVertical = -1f;
   
        
        // Calcula la posición objetivo en el eje Z (para moverse entre carriles)
        float targetZ = posicionesZ[posicionLinea];
        targetPosition = new Vector3(transform.position.x, transform.position.y, targetZ);

        // Mueve suavemente hacia el carril objetivo
        Vector3 nuevaPos = Vector3.MoveTowards(transform.position, targetPosition, velocidadCarril * Time.deltaTime);
        // ------------------------

        // --- SALTO Y GRAVEDAD ---
        // ------------------------
        // Detección del suelo
        enSuelo = Physics.Raycast(puntoChequeo.position, Vector3.down, distanciaChequeo, capaSuelo);
        // ------------------------


        // Detección del suelo
        enSuelo = Physics.Raycast(puntoChequeo.position, Vector3.down, distanciaChequeo, capaSuelo);

        if (enSuelo && velocidadVertical < 0)
        {
            velocidadVertical = -2f; // valor pequeño para mantener al jugador en el suelo
        }

        // Movimiento entre carriles
        if (enSuelo)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                posicionLinea = Mathf.Max(0, posicionLinea - 1);
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                posicionLinea = Mathf.Min(2, posicionLinea + 1);
            }

            // Salto
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocidadVertical = fuerzaSalto;
            }
        }
        else
        {
            // Aplicar gravedad
            velocidadVertical -= gravedad * Time.deltaTime;
        }

        // Movimiento final
        Vector3 movimientoLateral = Vector3.forward * ((posicionesZ[posicionLinea] - transform.position.z) * velocidadCarril * Time.deltaTime);
        Vector3 movimientoVertical = Vector3.up * velocidadVertical * Time.deltaTime;
        controller.Move(movimientoLateral + movimientoVertical);

        // Mantener X = 0 si está en rampa
        if (enRampa)
        {
            Vector3 pos = transform.position;
            pos.x = 0f;
            transform.position = pos;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rampa"))
        {
            enRampa = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Rampa"))
        {
            enRampa = false;
        }
    }
}
