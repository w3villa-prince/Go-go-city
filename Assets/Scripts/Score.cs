using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private PlayerController playerControllerScripts;

    // public TextMeshProUGUI playerScore;
    public TextMeshProUGUI playerScore;

    public int num;

    // Start is called before the first frame update
    private void Start()
    {
        playerControllerScripts = GameObject.Find("Player").GetComponent<PlayerController>();
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
    }
}
