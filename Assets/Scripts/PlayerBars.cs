using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerBars : MonoBehaviour
{
    [SerializeField]
    private Image _hPBar;
    [SerializeField]
    private Image _ManaBar;
    [SerializeField]
    private Player _player;

    void Update()
    {
        _hPBar.fillAmount = _player.Hp / _player.MHp;
    }
}
