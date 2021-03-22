using System;
using UnityEngine;

namespace Robot
{
    [Serializable]
    [CreateAssetMenu(fileName = "ActionMoveTranslate", menuName = "Actions/Move: Translate")]
    public class ActionMoveTranslate: Action
    {
                
        public override void Initialize(IBot bot)
        {
            if(!GetData<DataMove>())
            {
                Debug.Log("Data not found!");
                return;
            }
        }
    
        public override void OnAction()
        {
            if(_data is DataMove)
            {
                var data = _data as DataMove;
                _bot.Obj.transform.Translate(new Vector3(0, 0, 1) * data.Speed * Time.deltaTime, Space.World); 
            }      
        }

    }
}