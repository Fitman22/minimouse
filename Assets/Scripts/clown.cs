using Cinemachine;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class clown : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float factorDeRotacion;
    [SerializeField] CinemachineVirtualCamera ClownCamera;
    bool ring;
    private void Start()
    {
        CameraController.instance.addCamera(ClownCamera);
      
    }
    private void Update()
    {
        Quaternion rotacionDeseada;
        if (!ring)
        {
            float anguloDeRotacion = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
             rotacionDeseada = Quaternion.Euler(0f, 0f, anguloDeRotacion);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, Time.fixedDeltaTime * factorDeRotacion);
        }
        else { // rotacionDeseada = Quaternion.Euler(0f, 0f, 360f);factorDeRotacion = 2.8f; 
            GetComponent<Animator>().SetTrigger("fall");
            Invoke("stop",0.2f); }
        // Suaviza la rotación para que no sea instantánea
      
    }
    public void cameraMov()
    {
        ClownCamera.GetComponent<Animator>().Play("mov");
    }
    private void stop()
    {
        rb.velocity= new Vector2(0, rb.velocity.y);
        Debug.Log("stop");
    }
    public void win()
    {
        Debug.Log("win");
        controlAudio.instance.Win();
        Invoke("finish", 3);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ring"))
        {
            ring = true;

        }
        if (collision.transform.CompareTag("Wall"))
        {
            Invoke("laught", 1f);
            GetComponent<Animator>().Play("dead");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            Invoke("laught", 1f);
            GetComponent<Animator>().Play("dead");

        }
        if (collision.transform.CompareTag("ring"))
        {
            ring = true;

        }
    }
    void  laught()
    {
        int c = PlayerPrefs.GetInt("Bafle");
        if (c == 0) controlAudio.instance.Laughts();

    }        
    public void cameraClown()
    {
        ClownCamera.transform.SetParent(null);
        ClownCamera.transform.eulerAngles = Vector3.zero;
        CameraController.instance.changeCamera(ClownCamera);
    }
    public void clownFinish()
    {
        cameraClown();
        Invoke("finish2", 4);   
    }
    public void winFinish()
    {
     
    }
    void finish()
    {
        menu.instance.OpenMenu(0);
    }
    protected virtual void finish2()
    {
        menu.instance.OpenMenu(1);
        PlayerPrefs.SetInt("Bafle", 1);
       int c = PlayerPrefs.GetInt("Bafle");
        Debug.Log("c2:" + c);
        PlayerPrefs.Save();
    }
}
