using System;
using UnityEngine;

namespace Robot
{
    public interface IData: ICacheable
    {
        IBot Bot {get; }
    }
        
    [Serializable]
    public abstract class Data: IData
    {
        public IBot Bot {get; protected set;}
 
        public void SetBot(IBot bot)
        {
            Bot = bot;
       
        } 
    }
}
