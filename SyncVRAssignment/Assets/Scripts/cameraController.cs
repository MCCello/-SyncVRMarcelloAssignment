using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public lineGrapher lineGrapher;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void goBack31()
    {
        if (lineGrapher.cellCount > 6)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 31f);
        }
        if (lineGrapher.cellCount > 9)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 61f);

        }
    }
}
