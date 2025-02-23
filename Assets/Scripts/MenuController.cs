using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class MenuController : MonoBehaviour
{
    
    bool isOpen = false;

    [SerializeField] GameObject menu;
    [SerializeField] GameObject pause;

    

    public void OpenMenu()
    {
        if (!isOpen)
        {
            isOpen = true;
            pause.SetActive(false);
            menu.SetActive(true);
        }

    }

    public void CloseMenu()
    {
        if (isOpen)
        {
            isOpen = false;
            pause.SetActive(true);
            menu.SetActive(false);
        }
    }
        
}
