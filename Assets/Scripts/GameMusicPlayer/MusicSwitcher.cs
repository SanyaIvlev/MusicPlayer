
using System;
using UnityEngine;

public class  MusicSwitcher : MonoBehaviour
{
    [SerializeField] private AudioPlayer _audioPlayer;
    [SerializeField] private MusicClipData[] _clipsData;
    
    private Action _onSoundChanged;
    
    private AudioClip _currentClip;
    private int _currentClipIndex;

    private void Awake()
    {
        _currentClipIndex = 0;
        _currentClip = _clipsData[_currentClipIndex].audioClip;
    }
    
    public void AddSoundChangeCallBack(Action callback)
        => _onSoundChanged += callback;
    
    public void RemoveSoundChangeCallBack(Action callback)
        => _onSoundChanged -= callback;
    
    private void Update()
    {
        if (_audioPlayer.ClipTimePassed >= _currentClip.length)
        {
            PlayNext();
        }
    }
    
    public void PlayNext()
    {
        _currentClipIndex++;

        if (_currentClipIndex >= _clipsData.Length)
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
            _currentClipIndex = _clipsData.Length - 1;
        }
        
        PlayCurrentClip();
    }

    private void PlayCurrentClip()
    {
        _currentClip = _clipsData[_currentClipIndex].audioClip;
        _audioPlayer.PlayOnce(_currentClip);
        
        _onSoundChanged?.Invoke();
    }
}
