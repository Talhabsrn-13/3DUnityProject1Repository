using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Inputs;
using UnityEngine;

namespace UdemyProject1.Controllers
{

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _force;
        Rigidbody _rigidBody;
        DefaultInput _input;

        bool _isForceUp;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _input = new DefaultInput();
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
                _rigidBody.AddForce(Vector3.up * Time.deltaTime * _force);
            }
        }
    }
}