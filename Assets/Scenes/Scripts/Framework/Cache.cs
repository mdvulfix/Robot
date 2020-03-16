using UnityEngine;
using System.Collections.Generic;

namespace Robot.Framework
{
    public static class Cache
    {
        private static readonly int DATA_ARRAY_LENGTH_INT = 100;
        private static readonly int BEHAVIOUR_ARRAY_LENGTH_INT = 100;
        
        private static Dictionary<IActor, Dictionary<DataType, IData>> actorData = new Dictionary<IActor, Dictionary<DataType, IData>>(DATA_ARRAY_LENGTH_INT);
        private static Dictionary<IActor, Dictionary<DataType, IBehaviour>> actorBehaviour = new Dictionary<IActor, Dictionary<DataType, IBehaviour>>(BEHAVIOUR_ARRAY_LENGTH_INT);

      
        
        
        
        //private int [][,] actorData = new [][,] actorData 


        /*
        public static void SetData<A, D>(A actor, DataType dataType, D data) where A : IActor where D : IData, new()
        {
            actorData.Add(actor, dataType, data);

        }

        public static D GetData<A, D>(A actor) where A : IActor where D : IData, new()
        {
            IData _data;
            actorData.TryGetValue(actor, out _data);
            return (D)_data;
             
        }
        
        public static void SetBehaviour<A, B>(A actor, B behaviour) where A : IActor where B : IBehaviour, new()
        {
            actorBehaviour.Add(actor, behaviour);

        }

        public static B GetBehaviour<A, B>(A actor) where A : IActor where B : IBehaviour, new()
        {
            IBehaviour _behaviour;
            actorBehaviour.TryGetValue(actor, out _behaviour);
            return (B) _behaviour;
             
        }
        */

    }

    public enum DataType
    {
        None,
        Move
    }


}