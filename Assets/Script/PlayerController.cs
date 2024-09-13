using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Transform _transform;
    Vector3 _rightHandPos;
    Vector3 _leftHandPos;
    [SerializeField] float _rotationSpeed = 1.0f;
    [SerializeField] float _jumpSpeed = 1;
    public bool _isRightWire = false;
    public bool _isLeftWire = false;
    bool _isRightHand = false;
    bool _isLeftHand = false;
    Rigidbody2D _rbody;
    [SerializeField] GameObject _hingeJoint;
    public bool _isCleared = false;
    float _timer = 0;
    [SerializeField] float _jumpCoolTime = 1;
    [SerializeField] float _jumpPower;
    void Start()
    {
        _transform = GetComponent<Transform>();
        _rbody = GetComponent<Rigidbody2D>();
        _isRightHand = false;
        _isLeftHand = false;
        _isCleared = false;
    }

    void Update()
    {
        PlayerMovement();
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
        }
        _timer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        
    }

    void PlayerMovement()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_isRightWire)
            {
                _isRightHand = true;
                _rightHandPos = _transform.transform.Find("RightHand").gameObject.transform.position;
                Instantiate(_hingeJoint, _rightHandPos, Quaternion.identity);
            }
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (_isRightWire)
                _rbody.velocity = transform.up * _rotationSpeed;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            _isRightHand = false;
            Destroy(GameObject.FindGameObjectWithTag("JointObj"));
            if(_isRightWire)
                _rbody.AddForce(transform.up * _jumpSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_isLeftWire)
            {
                _isLeftHand = true;
                _rightHandPos = _transform.transform.Find("LeftHand").gameObject.transform.position;
                Instantiate(_hingeJoint, _rightHandPos, Quaternion.identity);
            }
        }

        if (Input.GetKey(KeyCode.Q))
        {
            if (_isLeftWire)
                _rbody.velocity = transform.up * _rotationSpeed;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            _isLeftHand = false;
            Destroy(GameObject.FindGameObjectWithTag("JointObj"));
            if(_isLeftWire)
                _rbody.AddForce(transform.up * _jumpSpeed);
        }

        if(Input.GetKey(KeyCode.Space) && _timer > _jumpCoolTime)
        {
            _timer = 0;
            _rbody.AddForce(Vector3.up * _jumpPower);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ClearItem")
        {
            _isCleared = true;
        }
    }
}
