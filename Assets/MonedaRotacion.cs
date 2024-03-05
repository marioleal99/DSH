using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaRotacion : MonoBehaviour
{
    public float velocidadGiro = 100f; // La velocidad de giro de la moneda
    public GameObject particulas;

    // Update is called once per frame
    void Update()
    {
        // Girar la moneda en el eje Y
        transform.Rotate(Vector3.up, velocidadGiro * Time.deltaTime);
    }

    void OnDestroy ()
    {
        Vector3 posactual = new Vector3 (transform.position.x, 2, transform.position.z);
        Instantiate (particulas, posactual, particulas.transform.rotation);
    }

}
