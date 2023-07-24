using Assets.Sources.Model.Movement;

namespace Model.Sources.Model.Movement
{
    public abstract class MovementStatsDecorator : IMovementStatsProvider
    {

        private readonly IMovementStatsProvider _wrappedEntity;

        protected MovementStatsDecorator(IMovementStatsProvider wrappedEntity)
        {
            _wrappedEntity = wrappedEntity;
        }

        public MovementStats Stats() => Decorate(_wrappedEntity);
        protected abstract MovementStats Decorate(IMovementStatsProvider statsProvider);
    }
}