using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int currentLevelIndex = 0;
    private GameObject activeLevel;

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        CoreGameEvents.Instance.onLevelChange += OnLevelChange;
        CoreGameEvents.Instance.onRestart += OnRestart;
    }


    private void UnSubscribeEvents()
    {
        CoreGameEvents.Instance.onLevelChange -= OnLevelChange;
        CoreGameEvents.Instance.onRestart -= OnRestart;
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }

    private void Start()
    {
        LoadLevel(currentLevelIndex);
    }

    private void OnLevelChange()
    {
        LoadNextLevel();
    }

    private void OnRestart()
    {
        ReloadLevel();
    }

    void LoadLevel(int levelIndex)
    {
        ClearActiveLevel();

        string levelPrefabPath = "Levels/Level" + levelIndex;
        GameObject levelPrefab = Resources.Load<GameObject>(levelPrefabPath);

        if (levelPrefab != null)
        {
            activeLevel = Instantiate(levelPrefab);
        }
        else
        {
            Debug.LogError("Level prefab not found at path: " + levelPrefabPath);
        }
    }

    void ClearActiveLevel()
    {
        if (activeLevel != null)
        {
            Destroy(activeLevel);
        }
    }

    void LoadNextLevel()
    {
        currentLevelIndex = (currentLevelIndex + 1) % 10; 
        LoadLevel(currentLevelIndex);
    }


    void ReloadLevel()
    {
        LoadLevel(currentLevelIndex);
    }
}