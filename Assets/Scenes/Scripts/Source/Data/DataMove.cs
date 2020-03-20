using UnityEngine;
using Robot.Framework;

namespace Robot
{
    [System.Serializable]
    public class DataMove: AData
    {    
        public int Speed { get; protected set; }
       
        public DataMove(IActor actor): base()
        {
            SetActor(actor);
            MetaIndex = new METAINDEX(DATA.MOVE);

            SetSpeed(5);
            Debug.Log(this.ToString() + "was created!");
            
        }

        public DataMove(IActor actor, int speed): base()
        {
            SetActor(actor);
            Debug.Log(this.ToString() + "was created!");
            
            SetSpeed(speed);
        }

        public void SetSpeed(int speed)
        {         
            this.Speed = speed;
        }
       
    }

}