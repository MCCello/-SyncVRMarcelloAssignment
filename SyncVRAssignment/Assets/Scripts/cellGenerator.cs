using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellDirection { left, right, up, down }

public class cellGenerator : MonoBehaviour
{
    public float top, bottom, left, right;
    public float buildTime;
    public CellDirection cellDirection;
    public IEnumerator SetUp(float top, float left, float right, float bottom)
    {
		this.top = top;
		this.bottom = bottom;
		this.left = left;
		this.right = right;

		//Cubemap cube = Instantiate 

		//top line
		Debug.DrawLine(new Vector3(left, top, 0),
					   new Vector3(right, top, 0),
					   Color.white, float.MaxValue);
		yield return new WaitForSeconds(buildTime);

		//right line
		Debug.DrawLine(new Vector3(right, top, 0),
					   new Vector3(right, bottom, 0),
					   Color.white, float.MaxValue);
		yield return new WaitForSeconds(buildTime);
		//bottom line
		Debug.DrawLine(new Vector3(right, bottom, 0),
					   new Vector3(left, bottom, 0),
					   Color.white, float.MaxValue);
		yield return new WaitForSeconds(buildTime);
		//left line
		Debug.DrawLine(new Vector3(left, bottom, 0),
					   new Vector3(left, top, 0),
					   Color.white, float.MaxValue);
		yield return new WaitForSeconds(buildTime);
	}
}
