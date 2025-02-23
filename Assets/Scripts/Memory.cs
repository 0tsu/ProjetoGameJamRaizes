using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Memory : MonoBehaviour
{
    public string memoryText;  // The text description for this memory
    public GameObject pagePrefab; // Reference to the Page prefab
    public Transform pageContainer; // Container where the Page prefab will be instantiated
    private ColorAdjustments colorAdjustments;
    public Volume globalVolume;

    void Start()
    {
        globalVolume.profile.TryGet(out colorAdjustments);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Assuming the player has a "Player" tag
        {
            colorAdjustments.saturation.value += 25;
            // Add memory to the GameManager
            GameManager.Instance.AddMemory(this);

            // Instantiate the Page prefab to display the memory
            DisplayMemoryPage();

            // Destroy the memory object after collection
            Destroy(gameObject);
        }
    }

    public GameObject DisplayMemoryPage()
    {
        // Instantiate the Page prefab in the specified container
        GameObject page = Instantiate(pagePrefab, pageContainer);

        // Set the image and text of the Page prefab
        page.GetComponentInChildren<UnityEngine.UI.Text>().text = memoryText;

        return page;
    }
}

