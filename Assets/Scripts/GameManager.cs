using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool hasUnlockedBedroom;
    private ColorAdjustments colorAdjustments;
    public Volume globalVolume;

    private void Awake()
    {
        globalVolume.profile.TryGet(out colorAdjustments);
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            
            Destroy(gameObject);
        }
    }
    
}
