using UnityEngine;

public class BirdIdle : MonoBehaviour
{
    [Header("��������� ���������")]
    [Tooltip("��������� (� ������)")]
    [SerializeField] private float amplitude = 0.25f;

    [Tooltip("�������� ��������� (������ � �������)")]
    [SerializeField] private float frequency = 1.5f;

    private Vector3 startPos;   // ����� ������ ������� ������
    private float phase;      // ����, ����� ����� ���� ����������

    void OnEnable()
    {
        gameObject.GetComponent<Rigidbody2D>().simulated = false; // ��������� ������, ����� �� ������
        startPos = transform.localPosition;
        phase = 0f;
    }

    void Update()
    {
        // ���������� �� scaled?time, ����� ��������� �������� ���� ��� timeScale = 0
        phase += Time.unscaledDeltaTime * frequency * Mathf.PI * 2f;

        float offsetY = Mathf.Sin(phase) * amplitude;
        transform.localPosition = startPos + Vector3.up * offsetY;
    }

    /// <summary>
    /// ���� ����� �������� ��������� (��������, ��� ������ �� �����).
    /// </summary>
    public void ResetBob()
    {
        phase = 0f;
        transform.localPosition = startPos;
    }
}
