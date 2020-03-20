namespace Robot.Framework
{
    public interface ICacheable
    {
        int Index {get; }
        METAINDEX MetaIndex{get; }
        

        int GetIndex();
    }
}


