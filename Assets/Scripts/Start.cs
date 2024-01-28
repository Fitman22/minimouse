using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start : MonoBehaviour
{
    [SerializeField] Sprite complete;
    [SerializeField] bool canon;
    private void Update()
    {
        if (canon)
        {
            if (PlayerPrefs.GetInt("Bafle") == 1)
            {
                GetComponent<Image>().sprite = complete;
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("canon") == 1)
            {
                GetComponent<Image>().sprite = complete;
            }
        }
    }
}
