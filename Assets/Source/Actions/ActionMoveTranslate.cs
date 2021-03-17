using UnityEngine;

namespace Robot
{
    [System.Serializable]
    public class ActionMoveTranslate: Action<DataMove>
    {
                
        public ActionMoveTranslate(IBot bot): base(bot)
        {
            
        }
    
        public Vector3 OnMove()
        {
            Bot.Transform.Translate(new Vector3(0, 0, 1) * Data.Speed * Time.deltaTime, Space.World);
            return Bot.Transform.position;
        
        }

    }
}