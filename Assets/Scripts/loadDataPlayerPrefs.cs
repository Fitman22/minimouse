using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadDataPlayerPrefs : MonoBehaviour
{
    [SerializeField] GameObject huecoPiso;
    [SerializeField] SpriteRenderer bafle;
    [SerializeField] Sprite dañado;
    private void Awake()
    {
        int b = PlayerPrefs.GetInt("Bafle");
      int c=  PlayerPrefs.GetInt("canon");
        Debug.Log(c +","+ b);
        if (c == 1) { 
            float x = PlayerPrefs.GetFloat("posx");
            float y = PlayerPrefs.GetFloat("posy");          
            huecoPiso.transform.position = new Vector2(x,y);
            huecoPiso.SetActive(true);
        }
        if (b == 1) bafle.sprite = dañado;
    }
}
