using System;
using System.Collections.Generic;
using UnityEngine;

namespace Robot.Framework
{
    
    public interface IBehaviour: IActorUnit, ICacheable 
    {

    }
    
    
    
    public abstract class ABehaviour: IBehaviour
    {
#region Properties
        
        public int Index { get; protected set; }
        
        public IActor Actor { get; protected set; }
        public ICache Cache { get; protected set; }     
        
#endregion
        
        private static readonly int BEHAVIOUR_INDEXES_LENGTH = 100;
        private static List<IBehaviour> indexes = new List<IBehaviour>(BEHAVIOUR_INDEXES_LENGTH);

        //Temp field
        public int index;

        public ABehaviour()
        {
            Index = GetIndex();
            Debug.Log("BehaviourIndex = " + Index.ToString());

            // TODO: Delete editor mode for Behaviour
            this.index = this.Index;

       
        } 
        



        public void SetActor(IActor actor)
        {
            this.Actor = actor;

        }
        
        public int GetIndex()
        {           
            
            //TODO: Create Indexator
            //TODO: Add Get-nethod to assign index to objects
            
            var _behaviour = this as ABehaviour;
            if (!indexes.Contains(_behaviour))
            {
                indexes.Add(_behaviour);
            }       
            
            return indexes.IndexOf(_behaviour);

        }


        /* 
        public void SetCache<T>(IActor actor, T objectToCache) where T: ABehaviour
        {
            Cache<T>.Set(actor, objectToCache);
        }

        public void GetCache<T>(IActor actor) where T: ABehaviour
        {
            Cache<T>.Get(actor);
        }
        */
    
    }
}