
using UnityEngine;
using Robot.Framework;
using Cache = Robot.Framework.Cache;

namespace Robot
{
    [System.Serializable]
    public class ActorRobot: Actor, IUpdate
    {
        [SerializeField] private DataMove dataMove;
        [SerializeField] private ActionMove actionMove;
      

        
        public override void OnInitialize()
        {
            base.OnInitialize();

            SetUpdatable();
            
            dataMove = Cache<DataMove>.Set(this, new DataMove(this, 10));
            actionMove = Cache<ActionMove>.Set(this, new ActionMove(this));
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


