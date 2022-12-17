using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputNode : MonoBehaviour
{
    private GameObject _connector;
    private SpriteRenderer _connectorRenderer;
    [Tooltip("ON/OFF")]
    public bool state;
    public bool hasConnection;

    void Awake()
    {
        _connector = transform.GetChild(0).gameObject;
        _connectorRenderer = _connector.GetComponent<SpriteRenderer>();
    }
    
    
    private void Update()
    {
        _connectorRenderer.color = hasConnection ? Color.yellow : Color.black;
    }
}
