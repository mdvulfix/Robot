using UnityEngine;
using Robot.Framework;

namespace Robot
{
    [System.Serializable]
    public class BehaviourMove: ABehaviour
    {
               
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private DataMove dataMove;
        

        public BehaviourMove(IActor actor): base()
        {
            SetActor(actor);
            rigidbody = actor.Transform.GetComponent<Rigidbody>();
            //SetCache<BehaviourMove>(Actor, this);

            //dataMove = Cache<DataMove>.Get(actor);
            //dataMove.Speed = 10;

            Debug.Log(this.ToString() + "was created!");

        }
       

        public void Move()
        {          
            rigidbody.AddForce(rigidbody.transform.forward * 5);

        }


    }
}