using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Vector3 pos,pos1;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        pos = Input.mousePosition;
        pos.y = target.position.y;
        pos.z = target.position.z;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 1.5f));
    }
}
