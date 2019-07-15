public class InputGameController
{
    public PlayerBehaviour playerBehaviour;

    public InputGameController()
    {
    }

    public void Init(PlayerBehaviour playerBehaviour)
    {
        this.playerBehaviour = playerBehaviour;
    }

    public virtual void GameController()
    {
    }
}