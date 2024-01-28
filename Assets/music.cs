using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    private static music instance;

    private void Awake()
    {
        // Asegurarse de que solo haya una instancia de este objeto
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Evita que el objeto se destruya al cargar una nueva escena
        }
        else
        {
            Destroy(gameObject); // Destruye el objeto si ya hay una instancia
        }
    }
}
