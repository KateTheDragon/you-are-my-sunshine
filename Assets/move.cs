using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] public float x=0;
    [SerializeField] public float y=0;
    [SerializeField] public float scale = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position = Vector3.ClampMagnitude(this.transform.position + new Vector3(x, y, 0) * Time.deltaTime, 10000);
        
        this.transform.localScale = Vector3.ClampMagnitude(this.transform.localScale + new Vector3(scale, scale) * Time.deltaTime, 10000);
    }
}
