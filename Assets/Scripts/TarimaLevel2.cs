using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarimaLevel2 : tarima
{
    protected override void openMenu()
    {
       int c= PlayerPrefs.GetInt("canon");
        Debug.Log(c);
        if(c==1)
        {

            controlAudio.instance.Buuu();
            menu.instance.OpenMenu(3);
        }
        else
        {

           base.openMenu();
        }
        Debug.Log("waosssbuff");
    }
}
