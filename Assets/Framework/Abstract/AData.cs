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
        
        public Index Index{get; protected set; }
        
        public IActor Actor { get; protected set; }
        public ICache Cache { get; protected set; }     
        
#endregion
        
        
        private static readonly int DATA_INDEXES_LENGTH = 100;
        public static List<IData> indexes = new List<IData>(DATA_INDEXES_LENGTH);

        public int index;

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
