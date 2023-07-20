using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int levelHolder;
    public List<GameObject> levels;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PlayerPrefs.SetInt("CurrentLevel",levelHolder);
        Instantiate(levels[LevelSave]);
    }


    public void NextLevel()
    {
        Destroy(GameObject.FindWithTag("Level"));
        levelHolder += 1;
        LevelSave = levelHolder;
        Instantiate(levels[PlayerPrefs.GetInt("CurrentLevel")]);
        StackManager.instance.NextPlatform();
    }

    public void TryAgain()
    {
        Destroy(GameObject.FindWithTag("Level"));
        Instantiate(levels[PlayerPrefs.GetInt("CurrentLevel")]);
        StackManager.instance.NextPlatform();
    }
    
    public int LevelSave
    {
        get => PlayerPrefs.GetInt("CurrentLevel");
        set => PlayerPrefs.SetInt("CurrentLevel", levelHolder);
    }
    
    
}
