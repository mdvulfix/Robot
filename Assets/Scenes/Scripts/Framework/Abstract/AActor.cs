
using UnityEngine;

namespace Robot.Framework
{

    public interface IActor
    {
        Transform Transform {get;}
    }


    [System.Serializable]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class AActor: MonoBehaviour, IActor
    {
        public Transform Transform {get; private set;}

        private void Awake() 
        {
            this.Transform = transform;
        }


    }
    
}


