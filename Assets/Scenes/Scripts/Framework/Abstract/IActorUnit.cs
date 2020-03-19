namespace Robot.Framework
{
    public interface IActorUnit
    {
        IActor Actor {get; }

        void SetActor(IActor actor);
    }
}


