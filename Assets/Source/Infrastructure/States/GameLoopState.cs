using Source.Infrastructure.GameLogic;
using Source.Infrastructure.Services;

namespace Source.Infrastructure.States
{
	public class GameLoopState : IState
	{
		private readonly GameStateMachine _stateMachine;
		private readonly IMonobehaviourService _monobehaviourService;
		private readonly IViewService _viewService;

		public GameLoopState(GameStateMachine stateMachine, IMonobehaviourService monobehaviourService, IViewService viewService)
		{
			_stateMachine = stateMachine;
			_monobehaviourService = monobehaviourService;
			_viewService = viewService;
		}

		public void Exit()
		{
			
		}

		public void Enter()
		{
			ButtonsGame buttonsGame = new ButtonsGame(_viewService, _monobehaviourService);
		}
	}
}