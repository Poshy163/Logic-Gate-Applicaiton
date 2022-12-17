using Unity.UI;
using UnityEngine;

public class InputNode : MonoBehaviour
{
    private GameObject _connector;
    private SpriteRenderer _connectorRenderer;
    [Tooltip("ON/OFF")]
    public bool state;

    void Awake()
    {
        _connector = this.transform.GetChild(0).gameObject;
        _connectorRenderer = _connector.GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        switch (state)
        {
            case true:
                _connectorRenderer.color = Color.black;
                state = false;
                break;
            case false:
                _connectorRenderer.color = Color.yellow;
                state = true;
                break;


        }
    }
}
