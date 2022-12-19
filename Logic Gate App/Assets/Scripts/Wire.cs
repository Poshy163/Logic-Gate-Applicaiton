using System.Collections;
using UnityEngine;

// ReSharper disable Unity.PerformanceCriticalCodeCameraMain
// ReSharper disable PossibleNullReferenceException
// ReSharper disable Unity.PerformanceCriticalCodeInvocation
// ReSharper disable Unity.PerformanceCriticalCodeNullComparison

public class Wire : MonoBehaviour
{
    public Camera cam;
    public int connection;
    private Coroutine _drawing;
    private GameObject _firstObject;
    private GameObject _lineObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var mousePos2D = new Vector2(mousePos.x, mousePos.y);

            var hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
                if (hit.transform.CompareTag("Input"))
                {
                    connection++;
                    _firstObject = hit.transform.gameObject;
                }

            StartLine();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var mousePos2D = new Vector2(mousePos.x, mousePos.y);

            var hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
                if (hit.transform.CompareTag("Output"))
                    connection++;

            if (connection != 2)
            {
                Destroy(_lineObject);
                connection = 0;
            }
            else
            {
                _firstObject.GetComponentInParent<InputNode>().connectedNode = hit.transform.gameObject;
                connection = 0;
            }

            FinishLine();
        }
    }


    private void StartLine()
    {
        if (_drawing != null) StopCoroutine(_drawing);
        _drawing = StartCoroutine(DrawLine());
    }

    private void FinishLine()
    {
        StopCoroutine(_drawing);
    }

    private IEnumerator DrawLine()
    {
        //GameObject prevLine = 
        _lineObject = Instantiate(Resources.Load("Line") as GameObject, new Vector3(0, 0, 0), Quaternion.identity);
        var line = _lineObject.GetComponent<LineRenderer>();
        line.positionCount = 0;

        while (true)
        {
            var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            var positionCount = line.positionCount;
            positionCount++;
            line.positionCount = positionCount;
            line.SetPosition(positionCount - 1, position);
            yield return null;
        }
    }
}