using System;
using System.Collections.Generic;
using UnityEngine;

namespace Robot.Framework
{
    
    public interface IBehaviour: ICacheable 
    {
        MetaIndexes MetaIndex {get; } 
        List<IBehaviour> ClassIndex {get; } 

        IActor Actor {get; }
    }
    
    
    
    public abstract class ABehaviour: IBehaviour
    {


#region Fields

        private static readonly MetaIndexes _metaIndex = MetaIndexes.BEHAVIOUR;
        
        private static readonly int BEHAVIOUR_INDEXES_LENGTH = 100;
        private static readonly List<IBehaviour> _classIndex = new List<IBehaviour>(BEHAVIOUR_INDEXES_LENGTH);

#endregion

#region Properties
        
        public MetaIndexes MetaIndex {get {return _metaIndex;}} 
        public List<IBehaviour> ClassIndex {get {return _classIndex;}} 
      
        public Index Index{get; protected set; }
        public IActor Actor { get; protected set; }
        
        
#endregion

#region Constructors


        public ABehaviour()
        {
            Index = GetIndex();

            // TODO: Delete editor mode for Behaviour
            this.index = this.Index.InstanceIndex;

       
        } 
        
#endregion
        
        
        public Index GetCacheIndex()
        {           
            return new Index(this);
        }

        public void SetActor(IActor actor)
        {
            this.Actor = actor;

        }
        
    
    }
}