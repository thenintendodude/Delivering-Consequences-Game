using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: MonoBehaviour
{
    public static AudioSource GetAudioSourceByName(string name)
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
    public static void ToggleMusic(MusicType musicType)
    {
        if (musicType == MusicType.indoor)
        {
            GetAudioSourceByName("Indoor Music").Play();
            GetAudioSourceByName("Outdoor Music").Stop();
        }
        else
        {
            GetAudioSourceByName("Outdoor Music").Play();
            GetAudioSourceByName("Indoor Music").Stop();

        }
    }
}
