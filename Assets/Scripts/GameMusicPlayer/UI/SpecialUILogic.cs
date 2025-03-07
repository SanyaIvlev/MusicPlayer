using UnityEngine;

public class SpecialUILogic : MonoBehaviour
{
    public void OnSwitchedPause(GameObject objectToSwitch)
    {
        objectToSwitch.SetActive(true);
        gameObject.SetActive(false);
    }
}
