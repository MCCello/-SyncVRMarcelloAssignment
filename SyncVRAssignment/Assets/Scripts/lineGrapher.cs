using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineGrapher : MonoBehaviour
{
    public int resolution = 1;
    public float buildTime;
    public int cellCount = 2;
    public cellGenerator cellObj;
    public GameObject trail;

    private List<cellGenerator> _cells = new List<cellGenerator>();
    private LineRenderer _line;
   
    private cellGenerator _selectedCell;

    float n1 = 0, n2 = 1, n3;
    // Start is called before the first frame update
    void Start()
    {
        _line = GetComponent<LineRenderer>();
        _line.positionCount = cellCount * resolution + 1;
        StartCoroutine(SetUpSpiral());
    }
    float CalculateFibonacciNumber()
    {
        n3 = n1 + n2;
        n1 = n2;
        n2 = n3;
        return n3;
    }
    IEnumerator SetUpSpiral()
    {
        //first cell added is up
        cellGenerator firstCell = Instantiate(cellObj) as cellGenerator;
        float initSize = CalculateFibonacciNumber();
        firstCell.cellDirection = CellDirection.up;

        StartCoroutine(firstCell.SetUp(0, 0, initSize, -initSize));
        _line.SetPosition(0, new Vector3(initSize, -initSize));
         
        _cells.Add(firstCell);

        yield return new WaitForSeconds(buildTime);

        for (int i = 0; i < cellCount; i++)
        {
            int moduleDirection = i % 4;
            cellGenerator cell = null;
            float size = CalculateFibonacciNumber();
            cellGenerator lastCell = null;

            float top;
            float left;
            float right;
            float bottom;

            if (_cells.Count > 0)
            {
                lastCell = _cells[i];
            }

            switch (moduleDirection)
            {
                case 0:
                    //left
                    cell = Instantiate(cellObj);
                    cell.cellDirection = CellDirection.left;

                    top = lastCell.top;
                    left = lastCell.left - size;
                    right = lastCell.left;
                    bottom = lastCell.top - size;

                    _line.SetPosition(i+1,new Vector3(right,top));
                    StartCoroutine(cell.SetUp(top, left, right, bottom));
                    break;
                case 1:
                    //down
                    cell = Instantiate(cellObj);
                    cell.cellDirection = CellDirection.down;

                    top = lastCell.bottom;
                    left = lastCell.left;
                    right = lastCell.left + size;
                    bottom = top - size;

                    _line.SetPosition(i + 1, new Vector3(left, top));

                    StartCoroutine(cell.SetUp(top, left, right, bottom));
                    break;
                case 2:
                    //right
                    cell = Instantiate(cellObj);
                    cell.cellDirection = CellDirection.right;

                    bottom = lastCell.bottom;
                    left = lastCell.right;
                    right = left + size;
                    top = bottom + size;

                    _line.SetPosition(i + 1, new Vector3(left, bottom));

                    StartCoroutine(cell.SetUp(top, left, right, bottom));
                    break;
                case 3:
                    //up
                    cell = Instantiate(cellObj);
                    cell.cellDirection = CellDirection.up;

                    top = lastCell.top + size;
                    left = lastCell.right - size;
                    right = lastCell.right;
                    bottom = lastCell.top;

                    _line.SetPosition(i + 1, new Vector3(right, bottom));

                    StartCoroutine(cell.SetUp(top, left, right, bottom));
                    break;
            }
            if (cell)
            {
                _cells.Add(cell);
                yield return new WaitForSeconds(buildTime);
            }
        }
    }

    public void AddNext()
    {
        foreach (cellGenerator item in _cells)
        {
            Destroy(item.gameObject);
            item.enabled = false;
        }
        n1 = 0;
        n2 = 1;
        n3 = 0;
        _cells.Clear();
        cellCount++;
        _line.positionCount = 0;
        _line.positionCount = cellCount * resolution + 1;
        _line.startWidth = 0.1f * (Camera.main.transform.position.z % 30);
        _line.endWidth = 0.1f * (Camera.main.transform.position.z % 30);
        StartCoroutine(SetUpSpiral());
    }
}
