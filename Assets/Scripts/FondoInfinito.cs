using UnityEngine;

public class FondoInfinito : MonoBehaviour
{
    public Transform Fondo1;
    public Transform Fondo2;
    public float velocidad = 2f;
    public Camera cam;

    private float ancho;

    void Start()
    {
        ancho = Fondo1.GetComponent<MeshRenderer>().bounds.size.x;
        Fondo2.position = Fondo1.position + Vector3.right * ancho;
    }

    void Update()
    {
        Fondo1.position += Vector3.left * velocidad * Time.deltaTime;
        Fondo2.position += Vector3.left * velocidad * Time.deltaTime;

        float camX = cam.transform.position.x;

        if (Fondo1.position.x < camX - ancho)
            Fondo1.position = Fondo2.position + Vector3.right * ancho;

        if (Fondo2.position.x < camX - ancho)
            Fondo2.position = Fondo1.position + Vector3.right * ancho;
    }
}