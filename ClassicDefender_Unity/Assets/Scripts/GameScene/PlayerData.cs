public class PlayerData
{
    private GameDataLoader gameDataLoader;
    private int level;

    public void InitData(GameDataLoader gameDataLoader)
    {
        this.gameDataLoader = gameDataLoader;
        DefaultData();
    }

    private void DefaultData()
    {
        level = 1;
    }

    public int GetLevel()
    {
        return level;
    }

    public bool PlusLevel()
    {
        bool isLevelExist = false;
        foreach (LevelDefinition l in gameDataLoader.GameDefinitions.LevelDefinitions)
        {
            if (l.Level == level + 1)
            {
                isLevelExist = true;
            }
        }

        if (isLevelExist)
        {
            level += 1;
            return true;
        }

        return false;
    }
}