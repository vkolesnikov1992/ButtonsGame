using UnityEngine;

namespace Source.Infrastructure.Mono
{
	public class MonobehaviourProvider : MonoBehaviour
	{
		public T ResourcesLoad<T>(string path) where T : MonoBehaviour
		{
			T result = null;
			
			try
			{
				result = Resources.LoadAll<T>(path)[0];
			}
			catch
			{
				Debug.LogError( "check path - " + path + ". prefab not found!");
			}
			

			return result;
		} 
		
		public T LoadScriptableObject<T>(string path) where T : ScriptableObject
		{
			return Resources.Load<T>(path);
		}
	}
}