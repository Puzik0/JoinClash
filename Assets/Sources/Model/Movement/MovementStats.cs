namespace Model.Sources.Model.Movement
{
    public readonly struct MovementStats
    {
        public readonly float MaxSpeed;
        public readonly float AccelerationTime;

        public MovementStats(float maxSpeed, float accelerationTime)
        {
            MaxSpeed = maxSpeed;
            AccelerationTime = accelerationTime;
        }
    }
}