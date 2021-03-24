using System;
using UnityEngine;

namespace Robot
{
    [Serializable]
    public class DataShoot: Data
    {    
        [SerializeField] private int        _speed;
        [SerializeField] private Vector3    _direction;
        [SerializeField] private GameObject _bulletPref;
        
        public int        Speed       {get => _speed;     protected set => _speed = value;}
        public Vector3    Direction   {get => _direction; protected set => _direction = value;}
        public GameObject BulletPref  {get => _bulletPref; }
        
        
        public DataShoot(IBot bot)
        {
            SetBot(bot);

            Speed = 100;
            Direction = Vector3.one;
        }

        public DataShoot(IBot bot, int speed)
        {
            SetBot(bot);
            
            Speed = speed;
            Direction = Vector3.one;
        }

    }

}