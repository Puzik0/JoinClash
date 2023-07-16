using UnityEngine;

namespace Sources.CompositionRoot.Extensions
{
	public static class GameObjectExtensions
	{
		public static TComponent RequireComponent<TComponent>(this GameObject gameObject) where TComponent : Component =>
			gameObject.TryGetComponent(out TComponent component)
				? component
				: gameObject.AddComponent<TComponent>();
	}
}