using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance{get; private set;}
    
    [SerializeField] private float volume = .5f; 

    public void PlaySound(AudioClip _audioClip, Vector2 _position, float _volumeMultiplier = 1f)
    {
        AudioSource.PlayClipAtPoint(_audioClip, _position, volume * _volumeMultiplier);
    }
}
