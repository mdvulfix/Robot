using System.Collections.Generic;

namespace Robot.Framework
{
      
    
    public static class Cache
    {
    
        public static List<IUpdate> Updatables = new List<IUpdate>(100);
        public static List<IFixUpdate> FixUpdatables = new List<IFixUpdate>(100);
        public static List<ILateUpdate> LateUpdatables = new List<ILateUpdate>(100);
    
        
        
        public static void SetUpdatable(IUpdate updatable)
        {
            if(!Updatables.Contains(updatable))
            {
                Updatables.Add(updatable);
            }
            
        }

        public static void SetFixUpdatable(IFixUpdate updatable)
        {
            if(!FixUpdatables.Contains(updatable))
            {
                FixUpdatables.Add(updatable);
            }
            
        }

        public static void SetLateUpdatable(ILateUpdate updatable)
        {
            if(!LateUpdatables.Contains(updatable))
            {
                LateUpdatables.Add(updatable);
            }
            
        }
    
    }
    
    public static class Cache<T> where T: ICacheable
    {
        
        private static Dictionary<int, Dictionary<int, T>> Storage = new Dictionary<int, Dictionary<int, T>>(100);


        public static T Set(IActor actor, T instance)
        {
            var _data = new  Dictionary<int, T>();
            _data.Add(typeof(T).GetHashCode(), instance);
            Storage.Add(actor.GetHashCode(), _data);
            return instance;
        }

        public static T Get(IActor actor)
        {
            Dictionary<int, T> _data;
            T _instance;
            Storage.TryGetValue(actor.GetHashCode(), out _data);
            _data.TryGetValue(typeof(T).GetHashCode(), out _instance);
            
            return _instance;
        }



    }
}