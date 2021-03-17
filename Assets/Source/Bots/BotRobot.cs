
using UnityEngine;
using Cache = Robot.Cache;

namespace Robot
{
    [System.Serializable]
    public class BotRobot: Bot, IUpdate
    {
        [SerializeField] private DataMove dataMove;
        [SerializeField] private ActionMoveForce actionMove;
      

        
        public override void OnAwake()
        {
            base.OnAwake();

            SetUpdatable();
            
            dataMove = Cache<DataMove>.Set(this, new DataMove(this, 10));
            actionMove = Cache<ActionMoveForce>.Set(this, new ActionMoveForce(this));
        }

        
        public void OnUpdate()
        {
            actionMove.OnMove();
        }
        
        
        public void SetUpdatable()
        {
            Cache.SetUpdatable(this);
        }


    }
    
}


