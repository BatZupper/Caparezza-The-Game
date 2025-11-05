using UnityEngine;
using TMPro;

public class HardMode : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("Hard", 0);
    }

    public TextMeshProUGUI text;

    public void Hard()
    {
        if (PlayerPrefs.GetInt("Hard") == 0)
        {
            PlayerPrefs.SetInt("Hard", 1);
            text.SetText("Easy Mode");
        }
        else 
        {
            PlayerPrefs.SetInt("Hard", 0);
            text.SetText("Hard Mode");
        }
    }
}
