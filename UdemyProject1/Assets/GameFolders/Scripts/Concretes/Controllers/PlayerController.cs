using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Inputs;
using UdemyProject1.Movements;
using UnityEngine;

namespace UdemyProject1.Controllers
{

    public class PlayerController : MonoBehaviour
    {
 
        DefaultInput _input;
        Mover _mover;

        bool _isForceUp;

        private void Awake()
        {
           
            _input = new DefaultInput();
            _mover = new Mover(GetComponent<Rigidbody>());
        }
        private void Update()
        {
            Debug.Log(_input.IsForceUp);
            //inputlar alýnýr
            if (_input.IsForceUp)
            {
                _isForceUp = true;
            }
            else
            {
                _isForceUp = false;
            }
        }
        private void FixedUpdate()
        {
            // fizik islemleri yapilir
            if (_isForceUp)
            {
                _mover.FixedTick();
            }
        }


    }
}