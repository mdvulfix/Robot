
using UnityEngine;
using Cache = Robot.Cache;

namespace Robot
{
    [System.Serializable]
    public class BotRobot: Bot, IUpdate
    {
        [SerializeField] private DataMove dataMove;
        [SerializeField] private ActionMoveForce actionMove;
      
        public Data[] Storage;
        
        
        public override void OnAwake()
        {
            base.OnAwake();

            SetUpdatable();
            
            if(dataMove == null)
            {
                foreach (var data in Storage)
                {
                    if(data is DataMove)
                        dataMove = data as DataMove;
                }
                
                //dataMove = new DataMove(this, 10);  
            
            }
            Cache<DataMove>.Set(this, dataMove);
            
            if(actionMove == null)
                actionMove = Cache<ActionMoveForce>.Set(this, new ActionMoveForce(this));
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


