using System;
using System.Collections.Generic;
using UnityEngine;

namespace Robot.Framework
{
    public enum METATYPE
    {
        NONE,
        ACTOR,
        DATA,
        BEHAVIOUR,
        META_COUNT
    }

    public enum ACTOR
    {
        NONE,
        ROBOT,
        ACTOR_COUNT
    }

    public enum DATA
    {
        NONE,
        MOVE,
        JUMP,
        DATA_COUNT
    }

    public enum BEHAVIOUR
    {
        NONE,
        MOVE,
        JUMP,
        BEHAVIOUR_COUNT
    }

    public struct METAINDEX
    {
       public int metaType;
       public int metaIndex;

        public METAINDEX(int metaType, int metaIndex)
        {
            this.metaType = metaType;
            this.metaIndex = metaIndex;

        }

        public METAINDEX(DATA metaIndex)
        {
            this.metaType = (int)METATYPE.DATA;
            this.metaIndex = (int)metaIndex;

        }

        public METAINDEX(BEHAVIOUR metaIndex)
        {
            this.metaType = (int)METATYPE.BEHAVIOUR;
            this.metaIndex = (int)metaIndex;

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
            
            private static readonly int METATYPE_LENGTH = 100;
            private static readonly int METAINDEXES_LENGTH = 100;
            
            private static readonly int ACTOR_INDEXES_LENGTH = 100;
            private static List<IActor> indexes = new List<IActor>(ACTOR_INDEXES_LENGTH);
            
            //private static readonly int INDEXES_LENGTH = 100;
            //private Dictionary<int, IData> actorData = new Dictionary<int, IData>(INDEXES_LENGTH);
            //private Dictionary<int, IBehaviour> actorBehaviour = new Dictionary<int, IBehaviour>(INDEXES_LENGTH);
        
            
            public static ICacheable[,,] cache = new ICacheable[ACTOR_INDEXES_LENGTH, METATYPE_LENGTH, METAINDEXES_LENGTH];



        #endregion
        
        #region Properties
            public int Index { get; protected set; } 
            public METAINDEX MetaIndex { get; protected set; } 
            public Transform Transform { get; protected set; } 
        
        
        #endregion  
        
        #region Constructors
            public void Start()
            {
                this.Index = GetIndex();
                this.Transform = transform;
                Debug.Log("ActorIndex = " + Index.ToString());

                OnInitialize();
            
            } 
        #endregion 


        #region PublicFunctions
            public abstract void OnInitialize();
            public virtual void OnUpdate()
            {



            }
        
        
        
        #endregion


        #region PrivateFunctions
            public int GetIndex()
            {           
                var actor = this as IActor;
                if (!indexes.Contains(actor))
                {
                    indexes.Add(actor);
                }       
                return indexes.IndexOf(actor);
            }
            
            public static T SetCache<T>(int actorIndex, T data) where T: ICacheable
            {           
                var metaType = data.MetaIndex.metaType;
                var metaIndex = data.MetaIndex.metaIndex;
                cache[actorIndex, metaType, metaIndex] = data;
                return data;
            }

            public static T GetCache<T>(int actorIndex, METAINDEX metaIndex) where T: ICacheable
            {           

                return (T)cache[actorIndex, metaIndex.metaType, metaIndex.metaIndex];
            }
              
        #endregion

    }
    
}


