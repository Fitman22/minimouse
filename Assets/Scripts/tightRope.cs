using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tightRope : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed,balance,sensibility;
    [SerializeField] List<String> animations;
    bool Falling,onMove;
    float startX;
    private void Start()
    {
        controls.instance.Getcontrols().tactil.started += ctr => StartTought();
        controls.instance.Getcontrols().tactil.canceled += ctr => canceltap();
    }
    void StartTought()
    {
       onMove = true;
        startX= controls.instance.Getcontrols().touch.ReadValue<Vector2>().normalized.y;
    }
    void canceltap()
    {
        onMove = false;
        startX = 0;
    }
    private void FixedUpdate()
    {
        if (Falling) return;
        rb.velocity = new Vector2(1,0)*speed;
        float x = 0;
     if (onMove)  x= controls.instance.Getcontrols().touch.ReadValue<Vector2>().normalized.y;
        x -= startX;
        Debug.Log(x * sensibility);
        balance -= x*sensibility*Time.fixedDeltaTime;

      /*  if (balance <= 0)
        {
            balance -= 0.1f; ;
        }
        else { balance += 0.1f; }*/
        if (transform.rotation.x >60 || transform.rotation.x < -60)
        {
            fall();
        }
       transform.eulerAngles = new Vector3(balance, 0, -90f);
    }
    private void playAnimation(int anim)
    {
        GetComponent<Animator>().Play(animations[anim]);
    }
    void fall()
    {
        Falling = true;
       rb.velocity = Vector2.zero;
    }


}
