using UnityEngine;

namespace Robot
{
    [System.Serializable]
    public class ControlUpdate: MonoBehaviour
    {        
        
        public void OnUpdate() 
        {
            foreach (var updatable in Cache.Updatables)
            {
                updatable.OnUpdate();
            }
        }

        public void OnFixUpdate() 
        {
            foreach (var updatable in Cache.FixUpdatables)
            {
                updatable.OnFixUpdate();
            }
        }
        
        public void OnLateUpdate() 
        {
            foreach (var updatable in Cache.LateUpdatables)
            {
                updatable.OnLateUpdate();
            }
        }


        private void Update() 
        {
            OnUpdate();
        }

        private void FixUpdate() 
        {
            OnFixUpdate();
        }

        private void LateUpdate() 
        {
            OnLateUpdate();
        }


    }


}