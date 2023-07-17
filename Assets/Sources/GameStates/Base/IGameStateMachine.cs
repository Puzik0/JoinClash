namespace GameStates.Base
{
	public interface IGameStateMachine
	{
		void Enter<TState>() where TState : IGameState;
	}
}