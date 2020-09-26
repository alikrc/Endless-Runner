using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadGameController : MonoBehaviour
{
    private PlayerController playerController;

    public GameObject reloadPanel;

    void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        if (reloadPanel != null)
        {
            if (playerController.gameOver == false)
            {
                reloadPanel.SetActive(false);
            }
            else
            {
                reloadPanel.SetActive(true);
            }
        }
    }
    public void ReloadGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
