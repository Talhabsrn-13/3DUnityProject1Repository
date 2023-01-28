using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace UdemyProject1.Managers
{
    public class GameManager : MonoBehaviour
    {
        public event System.Action OnGameOver;
        public event System.Action OnMissionSucced;

        public static GameManager Instance { get; private set; }
       
        private void Awake()
        {
            SingletonThisGameObject();
        }

        private void SingletonThisGameObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        public void GameOver()
        {
            //if (OnGameOver!= null)
            //{
            //    GameOver();
            //} VVV Kýsa yazýmý VVV
            OnGameOver?.Invoke();
        }
        public void MissionSucced()
        {
            OnMissionSucced?.Invoke();
        }
        public void LoadLevelScene()
        {

        }
        public void LoadLevelScene(int levelIndex = 0)
        {
            StartCoroutine(LoadLevelSceneAsync(levelIndex));
        }
        private IEnumerator LoadLevelSceneAsync(int levelIndex)
        {
            //0sa restart 1 ise bi sonraki bolume gec 
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + levelIndex);
        }
        public void LoadMenuScene()
        {
            StartCoroutine(LoadMenuSceneAsync());
        }
        public IEnumerator LoadMenuSceneAsync()
        {
            yield return SceneManager.LoadSceneAsync("Menu");
        }
        public void Exit()
        {
            Debug.Log("Exit process on triggered");
            Application.Quit();
        }
    }
}