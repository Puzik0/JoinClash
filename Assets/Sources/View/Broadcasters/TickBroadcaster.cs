using Model;
using UnityEngine;

namespace View.Sources.View.Broadcasters
{
	public class TickBroadcaster : MonoBehaviour
	{
		private ITickable _tickable;

		public GameObject Initialize(ITickable tickable)
		{
			_tickable = tickable;

			return gameObject;
		}

		private void Update()
		{
			_tickable.Tick(Time.deltaTime);
		}
	}
}