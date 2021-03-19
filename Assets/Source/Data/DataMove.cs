using System;
using UnityEngine;

namespace Robot
{
    [Serializable]
    [CreateAssetMenu(fileName = "DataMoveDefault", menuName = "Data/DataMove")]
    public class DataMove: Data
    {    
        
        
        [SerializeField] private int _speed;
        
        public int Speed {get {return _speed;} protected set {_speed = value;}}
        public int MaxSpeed {get; protected set;}
        public int Velocity {get; protected set;}
        public Vector3 Direction {get; protected set;}
        
        
        public DataMove(IBot bot): base(bot)
        {
            Speed = 0;
            MaxSpeed = 15;
            Velocity = 1;
            Direction = Vector3.one;
        }

        public DataMove(IBot bot, int speed): base(bot)
        {
            Speed = speed;
            MaxSpeed = 15;
            Velocity = 1;
            Direction = Vector3.one;
        }

    }

}