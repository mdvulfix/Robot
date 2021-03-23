using UnityEngine;

namespace Robot
{
    public class FolderAttribute : PropertyAttribute
    {
		public string 	Name 		{get; private set;}
		public bool		Multiple 	{get; private set;}
 
		public FolderAttribute(string name, bool multiple = false)
		{
			Name = name;
			Multiple = multiple;

		}
    }
}