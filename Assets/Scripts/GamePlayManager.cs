using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    private PlayerController player1;

    public bool gameOver = true;
    //public Scene GamePlay;

    public Button playBtn;
    public Button reStartBtn;

    // Start is called before the first frame update
    private void Start()
    {
        // player1 = GetComponent<PlayerController>();
        // gamecall();

        playBtn.onClick.AddListener(TaskOnClick);
        // reStartBtn.onClick.AddListener(SceneReload);
    }

    private void SceneReload()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().GamePlay);
    }

    private void TaskOnClick()
    {
        gameOver = false;
    }
}
