using UnityEngine;
using UnityEngine.Serialization;

public class PopUpUIHandler : MonoBehaviour
{
    [SerializeField] private AudioPlayer _audioPlayer;
    [SerializeField] private string _openTrigger;

    private Animator _animator;
    
    private bool _isOnScreen;
    
    private void Start()
        => _animator = GetComponent<Animator>();

    private void OnEnable()
        => _audioPlayer.AddSoundChangeCallBack(PlayOpenAnimation);

    private void OnDisable()
        => _audioPlayer.RemoveSoundChangeCallBack(PlayOpenAnimation);

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
