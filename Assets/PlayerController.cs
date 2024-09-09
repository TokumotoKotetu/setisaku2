using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform _transform;
    Vector3 _rightHandPos;
    Vector3 _leftHandPos;
    [SerializeField] float _rotationSpeed = 1.0f;
    public bool _isRightWire = false;
    public bool _isLeftWire = false;
    bool _isRightHand = false;
    bool _isLeftHand = false;
    Rigidbody2D _rbody;
    [SerializeField] GameObject _hingeJoint;
    void Start()
    {
        _transform = GetComponent<Transform>();
        _rbody = GetComponent<Rigidbody2D>();
        _isRightHand = false;
        _isLeftHand = false;
    }

    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_isRightWire && !_isLeftHand)
            {
                _isRightHand = true;
                _rightHandPos = _transform.transform.Find("RightHand").gameObject.transform.position;
                Instantiate(_hingeJoint, _rightHandPos, Quaternion.identity);
            }
        }

        if (Input.GetKey(KeyCode.E))
        {
            if(_isRightWire && !_isLeftHand)
                _rbody.velocity = transform.up * _rotationSpeed;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            _isRightHand = false;
            Destroy(GameObject.FindGameObjectWithTag("JointObj"));
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_isLeftWire && !_isRightHand)
            {
                _isLeftHand = true;
                _rightHandPos = _transform.transform.Find("LeftHand").gameObject.transform.position;
                Instantiate(_hingeJoint, _rightHandPos, Quaternion.identity);
            }
        }

        if (Input.GetKey(KeyCode.Q))
        {
            if(_isLeftWire && !_isRightHand)
                _rbody.velocity = transform.up * _rotationSpeed;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            _isLeftHand = false;
            Destroy(GameObject.FindGameObjectWithTag("JointObj"));
        }
    }
}
