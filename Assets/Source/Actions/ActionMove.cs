
using UnityEngine;

namespace Robot
{
    [System.Serializable]
    public class ActionMove: Action<DataMove>
    {
        public ActionMove(IBot bot): base(bot)
        {

        }
    
        public void OnMove()
        {
            
            Bot.Transform.Translate(new Vector3(0, 0, 1) * Data.Speed * Time.deltaTime, Space.World);

        }

    }
}