namespace GameStates.Base
{
	public interface IGameState
	{
		void Enter();
		void Exit();
		
		public class Empty : IGameState
		{
			public void Enter() { }
			public void Exit() { }
		}
	}
}