using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] audioSources;

    public void PlaySound(string soundName)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.name == soundName)
            {
                audioSource.Play();
                return;
            }
        }
    }
}
