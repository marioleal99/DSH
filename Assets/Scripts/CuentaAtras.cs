using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CuentaAtras : MonoBehaviour
{
    public Button boton;
    public Image imagen;
    public Sprite[] numeros;
    public AudioClip musica; // Agrega esta línea para referenciar tu música
    private AudioSource audioSource; // Referencia al AudioSource

    // Start is called before the first frame update
    void Start()
    {
        // Encuentra o asigna el AudioSource en la escena
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) // Si no se encuentra, añádelo
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        
        // Asigna la música al AudioSource
        audioSource.clip = musica;

        boton.onClick.AddListener(Empezar);
    }

    void Empezar()
    {
        imagen.gameObject.SetActive(true);
        boton.gameObject.SetActive(false);

        StartCoroutine(CuentaAtrass());
    }

    IEnumerator CuentaAtrass()
    {
        // Reproduce la música
        audioSource.Play();

        for(int i = 0; i < numeros.Length; i++)
        {
            imagen.sprite = numeros[i];
            yield return new WaitForSeconds(1);
        }
        
        // Detiene la música
        yield return new WaitForSeconds(1);
        audioSource.Stop();
        SceneManager.LoadScene("Nivel1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

