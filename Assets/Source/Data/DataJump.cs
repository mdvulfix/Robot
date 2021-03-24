using System;
using UnityEngine;

namespace Robot
{
    [Serializable]
    public class DataJump: Data
    {    
        [SerializeField] private int        _speed;
        [SerializeField] private int        _force;
        [SerializeField] private Vector3    _direction;
        
        public int      Speed       {get => _speed;     protected set => _speed = value;}
        public int      Force       {get => _force;     protected set => _force = value;}
        public Vector3  Direction   {get => _direction; protected set => _direction = value;}
        
        
        public DataJump(IBot bot)
        {
            SetBot(bot);

            Speed = 0;
            Force = 15;
            Direction = Vector3.one;
        }

        public DataJump(IBot bot, int speed)
        {
            SetBot(bot);
            
            Speed = speed;
            Force = 15;
            Direction = Vector3.one;
        }

    }

}