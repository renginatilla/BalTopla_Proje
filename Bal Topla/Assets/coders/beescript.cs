using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class beescript : MonoBehaviour
{
    public Text distanceText;
    public float distance;
    public float speed=5,upseed;
    public GameObject startpanel;
    public GameObject gameoverpanel;
    public int sayac = 0;
    public Text distanceText_sayac;
    public Text maxflowertext;
    public Text maxmetretext;
    public Text gmaxflowertext;
    public Text gmaxmetretext;
    public static bool panelvisible = true;
    // Start is called before the first frame update
    void Start()
    {
        if (beescript.panelvisible==false)
        {
            startpanel.SetActive(beescript.panelvisible);
            Time.timeScale = 1;         
        } 
        else
            Time.timeScale = 0;

        gameoverpanel.SetActive(false);
        //oyundaki textlere startta atama yapar.
        maxflowertext.text = "" + PlayerPrefs.GetInt("flower_max", 0);
        maxmetretext.text = "" + PlayerPrefs.GetInt("metre_max",0);
    }

    // Update is called once per frame
    void Update()
    {
        distance += 1 * Time.deltaTime;//alınan yolu hesaplar
        distanceText.text = ""+(int)distance + "mt";
        transform.Translate(speed * Time.deltaTime, 0, 0);

        //boşluk tuşuna basıldığında yapılacak işlemler...
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * upseed);
        }

        //mobildeki ekrana dokunma hareketini sağlar.
        foreach (Touch touch in Input.touches)
        {
            //burada parmağın dokunma hareketini almasını sağlar. sürüklemeyi falan kabul etmez.
            if (touch.phase==TouchPhase.Began)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * upseed);
            }
        }
    
    }
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "tree_gost_tag")
        {
            Debug.Log($"tree_gost_tag -> {obj.gameObject.name}");
            obj.gameObject.transform.root.gameObject.GetComponent<treescript>().tree_statu = true;
        }
        if (obj.gameObject.tag=="bush_gost_tag")
        {
            Debug.Log($"bush_gost_tag -> {obj.gameObject.name}");
            obj.gameObject.transform.root.gameObject.GetComponent<bushscript>().bush_statu = true;
        }
        if (obj.gameObject.tag=="Ivy_gost_tag")
        {
            Debug.Log($"Ivy_gost_tag ->{obj.gameObject.name}");
            obj.gameObject.transform.root.gameObject.GetComponent<Ivyscript>().Ivy_statu = true;
        }
        if (obj.gameObject.tag == "flower_tag")
        {
                   
            Debug.Log($"flower_tag: {obj.gameObject.name}");
            sayac++;
            obj.gameObject.transform.root.gameObject.GetComponent<flowerscript>().flower_statu = true;
            distanceText_sayac.text = "" + sayac;
        }
        if (obj.gameObject.tag == "flower_gost_tag")
        {
            Debug.Log($"flower_tag: {obj.gameObject.name}");
            obj.gameObject.transform.root.gameObject.GetComponent<flowerscript>().flower_gost_statu = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "tree_tag")
        {
            Debug.Log($"tree_tag -> {obj.gameObject.name}");
            gameover();
        }
        if (obj.gameObject.tag == "lvy_tag")
        {
            gameover();
        }
        if (obj.gameObject.tag == "bush_tag")
        {
            gameover();
        }
        
       
    }
   private void gameover()
    {
        //ilk atama yapar.
        int flower_max = PlayerPrefs.GetInt("flower_max", 0);
        int metre_max = PlayerPrefs.GetInt("metre_max",0);

        //karşılaştıma ile yeni atama yapılır. tırnak içindeki keye virgülden sonrakii value atılır.
        if (distance>metre_max)
        {
            PlayerPrefs.SetInt("metre_max", (int)distance);
        }
        if (sayac>flower_max)
        {
            PlayerPrefs.SetInt("flower_max", sayac);
        }
        gmaxflowertext.text = "" + PlayerPrefs.GetInt("flower_max", 0);
        gmaxmetretext.text = "" + PlayerPrefs.GetInt("metre_max", 0);
        gameoverpanel.SetActive(true);
        Time.timeScale = 0;

    }
    public void gamestart()
    {
        Debug.Log("start btn call");
        startpanel.SetActive(false); //start panelini gizle
        Time.timeScale = 1;//oyunu başlat
    }
    public void gamerestart()
    {
        beescript.panelvisible = false;
        SceneManager.LoadScene("SampleScene");
    }

}
