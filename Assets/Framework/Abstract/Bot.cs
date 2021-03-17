using UnityEngine;

namespace Robot
{
   
    public interface IBot: ICacheable
    { 
        Transform Transform { get; } 
        
        void OnAwake();
    
    }

    
    public abstract class Bot: MonoBehaviour, IBot
    {
      
        public Transform Transform { get; protected set; } 
        
        public void Awake()
        {
            OnAwake();
        
        } 

        public virtual void OnAwake()
        {
            Transform = transform;

        }
    
    }
    
}


