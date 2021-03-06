﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private Coroutine MusicFadingOutCoroutine;
    private AudioSource MusicFadingOut;
    private AudioSource CurrentMusicPlaying;

    private AudioSource OutdoorMusic;
    private AudioSource IndoorMusic;

    private AudioSource OpenDoor;
    private AudioSource CloseDoor;
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

        OpenDoor = GetAudioSourceByName("Open Door");
        CloseDoor = GetAudioSourceByName("Close Door");
        UIConfirmation = GetAudioSourceByName("UI Confirmation");

        CurrentMusicPlaying = IndoorMusic;
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
            case SoundEffect.uiConfirmation:
                UIConfirmation.Play();
                break;
        }
    }

    public void ToggleMusic(Music music)
    {
        AudioSource musicToPlay = ConvertToAudioSource(music);

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

    private AudioSource ConvertToAudioSource(Music music)
    {
        if (music == Music.indoor)
        {
            return IndoorMusic;
        }
        else
        {
            return OutdoorMusic;
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

public enum SoundEffect
{
    openDoor,
    closeDoor,
    uiConfirmation
}

public enum Music
{
    outdoor,
    indoor,
}

