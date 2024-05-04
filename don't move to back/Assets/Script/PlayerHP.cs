using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField, Header("HPÉAÉCÉRÉì")]
    private GameObject _playerIcon;

    private Player _player;
    private int _beforeHP;
    private List<GameObject> _hpIcons = new List<GameObject>();

    void Start()
    {
        _player = FindObjectOfType<Player>();
        _beforeHP = _player.GetHP();
        _CreateHPIcon();
    }

    private void _CreateHPIcon()
    {
        for (int i = 0; i < _player._maxHp; i++)
        {
            GameObject _playerHPObj = Instantiate(_playerIcon);
            _playerHPObj.transform.SetParent(transform, false);
            _hpIcons.Add(_playerHPObj);
            _playerHPObj.SetActive(i < _player.GetHP());
        }
    }

    void Update()
    {
        _ShowHPIcon();
    }

    private void _ShowHPIcon()
    {
        if (_beforeHP == _player.GetHP()) return;

        for (int i = 0; i < _hpIcons.Count; i++)
        {
            _hpIcons[i].SetActive(i < _player.GetHP());
        }
        _beforeHP = _player.GetHP();
    }
}


