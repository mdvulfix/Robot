using UnityEngine;
using Robot.Framework;

namespace Robot
{
    [System.Serializable]
    public class DataMove: AData
    {    
        public int Speed { get; protected set; }

        /*
        public DataMove(IActor actor) 
        {
            
            SetCache<DataMove>(actor, this);
            
        }
        */
        
        public DataMove(IActor actor): base()
        {
            SetActor(actor);
            Debug.Log(this.ToString() + "was created!");
            
        }

        public DataMove(IActor actor, int speed): base()
        {
            SetActor(actor);
            Debug.Log(this.ToString() + "was created!");
            
            this.Speed = 10;
        }
       
    }

}