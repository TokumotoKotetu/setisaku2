using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HingeJointController : MonoBehaviour
{
    HingeJoint2D _joint2D;
    GameObject _player;
    Rigidbody2D _pRig2D;
    // Start is called before the first frame update
    void Start()
    {
        _joint2D = GetComponent<HingeJoint2D>();
        _player = GameObject.Find("Player");
        _pRig2D = _player.GetComponent<Rigidbody2D>();
        _joint2D.connectedBody = _pRig2D;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
