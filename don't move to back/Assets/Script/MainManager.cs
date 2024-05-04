using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField, Header("�Q�[���I�[�o�[UI")]
    private GameObject _gameOverUi;
    [SerializeField, Header("�Q�[���N���AUI")]
    private GameObject _gameClearUIi;

    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        _ShowGameOverUI();
    }

    private void _ShowGameOverUI()
    {
        if (_player != null) return;

        _gameOverUi.SetActive(true);
    }

    public void ShowGameClearUI()
    {
        _gameClearUIi.SetActive(true);
    }
}
