
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelMenu : MonoBehaviour
{

    public void Select (string levelName){
    	SceneManager.LoadScene(levelName);
    }
}
