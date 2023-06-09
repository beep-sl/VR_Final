using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject player;
    public GameObject cactusSpawner;
    public AudioSource ouch;
    public int score = 0;
    public int maxHealth = 100;
    public int currentHealth = 100;
    private void Awake()
    {
        Instance = this;
    }

    private void Update() {
        CheckHealth();
        CheckEnemies();
    }
    public void CheckHealth()
    {
        Health playerHealth = player.GetComponent<Health>();
        if (currentHealth <= 0)
        {
            Debug.Log("Hiiiiii");
            GameOver();
        } else if (currentHealth == 50) {
            ouch.Play();
        }
    }

    private void CheckEnemies() {
        CactusSpawner cacti = cactusSpawner.GetComponent<CactusSpawner>();
        Debug.Log("Num cacti: " + cacti.numberOfEnemies);
        if (cacti.numberOfEnemies == 0) {
            YouWin();
        }
    }
    private void GameOver()
    {
        // You died, bring back to main menu
        Debug.Log("Game over");
        SceneManager.LoadScene(0);
    }

    private void YouWin() {
        // You won
        Debug.Log("You Win");
    }
}