using System.Linq;

namespace Model.Stickmen
{
	public class StickmanHordeMovement
	{
		private readonly StickmanHorde _horde;
		
		public StickmanHordeMovement(StickmanHorde horde)
		{
			_horde = horde;
		}

		public void Accelerate(float deltaTime)
		{
			foreach (StickmanMovement stickman in _horde.Stickmans)
				stickman.Accelerate(deltaTime);
		}

		public void Slowdown(float deltaTime)
		{
			foreach (StickmanMovement stickman in _horde.Stickmans)
				stickman.Slowdown(deltaTime);
		}

		public void StartMovingRight()
		{
			foreach (StickmanMovement stickman in _horde.Stickmans)
				stickman.StartMovingRight();
		}

		public void MoveRight(float axis)
		{
			if (CanMove(axis) == false)
			{
				StartMovingRight();
				return;
			}
			
			foreach (StickmanMovement stickman in _horde.Stickmans)
				stickman.MoveRight(axis);
		}

		private bool CanMove(float axis)
		{
			return _horde.Stickmans.Any(x => x.OnRightBound && axis > 0.0f || x.OnLeftBound && axis < 0.0f) == false;
		}
	}
}