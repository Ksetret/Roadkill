using UnityEngine;

public enum ComboState
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    KICK_1
}

public class CharacterAttack : MonoBehaviour
{
    CharacterAnimation _characterAnimation;

    ComboState _currentComboState;

    float _defaultComboTimer = 0.5f;
    float _currentComboTimer;
    bool _activateTimerToReset;

    void ComboAttacks()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //if (_currentComboState == ComboState.KICK_2)
                //return;

            _currentComboState++;
            _activateTimerToReset = true;
            _currentComboTimer = _defaultComboTimer;

            if (_currentComboState == ComboState.PUNCH_1)
                _characterAnimation.Punch_1();
            if (_currentComboState == ComboState.PUNCH_2)
                _characterAnimation.Punch_2();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_currentComboState == ComboState.KICK_1)
                _characterAnimation.Kick_1();
        }
    }

    void ResetComboState()
    {
        if (_activateTimerToReset)
        {
            _currentComboTimer -= Time.deltaTime;

            if (_currentComboTimer <= 0)
            {
                _currentComboState = ComboState.NONE;
                _activateTimerToReset = false;
                _currentComboTimer = _defaultComboTimer;
            }
        }
    }



    void Awake()
    {
        _characterAnimation = GetComponentInChildren<CharacterAnimation>();
    }

    void Start()
    {
        _currentComboTimer = _defaultComboTimer;
        _currentComboState = ComboState.NONE;
    }

    void Update()
    {
        ComboAttacks();
        ResetComboState();
    }
}
