using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tightRope : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed,balance,sensibility,
        min,max,timer;
    [SerializeField] List<String> animations;
    bool Falling,onMove,onHueco;
    float startX,time;
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
        balance = Mathf.Clamp(balance,-10,10);
         if (balance <= 0 )
          {
              balance -= 5*Time.fixedDeltaTime; 
          }
          else if(balance >0){ balance += 5 * Time.fixedDeltaTime; }
        /* if (transform.rotation.x >60 || transform.rotation.x < -60)
         {
             fall();
         }
        transform.eulerAngles = new Vector3(balance, 0, -90f);*/
        if(balance<=-10 || balance >= 10)
        {
            time += Time.fixedDeltaTime;
        }
        else { time = 0; }
        if (time >= timer)
        {
             playAnimation(2);
          
            rb.velocity = Vector2.zero;
            if (GetComponent<SpriteRenderer>().flipX)
            {
                transform.position = new Vector2(transform.position.x,
                    transform.position.y - 1);
            }
            else
            {
                transform.position = new Vector2(transform.position.x ,
                    transform.position.y + 1);
                if (onHueco) playAnimation(4);
            }
            Falling = true;
        }
        if(balance>=min && balance <=max)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            playAnimation(0);
            
        }
        else if (balance < min)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            playAnimation(1);
        }
        else if(balance > max)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            playAnimation(1);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("goal"))
        {
            playAnimation(3); rb.velocity = Vector2.zero;
            Falling = true;
            controlAudio.instance.Win();
            Invoke("wait", 5);
        }
        if (collision.CompareTag("hueco"))
        {
            onHueco = true;
        }
    }
    void deadFinish()
    {
        //GetComponent<SpriteRenderer>().laye = -1;
        Invoke("win", 3);
        controlAudio.instance.Laughts();
    }
    void win()
    {
        menu.instance.OpenMenu(1);
       
    }
    void failFall()
    {
        Invoke("fail", 3);
        controlAudio.instance.Buuu();
    }
    void fail()
    {
        menu.instance.OpenMenu(2);
    }
    void wait()
    {
        menu.instance.OpenMenu(0);
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
