
using UnityEngine;
using Robot.Framework;

namespace Robot
{
    public class ActorRobot: ActorBase, IActor, ICacheable
    {
        
        public Transform Transform{get; private set;}
        
    
        private DataMove dataMove;
        private BehaviourMove behaviourMove;
      
        [SerializeField] private int speed = 10;

        public ActorRobot()
        {
            this.Transform = transform;
            
            this.dataMove = new DataMove(this);
            this.dataMove.Speed = speed;

            //this.behaviourMove = new BehaviourMove(this);

        }





        public void SetData()
        {
           // Cache.SetData(this, dataMove);
        }

        public void SetBehaviour()
        {
            //Cache.SetBehaviour(this, behaviourMove);
        }


    }
    
}


