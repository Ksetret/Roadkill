using UnityEngine;

/// <summary>
/// ������������� ��� ���������, ������� ��� ������� (������ ������ �������� ������������� �� ������� �������)
/// </summary>
public class Heal : MonoBehaviour
{
    [SerializeField] uint _healAmount;

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HealthSystem healthSystem))
        {
            healthSystem.GetHealth(_healAmount);
            gameObject.SetActive(false);
        }
    }
}
