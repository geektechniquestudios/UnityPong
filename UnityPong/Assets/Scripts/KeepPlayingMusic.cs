using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlayingMusic : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
}
