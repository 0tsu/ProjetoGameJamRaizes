using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class MemorySystem : MonoBehaviour
{

    public void CloseMemory()
    {
        GameManager.Instance.AddColor();
        Destroy(gameObject);
    }
}
