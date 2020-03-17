using UnityEngine;
using System.Collections.Generic;

namespace Robot.Framework
{

    public interface ICache
    {

    }
    
    public class Cache<T> : ICache where T : ICacheable
    {
        private static Dictionary<T, Dictionary<IActor, T>> cache = new Dictionary<T, Dictionary<IActor, T>>(100);
        private Dictionary<IActor, T> actorCache;
       
        public Cache()
        {
            actorCache = new Dictionary<IActor, T>(100);


        }

        public T Get(IActor actor) 
        {
            T objectToCache;
            actorCache.TryGetValue(actor, out objectToCache);
            return objectToCache;
                
        }

        public void Set(IActor actor, T objectToCache)
        {
            actorCache.Add(actor, objectToCache);
            cache.Add(objectToCache, actorCache);
        }

        
        
        //private int [][,] actorData = new [][,] actorData 


        /*
        public static void SetData<A, D>(A actor, DataType dataType, D data) where A : IActor where D : IData, new()
        {
            actorData.Add(actor, dataType, data);

        }

        public static D GetData<A, D>(A actor) where A : IActor where D : IData, new()
        {
            IData _data;
            actorData.TryGetValue(actor, out _data);
            return (D)_data;
             
        }
        
        public static void SetBehaviour<A, B>(A actor, B behaviour) where A : IActor where B : IBehaviour, new()
        {
            actorBehaviour.Add(actor, behaviour);

        }

        public static B GetBehaviour<A, B>(A actor) where A : IActor where B : IBehaviour, new()
        {
            IBehaviour _behaviour;
            actorBehaviour.TryGetValue(actor, out _behaviour);
            return (B) _behaviour;
             
        }
        */

    }






}