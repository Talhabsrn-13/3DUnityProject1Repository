using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Managers;
using UnityEngine;

namespace UdemyProject1.UIs
{
    public class MenuPanel : MonoBehaviour
    {
        // Start is called before the first frame update

        public void StartClicked()
        {
            GameManager.Instance.LoadLevelScene(1);
        }
        public void ExitClicked()
        {
            GameManager.Instance.Exit();
        }
    }
}  