using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HealthSystem healthSystem))
        {
            if (other.TryGetComponent(out PlayerControls _controls))
            {
                if(!_controls._inBlockingState)
                    healthSystem.SetDamage();
            }
        }
    }
}
