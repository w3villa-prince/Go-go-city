using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStartGameplay : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void RestartScence()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Restart call...");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
