using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon : MonoBehaviour
{
    bool start;
    [SerializeField] float speed, min, max,force;
    [SerializeField] GameObject clown,burst;
    [SerializeField] Transform pos;
    float canonz;
    Vector2 startPos;
    void Start()
    {
        controls.instance.Getcontrols().tactil.started += ctr => canonEnter();
        controls.instance.Getcontrols().tactil.canceled += ctr => canonExit();
    }
    void canonEnter()
    {
        Debug.Log("tac");
        if (!CameraController.instance.getmove())
        {
            return;
        }
        start = true; 
        startPos = controls.instance.Getcontrols().touch.ReadValue<Vector2>();
        canonz = transform.eulerAngles.z;
    }
    void canonExit()
    {
        Debug.Log("tac");
        if (!CameraController.instance.getmove())
        {
            return;
        }
        start = false;
            burst.SetActive(true);
            GetComponent<AudioSource>().Play();
            //GameObject clownCanon=  Instantiate(clown, pos.position,transform.rotation);
            clown.GetComponent<Animator>().Play("clown");
            clown.transform.SetParent(null);
            //clown.GetComponent<clown>().cameraMov();
            clown.GetComponent<Rigidbody2D>().simulated = true;
            //clown.transform.eulerAngles = new Vector3(0,0,pos.transform.eulerAngles.z);
            Vector2 direccionDeLanzamiento = pos.up;
            clown.GetComponent<Rigidbody2D>().AddForce(direccionDeLanzamiento * force);
            CameraController.instance.shoot();
        
    }


    private void Update()
    {
        if (start && CameraController.instance.getmove())
        {
            Vector2 targetPosition = controls.instance.Getcontrols().touch.ReadValue<Vector2>();
            float diff = startPos.y -targetPosition.y;
            diff *= speed;          
             transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Clamp(canonz + diff, min, max));       
        }
    }
  
}
