using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gol : MonoBehaviour
{
    [SerializeField] AudioSource finishedSoundEffect;

    void Start()
    {

        finishedSoundEffect.Play();
    }

    void Update()
    {
        if (!finishedSoundEffect.isPlaying)
        {
    	    SceneManager.LoadScene("LevelMenu");
        }
    }

    
}
