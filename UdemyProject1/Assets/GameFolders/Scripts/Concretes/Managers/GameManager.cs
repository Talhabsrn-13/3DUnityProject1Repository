using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Abstracts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace UdemyProject1.Managers
{
    public class GameManager : SingleteonThisObject<GameManager>
    {
        public event System.Action OnGameOver;
        public event System.Action OnMissionSucced;
        private void Awake()
        {
            SingletonThisGameObject(this);
        }
        private void Start()
        {
            SoundManager.Instance.PlaySound(1);
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
        public void LoadLevelScene(int levelIndex = 0)
        {
            StartCoroutine(LoadLevelSceneAsync(levelIndex));
        }
        private IEnumerator LoadLevelSceneAsync(int levelIndex)
        {
            //0sa restart 1 ise bi sonraki bolume gec 
            SoundManager.Instance.StopSound(1);
            yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + levelIndex);
            SoundManager.Instance.PlaySound(2);
        }
        public void LoadMenuScene()
        {
            StartCoroutine(LoadMenuSceneAsync());
           
        }
        public IEnumerator LoadMenuSceneAsync()
        {
            SoundManager.Instance.StopSound(2);
            yield return SceneManager.LoadSceneAsync("Menu");
            SoundManager.Instance.PlaySound(1);
        }
        public void Exit()
        {
            Debug.Log("Exit process on triggered");
            Application.Quit();
        }
    }
}