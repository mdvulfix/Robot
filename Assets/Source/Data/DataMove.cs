using UnityEngine;
using Robot.Framework;

namespace Robot
{
    [System.Serializable]
    public class DataMove: Data
    {    
        
        public int Speed {get; protected set;}
        public int MaxSpeed {get; protected set;}
        public int Velocity {get; protected set;}
        public Vector3 Direction {get; protected set;}
        
        
        public DataMove(IActor actor): base(actor)
        {
            Speed = 5;
            MaxSpeed = 15;
            Velocity = 1;
            Direction = Vector3.one;
        }

        public DataMove(IActor actor, int speed ): base(actor)
        {
            Speed = speed;
            MaxSpeed = 15;
            Velocity = 1;
            Direction = Vector3.one;
        }

    }

}