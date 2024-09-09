using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCol : MonoBehaviour
{
    PlayerController _pController;
    [SerializeField] bool _isRighthand;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Player");
        _pController = obj.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "WireMesh")
        {
            if (_isRighthand)
                _pController._isRightWire = true;
            else
                _pController._isLeftWire = true;           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "WireMesh")
        {
            if (_isRighthand)
                _pController._isRightWire = false;
            else
                _pController._isLeftWire = false;
        }
    }
}
