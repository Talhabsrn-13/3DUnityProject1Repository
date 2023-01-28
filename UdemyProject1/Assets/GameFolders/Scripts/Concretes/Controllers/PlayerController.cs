using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Inputs;
using UdemyProject1.Movements;
using UnityEngine;

namespace UdemyProject1.Controllers
{

    public class PlayerController : MonoBehaviour
    {

        [SerializeField] float _turnSpeed = 180f;
        [SerializeField] float _force = 55f;
        DefaultInput _input;
        Mover _mover;
        Rotator _rotator;

        bool _isForceUp;
        float _leftRight;

        public float TurnSpeed => _turnSpeed;
        public float Force => _force;
        private void Awake()
        {
           
            _input = new DefaultInput();
            _mover = new Mover(this);
            _rotator = new Rotator(this);
        }
        private void Update()
        {
            //inputlar alýnýr

            if (_input.IsForceUp)
            {
                _isForceUp = true;
            }
            else
            {
                _isForceUp = false;
            }
            _leftRight = _input.LeftRight;
        }
        private void FixedUpdate()
        {
            // fizik islemleri yapilir
            if (_isForceUp)
            {
                _mover.FixedTick();
            }

            _rotator.FixedTick(_leftRight);
        }


    }
}