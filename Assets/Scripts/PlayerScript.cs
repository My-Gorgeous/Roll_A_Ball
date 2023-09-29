using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Text scoreText;
    private Text winText;

    public int score = 0;

    // Start is called before the first frame update
    // 用于游戏启动时的初始化，只执行一次
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        scoreText = GameObject.Find("Canvas/Score").GetComponent<Text>();
        winText = GameObject.Find("Canvas/Win").GetComponent<Text>();
        // 初始时设置Win对象不显示
        winText.enabled = false;
    }

    // Update is called once per frame
    // 用于游戏运行过程中的资源更新，执行多次
    void Update()
    {
        /*
        // Vector3中内置的向量大小都默认为1，即作用在刚体上时表示1N的力
        rigidbody.AddForce(Vector3.right);
        // 除了像上面那样使用内置的Vector，还可以自定义Vector
        Vector3 vector = new Vector3(1, 0, 0);  // 等价于Vector3.right
        rigidbody.AddForce(vector);
        //rigidbody.AddForce(new Vector3(1, 0, 0));
        */

        // 监听键盘输入控制物体移动
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rigidbody.AddForce(new Vector3(h, 0, v) * 3);
        // 可以通过将向量乘以某个倍数来控制移动的速度
        // rigidbody.AddForce(new Vector3(h, 0, v) * 5);

        // 当分数达到5分时，显示用户胜利，隐藏计分板
        if (score == 5)
        {
            scoreText.enabled = false;
            winText.enabled = true;
        }
    }

    /*
    // 系统事件调用，用于处理碰撞事件，发生碰撞时自动调用
    // 注意，在地面上时也是碰撞，所以只要初始时物体在地面上，一加载游戏就会发生碰撞事件
    private void OnCollisionEnter(Collision collision)
    {
        // Collision是一个碰撞信息对象，保存了发生碰撞的物体
        // 实验发现，使用碰撞检测来作为小球吃食物的话，小球每次撞到食物后会停顿一下
        // 这样的游戏效果不好，因此改用触发检测来判断，触发检测和碰撞检测相比只是没有物理效果
        if (collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
        }
    }
    */

    // 当设置游戏物体上的触发器后，即使脚本中存在onCollision碰撞脚本方法也不会执行了
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            // 不能直接删除Collider对象，这样并不是删除游戏场景中的实际物体，只是删除碰撞器
            // Destroy(other);
            Destroy(other.gameObject);
            score++;
            scoreText.text = "分数：" + score;
        }
    }
}
