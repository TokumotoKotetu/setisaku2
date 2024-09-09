using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject _clearPanel;
    PlayerController _pController;
    private void Start()
    {
        GameObject obj = GameObject.Find("Player");
        _pController = obj.GetComponent<PlayerController>();
        _clearPanel.SetActive(false);
    }
    private void Update()
    {
        if (_pController._isCleared)
        {
            _clearPanel.SetActive(true);
        }
    }
}
