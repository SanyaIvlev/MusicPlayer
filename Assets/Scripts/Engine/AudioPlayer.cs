using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public float ClipTimePassed => _audioSource.time;
    public bool IsPlaying => _audioSource.isPlaying;
    
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayOnce(AudioClip clip)
    {
        bool wasPaused = !_audioSource.isPlaying;
        
        _audioSource.clip = clip;
        _audioSource.Play();

        if (wasPaused)
            _audioSource.Pause();
    }
    
    public void Pause()
    {
        _audioSource.Pause();
    }

    public void Continue()
    {
        _audioSource.UnPause();
    }

    public void SetVolume(float volume)
    {
        _audioSource.volume = volume;
    }
}
