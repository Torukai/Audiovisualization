using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour
{
    public Vector3 _rotateAxis, _rotateSpeed;
    public float _xSpeed, _ySpeed, _zSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).transform.LookAt(this.transform);

        this.transform.Rotate(_xSpeed * Time.deltaTime,
                                _ySpeed *Time.deltaTime,
                                _zSpeed * Time.deltaTime, Space.Self);//(new Vector3(0, 0, 20) * Time.deltaTime);//_rotateAxis.x * _rotateSpeed.x * Time.deltaTime, _rotateAxis.y * _rotateSpeed.y * Time.deltaTime, _rotateAxis.z * _rotateSpeed.z * Time.deltaTime);


    }
}
