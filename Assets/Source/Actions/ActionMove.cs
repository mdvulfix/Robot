using System;
using UnityEngine;

namespace Robot
{
    [Serializable]
    [RequireComponent(typeof(BotRobot))]
    public class ActionMove: Action<DataMove>
    {
        public ActionMove(IBot bot)
        {
            if(!GetData(bot))
            {
                Debug.Log("Data not found!");
                return;
            }
        }
        
        public override void OnAction()
        {
            Bot.Obj.transform.Translate(new Vector3(0, 0, 1) * Data.Speed * Time.deltaTime, Space.World); 
        }

    }
}