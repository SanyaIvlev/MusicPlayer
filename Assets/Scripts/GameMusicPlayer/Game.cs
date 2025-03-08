using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private MusicSwitcher _musicSwitcher;
    [SerializeField] private PopUpUIHandler _popUpUIHandler;
    
    private InputBinds _binds;
    
    private void Awake()
    {
        _binds = new InputBinds();
    }
    
    private void OnEnable()
    {
        _binds.Enable();

        var playerActions = _binds.Player;
        
        playerActions.Next.performed += context => _musicSwitcher.PlayNext();
        playerActions.Previous.performed += context => _musicSwitcher.PlayPrevious();
        
        playerActions.SwitchPause.performed += context => _musicSwitcher.SwitchPause();

        playerActions.OpenPopUp.performed += context => _popUpUIHandler.PlayOpenAnimation();
    }

    private void OnDisable()
    {
        _binds.Disable();
        
        var playerActions = _binds.Player;
        
        playerActions.Next.performed -= _ => _musicSwitcher.PlayNext();
        playerActions.Previous.performed -= _ => _musicSwitcher.PlayPrevious();
        
        playerActions.SwitchPause.performed += _ => _musicSwitcher.SwitchPause();
        
        playerActions.OpenPopUp.performed -= _ => _musicSwitcher.SwitchPause();
    }
}