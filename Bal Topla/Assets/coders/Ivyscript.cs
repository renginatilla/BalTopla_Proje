using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ivyscript : MonoBehaviour
{
    public float speed = 2;
    public GameObject Ivy;
    public bool Ivy_statu = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate( (speed * Time.deltaTime * -1),0, 0);
        if (Ivy_statu==true)
        {
            Invoke("dublacate_Ivy", 0);
            Ivy_statu = false;
        }
    }
    private void dublacate_Ivy()
    {
        Instantiate(Ivy, new Vector3(10.58f, 3.07f, -1), Quaternion.identity);
        Invoke("hide_fnc",2);
    }
    private void hide_fnc()
    {
        Destroy(Ivy, 0);
    }
}
