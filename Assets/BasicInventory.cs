using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasicInventory : MonoBehaviour
{

    [SerializeField] int storedKeys;
    public TextMeshProUGUI keysUI;

    // Start is called before the first frame update
    void Start()
    {
        keysUI = GameObject.Find("KeysUILabel").GetComponent<TextMeshProUGUI>();

        if (PlayerPrefs.HasKey("Keys"))
        {
            storedKeys = PlayerPrefs.GetInt("Keys");
            Debug.Log("Start Keys: " + storedKeys);
            keysUI.SetText("Keys" + storedKeys);



        }
        else
        {
            PlayerPrefs.SetInt("Keys", 0);
            //PlayerPrefs.SetInt("Coins", 0);
            keysUI.SetText("Keys", 0);

            PlayerPrefs.Save();
        }
        if (PlayerPrefs.HasKey("Coins"))
        {
            PlayerPrefs.GetInt("Coins");
        }
    }

   
}
