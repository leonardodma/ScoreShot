using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Slider volumeListener;

    void Start(){
        if(!PlayerPrefs.HasKey("volume")){
            PlayerPrefs.SetFloat("volume", 1f);
            Load();
        } else {
            Load();
        }
    }

    public void PlayGame()
    {
    	// Pega a próxima cena
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
    	Debug.Log("QUIT");
    	Application.Quit();
    }

    public void ChangeVolume(){
        AudioListener.volume = volumeListener.value;
        Save();
    }

    private void Load(){
        volumeListener.value = PlayerPrefs.GetFloat("volume");
    }

    private void Save(){
        PlayerPrefs.SetFloat("volume", volumeListener.value);
    }
}
