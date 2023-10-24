using UnityEngine;

/// <summary>
/// Предоставляет хил персонажу, который его подберёт (данный скрипт вешается исключительно на объекты аптечек)
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
