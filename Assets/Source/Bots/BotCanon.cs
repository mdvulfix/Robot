using System;
using System.Collections.Generic;
using UnityEngine;
using Robot.Attributes;

namespace Robot
{
    [Serializable]
    public class BotCanon: Bot //, IUpdate
    {
        
        public DataShoot _dataShoot;

        [Folder("Actions")] 
        public ActionShootBomb      _actionShootMain;
        [Folder("Actions")] 
        public ActionShootRocket    _actionShootSecondary;
      
        [FlexibleList]
        public List<ActionShoot> ActionsList;
        
        
        
        public override void OnAwake()
        {
            base.OnAwake();

            //SetUpdatable();
            
            if(_dataShoot != null)
                Cache<DataShoot>.Set(this, _dataShoot as DataShoot);
            else
                _dataShoot = Cache<DataShoot>.Set(this, new DataShoot(this, 100));

            if(_actionShootMain != null)
                Cache<ActionShootBomb>.Set(this, _actionShootMain as ActionShootBomb);
            else
                _actionShootMain = Cache<ActionShootBomb>.Set(this, new ActionShootBomb(this));
            
        }

        
        public void Update()
        {
            _actionShootMain.OnAction();
        }
        
        /*
        public void SetUpdatable()
        {
            Cache.SetUpdatable(this);
        }
        */

    }
    
}


