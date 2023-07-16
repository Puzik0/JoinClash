using System;
using Model.Components;
using UnityEngine;

namespace Model.Stickmen
{
	public class Stickman : Transformable
	{
		private readonly Health _health;

		public Stickman(Health health, Vector3 position, Quaternion rotation) : base(position, rotation)
		{
			_health = health;
		}

		public event Action Died;

		public bool IsDead => _health.Value == 0.0f;
		
		public void TakeDamage(float damage)
		{
			if (IsDead)
				return;
			
			_health.TakeDamage(damage);

			if (IsDead)
				Died?.Invoke();
		}
	}
}
