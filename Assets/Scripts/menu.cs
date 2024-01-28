using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField] GameObject menuOpen, winOpen,nothingOpen, hand;
    public static menu instance;
    private void Start()
    {
        instance = this;
        Invoke("handVanish", 5f);
    }
    public void retry()
    {
        SceneManager.LoadScene(1);
    }
    public void exit()
    {
        SceneManager.LoadScene(0);
    }
    public void quit()
    {
        Application.Quit();
    }
    void handVanish()
    {
        hand.SetActive(false);
    }
    public void OpenMenu(int p)
    {
        if (p == 0)
        {
            menuOpen.GetComponent<Animator>().Play("open");
        }
        if (p == 1)
        {
            winOpen.GetComponent<Animator>().Play("open");
        }
        if (p == 2)
        {
            nothingOpen.GetComponent<Animator>().Play("open");
        }
    }
}
