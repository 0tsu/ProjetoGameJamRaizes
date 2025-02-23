using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool hasUnlockedBedroom;
    public List<Memory> collectedMemories = new List<Memory>(); // List to store collected memories
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


    // Call this method to add a memory to the list when the player collects it
    public void AddMemory(Memory memory)
    {
        collectedMemories.Add(memory);
    }

    public void AddColor()
    {
        colorAdjustments.saturation.value += 25;
    }
}
