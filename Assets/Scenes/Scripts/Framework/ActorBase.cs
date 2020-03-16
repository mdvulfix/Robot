
using UnityEngine;

namespace Robot.Framework
{
    [System.Serializable]
    [RequireComponent(typeof(Rigidbody))]
    public class ActorBase: MonoBehaviour
    {

        public Rigidbody Rigidbody {get; private set;}
        
        public virtual void OnAwake() 
        {
            this.Rigidbody = GetComponent<Rigidbody>();


        }
        

    }
    
}


