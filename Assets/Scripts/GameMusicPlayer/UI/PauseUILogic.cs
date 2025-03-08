using System;
using UnityEngine;
using UnityEngine.Audio;

public class PauseUILogic : MonoBehaviour
{
    [SerializeField] private MusicSwitcher _musicSwitcher;
    [SerializeField] private GameObject objectToSwitch;

    private void OnEnable()
    {
        _musicSwitcher.AddPauseSwitchCallBack(OnSwitchedPause);
    }

    private void OnDisable()
    {
        _musicSwitcher.RemovePauseSwitchCallBack(OnSwitchedPause);
    }

    private void OnSwitchedPause()
    {
        objectToSwitch.SetActive(true);
        gameObject.SetActive(false);
    }
}
