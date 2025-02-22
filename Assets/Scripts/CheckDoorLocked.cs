using UnityEngine;

public class CheckDoorLocked : MonoBehaviour
{
    public GameObject lockerObject;

    void Start()
    {
        if (!GameManager.Instance.hasUnlockedBedroom) {
            lockerObject.SetActive(true);
        }
    }
}