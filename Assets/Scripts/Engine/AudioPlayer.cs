using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public float ClipTimePassed => _audioSource.time;
    
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
}
