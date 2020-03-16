using UnityEngine;
using Robot.Framework;
namespace Robot
{
    public class BehaviourMove: IBehaviour
    {
        
        public IActor Actor { get; private set; }
        
        private Rigidbody rigidbody;
        private int speed;
        
        /*
        
        public BehaviourMove(IActor actor)
        {
            this.Actor = actor;
            this.rigidbody = actor.Transform.GetComponent<Rigidbody>();
            this.speed = GetData();
        }
        
        

        
        
        
        public void OnFixUpdate()
        {
            Move(speed);

        }
        
        private void Move()
        {
            DataMove dataMove = Cache.GetData(Actor, new)
            var _speed = Ger
            
            
            rigidbody.AddForce(Actor.Transform.forward * speed);
        }
        
        private DataMove GetDataMove()
        {
            
            retern Cache.GetData(Actor)

        }

        */
    }
}