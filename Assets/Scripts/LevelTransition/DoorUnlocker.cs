using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class DoorUnlocker : MonoBehaviour
{
    //state
    private int _enemyCount;

    //cache
    private List<EnemySelfDestroyer> _enemySelfDestroyers;
    private ExitDoorColorChange _exitDoorColorChange;



    private void Start() 
    {
        _enemySelfDestroyers = Enumerable.ToList(FindObjectsOfType<EnemySelfDestroyer>());
        _exitDoorColorChange = GetComponent<ExitDoorColorChange>();

        _enemyCount = _enemySelfDestroyers.Count;
    }

    private void OnEnable() 
    {
        _enemySelfDestroyers = Enumerable.ToList(FindObjectsOfType<EnemySelfDestroyer>());

        for(int enemyIndex = 0; enemyIndex < _enemySelfDestroyers.Count; enemyIndex++)
        {
            _enemySelfDestroyers[enemyIndex].OnEnemyDie += DecreaseEnemyCount;
        }
    }
    
    private void OnDisable() 
    {
        _enemySelfDestroyers = Enumerable.ToList(FindObjectsOfType<EnemySelfDestroyer>());

         for(int enemyIndex = 0; enemyIndex < _enemySelfDestroyers.Count; enemyIndex++)
        {
            if(_enemySelfDestroyers[enemyIndex] != null)
            _enemySelfDestroyers[enemyIndex].OnEnemyDie -= DecreaseEnemyCount;
        }
    }

    private void DecreaseEnemyCount()
    {
        _enemyCount--;

        if(_enemyCount <= 0)
        {
            _exitDoorColorChange.SetDoorUnlockedColor();
        }

    }

    private void LoadRandomScene()
    {
        int randomSceneIndex = new Random().Next(0, SceneManager.sceneCountInBuildSettings);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        while(randomSceneIndex == currentSceneIndex)
        {
            randomSceneIndex = new Random().Next(0, SceneManager.sceneCountInBuildSettings);
        }

        SceneManager.LoadScene(randomSceneIndex);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player") && _enemyCount <= 0)
        {
            LoadNextScene();
        }    
    }
}
