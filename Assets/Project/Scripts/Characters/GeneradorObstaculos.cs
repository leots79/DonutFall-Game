using UnityEngine;
using System.Collections.Generic;

public class GeneradorObstaculos : MonoBehaviour
{
    public float tiempoEntreFilas = 2f;
    public float distanciaZ = 100f;

    // Prefabs Obstaculos y Caminos seguros
    public GameObject[] prefabBlockers;
    public GameObject[] prefabSafePaths;

    public float[] posicionesZ = { 5f, 0f, -5f };
    float spawnX = 75f;
    float spawnY = 0f;
    void Start()
    {
        InvokeRepeating(nameof(GenerarFila), 0f, tiempoEntreFilas);
    }

    private void GenerarFila()
    {
        int blockerContador = Random.Range(1,3);

        List<int> filaLogica = new List<int>();

        for (int i = 0; i < blockerContador; i++)
        {
            filaLogica.Add(1);
        }

        while (filaLogica.Count < 3)
        {
            filaLogica.Add(0);
        }

        RevolverLista(filaLogica);

        for (int i = 0; i < filaLogica.Count; i++)
        {
            Vector3 posicionSpawn = new Vector3(spawnX, spawnY, posicionesZ[i]);

            if (filaLogica[i] == 1)
            {
                GameObject prefab = prefabBlockers[Random.Range(0, prefabBlockers.Length)];
                if (prefab != null)
                {
                    Instantiate(prefab, posicionSpawn, Quaternion.identity);
                }
            }
            else
            {
                GameObject prefab = prefabSafePaths[Random.Range(0, prefabSafePaths.Length)];
                if (prefab != null)
                {
                    Instantiate(prefab, posicionSpawn, Quaternion.identity);
                }
            }
        }
    }

    private void RevolverLista<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
    void Update()
    {
        
    }
}