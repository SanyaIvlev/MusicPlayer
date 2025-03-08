
using System;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class  MusicSwitcher : MonoBehaviour
{
    [SerializeField] private AudioPlayer _audioPlayer;
    [SerializeField] private MusicClipData[] _clipsData;
    
    private Action<MusicClipData> _onSoundChanged;
    private Action _onPauseSwitched;
    
    private AudioClip _currentClip;
    private int _currentClipIndex;

    private void Start()
    {
        _currentClipIndex = 0;
        PlayCurrentClip();
    }
    
    public void AddSoundChangeCallBack(Action<MusicClipData> callback)
        => _onSoundChanged += callback;
    
    public void RemoveSoundChangeCallBack(Action<MusicClipData> callback)
        => _onSoundChanged -= callback;
    
    public void AddPauseSwitchCallBack(Action callback) 
        => _onPauseSwitched += callback;
    
    public void RemovePauseSwitchCallBack(Action callback) 
        => _onPauseSwitched -= callback;
    
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
        
        _onSoundChanged?.Invoke(_clipsData[_currentClipIndex]);
    }

    public void SwitchPause()
    {
        if (_audioPlayer.IsPlaying)
            _audioPlayer.Pause();
        else
            _audioPlayer.Continue();
        
        _onPauseSwitched?.Invoke();
    }
}
