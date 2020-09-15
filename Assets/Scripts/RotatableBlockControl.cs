using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableBlockControl : MonoBehaviour
{

    private void OnMouseDown()
    {
        this.transform.Rotate(new Vector3(0, 30, 0)); //rotate real object
        GameObject.Find(this.name + "Temp").transform.Rotate(new Vector3(0, 30, 0)); //rotate prediction object
    }
}
