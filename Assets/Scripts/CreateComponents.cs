using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateComponents : MonoBehaviour
{

    public GameObject Cell;
    public Transform CanvasParent;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Cell, new Vector3(0, 0, 0), Quaternion.identity, CanvasParent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
