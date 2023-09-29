using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // ������������������֮��ĳ�ʼλ�ò�
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // ���������ƶ����ʵʱλ�ø��������λ��
        transform.position = playerTransform.position + offset;
    }
}
