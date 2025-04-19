using UnityEngine;

public class BirdIdle : MonoBehaviour
{
    [Header("Параметры колебаний")]
    [Tooltip("Амплитуда (в юнитах)")]
    [SerializeField] private float amplitude = 0.25f;

    [Tooltip("Скорость колебания (циклов в секунду)")]
    [SerializeField] private float frequency = 1.5f;

    private Vector3 startPos;   // точка вокруг которой «дышим»
    private float phase;      // фаза, чтобы можно было сбрасывать

    void OnEnable()
    {
        gameObject.GetComponent<Rigidbody2D>().simulated = false; // отключаем физику, чтобы не падали
        startPos = transform.localPosition;
        phase = 0f;
    }

    void Update()
    {
        // Используем не scaled?time, чтобы колебания работали даже при timeScale = 0
        phase += Time.unscaledDeltaTime * frequency * Mathf.PI * 2f;

        float offsetY = Mathf.Sin(phase) * amplitude;
        transform.localPosition = startPos + Vector3.up * offsetY;
    }

    /// <summary>
    /// Если нужно сбросить колебание (например, при выходе из паузы).
    /// </summary>
    public void ResetBob()
    {
        phase = 0f;
        transform.localPosition = startPos;
    }
}
