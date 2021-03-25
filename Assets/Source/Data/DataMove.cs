using System;
using UnityEngine;

namespace Robot
{
    [Serializable]
    [CreateAssetMenu(fileName = "Data Move (new)", menuName = "Data/Move", order = 3)]
    public class DataMove: Data
    {    
        [SerializeField] private int        _speed;
        [SerializeField] private int        _maxSpeed;
        [SerializeField] private int        _velocity;
        [SerializeField] private Vector3    _direction;
        
        public int      Speed       {get => _speed;      protected set => _speed = value;}
        public int      MaxSpeed    {get => _maxSpeed;   protected set => _maxSpeed = value;}
        public int      Velocity    {get => _velocity;   protected set => _velocity = value;}
        public Vector3  Direction   {get => _direction;  protected set => _direction = value;}
        
        
        public DataMove(IBot bot)
        {
            SetBot(bot);

            Speed = 0;
            MaxSpeed = 15;
            Velocity = 1;
            Direction = Vector3.one;
        }

        public DataMove(IBot bot, int speed)
        {
            SetBot(bot);
            
            Speed = speed;
            MaxSpeed = 15;
            Velocity = 1;
            Direction = Vector3.one;
        }

    }

}