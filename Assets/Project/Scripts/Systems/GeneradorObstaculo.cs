using UnityEngine;

namespace Kart
{
    public class GeneradorObstaculo : MonoBehaviour
    {
        public GameObject[] obstaculos;  // Array de prefabs de obstáculos (por ahora solo 1)
        public float intervaloSpawn = 2f; // Tiempo entre spawns
        public float spawnX = 0f;         // Posición fija en X
        public float spawnZ = 0f;         // Posición fija en Z (opcional, puedes variar si quieres carriles)
        public float spawnY = 0f;         // Altura donde aparece el obstáculo

        int indiceAleatorio = 0;

        private float[] posicionesZ = { 5f, 0f, -5f };
        void Start()
        {
            spawnX = 29.12f;
            spawnY = 0;
            InvokeRepeating(nameof(SpawnObstaculo), 2f, intervaloSpawn);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        private void SpawnObstaculo()
        {
            if (obstaculos.Length == 0)
            {
                Debug.LogWarning("No hay obstáculos asignados en el array.");
                return;
            }

            // Por ahora solo hay uno, luego podemos usar Random o switch para los 5 tipos
            int tipoObstaculo = 0;

            switch (tipoObstaculo)
            {
                case 0:
                    // Obstáculo 1
                    int indiceAleatorio = Random.Range(0, posicionesZ.Length);
                    // Obtener la posición Z correspondiente
                    float spawnZ = posicionesZ[indiceAleatorio];
                    Instantiate(obstaculos[1], new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
                    break;

                    // Aquí agregaremos los otros 4 obstáculos cuando los tengas
                    // case 1: Instantiate(obstaculos[1], new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity); break;
                    // case 2: ...
                    // case 3: ...
                    // case 4: ...
            }
        }
    }
}
