using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treescript : MonoBehaviour
{
    public float speed = 5;
    public GameObject tree;
    public bool tree_statu = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((speed * Time.deltaTime*-1), 0, 0);//sola git emri

        //objeden yeni bir tane üretiliyor....
        //float rnd = Random.Range(0, 2);
        //tree.transform.localPosition = new Vector2(10.58f, -3.27f);//f floatın kısaltması
        //transform.position = transform.position + new Vector3(10.58f, -3.27f);
        // tree.SetActive(true);//yeni nesnemi bana getir ve kullan.
        if (tree_statu==true)
        {
            Invoke("dublacate_tree", 0);// sadece bir sefer çalıştırmak istediğimiz metodlarda kullanılır.
            tree_statu = false;
        }
  
    }
    
    private void dublacate_tree()
    {
        Instantiate(tree, new Vector3(10.58f, -3.27f, -1), Quaternion.identity); //burada çoğaltma işlemi yapılır.
        Invoke("hide_fnc", 2);
    }
    private void hide_fnc()
    {
        Destroy(tree, 0);
    }



}
