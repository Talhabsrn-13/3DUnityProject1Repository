using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UdemyProject1.Managers
{
    public class GameManager : MonoBehaviour
    {
        public event System.Action OnGameOver;
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
            //} VVV K�sa yaz�m� VVV
            OnGameOver?.Invoke();
        }
    }
}