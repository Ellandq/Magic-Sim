namespace GameStates
{
    public interface IGameState
    {
        void Enter();
        void Update();
        void Exit();
    }
}