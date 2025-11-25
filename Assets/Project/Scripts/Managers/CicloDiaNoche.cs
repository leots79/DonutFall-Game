using UnityEngine;
    public class CicloDiaNoche : MonoBehaviour
    {
        float gradosPorSegundo;

        private void Start()
        {
            gradosPorSegundo = 5;
            transform.localRotation = Quaternion.Euler(57.88f, 0, 0);
        }

        private void Update()
        {
            transform.Rotate(Vector3.right * (-gradosPorSegundo * Time.deltaTime) * 3);
        }
    }
