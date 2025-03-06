using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    [SerializeField] private AudioPlayer _audioPlayer;

    private InputBinds _binds;

    private void Awake()
    {
        _binds = new InputBinds();
    }

    private void OnEnable()
    {
        _binds.Enable();
        
        _binds.Player.Next.performed += context => _audioPlayer.PlayNext();
        _binds.Player.Previous.performed += context => _audioPlayer.PlayPrevious();
    }

    private void OnDisable()
    {
        _binds.Disable();
        
        _binds.Player.Next.performed -= _ => _audioPlayer.PlayNext();
        _binds.Player.Previous.performed -= _ => _audioPlayer.PlayPrevious();
    }
}
