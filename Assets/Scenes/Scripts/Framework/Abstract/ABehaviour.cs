namespace Robot.Framework
{
    
    public interface IBehaviour
    {

    }
    
    public class ABehaviour: IBehaviour, ICacheable, IUpdatable
    {
        public IActor Actor { get; protected set; }
        public ICache Cache { get; protected set; }     
        
        
        public void SetActor(IActor actor)
        {
            this.Actor = actor;

        }
        
        public void SetCache<T>(IActor actor, T objectToCache) where T: ABehaviour
        {
            Cache<T>.Set(actor, objectToCache);
        }

        public void GetCache<T>(IActor actor) where T: ABehaviour
        {
            Cache<T>.Get(actor);
        }

        public virtual void OnFixUpdate()
        {


        }
    }
}