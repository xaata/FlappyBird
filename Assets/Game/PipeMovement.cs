using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float _pipeSpeed;

    // реализовать остановку труб через события
    void Update()
    {
        transform.position += Vector3.left * _pipeSpeed * Time.deltaTime;
    }
}
