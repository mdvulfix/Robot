using System;
using System.Collections.Generic;
using UnityEngine;

namespace Robot
{
   
    public interface IBot: ICacheable
    { 
        GameObject      Obj     {get; } 
        //List<int>   Actions {get; }
        
        void OnAwake();
    
    }

    [Serializable]
    public class Bot: MonoBehaviour, IBot
    {
        public GameObject      Obj     {get; private set;}    
        
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


