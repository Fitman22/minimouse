using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour
{
    public static controls instance;
    ControlMap controlsmap;
    ControlMap.ControlsActions actions;

    private void Awake()
    {
        instance = this;
        controlsmap = new ControlMap();
        actions = controlsmap.controls;
     
    }
    public ControlMap.ControlsActions Getcontrols()
    {
        return actions;
    }
    private void OnEnable()
    {
        controlsmap.Enable();
    }
    private void OnDestroy()
    {
        controlsmap.Disable();
    }
}
