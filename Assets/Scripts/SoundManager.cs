using UnityEngine;

using System.Collections;
using System.Collections.Generic;


public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Audio Sources")]
    public AudioSource shootingSoundM4; // Reference to an AudioSource for the shooting sound

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Ensure only one SoundManager instance exists
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
    }
}