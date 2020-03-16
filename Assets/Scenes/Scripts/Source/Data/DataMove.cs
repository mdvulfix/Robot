using Robot.Framework;

namespace Robot
{
    public class DataMove: IData
    {
        public IActor Actor { get; private set; }
        public int Speed { get; set; }

        public DataMove(IActor actor)
        {
            this.Actor = actor;


        }

    }
}