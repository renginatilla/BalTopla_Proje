using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bushscript : MonoBehaviour
{
    public float speed=5;
    public GameObject bush;
    public bool bush_statu = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((speed * Time.deltaTime * -1), 0, 0);

        if (bush_statu==true)
        {
            Invoke("dublacate_bush", 0);
            bush_statu = false;
        }
        
    }
    private void dublacate_bush()
    {
        Instantiate(bush, new Vector3(10.58f, -4.27f, -1), Quaternion.identity);
        Invoke("hide_fnc", 2);
    }
    private void hide_fnc()
    {
        Destroy(bush, 0);
    }
}
