using NUnit.Framework;
using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class AudioManager:MonoBehaviour
{
    [SerializeField] List<AudioValue> AudioData;
    [SerializeField] AudioSource soundAudioSource;
    [SerializeField] AudioSource musicAudioSource;
    private void OnValidate()
    {
        if (soundAudioSource == null || musicAudioSource == null)
        {
            Debug.LogError("Audio manager has no audio sources!");
        }
    }

    public void PlaySound(string audioName)
    {
        var audioClip = GetAudioClip(audioName);


        if (audioClip != null)
        {
            if (audioClip.randomPitched)
            {
                soundAudioSource.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
                soundAudioSource.PlayOneShot(audioClip.audioClip);
                soundAudioSource.pitch = 1;
                return;
            }

            soundAudioSource.PlayOneShot(audioClip.audioClip);
        }
    }

    public float SoundDuration(string audioName)
    {
        var audioClip = GetAudioClip(audioName);


        if (audioClip != null)
        {
            return audioClip.audioClip.length;

        }

        return 0f;
    }
    public void PlayMusic(string audioName, bool looped)
    {
        var audioClip = GetAudioClip(audioName);

        if(audioClip!=null)
        {
            musicAudioSource.Stop();
            musicAudioSource.loop = looped;
            musicAudioSource.clip = audioClip.audioClip;
            musicAudioSource.Play();
        }


    }


    AudioValue GetAudioClip(string name)
    {
        foreach (var audio in AudioData)
        {
            if(audio.audioName == name)
                return audio;
        }

        return null;
    }

}
