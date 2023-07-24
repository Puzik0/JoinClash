using Assets.Sources.Model.Movement;
using Model.Sources.Model.Movement;
using System.Linq;
using UnityEngine;

namespace Model.Stickmen
{
	public class StickmanHordeMovement : IMovementStatsProvider
	{
		[System.Serializable]
		public struct Preferences
		{
			public float MaxSpeed;
			public float AccelerationTime;
		}

		private readonly StickmanHorde _horde;
		private readonly Preferences _preferences;
		private InertialMovement _inertialMovement;
		
		public StickmanHordeMovement(StickmanHorde horde, Preferences preferences)
		{
			_horde = horde;
			_preferences = preferences;

			_inertialMovement = new InertialMovement(this);
		}

		public void OnEnable()
		{
			_horde.Added += OnStickmanAdded;
		}
		public void OnDisable()
		{
			_horde.Added -= OnStickmanAdded;
		}
		public StickmanHordeMovement Initialize ()
		{
			foreach (StickmanMovement stickman in _horde.Stickmans)
			{
				stickman.Bind(_inertialMovement);
			}  
			return this;
		}

        public MovementStats Stats() => 
			new MovementStats(_preferences.MaxSpeed, _preferences.AccelerationTime);

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

		private void OnStickmanAdded(StickmanMovement stickman)
		{
			stickman.StartMovingRight();
			stickman.Bind(_inertialMovement);
		}
	}
}