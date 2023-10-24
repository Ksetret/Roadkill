using UnityEngine;

/// <summary>
/// ������������� ��� ���������, ������� ��� ������� (������ ������ �������� ������������� �� ������ �������)
/// </summary>
public class Heal : MonoBehaviour
{
    [SerializeField] uint _healAmount;

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HealthSystem health_system))
        {
            health_system.GetHealth(_healAmount);
            gameObject.SetActive(false);
        }
    }
}
