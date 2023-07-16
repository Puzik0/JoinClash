namespace Model.Timers
{
	public class Timer
	{
		private float _time;
		private float _elapsedTime;

		public bool IsOver => _elapsedTime >= _time;
		
		public void Start(float time)
		{
			_time = time;
			_elapsedTime = 0.0f;
		}

		public void Tick(float deltaTime)
		{
			_elapsedTime += deltaTime;
		}
	}
}