using UnityEngine;

public class SpwanManagerOFCoin : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] obstaclePrefab;

    private Vector3 spwanPos = new Vector3(6, 0, 0);
    private float startDealy = 1f;
    private float repeatRate = .5f;
    private PlayerController playerControllerScripts;
    private int index;

    // Start is called before the first frame update
    private void Start()
    {
        playerControllerScripts = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpwanObstacle", startDealy, repeatRate);
    }

    // Update is called once per frame
    // Update is called once per frame
    private void Update()
    {
    }

    private void SpwanObstacle()
    {
        int index = Random.Range(0, (obstaclePrefab.Length) - 1);
        if (playerControllerScripts.gameOver == false)
        {
            Instantiate(obstaclePrefab[index], spwanPos, obstaclePrefab[index].transform.rotation);
        }
    }
}
