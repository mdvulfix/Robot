using System;

namespace Robot
{
    public interface IAction: ICacheable 
    {
        void OnAction();
    }
    
    [Serializable]
    public abstract class Action<T>: IAction where T: IData
    {       
        public IBot    Bot  {get; private set;}
        public T       Data {get; private set;}
        
        public bool GetData(IBot bot)
        {
            Bot = bot;
            Data = Cache<T>.Get(bot);
            
            if(Data!=null)
                return true;
            
            return false;
        }

        public abstract void OnAction();
    }
}