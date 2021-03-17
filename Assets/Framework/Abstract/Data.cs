namespace Robot
{
    public interface IData: ICacheable
    {
        IBot Bot {get; }
    }
        
    
    public abstract class Data: IData
    {
        public IBot Bot {get; protected set;}
 
        public Data(IBot bot)
        {
            Bot = bot;
       
        } 
    }
}
