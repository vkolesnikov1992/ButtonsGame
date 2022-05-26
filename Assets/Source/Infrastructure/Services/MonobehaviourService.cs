using Source.Infrastructure.Mono;
using UnityEngine;

namespace Source.Infrastructure.Services
{
	public class MonobehaviourService : IMonobehaviourService
	{
		private readonly MonobehaviourProvider _provider;

		public MonobehaviourService(MonobehaviourProvider provider)
		{
			_provider = provider;
		}
		
		public T ResourcesLoad<T>(string path) where T : MonoBehaviour
		{
			return _provider.ResourcesLoad<T>(path);
		}
		
		public T LoadScriptableObject<T>(string path) where T : ScriptableObject
		{
			return _provider.LoadScriptableObject<T>(path);
		}
	}
}