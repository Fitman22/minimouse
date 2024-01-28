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
            GameObject h = null;
            if (hueco != null) { h = Instantiate(hueco, collision.transform.position, new Quaternion(0, 0, 0, 0)); }
            collision.GetComponent<clown>().cameraClown();
            Destroy(collision.gameObject);
            int c = PlayerPrefs.GetInt("canon");
          if(c==0)  controlAudio.instance.Laughts();
            //Debug.Log("canon1:" + c);
            Invoke("openMenu", 3);
            
            PlayerPrefs.SetFloat("posx", h.transform.position.x);
            PlayerPrefs.SetFloat("posy", h.transform.position.y);
            PlayerPrefs.Save();
            c = PlayerPrefs.GetInt("canon");
            //Debug.Log("canon2:" + c);
            
        }
    }
  
   protected virtual void openMenu()
    {
        Debug.Log("waosss");
        menu.instance.OpenMenu(1);
PlayerPrefs.SetInt("canon", 1);
        PlayerPrefs.Save();
    }
}
