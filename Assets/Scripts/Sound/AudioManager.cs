using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sound;
    void Awake()
    {
        for (int i = 0; i < sound.Length; i++)
        {
            sound[i].source = gameObject.AddComponent<AudioSource>();
            sound[i].source.clip = sound[i].clip;
            sound[i].source.volume = sound[i].volume;
            sound[i].source.pitch = sound[i].pitch;
            sound[i].source.loop = sound[i].loop;
        }
    }
    public void Play()// Plays the audio
    {
        foreach(Sound s in sound)
            s.source.Play();
    }
    public void Pause()// Stops the audio
    {
        foreach (Sound s in sound)
            s.source.Pause();
    }
}