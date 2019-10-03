using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flowerscript : MonoBehaviour
{
    public GameObject flower;
    public float speed = 2;
    public bool flower_statu = false;
    public bool flower_gost_statu = false;
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((speed * Time.deltaTime * -1), 0, 0);
        if (flower_statu==true && flower_gost_statu==false)
        {
            Invoke("fnc_settings", 0);         
            flower_statu = false;
        }
        else
        {
            Invoke("fnc_settings", 10);
            flower_gost_statu = false;
        }
    }
    private void fnc_settings()
    {
        
        //yeni çiçeği oluştur.
        float rnd = Random.Range(3.5f, -3.5f);
        Instantiate(flower, new Vector3(10.0f, rnd, -1), Quaternion.identity);
       //ilk çiçeği sil
        Destroy(flower, 0); //burada çiçeği sildiğimizde içindeki nesne olan gostu da siliyor.
    }
}
