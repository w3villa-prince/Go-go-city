using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRd;
    public float force = 200;
    public float gravityModifier = 3;
    private bool isOnground = true;
    public bool gameOver;
    private Animator animat;
    public int score = 1;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtyParticle;
    public AudioClip jumpClip;
    public AudioClip crashClip;
    private AudioSource playerAudio;
    public GameObject gameEndScreen;
    private GamePlayManager gamePlayManager;
    public float num;

    // Start is called before the first frame update
    private void Start()
    {
        playerRd = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        animat = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        gamePlayManager = GetComponent<GamePlayManager>();
        gameOver = gamePlayManager.gameOver;

        //  playerRd.AddForce(Vector3.up * force);
    }

    // Update is called once per frame
    private void Update()
    {
        // if ((Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0)) && isOnground)
        if ((Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0)) && isOnground && !gameOver)
        {
            playerRd.AddForce(Vector3.up * force, ForceMode.Impulse);
            Debug.Log("Jump Facter  Y player ==" + playerRd.position.y + " Up height== " + Vector3.up + "Force ==" + force);
            Debug.Log("Player position X After Jump " + playerRd.position.z);
            Debug.Log("Player position X After Jump " + playerRd.position.x);

            isOnground = false;
            animat.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpClip, 1.0f);

            dirtyParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            score++;

            //  h.num++;

            Debug.Log("PLayerControl Score " + score);
            isOnground = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("game over" + score);

            //Destroy(this.gameObject);
            gameOver = true;
            animat.SetBool("Death_b", true);
            explosionParticle.Play();
            dirtyParticle.Stop();
            playerAudio.PlayOneShot(crashClip, 1.0f);
            gameEndScreen.SetActive(true);

            animat.SetInteger("DeathType_int", 1);
        }
        num++;
    }
}
