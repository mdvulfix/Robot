using System;
using System.Collections.Generic;
using UnityEngine;

namespace Robot.Framework
{
    public enum MetaIndexValue
    {
        NONE,
        ACTOR,
        DATA,
        BEHAVIOUR,
        META_COUNT
    }

    public enum CacheActor
    {
        NONE,
        ROBOT,
        ACTOR_COUNT
    }

    public enum CacheData
    {
        NONE,
        MOVE,
        JUMP,
        DATA_COUNT
    }

    public enum CacheBehaviour
    {
        NONE,
        MOVE,
        JUMP,
        BEHAVIOUR_COUNT
    }

    
    public interface ICache
    {       
        Type[] MetaIndexes{get; }
        Type[] DataIndexes {get; }
        ICacheable[,,] Storage{get; }

        int FindIndexInCache(Type type, Type[] indexes);

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
        

        /*
        public CacheMetaIndex(CacheData dataIndex, int objectIndex)
        {
            this.metaTypeIndex = (int)CacheMetaType.DATA;
            this.metaClassIndex = (int)dataIndex;
            this.objectIndex = objectIndex;

        }

        public CacheMetaIndex(CacheBehaviour behaviourIndex, int objectIndex)
        {
            this.metaTypeIndex = (int)CacheMetaType.BEHAVIOUR;
            this.metaClassIndex = (int)behaviourIndex;
            this.objectIndex = objectIndex;

        }
        */

    }
    
    
    public static class Cache
    {
        public static readonly Type[] MetaIndexes = new Type[]
        {
            null,
            typeof(IActor),
            typeof(IData),
            typeof(IBehaviour)
        };

        public static Type[] DataIndexes = new Type[100];


        private static readonly int METATYPE_INDEXES_LENGTH = 100;
        private static readonly int CLASSTYPE_INDEXES_LENGTH = 100;
        private static readonly int INSTANCE_INDEXES_LENGTH = 100;
        
        public static ICacheable[,,] Storage = new ICacheable[METATYPE_INDEXES_LENGTH, CLASSTYPE_INDEXES_LENGTH, INSTANCE_INDEXES_LENGTH];

        public static int FindIndexInCache(Type type, Type[] indexes)
        {
            for (int _index = 0; _index < indexes.Length; _index++)
            {
                if(indexes[_index] == type)
                    return _index;
            }
            
            for (int _index = 0; _index < indexes.Length; _index++)
            {
                if(indexes[_index] == null)
                {
                    indexes[_index] = type;
                    return _index;
                }
                    
            }

            return 0;
        }
        
    }
    

    public class Index
    {
        public int MetaIndex {get; private set;}
        public int DataIndex {get; private set;}
        public int InstanceIndex {get; private set;}

        private ICacheable instance;
        
        public Index(ICacheable instance)
        {
            this.instance = instance;
            GetIndex();
        }

        public void GetIndex()
        {
            var index = CacheIndexer.CreateIndex(instance);

            MetaIndex = index.MetaIndex;
            DataIndex = index.DataIndex;
            InstanceIndex = index.InstanceIndex;
        }


    }

    public static class CacheIndexer
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

                    
                    _metaIndex.MetaIndex = Cache.FindIndexInCache(_interface, Cache.MetaIndexes);
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
        Transform Transform { get; } 
        void OnInitialize();
    }

    
    public abstract class AActor: MonoBehaviour, IActor
    {
        
        #region Fields
            

            
            private static readonly int ACTOR_INDEXES_LENGTH = 100;
            public static List<IActor> indexes = new List<IActor>(ACTOR_INDEXES_LENGTH);
            
            
            

            

        #endregion
        
        #region Properties
            public Index Index { get; protected set; } 
            public Transform Transform { get; protected set; } 
        
        
        #endregion  
        
        #region Constructors
            public void Start()
            {
                Index = GetIndex();
                this.Transform = transform;

                OnInitialize();
            
            } 
        #endregion 


        #region PublicFunctions
            public abstract void OnInitialize();
            
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

            public Index GetIndex()
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


