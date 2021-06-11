using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class graphGenerator : MonoBehaviour
{
    public fibonacciGenerator fibGenerator;

    [SerializeField] private Image columnSprite;
    [SerializeField] private RectTransform graphContainer;
    [SerializeField] private RectTransform templateLabelX;
    public int maxVisibleAmount = 10;

    private List<GameObject> gameObjectList = new List<GameObject>();
    private void Start()
    {
        //graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        fibGenerator = FindObjectOfType<fibonacciGenerator>();
        if (fibGenerator!=null)
        {
            ShowGraph(fibGenerator.fibNumbers);
        }
    }
    private void Update()
    {
        //if (counter != fibGenerator.fibNumbers.Count)
        //{
        //    ShowGraph(fibGenerator.fibNumbers);
        //}
    }
    private GameObject GenerateColumn(Vector2 position, float barWidth)
    {
        GameObject gameObject = new GameObject("column", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(position.x,0f);
        rectTransform.sizeDelta = new Vector2(barWidth , position.y);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        //set pivot to bottom left
        rectTransform.pivot = new Vector2(.5f, 0f);
        return gameObject;
    }
    private void ShowGraph(List<int> valueList)
    {
        #region Destroy previous list before remake
        foreach (GameObject item in gameObjectList)
        {
            Destroy(item);
        }
        gameObjectList.Clear();
        #endregion  

        float graphHeight = graphContainer.sizeDelta.y;
        float graphWidth = graphContainer.sizeDelta.x;

        #region Dynamic X Axis 
        if (maxVisibleAmount>valueList.Count)
        {
            maxVisibleAmount = valueList.Count;
        }
        int xIndex = 0;
        float xSize = graphWidth / (valueList.Count + 1);
        #endregion

        #region Dynamic Y Axis
        float yMaximum = valueList[0];
        float yMinimum = valueList[0];
        //checks values being displayed
        for (int i = 0; i < valueList.Count; i++)
        {
            int item = valueList[i];
            if (item > yMaximum)
            {
                yMaximum = item;
            }
            if (item < yMinimum)
            {
                yMinimum = item;
            }
        }
        yMaximum = yMaximum + (yMaximum - yMinimum) * 0.2f;
        yMinimum = yMinimum - (yMaximum - yMinimum) * 0.05f;
        #endregion

        #region Spawn Columns
        //only spawns the last values depending on MaxVisibleAmount
        for (int i = 0; i < valueList.Count; i++)
        {
            //Create column based on xSize difference and the Dynamic yMin / Max
            float xPosition = xSize +xIndex * xSize;
            float yPosition = ((valueList[i] - yMinimum) / (yMaximum - yMinimum) * graphHeight);

            gameObjectList.Add(GenerateColumn(new Vector2(xPosition, yPosition), xSize*.9f));
            
            //Creating Labels with Fib Number
            RectTransform labelX = Instantiate(templateLabelX);
            labelX.SetParent(graphContainer);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(xPosition, -10f);
            labelX.GetComponent<Text>().text = valueList[i].ToString();
            gameObjectList.Add(labelX.gameObject);

            //index for X positions
            xIndex++;
        }
        #endregion
    }
    public void GetNext()
    {
        fibGenerator.GetNextFibNumber();
        //fibGenerator.fibNumbers.Add(999); <- testing ratios since fib numbers always have the same ratio it looked like the graph was bugged.
        Debug.Log($"{fibGenerator.fibNumbers[fibGenerator.fibNumbers.Count - 1]}");
        ShowGraph(fibGenerator.fibNumbers);
    }

}
