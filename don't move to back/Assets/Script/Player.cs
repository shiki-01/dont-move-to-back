using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField, Header("�ړ����x")]
    private float _moveSpeed;
    [SerializeField, Header("�W�����v���x")]
    private float _jumpSpeed;
    [SerializeField, Header("�̗�")]
    private int _hp;

    private Vector2 _inputDirection;
    private Rigidbody2D _rigid;
    private bool _bJump;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _bJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        Debug.Log(_hp);
    }

    private void _Move()
    {
        _rigid.velocity = new Vector2(_inputDirection.x * _moveSpeed, _rigid.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            _bJump = false;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            _HitEnemy(collision.gameObject);
        }

    }

    private void _HitEnemy(GameObject enemy)
    {
        float halfScaleY = transform.localScale.y / 2.0f;
        float enemyHalfSaleY = enemy.transform.localScale.y / 2.0f;
        if (transform.position.y - (halfScaleY - 0.1f) >= enemy.transform.position.y + (enemyHalfSaleY - 0.1f))
        {
            Destroy(enemy);
        }
        else
        {
            enemy.GetComponent<Enemy>().PlayerDamage(this);
        }
    }

    public void _OnMove(InputAction.CallbackContext context)
    {
        _inputDirection = context.ReadValue<Vector2>();
    }

    public void _OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed || _bJump) return;

        _rigid.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
        _bJump = true;
    }

    public void Damage(int  damage)
    {
        _hp = Mathf.Max(_hp - damage, 0);
    }
}
