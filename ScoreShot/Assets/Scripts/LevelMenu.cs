
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelMenu : MonoBehaviour
{

    public void Select (string levelName){
    	SceneManager.LoadScene(levelName);
    }

    public void Back (){
    	SceneManager.LoadScene("Menu");
    }

    public void BackToLevelMenu (){
    	SceneManager.LoadScene("LevelMenu");
    }
}
