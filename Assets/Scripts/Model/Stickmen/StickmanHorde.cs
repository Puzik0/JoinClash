using System;
using System.Collections.Generic;
using System.Linq;
using Model.Messaging;
using UnityEngine;

namespace Model.Stickmen
{
	public class StickmanHorde
	{
		private readonly HashSet<StickmanMovement> _stickmans;

		public StickmanHorde(StickmanMovement firstStickman)
		{
			_stickmans = new HashSet<StickmanMovement> {firstStickman};
		}

		public event Action<StickmanMovement> Added; 

		public IEnumerable<StickmanMovement> Stickmans => _stickmans;

		public void Add(StickmanMovement stickman)
		{
			stickman.StartMovingRight();
			_stickmans.Add(stickman);
			Added?.Invoke(stickman);
		}

		public void Remove(StickmanMovement stickman)
		{
			_stickmans.Remove(stickman);
		}

		public IEnumerable<Stickman> Entities => _stickmans.Select(x => x.Model);
	}
}