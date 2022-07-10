using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectName : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI inputField;

    private string playerNameKey = "PlayerName";

    public void OnNameEntered()
    {
        if (inputField.text != null)
        {
            if (PlayerPrefs.HasKey(playerNameKey))
            {
                PlayerPrefs.SetString(playerNameKey, inputField.text.ToString());
                PlayerPrefs.Save();
            }
        }
    }

    public void OnDeselect()
    {
        if (inputField.text != null)
        {
            if (PlayerPrefs.HasKey(playerNameKey))
            {
                PlayerPrefs.SetString(playerNameKey, inputField.text.ToString());
                PlayerPrefs.Save();
            }
        }
    }
}
