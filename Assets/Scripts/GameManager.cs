using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool hasUnlockedBedroom;
    public List<Memory> collectedMemories = new List<Memory>(); // List to store collected memories

    private void Awake()
    {
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
}
