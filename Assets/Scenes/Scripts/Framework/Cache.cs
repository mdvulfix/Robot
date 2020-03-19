using UnityEngine;
using System;
using System.Collections.Generic;

namespace Robot.Framework
{

    public interface ICache
    {

    }
    
    public class Cache<T> : ICache where T : ICacheable
    {
        private static readonly int CACHE_LENGTH = 100;
        private static Dictionary<int, Dictionary<int, T>> cache = new Dictionary<int, Dictionary<int, T>>(CACHE_LENGTH);
        
        
        public static T Get(int actorIndex) 
        {
            var type = typeof(T);
            Dictionary<Type, T> container = null;
            
            if (!cache.TryGetValue(actor, out container)) 
            {
                Debug.LogWarning("Object not in cache!");
            }


            T item = default(T);
            if (!container.TryGetValue(type, out item)) 
            {
                Debug.LogWarning("Object not in cache!");
            }
            return item;
        }
        /*
        public static void Set(IActor actor, T objectToCache) 
        {
            var type = typeof(T);
            Dictionary<Type, T> container = null;
            
		    if (!cache.TryGetValue(actor, out container)) {
			    container = new Dictionary<Type, T>();
			    cache.Add(actor, container);
            }

			container.Add(type, objectToCache);
            Debug.Log(objectToCache.ToString() + "was added to cache!");
        }
        */
       
    }

}