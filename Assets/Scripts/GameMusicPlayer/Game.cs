using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private MusicSwitcher _musicSwitcher;
    
    private InputBinds _binds;
    
    private void Awake()
    {
        _binds = new InputBinds();
    }
    
    private void OnEnable()
    {
        _binds.Enable();
        
        _binds.Player.Next.performed += context => _musicSwitcher.PlayNext();
        _binds.Player.Previous.performed += context => _musicSwitcher.PlayPrevious();
    }

    private void OnDisable()
    {
        _binds.Disable();
        
        _binds.Player.Next.performed -= _ => _musicSwitcher.PlayNext();
        _binds.Player.Previous.performed -= _ => _musicSwitcher.PlayPrevious();
    }
}