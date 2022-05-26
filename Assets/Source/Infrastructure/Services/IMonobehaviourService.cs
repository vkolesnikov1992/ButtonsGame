using UnityEngine;

namespace Source.Infrastructure.Services
{
	public interface IMonobehaviourService : IService
	{
		T ResourcesLoad<T>(string path) where T : MonoBehaviour;
		T LoadScriptableObject<T>(string path) where T : ScriptableObject;
	}
}