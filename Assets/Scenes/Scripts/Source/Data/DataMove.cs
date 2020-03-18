using UnityEngine;
using Robot.Framework;

namespace Robot
{
    public class DataMove: AData
    {    
        public int Speed { get; set; }

        public DataMove(IActor actor) 
        {
            SetActor(actor);
            SetCache<DataMove>(actor, this);
            Debug.Log(this.ToString() + "was created!");
        }


    }

}