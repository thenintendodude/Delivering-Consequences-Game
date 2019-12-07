using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: MonoBehaviour
{
    private Coroutine OutdoorFadeOut;
    private Coroutine IndoorFadeOut;

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
        indoor
    }
    public void ToggleMusic(MusicType musicType)
    {
        var outdoorMusic = GetAudioSourceByName("Outdoor Music");
        var indoorMusic = GetAudioSourceByName("Indoor Music");

        if (musicType == MusicType.indoor)
        {
            if (IndoorFadeOut != null)
            {
                // Stop a previous coroutine that was fading out the indoor music.
                StopCoroutine(IndoorFadeOut);
            }
            OutdoorFadeOut = StartCoroutine(StartFade(outdoorMusic, 1f, 0));
            indoorMusic.Play();
            StartCoroutine(StartFade(indoorMusic, 1f, 1));
        }
        else if (musicType == MusicType.outdoor)
        {
            if (OutdoorFadeOut != null)
            {
                // Stop a previous coroutine that was fading out the outdoor music.
                StopCoroutine(OutdoorFadeOut);
            }
            IndoorFadeOut = StartCoroutine(StartFade(indoorMusic, 1f, 0));
            outdoorMusic.Play();
            StartCoroutine(StartFade(outdoorMusic, 1f, 1));
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
