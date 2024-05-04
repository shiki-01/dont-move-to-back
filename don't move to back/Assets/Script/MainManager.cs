using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [SerializeField, Header("�Q�[���I�[�o�[UI")]
    private GameObject _gameOverUi;
    [SerializeField, Header("�Q�[���N���AUI")]
    private GameObject _gameClearUIi;
    [SerializeField, Header("BGM")]
    private AudioSource bgm;
    [SerializeField, Header("���艹")]
    private GameObject _submitSE;
    [SerializeField, Header("�Q�[���N���ASE")]
    private GameObject _gameClearSE;
    [SerializeField, Header("�Q�[���I�[�o�[SE")]
    private GameObject _gameOverSEi;

    private GameObject _player;
    private bool _bShowUI;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>().gameObject;
        _bShowUI = false;
    }

    // Update is called once per frame
    void Update()
    {
        _ShowGameOverUI();
    }

    private void _ShowGameOverUI()
    {
        if (_player != null || _gameOverUi.activeSelf) return;

        _gameOverUi.SetActive(true);
        _bShowUI = true;
        bgm.Stop();
        Instantiate(_gameOverSEi);
    }

    public void ShowGameClearUI()
    {
        if (_gameClearUIi.activeSelf) return;

        _gameClearUIi.SetActive(true);
        _bShowUI = true;
        bgm.Stop();
        Instantiate(_gameClearSE);
    }

    public void OnRestart(InputAction.CallbackContext context)
    {
        if (!_bShowUI || !context.performed) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Instantiate(_submitSE);
    }
}
