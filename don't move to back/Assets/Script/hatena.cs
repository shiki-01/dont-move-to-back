using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    public enum EffectType
    {
        SpeedBoost,
        JumpBoost,
        HPBoost
    }

    [SerializeField, Header("�X�s�[�h������")]
    private float _speedBoostAmount;
    [SerializeField, Header("�W�����v������")]
    private float _jumpBoostAmount;
    [SerializeField, Header("���C�t�񕜗�")]
    private int _hpBoostAmount;
    [SerializeField, Header("�ő�q�b�g��")]
    private int maxHitCount;
    [SerializeField, Header("��̃u���b�N�̃X�v���C�g")]
    private GameObject emptyBlockPrefab;

    private int hitCount;
    private bool isDeactived;

    public EffectType selectedEffect;

    void Start()
    {
        hitCount = 0;
        isDeactived = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 playerPos = collision.gameObject.transform.position;
            Vector2 blockPos = transform.position;

            if (playerPos.y < blockPos.y && !isDeactived)
            {
                Player player = collision.gameObject.GetComponent<Player>();

                if (hitCount < maxHitCount)
                {
                    switch (selectedEffect)
                    {
                        case EffectType.SpeedBoost:
                            player.IncreaseSpeed(_speedBoostAmount);
                            break;
                        case EffectType.JumpBoost:
                            player.IncreaseJump(_jumpBoostAmount);
                            break;
                        case EffectType.HPBoost:
                            player.IncreaseHP(_hpBoostAmount);
                            break;
                    }
                    hitCount++;

                    if (hitCount >= maxHitCount)
                    {
                        isDeactived = true;
                        Instantiate(emptyBlockPrefab, transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }
}
