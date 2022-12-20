using UnityEngine;

public class moveLeft : MonoBehaviour
{
    private float speed = 20;
    private float leftBound = -15;
    private PlayerController playerConterllerScript;

    // Start is called before the first frame update
    private void Start()
    {
        playerConterllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerConterllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
