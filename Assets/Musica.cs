using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour
{
    public AudioClip musicClip;
    private AudioSource musicSource;

    void Start()
    {
        // Obtener el AudioSource o añadirlo si no existe
        musicSource = GetComponent<AudioSource>();
        if (musicSource == null)
        {
            musicSource = gameObject.AddComponent<AudioSource>();
        }

        musicSource.clip = musicClip;
        musicSource.loop = true; // Establecer la música en bucle
        musicSource.Play();
    }
}
