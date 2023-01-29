using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Managers;
using UnityEngine;

namespace UdemyProject1.UIs { 
public class WinConditionObject : MonoBehaviour
{
        [SerializeField] GameObject _winConditionPanel;
        private void Awake()
        {
            if (_winConditionPanel.activeSelf)
            {
                _winConditionPanel.SetActive(false);
            }
        }

        private void OnEnable()
        {
            GameManager.Instance.OnMissionSucced += HandledOnLevelSucced;
        }
        private void OnDisable()
        {
            GameManager.Instance.OnMissionSucced -= HandledOnLevelSucced;
        }

        private void HandledOnLevelSucced()
        {
            if (!_winConditionPanel.activeSelf)
            {
                _winConditionPanel.SetActive(true);
            }
        }
    }
}