using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField, Header("éãç∑å¯â "), Range(0, 1)]
    private float _parallaxEffect;

    private GameObject _camera;
    private float _length;
    private float _statPosX;

    // Start is called before the first frame update
    void Start()
    {
        _statPosX = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
        _camera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _Parallax();
    }

    private void _Parallax()
    {
        float temp = _camera.transform.position.x * (1 - _parallaxEffect);
        float dist = _camera.transform.position.x * _parallaxEffect;

        transform.position = new Vector3(_statPosX + dist, transform.position.y, transform.position.z);

        if (temp > _statPosX + _length)
        {
            _statPosX += _length;
        }
        else if (temp < -_statPosX - _length)
        {
            _statPosX -= _length;
        }
    }
}
