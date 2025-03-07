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
        _audioSource.clip = clip;
        _audioSource.Play();
    }
    
    public void Pause()
    {
        _audioSource.Pause();
    }

    public void Continue()
    {
        _audioSource.UnPause();
    }
}
