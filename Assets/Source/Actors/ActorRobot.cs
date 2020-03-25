
using UnityEngine;
using Robot.Framework;

namespace Robot
{
    [System.Serializable]
    public class ActorRobot: AActor
    {
        [SerializeField] DataMove dataMove;
        [SerializeField] private BehaviourMove behaviourMove;
      

        
        public override void OnInitialize()
        {
            dataMove = SetCache<DataMove>(new DataMove(this, 5)); 
            behaviourMove = SetCache<BehaviourMove>(new BehaviourMove(this));
            
        }

        
        public override void OnFixedUpdate()
        {
            behaviourMove.Move();

        }

        private void FixedUpdate() 
        {
            
            OnFixedUpdate();



        }





    }
    
}


