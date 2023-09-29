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
        // 计算相机与待跟随物体之间的初始位置差
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 根据物体移动后的实时位置更新相机的位置
        transform.position = playerTransform.position + offset;
    }
}
