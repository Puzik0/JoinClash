using System;
using Sources.View;
using Sources.View.Extensions;
using UnityEngine;
using View.Sources.View.Broadcasters;
using UnityObject = UnityEngine.Object;

namespace Sources.CompositeRoot.Extensions
{
	public static class GameObjectExtensions
	{
		public static GameObject ContinueWith(this GameObject gameObject, Action continuation)
		{
			continuation.Invoke();
			return gameObject;
		}

		public static TComponent Append<TComponent>(this GameObject gameObject, TComponent childObject) where TComponent : Component => 
			UnityObject.Instantiate(childObject, gameObject.transform);

		public static EventTrigger.Subscription OnTrigger(this GameObject gameObject, EventTrigger trigger)
		{
			PhysicsTransformableView context = gameObject.RequireComponent<PhysicsTransformableView>();

			return new EventTrigger.Subscription(trigger, context);
		}
	}
}