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

    private AudioSource OpenDoor;
    private AudioSource CloseDoor;
    private AudioSource MadeProgress;
    private AudioSource BeatTheGame;
    private AudioSource UIConfirmation;

    /// Gets the shared instance of AudioManager
    public static AudioManager Get()
    {
        return GameObject.FindWithTag("audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        OutdoorMusic = GetAudioSourceByName("Outdoor Music");
        IndoorMusic = GetAudioSourceByName("Indoor Music");
        MainMenuMusic = GetAudioSourceByName("Main Menu Music");
        OpenDoor = GetAudioSourceByName("Open Door");
        CloseDoor = GetAudioSourceByName("Close Door");
        MadeProgress = GetAudioSourceByName("Made Progress");
        BeatTheGame = GetAudioSourceByName("Beat The Game");
        UIConfirmation = GetAudioSourceByName("UI Confirmation");

        CurrentMusicPlaying = OutdoorMusic;
    }

    private AudioSource GetAudioSourceByName(string name)
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

    public void TriggerSoundEffect(SoundEffect soundEffect)
    {
        switch (soundEffect)
        {
            case SoundEffect.openDoor:
                OpenDoor.Play();
                break;
            case SoundEffect.closeDoor:
                CloseDoor.Play();
                break;
            case SoundEffect.madeProgress:
                MadeProgress.Play();
                break;
            case SoundEffect.beatTheGame:
                BeatTheGame.Play();
                break;
            case SoundEffect.uiConfirmation:
                UIConfirmation.Play();
                break;
        }
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
    private IEnumerator Fade(AudioSource audioSource, float duration, float newVolume)
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
public enum SoundEffect
{
    openDoor,
    closeDoor,
    madeProgress,
    beatTheGame,
    uiConfirmation
}

public enum MusicType
{
    outdoor,
    indoor,
    mainMenu
}