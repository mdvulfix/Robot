
using UnityEngine;
using Robot.Framework;

namespace Robot
{
    [System.Serializable]
    public class ActionMove: Action<DataMove>
    {
        public ActionMove(IActor actor): base(actor)
        {

        }
    
        public override void OnAction()
        {
            
            Actor.Transform.Translate(new Vector3(0, 0, 1) * Data.Speed * Time.deltaTime, Space.World);

        }

    }
}