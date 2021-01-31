using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlowMotion : MonoBehaviour
{
    [System.Serializable]
    public class AudioSourceData
    {
        public AudioSource audioSource;
        public float defaultPitch;
    }

    [SerializeField]
    private float timeScale = 0.5f;

    [SerializeField]
    private float duration = 1.5f;

    private bool disableAudio = false;
    AudioSourceData[] audioSources;
    private float fixedDeltaTime;

    void Awake()
    {
        fixedDeltaTime = Time.fixedDeltaTime;
    }

    void Start()
    {
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        audioSources = new AudioSourceData[audios.Length];

        for (int i = 0; i < audios.Length; i++)
        {
            AudioSourceData sourceData = new AudioSourceData();
            sourceData.defaultPitch = audios[i].pitch;
            sourceData.audioSource = audios[i];
            audioSources[i] = sourceData;
        }
    }

    public void Play(bool audio = false)
    {
        disableAudio = audio;
        Invoke("Stop", duration);

        Time.timeScale = timeScale;
        Time.fixedDeltaTime = Time.timeScale * fixedDeltaTime;

        for (int i = 0; audio && i < audioSources.Length; i++)
        {
            audioSources[i].audioSource.pitch = Time.timeScale * audioSources[i].defaultPitch;
        }
    }

    void Stop()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = fixedDeltaTime;

        for (int i = 0; disableAudio && i < audioSources.Length; i++)
        {
            audioSources[i].audioSource.pitch = audioSources[i].defaultPitch;
        }
    }
}
