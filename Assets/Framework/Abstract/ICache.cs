using System;
using System.Collections.Generic;
using UnityEngine;

namespace Robot.Framework
{
    public enum MetaIndexes
    {
        NONE,
        ACTOR,
        DATA,
        BEHAVIOUR,
        META_COUNT
    }

        
    public interface ICache
    {       
        Index[,,] Storage{get; }
        ICacheable FindIndexInCache(Index index);

    }

    public struct IndexStruct
    {
       public int MetaIndex;
       public int DataIndex;
       public int InstanceIndex;

        public IndexStruct(int metaIndex, int dataIndex, int instanceIndex)
        {
            this.MetaIndex = metaIndex;
            this.DataIndex = dataIndex;
            this.InstanceIndex = instanceIndex;

        }
    }
    
    
    public static class Cache
    {      
        
        private static readonly int STORAGE_LENGTH = 100;
        public static Dictionary<Index, ICacheable> Storage = new Dictionary <Index, ICacheable>(100);

        public static ICacheable FindIndexInCache(Index index)
        {
            ICacheable _instance = null;
            if (!Storage.ContainsKey(index))
            {
                Storage.Add(index, index.Instance);
            }  
            
            Storage.TryGetValue(index, out _instance);
            
            return _instance;
        }
        
    }
    

    public class Index
    {
        public int MetaIndex {get; private set;}
        public int DataIndex {get; private set;}
        public int InstanceIndex {get; private set;}

        
        
        public ICacheable Instance{get; private set;}
        
        public Index(ICacheable instance)
        {
            this.Instance = instance;
            GetIndex();
        }

        public void GetIndex()
        {
            var index = Indexer.CreateIndex(this);
            
            MetaIndex = index.MetaIndex;
            DataIndex = index.DataIndex;
            InstanceIndex = index.InstanceIndex;
        }


    }

    public static class Indexer
    {     
        public static IndexStruct CreateIndex(ICacheable instance) 
        {
            var _type = instance.GetType();
            var _interfaces = instance.GetType().GetInterfaces();
            var _metaIndex = new IndexStruct();
            
            // TODO: make this GetTypeIndex function shorter
            foreach (var _interface in _interfaces)
            {
            


                if(_interface == typeof(IActor))
                {
                    
                    var _actor = instance as IActor;
                    if (!AActor.indexes.Contains(_actor))
                    {
                        AActor.indexes.Add(_actor);
                    }  

                    
                    ;
                    _metaIndex.DataIndex = Cache.FindIndexInCache(_type, Cache.DataIndexes);
                    _metaIndex.InstanceIndex = AActor.indexes.IndexOf(_actor);
                
                }
                
                if(_interface == typeof(IData)) 
                {

                    var _data = instance as IData;
                    if (!AData.indexes.Contains(_data))
                    {
                        AData.indexes.Add(_data);
                    }  

                    
                    _metaIndex.MetaIndex = Cache.FindIndexInCache(_interface, Cache.MetaIndexes);
                    _metaIndex.DataIndex = Cache.FindIndexInCache(_type, Cache.DataIndexes);
                    _metaIndex.InstanceIndex = AData.indexes.IndexOf(_data);
                
                }

                if(_interface == typeof(IBehaviour))
                {
                    var _behaviour = instance as IBehaviour;
                    if (!ABehaviour.indexes.Contains(_behaviour))
                    {
                        ABehaviour.indexes.Add(_behaviour);
                    }  

                    _metaIndex.MetaIndex = Cache.FindIndexInCache(_interface, Cache.MetaIndexes);
                    _metaIndex.DataIndex = Cache.FindIndexInCache(_type, Cache.DataIndexes);
                    _metaIndex.InstanceIndex = ABehaviour.indexes.IndexOf(_behaviour);
                }
            

            }
            return _metaIndex;
        }



    }
    
    

    
    
    public interface IActor: ICacheable, IUpdatable
    {
        
        MetaIndexes MetaIndex {get; }  
        Dictionary<Type, int> ClassIndex {get; } 
        List<IActor> InstanceIndex {get; } 
        
        Transform Transform { get; } 
        
        
        
        void OnInitialize();
    
    
    }

    
    [System.Serializable]
    public abstract class AActor: MonoBehaviour, IActor
    {
        
        #region Fields
            private static readonly int ACTOR_CLASS_INDEXES_LENGTH = 100;
            private static readonly int ACTOR_INSTANCE_INDEXES_LENGTH = 100;
          
            

        #endregion
        
        #region Properties
            

            public static MetaIndexes MetaIndex {get; private set;}
            public static Dictionary<Type, int> ClassIndex {get; protected set;} 
            public static List<IActor> InstanceIndex {get; protected set;} 
            
            public Index Index { get; protected set; } 
            
            public Transform Transform { get; protected set; } 
        
        
        #endregion  
        
        #region Constructors
            public void Start()
            {
                
                this.

                OnInitialize();
            
            } 
        #endregion 


        #region PublicFunctions
            public virtual void OnInitialize()
            {
                MetaIndex = MetaIndexes.ACTOR;
                ClassIndex = new Dictionary<Type, int> (ACTOR_CLASS_INDEXES_LENGTH);
                InstanceIndex = new List<IActor>(ACTOR_INSTANCE_INDEXES_LENGTH);
                
                
                Index = GetCacheIndex();

                Transform = transform;

            }
            
            public virtual void OnUpdate()
            {

               

            }
            public virtual void OnFixedUpdate()
            {

               

            }
            public virtual void OnLateUpdate()
            {

               

            }
        
                
        #endregion


        #region PrivateFunctions

            public Index GetCacheIndex()
            {           
                return new Index(this);
                
            }


            public static T SetCache<T>(T data) where T: ICacheable
            {           
                var _index = data.Index;
                Cache.Storage[_index.MetaIndex, _index.DataIndex, _index.InstanceIndex] = data;
                return data;
            }

            public static T GetCache<T>(int metaIndex, int dataIndex, int instanceIndex) where T: ICacheable
            {           
                return (T)Cache.Storage[metaIndex, dataIndex, instanceIndex];
            }
              
        #endregion

    }
    
}


