namespace StateMachine
{
    public interface IGameState
    {
        IGameState DoState(GameManager manager);
    }
}
