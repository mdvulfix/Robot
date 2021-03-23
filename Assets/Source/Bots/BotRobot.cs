using System;
using UnityEngine;
using UnityEditor;
using Cache = Robot.Cache;

namespace Robot
{
    [Serializable]
    public class BotRobot: Bot //, IUpdate
    {
        
        [SerializeField]
        private DataMove _move;
        
        private IData    _dataMove;
        private IAction  _actionMove;
      
        public override void OnAwake()
        {
            base.OnAwake();

            //SetUpdatable();
            
            if(_dataMove != null)
                Cache<DataMove>.Set(this, _dataMove as DataMove);
            else
                _dataMove = Cache<DataMove>.Set(this, new DataMove(this, 15));

            if(_actionMove != null)
                Cache<ActionMoveForce>.Set(this, _actionMove as ActionMoveForce);
            else
                _actionMove = Cache<ActionMoveForce>.Set(this, new ActionMoveForce(this));
            
        }

        
        public void Update()
        {
            _actionMove.OnAction();
        }
        
        /*
        public void SetUpdatable()
        {
            Cache.SetUpdatable(this);
        }
        */

    }
    
}


