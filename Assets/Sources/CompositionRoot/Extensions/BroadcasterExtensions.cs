using Model;
using UnityEngine;
using View.Sources.View.Broadcasters;

namespace Sources.CompositeRoot.Extensions
{
	public static class BroadcasterExtensions
	{
		public static GameObject InitializeAs<TTickable>(this TickBroadcaster broadcaster, TTickable tickable, out TTickable instance)
			where TTickable : ITickable
		{
			instance = tickable;
			return broadcaster.Initialize(tickable);;
		}
	}
}