using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioMixerGroup mixerGroup;
    
    [Header("Sound information")]
    public string name;
    public AudioClip clip;
    public Transform sourceTransform;
    public bool loop = false;
    public bool spatialize = true;

    [Header("3D settings")]
    public AnimationCurve blendCurve;
    public float maxDistance = 10.0f;
    public float minDistance = 0.1f;
    
    [Header("Volume information")]
    [Range(0f, 1f)] public float volume = .75f;
    [Range(0f, 1f)] public float volumeVariance = .1f;

    [Header("Pitch information")]
    [Range(.1f, 3f)] public float pitch = 1f;
    [Range(0f, 1f)] public float pitchVariance = .1f;

    [HideInInspector]
    public AudioSource source;
}