using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string _gameSceneName = "GameScene";
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private GameObject _gameStartUI;
    [SerializeField] private GameObject _bird;

    private BirdIdle _birdIdle;
    private BirdMovement _birdMovement;
    private PipeSpawner _pipeSpawner;
    private Rigidbody2D _birdRB;

    private void Start()
    {
        _birdIdle = _bird.GetComponent<BirdIdle>();
        _birdMovement = _bird.GetComponent<BirdMovement>();
        _birdRB = _bird.GetComponent<Rigidbody2D>();
        _pipeSpawner = GetComponent<PipeSpawner>();
    }
    public void StartGame()
    {
        _birdIdle.enabled = false; // Disable idle animation
        _birdRB.simulated = true; // Enable physics for the bird     
        _birdMovement.enabled = true; // Enable bird movement
        _pipeSpawner.enabled = true; // Enable pipe spawner
        _gameStartUI.SetActive(false); // Disable start UI
    }
    public void RestartGame()
    {
        //_gameOverUI.SetActive(false);
        //_gameStartUI.SetActive(true);
        //_birdIdle.enabled = true; // Enable idle animation
        //_birdRB.simulated = false; // Disable physics for the bird     
        //_birdMovement.enabled = false; // Disable bird movement
        //_pipeSpawner.enabled = false; // Disable pipe spawner     
        Time.timeScale = 1; // Reset time scale
        //Time.fixedDeltaTime = 0.02f; // Reset fixed time step


        SceneManager.LoadScene(_gameSceneName); // Reload the game scene
    }
    public void GameOver()
    {
        Time.timeScale = 0; // Pause the game
        _birdMovement.enabled = false;
        _pipeSpawner.enabled = false;
        _gameOverUI.SetActive(true);
    }
}
