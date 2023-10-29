using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthUI : MonoBehaviour
{
    private Image _health_UI;
    [SerializeField] private GameObject _healthBar;

    private void Awake()
    {
        _health_UI = _healthBar.GetComponent<Image>();
    }

    public void DisplayHealth(float value)
    {
        value /= 100f;

        if(value < 0)
            value = 0;

        _health_UI.fillAmount = value;
    }
}


