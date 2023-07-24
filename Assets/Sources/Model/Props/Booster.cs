using Assets.Sources.Model.Movement;
using Model.Sources.Model.Movement;
using Model.Timers;

namespace Model.Props
{
    public class Booster : MovementStatsDecorator, ITickable
    {
        [System.Serializable]
        public struct Preferances
        {
            public float Time;
            public float SpeedMultiplier;
        }
        private readonly Preferances _preferances;
        private readonly Timer _timer = new Timer();
        public Booster(Preferances preferances ,IMovementStatsProvider wrappedEntity) : base(wrappedEntity)
        {
            _preferances = preferances;
        }
        public void Applay()
        {
            _timer.Start(_preferances.Time);
        }
        public void Tick(float deltaTime)
        {
            _timer.Tick(deltaTime);
        }

        protected override MovementStats Decorate(IMovementStatsProvider statsProvider)
        {
            MovementStats stats = statsProvider.Stats();
            return _timer.IsOver 
                ? statsProvider.Stats()
                : new MovementStats(stats.MaxSpeed * _preferances.SpeedMultiplier, stats.AccelerationTime);
        }

    }
}