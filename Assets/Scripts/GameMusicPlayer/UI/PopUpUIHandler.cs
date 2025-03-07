using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PopUpUIHandler : MonoBehaviour
{
    [SerializeField] private MusicSwitcher _musicSwitcher;
    [SerializeField] private string _openTrigger;
    [SerializeField] private string _closeTrigger;
    
    [SerializeField] private TMP_Text _songField;
    [SerializeField] private TMP_Text _authorField;

    private float _closeDelay = 3;
    private float _timeWentToClose;

    private bool _isHovered;

    private Animator _animator;
    
    private bool _isOnScreen;
    
    private void Awake()
        => _animator = GetComponent<Animator>();

    private void OnEnable()
        => _musicSwitcher.AddSoundChangeCallBack(UpdatePopUp);

    private void OnDisable()
        => _musicSwitcher.RemoveSoundChangeCallBack(UpdatePopUp);

    public void MouseEntered()
        => _isHovered = true;

    public void MouseExited()
        => _isHovered = false;


    private void Update()
    {
        if (_isOnScreen)
        {
            _timeWentToClose += Time.deltaTime;
            
            if (_timeWentToClose >= _closeDelay && !_isHovered)
            {
                _timeWentToClose = 0;
                Close();
            }
        }
    }

    private void UpdatePopUp(MusicClipData data)
    {
        _songField.text = data.Name;
        _authorField.text = data.Author;
        
        PlayOpenAnimation();
    }
    
    private void PlayOpenAnimation()
    {
        if (_isOnScreen)
            return;
        
        _isOnScreen = true;
        
        _animator.ResetTrigger(_closeTrigger);
        _animator.SetTrigger(_openTrigger);
    }
    
    private void Close()
    {
        _isOnScreen = false;
        
        _animator.ResetTrigger(_openTrigger);
        _animator.SetTrigger(_closeTrigger);
    }
}
