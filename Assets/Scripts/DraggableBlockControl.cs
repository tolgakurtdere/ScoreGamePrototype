using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableBlockControl : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    public GameObject upBorder, downBorder;

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    
    void OnMouseDrag()
    {

        if(transform.position.z - (GetMouseAsWorldPoint() + mOffset).z < 0 && transform.position.z < upBorder.transform.position.z) //upside
        {
            if(transform.rotation.eulerAngles.y == 0)
            {
                Vector3 v = new Vector3(0, 0, 1);
                transform.position += v * 0.1f;
            }
            else
            {
                Vector3 v = new Vector3(1, 0, Cot(transform.rotation.eulerAngles.y * Mathf.PI / 180));
                transform.position += v * 0.1f;
            }
            
        }
        else //downside
        {
            if(transform.position.z > downBorder.transform.position.z)
            {
                if (transform.rotation.eulerAngles.y == 0)
                {
                    Vector3 v = new Vector3(0, 0, 1);
                    transform.position -= v * 0.1f;
                }
                else
                {
                    Vector3 v = new Vector3(1, 0, Cot(transform.rotation.eulerAngles.y * Mathf.PI / 180));
                    transform.position -= v * 0.1f;
                }
            }
            
        }
        GameObject.Find(this.name + "Temp").transform.position = transform.position; //fix position of prediction object
    }

    private float Cot(float f)
    {
        return Mathf.Cos(f) / Mathf.Sin(f);
    }
}
