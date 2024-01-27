using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon : MonoBehaviour
{
    bool start;
    [SerializeField] float speed, min, max,force;
    [SerializeField] GameObject clown;
    [SerializeField] Transform pos;
    float canonz;
    Vector2 startPos;
    void Start()
    {
        controls.instance.Getcontrols().tactil.performed += ctr => canonEnter();
    }
    void canonEnter()
    {
        start = !start;
        startPos = controls.instance.Getcontrols().touch.ReadValue<Vector2>();
        canonz = transform.eulerAngles.z;
        if (!start)
        {
            GetComponent<AudioSource>().Play();
          GameObject clownCanon=  Instantiate(clown, pos.position,transform.rotation);
            clownCanon.transform.eulerAngles = new Vector3(0,0,pos.transform.eulerAngles.z);
            Vector2 direccionDeLanzamiento = pos.up;
            clownCanon.GetComponent<Rigidbody2D>().AddForce(direccionDeLanzamiento * force);
        }
    }
 

    private void Update()
    {
        if (start)
        {
            Vector2 targetPosition = controls.instance.Getcontrols().touch.ReadValue<Vector2>();
            float diff = startPos.y -targetPosition.y;
            diff *= speed;          
             transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Clamp(canonz + diff, min, max));       
        }
    }
  
}
