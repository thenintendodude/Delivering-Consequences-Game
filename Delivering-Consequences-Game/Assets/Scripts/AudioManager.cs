using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: MonoBehaviour
{
    private Coroutine MusicFadingOutCoroutine;
    private AudioSource MusicFadingOut;
    private AudioSource CurrentMusicPlaying;

    private AudioSource OutdoorMusic;
    private AudioSource IndoorMusic;
    private AudioSource MainMenuMusic;

    private void Start()
    {
        OutdoorMusic = GetAudioSourceByName("Outdoor Music");
        IndoorMusic = GetAudioSourceByName("Indoor Music");
        MainMenuMusic = GetAudioSourceByName("Main Menu Music");

        CurrentMusicPlaying = OutdoorMusic;
    }

    public AudioSource GetAudioSourceByName(string name)
    {
        var audioObject = GameObject.FindWithTag("audio");
        Transform childTrans = audioObject.transform.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject.GetComponent<AudioSource>();
        }
        else
        {
            return null;
        }
    }

    public enum MusicType {
        outdoor,
        indoor,
        mainMenu
    }

    public void ToggleMusic(MusicType musicType)
    {
        AudioSource musicToPlay = ConvertToAudioSource(musicType);

        if (musicToPlay == MusicFadingOut)
        {
            // Stop a previous coroutine if it was still fading out the music we're about to play again.
            StopCoroutine(MusicFadingOutCoroutine);
        }

        MusicFadingOutCoroutine = StartCoroutine(StartFade(CurrentMusicPlaying, 1f, 0));
        MusicFadingOut = CurrentMusicPlaying;

        musicToPlay.Play();
        CurrentMusicPlaying = musicToPlay;
        StartCoroutine(StartFade(musicToPlay, 1f, 1));





        //{
        //    if (IndoorFadeOut != null)
        //    {
        //        // Stop a previous coroutine that was fading out the indoor music.
        //        StopCoroutine(IndoorFadeOut);
        //    }
        //    var musicFadeOut = StartCoroutine(StartFade(CurrentMusicPlaying, 1f, 0));
        //    SetWhichMusicIsFadingOut(musicFadeOut);
        //    IndoorMusic.Play();
        //    StartCoroutine(StartFade(IndoorMusic, 1f, 1));
        //    CurrentMusicPlaying = IndoorMusic;
        //}
        //else if (musicType == MusicType.outdoor)
        //{
        //    if (OutdoorFadeOut != null)
        //    {
        //        // Stop a previous coroutine that was fading out the outdoor music.
        //        StopCoroutine(OutdoorFadeOut);
        //    }
        //    IndoorFadeOut = StartCoroutine(StartFade(IndoorMusic, 1f, 0));
        //    OutdoorMusic.Play();
        //    StartCoroutine(StartFade(OutdoorMusic, 1f, 1));
        //}
        //else if (musicType == MusicType.mainMenu)
        //{

        //}

    }

    private AudioSource ConvertToAudioSource(MusicType musicType)
    {
        if (musicType == MusicType.indoor)
        {
            return IndoorMusic;
        }
        else if (musicType == MusicType.outdoor)
        {
            return OutdoorMusic;
        }
        else
        {
            return MainMenuMusic;
        }
    }

    private IEnumerator StartFade(AudioSource audioSource, float duration, float newVolume)
    {
        float currentTime = 0;
        float startVolume = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, newVolume, currentTime / duration);
            yield return null;
        }
        if (newVolume == 0)
        {
            audioSource.Stop();
        }
        yield break;
    }
}
