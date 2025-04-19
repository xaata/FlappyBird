using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BirdHP : MonoBehaviour
{
    public UnityEvent onDeath;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Pipe"))
        {           
            transform.GetComponent<BirdMovement>().enabled = false;
            transform.GetComponent<Collider2D>().enabled = false;
            Debug.Log("Bird is dead");
            Die();
            //SceneManager.LoadScene();
        }
    }
    private void Die()
    {
        onDeath?.Invoke();
    }
}
