using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] _clips;

    private AudioSource _audioSource;
    private int _currentClipIndex;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        
        _currentClipIndex = 0;
    }
    
    public void PlayNext()
    {
        _currentClipIndex++;

        if (_currentClipIndex >= _clips.Length)
        {
            _currentClipIndex = 0;
        }
        
        PlayCurrentClip();
    }

    public void PlayPrevious()
    {
        _currentClipIndex--;

        if (_currentClipIndex < 0)
        {
            _currentClipIndex = _clips.Length - 1;
        }
        
        PlayCurrentClip();
    }
    
    
    private void PlayCurrentClip()
    {
        _audioSource.clip = _clips[_currentClipIndex];
        _audioSource.Play();
    }
}
