using System;
using UnityEngine;

namespace Robot
{
    public interface IData: ICacheable
    {
        IBot Bot {get; }
    }
        
    [Serializable]
    public class Data: ScriptableObject, IData
    {
        public IBot Bot {get; protected set;}
 
        public Data()
        {
            Bot = bot;
       
        } 
    }
}
