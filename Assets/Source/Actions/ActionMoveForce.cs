using System;
using System.Collections.Generic;
using UnityEngine;

namespace Robot
{
    [Serializable]
    [RequireComponent(typeof(Rigidbody))]
    public class ActionMoveForce: Action<DataMove>
    {
        private Rigidbody _rigidbody;

        public ActionMoveForce(IBot bot)
        {
            if(!GetData(bot))
            {
                Debug.Log("Data not found!");
                return;
            }

            _rigidbody = Bot.Obj.GetComponent<Rigidbody>();
        }
    
        public override void OnAction()
        {
            if(Input.GetKey (KeyCode.W))
                _rigidbody.AddForce(0,0, Data.Speed, ForceMode.Acceleration);
            if (Input.GetKey (KeyCode.S))
                _rigidbody.AddForce(0,0,-Data.Speed, ForceMode.Acceleration);
            if (Input.GetKey (KeyCode.A))
                _rigidbody.AddForce(-Data.Speed,0,0, ForceMode.Acceleration);
            if (Input.GetKey (KeyCode.D))
                _rigidbody.AddForce(Data.Speed,0,0, ForceMode.Acceleration);
            
            if (Input.GetKey (KeyCode.Space))
                _rigidbody.AddForce(0, Data.Speed * 3 , 0, ForceMode.Acceleration);
        }
    }
}