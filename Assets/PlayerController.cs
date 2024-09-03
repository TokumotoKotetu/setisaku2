using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rotation _rotation;
    Vector2 _rightHandPos;
    Vector2 _leftHandPos;
    Transform _transform;
    [SerializeField] float _rotationSpeed = 1.0f;
    void Start()
    {
        _rotation = Rotation.Stop;
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_rotation)
        {
            case Rotation.Stop:
                Debug.Log("–³‰ñ“]");
                break;
            case Rotation.RightRot:
                Debug.Log("ŽžŒv‰ñ‚è");
                _transform.RotateAround(_rightHandPos, new Vector3(0,0,-1), (360 / _rotationSpeed) * Time.deltaTime);
                break;
            case Rotation.LeftRot:
                Debug.Log("”½ŽžŒv‰ñ‚è");
                _transform.RotateAround(_leftHandPos, new Vector3(0, 0, 1), (360 / _rotationSpeed) * Time.deltaTime);
                break;
        }

        _rightHandPos = transform.GetChild(0).gameObject.transform.position;
        _leftHandPos = transform.GetChild(1).gameObject.transform.position;

        if (Input.GetKey(KeyCode.E))
        {
            _rotation = Rotation.RightRot;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            _rotation = Rotation.LeftRot;
        }
    }

    enum Rotation{Stop, RightRot, LeftRot}
}
