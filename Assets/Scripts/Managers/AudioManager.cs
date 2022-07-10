using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public List<AudioClip> audioClips;
    public AudioSource audioSource;

    public AudioSource gameMusic;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        GameManager.Instance.GameStateChanged += Instance_GameStateChanged;
    }

    private void Instance_GameStateChanged(GameState state)
    {
        if (state == GameState.MainMenu)
            gameMusic.Stop();
        else if(!gameMusic.isPlaying)
            gameMusic.Play();
    }

    public void PlayClip(string clipName, bool isLoop = false)
    {
        PlayClipFromSource(audioSource, clipName, isLoop);
    }

    public void StopClip()
    {
        StopClipSource(audioSource);
    }

    public void StopClipSource(AudioSource audioSource)
    {
        audioSource.Stop();
    }
    
    public void PlayClipFromSource(AudioSource audioSource, string clipName, bool isLoop = false)
    {
        var clip = audioClips.First(x => x.name == clipName);
        audioSource.clip = clip;
        audioSource.loop = isLoop;
        audioSource.Play();
    }
}
