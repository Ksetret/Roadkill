using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public uint _maxHealth;
    public uint _currentHealth;
    public bool _inBlockingState;

    public void SetDamage(uint damage)
    {
        if(!_inBlockingState)
            _currentHealth -= damage;

        if (_currentHealth <= 0)
            gameObject.SetActive(false);
    }

    public void GetHealth(uint heal_amount)
    {
        _currentHealth += heal_amount;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
    }
}