using System;
using System.Collections.Generic;
using UnityEngine;

namespace Robot
{
    public interface IAction: ICacheable 
    {
        IBot Bot {get; }
    }
    
    [System.Serializable]
    public abstract class Action<T>: IAction where T: IData
    {
        public IBot Bot {get; set;}
        public T Data {get; protected set;}
        
        public Action(IBot bot)
        {
            Bot = bot;
            Data = Cache<T>.Get(bot);

        }
    
    }
}