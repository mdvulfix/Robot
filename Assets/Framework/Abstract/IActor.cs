using System;
using System.Collections.Generic;
using UnityEngine;

namespace Robot.Framework
{
   
    public interface IActor: ICacheable
    { 
        Transform Transform { get; } 
        
        void OnInitialize();
    
    }

    
    public abstract class Actor: MonoBehaviour, IActor
    {
      
        public Transform Transform { get; protected set; } 
        
        public void Awake()
        {
            OnInitialize();
        
        } 

        public virtual void OnInitialize()
        {
            Transform = transform;

        }
    
    }
    
}


