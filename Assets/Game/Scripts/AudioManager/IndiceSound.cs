using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class IndiceSound : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float volume;
    [SerializeField] [Range(0, 20)] private float MaxDistance;

    [SerializeField] private Transform camPos;
    [SerializeField] [Range(0.0f, 1.0f)] private float minVolume = 0.2f;
    [SerializeField] private AudioSource indiceAudioSource;

    private List<ErrorLinker> linkers;

    public void StartIndiceSound()
    {
        if (linkers == null || linkers.Count == 0)
        {
            linkers = new List<ErrorLinker>();
            linkers = GameObject.FindObjectsOfType<ErrorLinker>().ToList();
        }

        float minDistance = float.MaxValue;
        foreach (var item in ErrorManager.Instance.Errors)
        {
            if (item.IsChecked)
            {
                continue;
            }

            var dist = Vector3.Distance(camPos.position, item.gameObject.transform.position);
            if (dist < minDistance)
            {
                minDistance = dist;
            }
        }

        foreach (var item in linkers)
        {
            if (item.linkedError.IsChecked)
            {
                continue;
            }

            var dist = Vector3.Distance(camPos.position, item.gameObject.transform.position);
            if (dist < minDistance)
            {
                minDistance = dist;
            }
        }

        float t = Mathf.Clamp(minDistance / MaxDistance, 0, 1);
        this.volume = Mathf.Lerp(this.minVolume, 1.0f, 1 - t);
        Debug.Log("Volume = " + this.volume);
        Debug.Log("Distance = " + minDistance);
        Debug.Log("Coef = " + (1 - t));

        if (this.indiceAudioSource != null)
        {
            this.indiceAudioSource.volume = this.volume;
            this.indiceAudioSource.Play();
        }
        else
        {
            Debug.Log("Il n'y a pas d'audio source assigné à l'indice");
        }
    }
}