using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjTime : MonoBehaviour
{
    // Declarar a variável para armazenar o tempo de vida do objeto
    public float TimeLife = 3.0f;

    // Destruir o objeto após o tempo de vida definido
    void Start()
    {
        Destroy(gameObject, TimeLife);
    }

    }
