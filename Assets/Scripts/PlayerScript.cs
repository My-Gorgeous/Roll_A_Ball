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
    // ������Ϸ����ʱ�ĳ�ʼ����ִֻ��һ��
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        scoreText = GameObject.Find("Canvas/Score").GetComponent<Text>();
        winText = GameObject.Find("Canvas/Win").GetComponent<Text>();
        // ��ʼʱ����Win������ʾ
        winText.enabled = false;
    }

    // Update is called once per frame
    // ������Ϸ���й����е���Դ���£�ִ�ж��
    void Update()
    {
        /*
        // Vector3�����õ�������С��Ĭ��Ϊ1���������ڸ�����ʱ��ʾ1N����
        rigidbody.AddForce(Vector3.right);
        // ��������������ʹ�����õ�Vector���������Զ���Vector
        Vector3 vector = new Vector3(1, 0, 0);  // �ȼ���Vector3.right
        rigidbody.AddForce(vector);
        //rigidbody.AddForce(new Vector3(1, 0, 0));
        */

        // ��������������������ƶ�
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rigidbody.AddForce(new Vector3(h, 0, v) * 3);
        // ����ͨ������������ĳ�������������ƶ����ٶ�
        // rigidbody.AddForce(new Vector3(h, 0, v) * 5);

        // �������ﵽ5��ʱ����ʾ�û�ʤ�������ؼƷְ�
        if (score == 5)
        {
            scoreText.enabled = false;
            winText.enabled = true;
        }
    }

    /*
    // ϵͳ�¼����ã����ڴ�����ײ�¼���������ײʱ�Զ�����
    // ע�⣬�ڵ�����ʱҲ����ײ������ֻҪ��ʼʱ�����ڵ����ϣ�һ������Ϸ�ͻᷢ����ײ�¼�
    private void OnCollisionEnter(Collision collision)
    {
        // Collision��һ����ײ��Ϣ���󣬱����˷�����ײ������
        // ʵ�鷢�֣�ʹ����ײ�������ΪС���ʳ��Ļ���С��ÿ��ײ��ʳ����ͣ��һ��
        // ��������ϷЧ�����ã���˸��ô���������жϣ�����������ײ������ֻ��û������Ч��
        if (collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
        }
    }
    */

    // ��������Ϸ�����ϵĴ������󣬼�ʹ�ű��д���onCollision��ײ�ű�����Ҳ����ִ����
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            // ����ֱ��ɾ��Collider��������������ɾ����Ϸ�����е�ʵ�����壬ֻ��ɾ����ײ��
            // Destroy(other);
            Destroy(other.gameObject);
            score++;
            scoreText.text = "������" + score;
        }
    }
}
