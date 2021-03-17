using System;
using System.Collections.Generic;
using UnityEngine;

namespace Robot
{
    [Serializable]
    public class ActionMoveForce: Robot.Action<DataMove>
    {
                
        private Rigidbody _rigidbody;
        private int _speed;


        public ActionMoveForce(IBot bot): base(bot)
        {
            _rigidbody = Bot.Transform.gameObject.GetComponent<Rigidbody>();
            _speed = Data.Speed;
        }
    
        public Vector3 OnMove()
        {

            if (Input.GetKey (KeyCode.W)) 
            {
                _rigidbody.AddForce(0,0, _speed,ForceMode.Acceleration);
            }
            if (Input.GetKey (KeyCode.S)) 
            {
                _rigidbody.AddForce(0,0,-_speed,ForceMode.Acceleration);
            }
            if (Input.GetKey (KeyCode.A)) 
            {
               _rigidbody.AddForce(-_speed,0,0,ForceMode.Acceleration);
            }
            if (Input.GetKey (KeyCode.D)) 
            {
               _rigidbody.AddForce(_speed,0,0,ForceMode.Acceleration);
            }
            if (Input.GetKey (KeyCode.Space)) 
            {
               _rigidbody.AddForce(0, _speed * 3 , 0, ForceMode.Acceleration);
            }

            return Bot.Transform.position;
        }
    }
}