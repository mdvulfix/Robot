using System;
using System.Collections.Generic;
using UnityEngine;

namespace Robot
{
    [Serializable]
    [RequireComponent(typeof(Rigidbody))]
    public class ActionShootBomb: ActionShoot
    {
        
        private Rigidbody _rigidbody;

        public ActionShootBomb(IBot bot)
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