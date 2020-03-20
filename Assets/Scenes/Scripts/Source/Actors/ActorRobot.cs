
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
            dataMove = SetCache<DataMove>(Index, new DataMove(this, 5)); 
            behaviourMove = SetCache<BehaviourMove>(Index, new BehaviourMove(this));

        }

        
        public override void OnUpdate()
        {
            behaviourMove.Move();

        }

        private void Update() 
        {
            
            OnUpdate();



        }





    }
    
}


