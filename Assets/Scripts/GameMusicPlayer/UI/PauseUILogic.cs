using UnityEngine;

public class PauseUILogic : MonoBehaviour
{
    public void OnSwitchedPause(GameObject objectToSwitch)
    {
        objectToSwitch.SetActive(true);
        gameObject.SetActive(false);
    }
}
