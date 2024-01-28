using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bafleLevel2 : clown
{
    protected override void finish2()
    {
        int c = PlayerPrefs.GetInt("Bafle");
        Debug.Log(c);
        if (c == 1)
        {
            controlAudio.instance.Buuu();
            menu.instance.OpenMenu(3);
        }
        else
        {
            base.finish2();
        }
      
    }
}
