using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaRotacion : MonoBehaviour
{
    public float velocidadGiro = 100f; // La velocidad de giro de la moneda

    // Update is called once per frame
    void Update()
    {
        // Girar la moneda en el eje Y
        transform.Rotate(Vector3.up, velocidadGiro * Time.deltaTime);
    }
}
