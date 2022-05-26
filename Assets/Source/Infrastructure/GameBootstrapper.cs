using Source.Infrastructure.Services;
using Source.Infrastructure.States;
using UnityEngine;

namespace Source.Infrastructure
{
	public static class GameBootstrapper
	{
		[RuntimeInitializeOnLoadMethod]
		private static void  OnInitialized()
		{
			GameStateMachine gameStateMachine = new GameStateMachine(AllServices.Container);
			gameStateMachine.Enter<BootstrapState>();
		} 
	}
}
