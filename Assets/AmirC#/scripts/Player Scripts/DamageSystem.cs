using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [SerializeField] uint _damageAmount;

    HealthSystem _healthSystem;

    private void Awake()
    {
        _healthSystem = GetComponentInChildren<HealthSystem>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HealthSystem healthSystem))
            if (_healthSystem != healthSystem)
                healthSystem.SetDamage(_damageAmount);
    }
}
