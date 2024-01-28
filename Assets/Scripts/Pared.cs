using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pared : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<clown>())
        {
            controlAudio.instance.Buuu();
            Invoke("openMenu", 3);
        }
    }  
void openMenu()
{
    menu.instance.OpenMenu(2);
   
}
}
