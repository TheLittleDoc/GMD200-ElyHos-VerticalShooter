using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    public AudioClip[] music;
    public AudioSource musicSource, soundEffects;
    private int currentTrack = 0;
    private bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayMusic());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayMusic()
    {
        isPlaying = true;
        musicSource.volume = 1;
        musicSource.PlayOneShot(music[currentTrack]);
        while (isPlaying)
        {
            
            
            yield return new WaitForSeconds(29.5392f);
            musicSource.PlayOneShot(music[currentTrack]);
        }
    }

    public void StopMusic()
    {
        //fade music out 

        StartCoroutine(FadeOut(musicSource, 100));

    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    public void PlaySoundEffect(int trackNumber)
    {
        soundEffects.PlayOneShot(music[trackNumber]);
    }
}
