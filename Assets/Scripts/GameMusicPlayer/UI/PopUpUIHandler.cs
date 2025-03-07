using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PopUpUIHandler : MonoBehaviour
{
    [FormerlySerializedAs("_audioPlayer")] [SerializeField] private MusicSwitcher _musicSwitcher;
    [SerializeField] private string _openTrigger;
    
    [SerializeField] private TMP_Text _songField;
    [SerializeField] private TMP_Text _authorField;

    private Animator _animator;
    
    private bool _isOnScreen;
    
    private void Awake()
        => _animator = GetComponent<Animator>();

    private void OnEnable()
        => _musicSwitcher.AddSoundChangeCallBack(UpdatePopUp);

    private void OnDisable()
        => _musicSwitcher.RemoveSoundChangeCallBack(UpdatePopUp);

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
        _animator.SetTrigger(_openTrigger);
    }
    
    private void OnClose()
    {
        _isOnScreen = false;
        _animator.ResetTrigger(_openTrigger);
    }
}
