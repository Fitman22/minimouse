using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlAudio : MonoBehaviour
{
    public static controlAudio instance;
    [SerializeField] AudioClip win, laughts,applauses,bruh;
    [SerializeField] GameObject laughtsObjects;
    private void Start()
    {
        instance= this;
    }
    public void Laughts()
    {
        GetComponent<AudioSource>().clip=laughts;
        GetComponent<AudioSource>().Play();
        laughtsObjects.SetActive(true);
    }
    public void Win()
    {
        GetComponent<AudioSource>().clip = win;
        GetComponent<AudioSource>().Play();
        Invoke("Applauses", 2);
    }
    public void Applauses()
    {
       
        GetComponent<AudioSource>().clip = applauses;
        GetComponent<AudioSource>().Play();
    }
    public void Buuu()
    {

        GetComponent<AudioSource>().clip = bruh;
        GetComponent<AudioSource>().Play();
    }
}
