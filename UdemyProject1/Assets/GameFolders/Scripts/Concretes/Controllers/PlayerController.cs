using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Inputs;
using UdemyProject1.Managers;
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
        Fuel _fuel;

        bool _canForceUp;
        float _leftRight;
        bool _canMove;

        public float TurnSpeed => _turnSpeed;
        public float Force => _force;

        public bool CanMove => _canMove;

        private void Awake()
        {
            _input = new DefaultInput();
            _mover = new Mover(this);
            _rotator = new Rotator(this);
            _fuel = GetComponent<Fuel>();
        }
        private void Start()
        {
            _canMove = true;
        }
        private void OnEnable()
        {
            GameManager.Instance.OnGameOver += HandleOnEvnetTriggered;
            GameManager.Instance.OnMissionSucced += HandleOnEvnetTriggered;
        }
        private void OnDisable()
        {
            GameManager.Instance.OnGameOver -= HandleOnEvnetTriggered;
            GameManager.Instance.OnMissionSucced -= HandleOnEvnetTriggered;
        }

        private void Update()
        {
            //inputlar alýnýr
            if (!_canMove) return;

            if (_input.IsForceUp && !_fuel.IsEmpty)
            {
                _canForceUp = true;
            }
            else
            {
                _canForceUp = false;
                _fuel.FuelIncrease(0.01f);
            }
            _leftRight = _input.LeftRight;
        }
        private void FixedUpdate()
        {
            // fizik islemleri yapilir
            if (_canForceUp)
            {
                _mover.FixedTick();
                _fuel.FuelDecrease(0.2f);
            }

            _rotator.FixedTick(_leftRight);
        }

        private void HandleOnEvnetTriggered()
        {
            _canMove = false;
            _canForceUp = false;
            _leftRight = 0;
            _fuel.FuelIncrease(0f);
        }
    }
}