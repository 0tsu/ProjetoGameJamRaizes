using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InputFieldHandler : MonoBehaviour
{
    public TMP_InputField inputField;

    void Start()
    {
        if (inputField == null)
        {
            inputField = GetComponent<TMP_InputField>();
        }

        inputField.onValueChanged.AddListener(CheckInput);
    }

    void CheckInput(string input)
    {
        if (input == "1234")
        {
            GameManager.Instance.hasUnlockedBedroom = true;
            SceneManager.LoadScene("Cenas/Quarto");
        }
    }

    void OnDestroy()
    {
        if (inputField != null)
        {
            inputField.onValueChanged.RemoveListener(CheckInput);
        }
    }
}
