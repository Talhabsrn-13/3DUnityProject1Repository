using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace UdemyProject1.Controllers
{
    public class FinishFloorController : MonoBehaviour
    {
        [SerializeField] GameObject _finishLigth;
        [SerializeField] GameObject _finishFirework;

        private void OnCollisionEnter(Collision other)
        {
            PlayerController player = other.collider.GetComponent<PlayerController>();

            if (player == null) return;

            // tam tepeden assagiya dogru mu iniyor demis olduk
            if (other.GetContact(0).normal.y == -1)
            {
                _finishFirework.gameObject.SetActive(true);
                _finishLigth.gameObject.SetActive(true);
            }
            else
            {
                //gameover
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}