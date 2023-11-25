using Events;
using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private int currentLevelIndex;
        [SerializeField] private GameObject[] levelList; 

        private GameObject _activeLevel;

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

        private void LoadLevel(int levelIndex)
        {
            ClearActiveLevel();

            if (levelIndex >= 0 && levelIndex < levelList.Length)
            {
                _activeLevel = Instantiate(levelList[levelIndex]);
            }
       
        }

        private void ClearActiveLevel()
        {
            if (_activeLevel != null)
            {
                Destroy(_activeLevel);
            }
        }

        private void LoadNextLevel()
        {
            currentLevelIndex = (currentLevelIndex + 1) % levelList.Length; 
            LoadLevel(currentLevelIndex);
        }

        private void ReloadLevel()
        {
            LoadLevel(currentLevelIndex);
        }
    }
}