using UnityEngine;

public class Spwanmanager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spwanPos = new Vector3(20, 0, 0);
    private float startDealy = 1.5f;
    private float repeatRate = 1.5f;
    private PlayerController playerControllerScripts;

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
        if (playerControllerScripts.gameOver == false)
        {
            Instantiate(obstaclePrefab, spwanPos, obstaclePrefab.transform.rotation);
        }
    }
}
