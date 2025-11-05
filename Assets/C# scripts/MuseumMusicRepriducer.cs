using UnityEngine;


public class MuseumMusicRepriducer : MonoBehaviour
{
    bool inArea = false;
    bool isPlaying;

    public AudioSource musica;

    // Update is called once per frame
    void Update()
    {
        if (inArea)
        {
            if (Input.GetKeyDown("e"))
            {
                if (isPlaying == false)
                {
                    musica.Play();
                    isPlaying = true;
                } 
                else
                {
                    musica.Stop();
                    isPlaying = false;
                }

            }
        }
    }

    void OnTriggerEnter() 
    {
        inArea = true;
    }

    void OnTriggerExit() 
    {
        inArea = false;
    }
}
