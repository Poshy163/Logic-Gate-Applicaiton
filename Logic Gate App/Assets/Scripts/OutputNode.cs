using UnityEngine;

public class OutputNode : MonoBehaviour
{
    [Tooltip("ON/OFF")] public int connectionAmount;

    private GameObject _connector;
    private SpriteRenderer _connectorRenderer;

    private void Awake()
    {
        _connector = transform.GetChild(0).gameObject;
        _connectorRenderer = _connector.GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        _connectorRenderer.color = connectionAmount > 0 ? Color.yellow : Color.black;
    }
}