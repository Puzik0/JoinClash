using System.Collections.Generic;

namespace Model.Stickmen
{
	public class StickmanHorde
	{
		private readonly HashSet<StickmanMovement> _stickmans;

		public StickmanHorde(StickmanMovement firstStickman)
		{
			_stickmans = new HashSet<StickmanMovement> {firstStickman};
		}

		public IEnumerable<StickmanMovement> Stickmans => _stickmans;

		public void Add(StickmanMovement stickman)
		{
			_stickmans.Add(stickman);
		}

		public void Remove(StickmanMovement stickman)
		{
			_stickmans.Remove(stickman);
		}
	}
}