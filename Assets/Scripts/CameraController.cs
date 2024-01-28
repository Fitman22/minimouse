using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    bool onmove;
    public static CameraController instance;
    [SerializeField] List<CinemachineVirtualCamera> cameras;
    private void Awake()
    {
        instance = this;
        activemove();
    }
    void activemove()
    {
           onmove = true;
    }
    public void shoot()
    {
        onmove= false;
    }
    public bool getmove()
    {
        return onmove;
    }
    private void Start()
    {
        changeCamera(cameras[1]);
    }
    public void addCamera(CinemachineVirtualCamera camera)
    {
        cameras.Add(camera);
    }
    public void changeCamera(CinemachineVirtualCamera camera)
    {
        foreach(CinemachineVirtualCamera c in cameras)
        {
            c.Priority = 10;
            if (c == camera)
            {
                c.Priority = 15;
            }
        }
    }
}
