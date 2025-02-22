using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CollectibleMemories : MonoBehaviour
{
    public Volume globalVolume;
    private ColorAdjustments colorAdjustments;

    void Start()
    {
        globalVolume.profile.TryGet(out colorAdjustments);
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Destroy(gameObject);
            colorAdjustments.saturation.value += 25;
        }
    }
}
