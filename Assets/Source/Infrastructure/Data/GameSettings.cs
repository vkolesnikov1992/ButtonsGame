using UnityEngine;

namespace Source.Infrastructure.Data
{
	[CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings", order = 0)]
	public class GameSettings : ScriptableObject
	{
		public int ButtonsCount;
	}
}