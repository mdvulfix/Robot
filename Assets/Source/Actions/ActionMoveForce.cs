using System;
using System.Collections.Generic;
using UnityEngine;

namespace Robot
{
    [Serializable]
    [RequireComponent(typeof(Rigidbody))]
    public class ActionMoveForce: ActionMove
    {
        
        private Rigidbody _rigidbody;

        public ActionMoveForce(IBot bot)
        {
            base.Initialize(bot);
        }
        
        public override void GetComponents()
        {
            _rigidbody = _bot.Obj.GetComponent<Rigidbody>();
        }
        
        public override void OnAction()
        {
                if(Input.GetKey (KeyCode.W))
                    _rigidbody.AddForce(0,0, _data.Speed, ForceMode.Acceleration);
                if (Input.GetKey (KeyCode.S))
                    _rigidbody.AddForce(0,0,-_data.Speed, ForceMode.Acceleration);
                if (Input.GetKey (KeyCode.A))
                    _rigidbody.AddForce(-_data.Speed,0,0, ForceMode.Acceleration);
                if (Input.GetKey (KeyCode.D))
                    _rigidbody.AddForce(_data.Speed,0,0, ForceMode.Acceleration);
                
                if (Input.GetKey (KeyCode.Space))
                    _rigidbody.AddForce(0, _data.Speed * 3 , 0, ForceMode.Acceleration);
        }   
    



    }
}