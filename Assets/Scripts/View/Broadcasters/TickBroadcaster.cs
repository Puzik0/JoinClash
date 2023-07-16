using Model;
using UnityEngine;

namespace View.Sources.View.Broadcasters
{
	public class TickBroadcaster : MonoBehaviour
	{
		private ITickable _tickable;

		public void Initialize(ITickable tickable)
		{
			_tickable = tickable;
		}

		private void Update()
		{
			_tickable.Tick(Time.deltaTime);
		}
	}
}