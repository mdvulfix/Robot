using System;
using UnityEngine;

namespace Robot
{
    public interface IAction: ICacheable 
    {
        void Initialize(IBot bot);
        void OnAction();
    }
    
    [Serializable]
    public abstract class Action: ScriptableObject, IAction 
    {       
        protected IBot    _bot;
        protected IData   _data;
        
        public virtual void Initialize(IBot bot)
        {
            SetBot(bot);

        }

        public bool GetData<T>() where T: IData
        {
            _data = Cache<T>.Get(_bot) as IData;
            
            if(_data == null)
                return false;
            
            return true;
        }

        public abstract void OnAction();
    
        protected void SetBot(IBot bot)
        {
            _bot = bot;
        }
        
        protected void SetData(IData data)
        {
            _data = data;
        }
    
    
    }
}