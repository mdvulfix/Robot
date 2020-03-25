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
        
      
        public Index Index{get; protected set; }
        public IActor Actor { get; protected set; }
        
        
#endregion
        
        private static readonly int BEHAVIOUR_INDEXES_LENGTH = 100;
        public static List<IBehaviour> indexes = new List<IBehaviour>(BEHAVIOUR_INDEXES_LENGTH);

        //Temp field
        public int index;

        public ABehaviour()
        {
            Index = GetIndex();

            // TODO: Delete editor mode for Behaviour
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