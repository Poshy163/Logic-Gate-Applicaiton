using UnityEngine;

// ReSharper disable RedundantCheckBeforeAssignment

public class InputNode : MonoBehaviour
{
    public GameObject connectedNode;
    [Tooltip("ON/OFF")] public bool state;
    private GameObject _connector;
    private SpriteRenderer _connectorRenderer;

    private void Awake()
    {
        _connector = transform.GetChild(0).gameObject;
        _connectorRenderer = _connector.GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        switch (state)
        {
            case true:
                state = false;
                _connectorRenderer.color = Color.black;
                if (connectedNode != null)
                    connectedNode.GetComponent<OutputNode>().connectionAmount--;
                break;


            case false:
                state = true;
                _connectorRenderer.color = Color.yellow;
                if (connectedNode != null)
                    connectedNode.GetComponent<OutputNode>().connectionAmount++;
                break;
        }
    }
}