using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]private float _pipeSpawnInterval = 3.0f;
    [SerializeField] private float _pipeGap = 4f;
    [SerializeField] private float _pipePairHeight = 10f;
    private float _pipeSpawnTimer = 0.0f;
    private float _pipeSpawnX = 6f;

    private void Update()
    {
        _pipeSpawnTimer += Time.deltaTime;
        if (_pipeSpawnTimer >= _pipeSpawnInterval)
        {
            SpawnPipe(new Vector3(_pipeSpawnX, 0, 0), Quaternion.identity);
            _pipeSpawnTimer = 0.0f;
        }
    }

    private void SpawnPipe(Vector3 position, Quaternion rotation)
    {
        PipePair pipePair = PipePool.Instance.GetPipe();

        pipePair.transform.Find("TopPipe").localPosition = new Vector3(0, _pipePairHeight / 2, 0);
        pipePair.transform.Find("BotPipe").localPosition = new Vector3(0, _pipePairHeight / -2, 0);

        pipePair.transform.position = position;
        pipePair.transform.rotation = rotation;
        float random = Random.Range(1.0f, 5.0f);
        pipePair.transform.GetChild(0).localScale = new Vector3(1, random,1);
        pipePair.transform.GetChild(1).localScale = new Vector3(1, _pipePairHeight - random - _pipeGap, 1);
        pipePair.gameObject.SetActive(true);
    }
}
