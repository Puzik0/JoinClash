using System;
using UnityEngine;

namespace Model.Components
{
	public class Health
	{
		public Health(float value)
		{
			Value = value;
		}
		
		public float Value { get; private set; }

		public void TakeDamage(float damage)
		{
			if (damage < 0.0f)
				throw new ArgumentOutOfRangeException(nameof(damage));
			
			Value = Mathf.Clamp(Value - damage, 0, Value);
		}
	}
}