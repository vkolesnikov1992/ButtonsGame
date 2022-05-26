using Source.Infrastructure.Mono;
using Source.Infrastructure.Services;
using UnityEngine;

namespace Source.Infrastructure.States
{
	public class BootstrapState : IState
	{
		private readonly GameStateMachine _stateMachine;
		private readonly AllServices _services;

		public BootstrapState(GameStateMachine stateMachine, AllServices services)
		{
			_stateMachine = stateMachine;
			_services = services;
			
			RegisterServices();
		}

		public void Exit()
		{
			
		}

		public void Enter()
		{
			_stateMachine.Enter<GameLoopState>();
		}


		private void RegisterServices()
		{
			_services.RegisterSingle<IMonobehaviourService>(new MonobehaviourService(CreateMonobehaviourService<MonobehaviourProvider>()));
			_services.RegisterSingle<IViewService>(new ViewService(_services.Single<IMonobehaviourService>()));
		}
		
		private static T CreateMonobehaviourService<T>() where T : MonoBehaviour 
		{
			var provider = new GameObject().AddComponent<T>();
			provider.name = typeof(T).Name;
			return provider;
		}
	}
}