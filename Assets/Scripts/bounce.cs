using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<clown>())
        {
            GetComponent<BoxCollider2D>().sharedMaterial = null;
        }
    }
}
