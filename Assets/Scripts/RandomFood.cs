using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFood : MonoBehaviour
{
    public GameObject m_Food;

    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 3)
        {
            int x = Random.Range(-8, 9);
            int z = Random.Range(-8, 9);
            Vector3 foodPosition = new Vector3(x, 0.5f, z);
            Instantiate(m_Food, foodPosition, m_Food.transform.rotation);
            time = 0;
        }
    }
}
