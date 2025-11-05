using UnityEngine;
using System;
using System.Collections;

public class menu_audio : MonoBehaviour
{
    public AudioSource audioSource1; // Primo AudioSource per il primo audio
    public AudioSource audioSource2; // Secondo AudioSource per il secondo audio

    void Start()
    {
        // Avvia la riproduzione del primo audio
        audioSource1.Play();

        // Registra un evento che verrà chiamato al termine del primo audio
        StartCoroutine(WaitForFirstAudioToEnd());
    }

    private IEnumerator WaitForFirstAudioToEnd()
    {
        // Aspetta la fine del primo audio
        yield return new WaitForSeconds(audioSource1.clip.length);

        // Una volta finito, avvia il secondo audio in loop
        audioSource2.loop = true;
        audioSource2.Play();
    }
}

