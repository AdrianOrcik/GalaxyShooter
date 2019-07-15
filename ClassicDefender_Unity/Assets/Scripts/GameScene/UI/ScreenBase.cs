using TMPro;
using UnityEngine.UI;


public class ScreenBase : MainBehaviour
{
    public ScreenType ScreenType;
    public Image[] Stars;
    private int[] percents = new int[] {50, 75, 100};
    public TMP_Text Score;

    private void OnEnable()
    {
        Score.text = LevelManager.LevelStats.KilledEnemy + " / " + LevelManager.LevelStats.LevelDefinition.TotalEnemy;
        ShowStars();
    }

    private void ShowStars()
    {
        for (int i = 0; i < Stars.Length; i++)
        {
            float killedAmount = (float) ((float) LevelManager.LevelStats.LevelDefinition.TotalEnemy / (float) 100) *
                                 percents[i];
            if (LevelManager.LevelStats.KilledEnemy >= killedAmount)
            {
                Stars[i].sprite = ResourceManager.GetGameSprite(Constants.STAR_ID);
            }
            else
            {
                return;
            }
        }
    }
}