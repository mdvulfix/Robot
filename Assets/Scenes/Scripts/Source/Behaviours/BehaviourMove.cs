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
            MetaIndex = new METAINDEX(BEHAVIOUR.MOVE);
            
            rigidbody = actor.Transform.GetComponent<Rigidbody>();


            dataMove = GetDataMove();
            dataMove.SetSpeed(10);

            Debug.Log(this.ToString() + "was created!");

        }
       

        public void Move()
        {          
            rigidbody.AddForce(rigidbody.transform.forward * dataMove.Speed);

        }

        private DataMove GetDataMove()
        {
            return AActor.GetCache<DataMove>(Actor.Index, new METAINDEX(DATA.MOVE));
        }


    }
}