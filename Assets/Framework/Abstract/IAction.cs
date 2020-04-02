using System;
using System.Collections.Generic;
using UnityEngine;

namespace Robot.Framework
{
    public interface IAction: ICacheable 
    {
        IActor Actor {get; }
    }
    
    [System.Serializable]
    public abstract class Action<T>: IAction where T: IData
    {
        public IActor Actor {get; set;}
        public T Data {get; protected set;}
        
        public Action(IActor actor)
        {
            Actor = actor;
            Data = Cache<T>.Get(actor);

        }

        public abstract void OnAction();
    
    }
}