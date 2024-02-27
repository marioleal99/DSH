using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JugadorBola : MonoBehaviour
{
    public Camera camara;
    public GameObject Suelo;
    private Vector3 offSet;
    private Vector3 DireccionActual;
    private float ValX;
    private float ValZ;
    public float velocidad=2;
    public GameObject premioPrefab;
    private int puntos = 0;
    public AudioClip sonidoMoneda;
    private AudioSource audioSource;
    public Text textoPuntos;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        audioSource.clip = sonidoMoneda; 
        CrearSueloInicial();
        DireccionActual = Vector3.forward;
        offSet = camara.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        camara.transform.position = transform.position + offSet;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CambiarDireccion();
        }
        transform.Translate(DireccionActual * velocidad * Time.deltaTime);
    }

    void CambiarDireccion()
    {
        if(DireccionActual==Vector3.forward)
        {
            DireccionActual = Vector3.right;
        }
        else
        {
            DireccionActual = Vector3.forward;
        }

    }

    private void OnCollisionExit(Collision other)
    {
        StartCoroutine(BorrarSuelo(other.gameObject));
    }

    IEnumerator BorrarSuelo(GameObject Suelo)
    {
        float aleatorio = Random.Range(0.0f, 1.0f);
        if(aleatorio>0.5f)
        {
            ValX += 6.0f;
        }
        else
        {
            ValZ += 6.0f;
        }

        Instantiate(Suelo, new Vector3(ValX, 0, ValZ), Quaternion.identity);
        if (Random.value > 0.5f) 
        {
            Instantiate(premioPrefab, new Vector3(ValX, 1, ValZ), Quaternion.identity);
        }
        yield return new WaitForSeconds(2);
        Suelo.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        Suelo.gameObject.GetComponent<Rigidbody>().useGravity=true;
        yield return new WaitForSeconds(2);
        Destroy(Suelo);


    }

    void CrearSueloInicial()
    {
        for(int i=0;i<3;i++)
        {
            ValZ += 6.0f;
            Instantiate(Suelo, new Vector3(ValX, 0, ValZ), Quaternion.identity);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Moneda"))
        {
            puntos++;
            textoPuntos.text = "Puntos: " + puntos.ToString();
            audioSource.PlayOneShot(sonidoMoneda);
            Destroy(other.gameObject);
        }
    }
}
