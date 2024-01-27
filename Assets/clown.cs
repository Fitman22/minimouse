using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clown : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float factorDeRotacion;
    bool ring;
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
    private void stop()
    {
        rb.velocity= new Vector2(0, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ring"))
        {
            ring = true;
        }
    }
}
