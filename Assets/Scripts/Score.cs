using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private PlayerController playerControllerScripts;

    // public TextMeshProUGUI playerScore;
    public TextMeshProUGUI playerScore;

    public TextMeshProUGUI highScore;

    public int num;

    // Start is called before the first frame update
    private void Start()
    {
        playerControllerScripts = GameObject.Find("Player").GetComponent<PlayerController>();
        highScore.text = PlayerPrefs.GetInt("highScore", 0).ToString();
        /*  Debug.Log("Calling....Start");
          Debug.Log("Calling....update");
          UpdateScore(num);*/
    }

    // Update is called once per frame
    private void Update()
    {
        //  playerScore.text = playerController.score.ToString();
        UpdateScore();
    }

    private void UpdateScore()
    {
        //  Debug.Log("Score");
        playerScore.text = " " + playerControllerScripts.score.ToString();
        if (playerControllerScripts.score > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", playerControllerScripts.score);
            highScore.text = playerControllerScripts.score.ToString();
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        highScore.text = "0";
    }
}
