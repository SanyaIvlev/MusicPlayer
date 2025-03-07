using UnityEngine;
using UnityEngine.Serialization;

public class PopUpUIHandler : MonoBehaviour
{
    [FormerlySerializedAs("_audioPlayer")] [SerializeField] private MusicSwitcher _musicSwitcher;
    [SerializeField] private string _openTrigger;

    private Animator _animator;
    
    private bool _isOnScreen;
    
    private void Awake()
        => _animator = GetComponent<Animator>();

    private void OnEnable()
        => _musicSwitcher.AddSoundChangeCallBack(PlayOpenAnimation);

    private void OnDisable()
        => _musicSwitcher.RemoveSoundChangeCallBack(PlayOpenAnimation);

    private void PlayOpenAnimation()
    {
        if (_isOnScreen)
            return;
        
        _isOnScreen = true;
        _animator.SetTrigger(_openTrigger);
    }
    
    private void OnClose()
    {
        _isOnScreen = false;
        _animator.ResetTrigger(_openTrigger);
    }
}
