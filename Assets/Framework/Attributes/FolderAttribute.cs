using UnityEngine;

namespace Robot
{
    public class FolderAttribute : PropertyAttribute
    {
		private string _name;
 
		public FolderAttribute(string name)
		{
			_name = name;
		}
    }
}