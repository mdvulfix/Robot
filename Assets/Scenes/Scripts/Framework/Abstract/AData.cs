namespace Robot.Framework
{
    
    public interface IData
    {

    }
    
    public class AData: IData, ICacheable
    {
        public IActor Actor { get; protected set; }
        public ICache Cache { get; protected set; }     
        
        
        public void SetActor(IActor actor)
        {
            this.Actor = actor;

        }
        
        public void SetCache<T>(IActor actor, T objectToCache) where T: AData
        {
            Cache<T>.Set(actor, objectToCache);
        }
    }
}
