using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    CharacterAnimation _characterAnimation;

    public bool _isDead = false;
    public bool _inBlockingState = false;


    public uint _maxHealth;
    public uint _currentHealth;

    [SerializeField] private bool _robot = false;
    [SerializeField] private GameObject _deathWindow;
    [SerializeField] private GameObject _fonWinndow;
    [SerializeField] private GameObject _readyWindow;
    public void SetDamage(uint damage)
    {
        if (_robot == true)
        {
            _readyWindow.SetActive(true);
            Time.timeScale = 0;
        }

        if (_currentHealth > _maxHealth)
            _currentHealth = 0; 
        
        if (_currentHealth <= 0)
        {
            _isDead = true;
            _characterAnimation.Death();
            _deathWindow.SetActive(true);
            _fonWinndow.SetActive(true);


        }
        else if (!_inBlockingState)
        {
            _currentHealth -= damage;
            _characterAnimation.Hit();  
        }

    }

    public void GetHealth(uint heal_amount)
    {
        _currentHealth += heal_amount;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
    }



    void Awake()
    {
        _characterAnimation = GetComponentInChildren<CharacterAnimation>();
    }

   
}
