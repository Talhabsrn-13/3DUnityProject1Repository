using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject1.Movements
{
    public class Mover
    {
        Rigidbody _rigidbody;

        public Mover(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }
        public void FixedTick()
        {
            //Pozisyona gore force veriyor
            _rigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * 55f);
        }
    }
}
