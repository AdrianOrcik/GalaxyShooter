using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameScene.UI
{
    public class LoseScreen : ScreenBase
    {
        public Button RestartBtn;

        private void Start()
        {
            RestartBtn.onClick.AddListener(OnRestartLevel);
        }

        private void OnRestartLevel()
        {
            SceneManager.LoadScene(2);
        }
    }
}