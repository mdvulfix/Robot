using System;
using System.Collections.Generic;
using UnityEngine;

namespace Robot
{
    [Serializable]
    [RequireComponent(typeof(Rigidbody))]
    public class ActionShootRocket: ActionShoot
    {
        
        private Rigidbody _rigidbody;

        public ActionShootRocket(IBot bot)
        {
            base.Initialize(bot);
        }
        
        public override void GetComponents()
        {
            _rigidbody = _bot.Obj.GetComponent<Rigidbody>();
        }
        
        public override void OnAction()
        {

        }   
    



    }
}