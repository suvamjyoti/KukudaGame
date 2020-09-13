using UnityEngine;


public class LevelControl : MonoBehaviour
{
    
    public GameObject levelCompleteUI;
    private Enemy[] _enemies;


    private void OnEnable() {
        _enemies = FindObjectsOfType<Enemy>();
    }

    void Update()
    {
        foreach(Enemy enemy in _enemies){
            if(enemy!=null){
                return;
            }
        }

        levelCompleteUI.SetActive(true);
        return;
    }
}
