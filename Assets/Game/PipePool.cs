using System;
using UnityEngine;
using UnityEngine.Pool;

public class PipePool: MonoBehaviour
{
    public static PipePool Instance { get; private set; }
    [SerializeField]private GameObject pipePrefab;
    private ObjectPool<PipePair> pipePool;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            pipePool = new ObjectPool<PipePair>(CreatePipe, OnGetPipe, OnReleasePipe, OnDestroyPipe, false, 4, 10);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private PipePair CreatePipe()
    {
        GameObject pipeObject = Instantiate(pipePrefab);
        PipePair pipePair = pipeObject.GetComponent<PipePair>();
        //pipePair.transform.SetParent(transform);//??
        pipePair.Init(pipePool.Release);
        return pipePair;
    }
    private void OnGetPipe(PipePair pair)
    {
        pair.gameObject.SetActive(true);
        pair.transform.position = new Vector3(6.0f, 0, 0);
        pair.transform.rotation = Quaternion.identity;
    }
    private void OnReleasePipe(PipePair pair)
    {
        pair.gameObject.SetActive(false);
    }
    private void OnDestroyPipe(PipePair pair)
    {
        Destroy(pair.gameObject);
    }
    public PipePair GetPipe()
    {
        return pipePool.Get();
    }






}
