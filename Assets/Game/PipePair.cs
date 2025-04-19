using UnityEngine;
using UnityEngine.Events;

public class PipePair : MonoBehaviour
{ 
    private float _maxDistanceByX = -6.0f;
    private System.Action<PipePair> _returnToPool;
    

    public void Init(System.Action<PipePair> returnToPool)
    {
        _returnToPool = returnToPool;
    }
    public void ReturnToPool()
    {
        //transform.GetComponent<ScoreChecker>()._isScored = false;
        gameObject.SetActive(false);
        _returnToPool?.Invoke(this);
    }

    private void Update()
    {
        if(transform.position.x < _maxDistanceByX && this.enabled)
        {
            ReturnToPool(); 
        }
    }

}
