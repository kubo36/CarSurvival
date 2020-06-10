using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = true;
            s.source.volume = s.volume;
            //s.source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
        // find the sound in the sounds array by the name
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Stop(string name)
    {
        StartCoroutine(StopCoroutine(name));
    }

    public new IEnumerator StopCoroutine(string name)
    {
        yield return new WaitForSeconds(1f);
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}
