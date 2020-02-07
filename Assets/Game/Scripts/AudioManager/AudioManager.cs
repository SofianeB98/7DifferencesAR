using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioMixerGroup mixerGroup;

    public Sound[] sounds;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = s.sourceTransform.gameObject.AddComponent<AudioSource>();
            
            s.source.spatialize = s.spatialize;
            s.source.clip = s.clip;
            s.source.loop = s.loop;

            s.source.SetCustomCurve(AudioSourceCurveType.SpatialBlend, s.blendCurve);
            
            s.source.rolloffMode = AudioRolloffMode.Logarithmic;
            
            s.source.minDistance = s.minDistance;
            s.source.maxDistance = s.maxDistance;

            if (s.spatialize)
                s.source.spatialBlend = 1.0f;
            
            s.source.outputAudioMixerGroup = s.mixerGroup;
        }
    }

    public void Play(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

        s.source.Play();
    }

    public void PlayOneShot(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

        s.source.PlayOneShot(s.clip);
    }
    
    public void Stop(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Stop();
    }
}