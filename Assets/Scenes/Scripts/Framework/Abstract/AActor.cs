using System;
using System.Collections.Generic;
using UnityEngine;

namespace Robot.Framework
{
    enum MetaType
    {
        NONE,
        DATA,
        BEHAVIOUR,
        METATYPE_COUNT
    }

    
    
    public interface IActor: ICacheable, IUpdatable
    {
        Transform Transform { get; } 
        void OnInitialize();
    }

    
    public abstract class AActor: MonoBehaviour, IActor
    {
        
        #region Fields
            
            private static readonly int META_TYPES_LENGTH = (int)MetaType.METATYPE_COUNT;
            
            private static readonly int ACTOR_INDEXES_LENGTH = 100;
            private static List<IActor> indexes = new List<IActor>(ACTOR_INDEXES_LENGTH);
            
            private static readonly int INDEXES_LENGTH = 100;
            private Dictionary<int, IData> actorData = new Dictionary<int, IData>(INDEXES_LENGTH);
            private Dictionary<int, IBehaviour> actorBehaviour = new Dictionary<int, IBehaviour>(INDEXES_LENGTH);
        
            
            public static int[,,] cache = new int[ACTOR_INDEXES_LENGTH, META_TYPES_LENGTH, INDEXES_LENGTH];



        #endregion
        
        #region Properties
            public int Index { get; protected set; } 
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
            
            public T SetData<T>(T data) where T: IData
            {           
                if (!actorData.ContainsKey(data.Index))
                {
                    actorData.Add(data.Index, data);
                    Debug.Log("Data was set to cache!");
                }       
                else
                {
                    Debug.LogWarning("Data was not set to cache!");
                }

                return data;
            }
            
            public T SetBehaviour<T>(T behaviour) where T: IBehaviour
            {           
                if (!actorBehaviour.ContainsKey(behaviour.Index))
                {
                    actorBehaviour.Add(behaviour.Index, behaviour);
                    Debug.Log("Behaviour was set to cache!");
                }       
                else
                {
                    Debug.LogWarning("Behaviour was not set to cache!");
                }

                return behaviour;
            }
        
        
        
        
        
        #endregion

    }
    
}


