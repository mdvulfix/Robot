namespace Robot.Framework
{
    public interface IData: ICacheable
    {
        IActor Actor {get; }
    }
        
    
    public abstract class Data: IData
    {
        public IActor Actor {get; protected set;}
 
        public Data(IActor actor)
        {
            Actor = actor;
       
        } 
    }
}
