using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: MonoBehaviour
{
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
            StartCoroutine(StartFade(outdoorMusic, 1f, 0));
            StartCoroutine(StartFade(indoorMusic, 1f, 1));
        }
        else if (musicType == MusicType.outdoor)
        {
            StartCoroutine(StartFade(indoorMusic, 1f, 0));
            StartCoroutine(StartFade(outdoorMusic, 1f, 1));
        }
    }
    private IEnumerator StartFade(AudioSource audioSource, float duration, float newVolume)
    {
        float currentTime = 0;
        float startVolume = audioSource.volume;

        if (newVolume == 1)
        {
            audioSource.Play();
        }
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
