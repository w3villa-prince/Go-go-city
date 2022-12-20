using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRd;
    public float force = 500;
    public float gravityModifier = 1;
    private bool isOnground = true;
    public bool gameOver = false;
    private Animator animat;
    private int score = 0;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtyParticle;
    public AudioClip jumpClip;
    public AudioClip crashClip;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    private void Start()
    {
        playerRd = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        animat = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        //  playerRd.AddForce(Vector3.up * force);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnground && !gameOver)
        {
            playerRd.AddForce(Vector3.up * force, ForceMode.Impulse);

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

            animat.SetInteger("DeathType_int", 1);
        }
    }
}
