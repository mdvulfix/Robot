using System;
using System.Collections.Generic;
using UnityEngine;

namespace Robot.Framework
{
    
    
    public interface IData: IActorUnit, ICacheable
    {

        
        
    }
    
    
    public abstract class AData: IData
    {


#region Properties
        
        public int Index { get; protected set; }
        
        public IActor Actor { get; protected set; }
        public ICache Cache { get; protected set; }     
        
#endregion
        
        
        private static readonly int DATA_INDEXES_LENGTH = 100;
        private static List<IData> indexes = new List<IData>(DATA_INDEXES_LENGTH);

        public int index;

        public AData()
        {
            Index = GetIndex();
            Debug.Log("DataIndex = " + Index.ToString());
            
            // TODO: Delete editor mode for Data
            this.index = this.Index;

        } 

        public int GetIndex()
        {           
            var data = this as AData;
            if (!indexes.Contains(data))
            {
                indexes.Add(data);
            }       
            
            return indexes.IndexOf(data);

        }
        



        
        public void SetActor(IActor actor)
        {
            this.Actor = actor;

        }
        
        


        /*
        public void GetCache<T>(IActor actor) where T: AData
        {
            Cache<T>.Get(actor);
        }
        
        public void SetCache<T>(IActor actor, T objectToCache) where T: AData
        {
            Cache<T>.Get(actor);
        }
        */

    }
}
