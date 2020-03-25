using UnityEngine;

namespace Robot.Framework
{
    public class Session: MonoBehaviour
    {
        
        public GameObject actor; 


        SystemUpdating updating;
        
        private void Awake() 
        {
            //updating = new SystemUpdating();

        }

        private void Start() 
        {
            for (int i = 0; i < 1; i++)
            {
                Instantiate(actor, new Vector3(0f,10f,0f), Quaternion.identity);
                
                

            }
            


        }



    }
}