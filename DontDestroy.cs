using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    { 
        DontDestroyOnLoad(gameObject);
        if (GameObject.FindGameObjectsWithTag("Music").Length >= 2)
        {
            Destroy(gameObject);
        }
    }
}

