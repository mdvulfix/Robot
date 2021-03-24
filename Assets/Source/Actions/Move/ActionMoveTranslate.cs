using System;
using UnityEngine;

namespace Robot
{
    [Serializable]
    public class ActionMoveTranslate: ActionMove
    {
        private Transform _transform;

        public override void GetComponents()
        {
            _transform = _bot.Obj.transform;
        }

        public override void OnAction()
        {
            _transform.Translate(new Vector3(0, 0, 1) * _data.Speed * Time.deltaTime, Space.World); 
  
        }

    }
}