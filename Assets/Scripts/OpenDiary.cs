using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDiary : MonoBehaviour
{
    private int currentIndex = 0;
    private GameObject currentPage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    GameObject displayPage()
    {
        return GameManager.Instance.collectedMemories[currentIndex].DisplayMemoryPage();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.Instance.collectedMemories.Count >= 1)
            {
                currentPage = displayPage();
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (GameManager.Instance.collectedMemories.Count >= currentIndex + 2)
            {
                Destroy(currentPage);
                currentIndex += 1;
                displayPage();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (!(currentIndex - 1 < 0) && GameManager.Instance.collectedMemories.Count >= currentIndex)
            {
                Destroy(currentPage);
                currentIndex -= 1;
                displayPage();
            }
        }
    }
}
