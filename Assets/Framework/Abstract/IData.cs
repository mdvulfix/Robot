using System;
using System.Collections.Generic;
using UnityEngine;

namespace Robot.Framework
{
    
    
    public interface IData: IActorUnit, ICacheable
    {
        MetaIndexes DataMetaIndex {get; } 
        List<IData> DataClassIndex {get; } 

        IActor Actor {get; }
    }
        
    
    [System.Serializable]
    public abstract class AData: IData
    {
        [Seria]private int index;

        



#region Properties
        
        public static readonly MetaIndexes DataMetaIndex {get; set{value = MetaIndexes.DATA;}} 
        
        private static readonly int DATA_INDEXES_LENGTH = 100;
        protected static List<IData> DataClassIndex {get; set{value = new List<IData>(DATA_INDEXES_LENGTH);}} 
        
        
        public Index Index {get; protected set; }
        public IActor Actor { get; protected set; }
 
#endregion
        

        

        public AData()
        {
 
            Index = GetIndex();           

            
            // TODO: Delete editor mode for Data
            this.index = this.Index.InstanceIndex;

        } 

        public Index GetIndex()
        {           
            return new Index(this);
        }
        
        public void SetActor(IActor actor)
        {
            this.Actor = actor;

        }
        


    }
}
