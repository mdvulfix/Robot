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
    public abstract class Action<T>: IAction where T: class, IData
    {       
        protected IBot  _bot;
        protected T _data;

        
        protected void SetBot(IBot bot)
        {
            _bot = bot;
        }
        
        protected void SetData(IData data)
        {
            _data = data as T;
        }

        public T GetData() 
        {
            var data = Cache<T>.Get(_bot);
            return data;
        }

        public abstract void Initialize(IBot bot);
        public abstract void OnAction();

    }





}