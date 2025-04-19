using UnityEngine;

public class ScoreChecker : MonoBehaviour
{    
    private ScoreManager _scoreManager;
    private void Awake()
    {
        _scoreManager = FindFirstObjectByType<ScoreManager>();//optimize it
        if (_scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene.");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<BirdMovement>(out BirdMovement bird) == true)
        {
            //Debug.Log("Bird Entered Trigger");
            if (bird != null)
            {
                _scoreManager.AddScore();
                //Should I use deligates?
            }
        }
    }
}
