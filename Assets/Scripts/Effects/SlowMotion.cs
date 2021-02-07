using UnityEngine;

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
    private float duration = 1.0f;

    private float fixedDeltaTime;
    private bool affectAudio = false;
    private AudioSourceData[] audioSources;

    private void Awake()
    {
        fixedDeltaTime = Time.fixedDeltaTime;
    }

    private void Start()
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
        affectAudio = audio;
        Invoke("Stop", duration);

        Time.timeScale = timeScale;
        Time.fixedDeltaTime = Time.timeScale * fixedDeltaTime;

        for (int i = 0; audio && i < audioSources.Length; i++)
        {
            audioSources[i].audioSource.pitch = Time.timeScale * audioSources[i].defaultPitch;
        }
    }

    private void Stop()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = fixedDeltaTime;

        for (int i = 0; affectAudio && i < audioSources.Length; i++)
        {
            audioSources[i].audioSource.pitch = audioSources[i].defaultPitch;
        }
    }
}
