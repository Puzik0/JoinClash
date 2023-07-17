using UnityEngine;

namespace Sources.View.Extensions
{
	public static class GameObjectExtensions
	{
		public static TComponent RequireComponent<TComponent>(this GameObject gameObject) where TComponent : Component =>
			gameObject.TryGetComponent(out TComponent component)
				? component
				: gameObject.AddComponent<TComponent>();

		public static TComponent RequireComponent<TComponent>(this GameObject gameObject, out TComponent instance) where TComponent : Component
		{
			instance = gameObject.RequireComponent<TComponent>();
			return instance;
		}
	}
}