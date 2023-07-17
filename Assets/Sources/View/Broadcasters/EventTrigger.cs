using System;
using System.Collections.Generic;
using Sources.View;
using UnityEngine;

namespace View.Sources.View.Broadcasters
{
	public class EventTrigger : MonoBehaviour
	{
		private readonly Dictionary<PhysicsTransformableView, Action> _contextHandlers = new Dictionary<PhysicsTransformableView, Action>();
		private readonly List<Action> _listeners = new List<Action>();

		public void Subscribe(PhysicsTransformableView context, Action handler)
		{
			_contextHandlers.Add(context, handler);			
		}

		public void Unsubscribe(PhysicsTransformableView context)
		{
			_contextHandlers.Remove(context);
		}

		public void ReactOnce(Action listener)
		{
			_listeners.Add(listener);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out PhysicsTransformableView view) == false)
				return;

			if (_contextHandlers.TryGetValue(view, out var handler) == false)
				return;
			
			handler.Invoke();
			_listeners.ForEach(listeners => listeners?.Invoke());
			_listeners.Clear();
		}

		public class Subscription
		{
			private readonly EventTrigger _trigger;
			private readonly PhysicsTransformableView _context;
			
			public Subscription(EventTrigger trigger, PhysicsTransformableView context)
			{
				_trigger = trigger;
				_context = context;
			}

			public GameObject Do(Action handler)
			{
				_trigger.Subscribe(_context, handler);

				return _context.gameObject;
			}

			public GameObject ReactOnce(Action listener)
			{
				_trigger.ReactOnce(listener);
				return _context.gameObject;
			}
		}
	}
}