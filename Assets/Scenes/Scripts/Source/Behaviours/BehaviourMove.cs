using UnityEngine;
using Robot.Framework;

namespace Robot
{
    public class BehaviourMove: ABehaviour
    {
               
        private Rigidbody rigidbody;
        private DataMove dataMove;
        
        
        public BehaviourMove(IActor actor)
        {
            SetActor(actor);
            SetCache<BehaviourMove>(Actor, this);

            dataMove = Cache<DataMove>.Get(actor);
            dataMove.Speed = 10;

            Debug.Log(this.ToString() + "was created!");

        }



        public override void OnFixUpdate()
        {
            Move();
        }


        private void Move()
        {          
            rigidbody.AddForce(Actor.Transform.forward * dataMove.Speed);
        }
        
    }
}