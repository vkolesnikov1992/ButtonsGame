using System;
using System.Collections.Generic;
using Source.Infrastructure.Services;

namespace Source.Infrastructure.States
{
	public class GameStateMachine
	{
		private readonly Dictionary<Type, IExitableState> _states;
		private IExitableState _activeState;

		public GameStateMachine(AllServices services)
		{
			_states = new Dictionary<Type, IExitableState>()
			{
				[typeof(BootstrapState)] = new BootstrapState(this, services),
				[typeof(GameLoopState)] = new GameLoopState(this, services.Single<IMonobehaviourService>(), services.Single<IViewService>())
			};
		}

		public void Enter<TState>() where TState : class, IState
		{
			var state = ChangeState<TState>();
			state.Enter();
		}

		public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayloadedState<TPayLoad>
		{
			TState state = ChangeState<TState>();
			state.Enter(payLoad);
		}

		private TState ChangeState<TState>() where TState : class, IExitableState
		{
			_activeState?.Exit();
			TState state = GetState<TState>();
			_activeState = state;
			return state;
		}

		private TState GetState<TState>() where TState : class, IExitableState => _states[typeof(TState)] as TState;
	}
}