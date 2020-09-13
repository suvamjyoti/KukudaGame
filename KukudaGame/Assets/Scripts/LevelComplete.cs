using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public static int _levelIndex=1;
    void LoadNextLevel(){
        _levelIndex++;
        string nextLevelName = "Level" + _levelIndex;
        SceneManager.LoadScene(nextLevelName);
    }
}
