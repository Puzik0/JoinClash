using System;
using Model.Physics;
using UnityEngine;

namespace Model.Stickmen
{
	public class StickmanMovement
	{
		private readonly Stickman _stickman;
		private readonly SurfaceSliding _surfaceSliding;
		private readonly InertialMovement _inertialMovement;
		private readonly float _distanceBetweenBounds;
		
		private Vector3 _startMovePosition;
		
		public StickmanMovement(Stickman stickman, SurfaceSliding surfaceSliding, InertialMovement inertialMovement, float distanceBetweenBounds)
		{
			_stickman = stickman;
			_surfaceSliding = surfaceSliding;
			_inertialMovement = inertialMovement;
			_distanceBetweenBounds = distanceBetweenBounds;
		}

		public bool OnRightBound => Math.Abs(_stickman.Position.x - DistanceToBound) < 0.1f;

		public bool OnLeftBound => Math.Abs(_stickman.Position.x - -DistanceToBound) < 0.1f;

		public float Acceleration => _inertialMovement.Acceleration;
		
		private float DistanceToBound => _distanceBetweenBounds / 2.0f;
		
		public void StartMovingRight()
		{
			_startMovePosition = _stickman.Position;
		}

		public void MoveRight(float axis)
		{
			Vector3 position = new Vector3
			{
				x = _distanceBetweenBounds * axis + _startMovePosition.x,
				y = _stickman.Position.y,
				z = _stickman.Position.z
			};

			position.x = Mathf.Clamp(position.x, -DistanceToBound, DistanceToBound);
			
			_stickman.Move(position);
		}

		public void Accelerate(float deltaTime)
		{
			_inertialMovement.Accelerate(deltaTime);

			MoveForward(deltaTime);
		}

		public void Slowdown(float deltaTime)
		{
			_inertialMovement.Slowdown(deltaTime);
			
			MoveForward(deltaTime);
		}

		private void MoveForward(float deltaTime)
		{
			Vector3 directionAlongSurface = _surfaceSliding.DirectionAlongSurface(_stickman.Forward);
			Vector3 delta = directionAlongSurface * (_inertialMovement.Acceleration * deltaTime);

			_stickman.Move(_stickman.Position + delta);
		}
	}
}