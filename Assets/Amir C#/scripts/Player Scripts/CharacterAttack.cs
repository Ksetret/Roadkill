using UnityEngine;

public enum ComboState
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    KICK_1,
    SPECIAL1
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
                _characterAnimation.SetAnimationTriggerByName(AnimationTags.PUNCH_1_TRIGGER);
            if (_currentComboState == ComboState.PUNCH_2)
                _characterAnimation.SetAnimationTriggerByName(AnimationTags.PUNCH_2_TRIGGER);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_currentComboState == ComboState.KICK_1)
                _characterAnimation.SetAnimationTriggerByName(AnimationTags.KICK_1_TRIGGER);
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
