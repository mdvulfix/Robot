using System;
using UnityEngine;
using UnityEditor;
using Cache = Robot.Cache;

namespace Robot
{
    [Serializable]
    public class BotRobot: Bot //, IUpdate
    {
        
        
        [FoldoutGroup("Data")] public DataMove _move;
        [FoldoutGroup("Data")] public DataMove _move2;
        
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


