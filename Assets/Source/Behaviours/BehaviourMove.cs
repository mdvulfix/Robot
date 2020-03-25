using System;
using System.Collections.Generic;
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

            
            dataMove = GetDataMove();
            dataMove.SetSpeed(15);


        }
       

        public void Move()
        {          
            rigidbody.AddForce(rigidbody.transform.position * dataMove.Speed * Time.fixedDeltaTime);

        }

        private DataMove GetDataMove()
        {
            var _interface = typeof(IData);
            var _type = typeof(DataMove);
            var _metaIndex = Robot.Framework.Cache.FindIndexInCache(_interface, Robot.Framework.Cache.MetaIndexes);
            var _dataIndex = Robot.Framework.Cache.FindIndexInCache(_type, Robot.Framework.Cache.DataIndexes);
            var _instanceIndex = Actor.Index.InstanceIndex;
            
            return Robot.Framework.Cache.Storage[_metaIndex,_dataIndex,_instanceIndex] as DataMove;
        }


    }
}