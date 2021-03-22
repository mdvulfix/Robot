using System;
using System.Collections.Generic;
using UnityEngine;

namespace Robot
{
    [Serializable]
    [RequireComponent(typeof(Rigidbody))]
    [CreateAssetMenu(fileName = "ActionMoveForce", menuName = "Actions/Move: Force")]
    public class ActionMoveForce: Action
    {
        private Rigidbody _rigidbody;

        public override void Initialize(IBot bot)
        {
            base.Initialize(bot);
            
            if(!GetData<DataMove>())
            {
                Debug.Log("Data not found!");
                return;
            }

            _rigidbody = _bot.Obj.GetComponent<Rigidbody>();
        }
    
        public override void OnAction()
        {
            if(_data is DataMove)
            {
                var data = _data as DataMove;
                if(Input.GetKey (KeyCode.W))
                    _rigidbody.AddForce(0,0, data.Speed, ForceMode.Acceleration);
                if (Input.GetKey (KeyCode.S))
                    _rigidbody.AddForce(0,0,-data.Speed, ForceMode.Acceleration);
                if (Input.GetKey (KeyCode.A))
                    _rigidbody.AddForce(-data.Speed,0,0, ForceMode.Acceleration);
                if (Input.GetKey (KeyCode.D))
                    _rigidbody.AddForce(data.Speed,0,0, ForceMode.Acceleration);
                
                if (Input.GetKey (KeyCode.Space))
                    _rigidbody.AddForce(0, data.Speed * 3 , 0, ForceMode.Acceleration);
            }
        }   
    



    }
}