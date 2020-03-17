
using UnityEngine;
using Robot.Framework;

namespace Robot
{
    public class ActorRobot: AActor
    {
        
        private DataMove dataMove;
        private BehaviourMove behaviourMove;
      
        public ActorRobot()
        {
         
            this.dataMove = new DataMove(this);
            this.behaviourMove = new BehaviourMove(this);

        }

    }
    
}


