using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundCircle : MonoBehaviour
{

    public float rotateSpeed = 50f; // �������� ��������

    void Update()
    {
        transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
    }

}
