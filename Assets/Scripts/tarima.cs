using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tarima : MonoBehaviour
{
    [SerializeField] GameObject hueco;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<clown>())
        {
            if (hueco != null) { Instantiate(hueco, collision.transform.position, new Quaternion(0, 0, 0, 0)); }
            Destroy(collision.gameObject);
            Invoke("openMenu",3);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<clown>())
        {
            if(hueco != null) { Instantiate(hueco, collision.transform.position, new Quaternion(0, 0, 0, 0)); }
           
            Destroy(collision.gameObject);
            Invoke("openMenu", 3);
        }
    }
    void openMenu()
    {
        menu.instance.OpenMenu(2);
    }
}
