namespace Framework.EventListeners
{
    public interface IEventListener<T>
    {
        void OnEventRaised(T arg);
    }
}