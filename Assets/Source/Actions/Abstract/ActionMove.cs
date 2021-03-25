using System;
using UnityEngine;

namespace Robot
{    
    
    [Serializable]
    public abstract class ActionMove: Action<DataMove>
    {
        
        public DataMove dataMove;
        
        public override void Initialize(IBot bot)
        {
            SetBot(bot);
            
            if(GetData() == null)
            {
                Debug.Log("Data not found!");
                return;
            }
            
            GetComponents();
        }
    
        public abstract void GetComponents();

    }

}