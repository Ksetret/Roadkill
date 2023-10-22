using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [SerializeField] HealthSystem _healthSystem;

    private void Awake()
    {
        _healthSystem = GetComponentInChildren<HealthSystem>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HealthSystem healthSystem))
            if(_healthSystem != healthSystem)
            {
                print(healthSystem.name);
                healthSystem.SetDamage(1);
            }
    }
}
