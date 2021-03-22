using System;
using UnityEngine;
using Cache = Robot.Cache;

namespace Robot
{
    [Serializable]
    public class BotRobot: Bot, IUpdate
    {
        [SerializeField] private Data dataMove;
        [SerializeField] private Action actionMove;
      
        public override void OnAwake()
        {
            base.OnAwake();

            SetUpdatable();
            
            if(dataMove != null)
                Cache<DataMove>.Set(this, dataMove as DataMove);

            actionMove.Initialize(this);
            
        }

        
        
        
        public void OnUpdate()
        {
            actionMove.OnAction();
        }
        
        
        public void SetUpdatable()
        {
            Cache.SetUpdatable(this);
        }


    }
    
}


