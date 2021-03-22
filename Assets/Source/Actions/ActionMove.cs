using System;
using UnityEngine;

namespace Robot
{
    [Serializable]
    public abstract class Action<T>: Action where T: IData
    {
        public T Data;
        
        public override void Initialize(IBot bot)
        {
            if(!GetData<T>())
            {
                Debug.Log("Data not found!");
                return;
            }
        }

    }
}