using UnityEngine;

namespace Robot
{
   
    public interface IBot: ICacheable
    { 
        GameObject Obj {get; } 
        
        void OnAwake();
    
    }

    
    public abstract class Bot: MonoBehaviour, IBot
    {
        public GameObject Obj {get; private set;} 
        
        public void Awake()
        {
            OnAwake();
        
        } 

        public virtual void OnAwake()
        {
            Obj = gameObject;

        }
    
    }
    
}


