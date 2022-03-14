using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

using UnityEngine.UI;

public class Invent : MonoBehaviour
{
    Animator anim;
    public Animator plant_amim;
    public int plant_has_grown;
    public static int coin;
    public static int farm;
    public int stone;
    public int stone2;
    public int stone3;
    public int stone4;
    
    public float repeat_time; /* Время в секундах */ 
    private float curr_time;
    
    public float repeat_time_plant; /* Время в секундах */ 
    private float curr_time_plant;
    
    public GameObject TextObject; 
    Text textComponent;
    
    
    
    
    
    public GameObject TextObject1;
    Text textComponent1;
    public GameObject TextObject2; 
    Text textComponent2;
    public GameObject TextObject3; 
    Text textComponent3;
    public GameObject TextObject4; 
    TextMeshProUGUI textComponent4;
    public GameObject TextObject01;
    Text textComponent01;
    public GameObject TextObject02;
    Text textComponent02;
    public GameObject TextObject03;
    Text textComponent03;
    public GameObject TextObject04;
    Text textComponent04;
    
    
    public static float  speed;
    public GameObject BUR;
    public GameObject Table;
    public GameObject Farm;
    private int dd1;
    private int dd2;
    public GameObject Plant;
    public GameObject Plant2;
    
    
    
    
    
    public static int problem1;
    public static int problem2;
    public static int problem3;
    public static int problem4;
    public static int p1;
    public static int p2;
    
   
    
 
    void Start()
    {
        repeat_time = 1;
        curr_time = repeat_time * 1f;
        curr_time_plant = 30f;
        plant_has_grown = 0;
        coin = 200;
        farm = 1;
        speed = 0;
        problem1 = 5;
        problem2 = 50;
        problem3 = 20;
        problem4 = 100;
        p1 = 0;
        p2 = 1;
        
        anim = gameObject.GetComponent<Animator>();
        textComponent = TextObject.GetComponent <Text> ();
        
        
        textComponent1 = TextObject1.GetComponent <Text> ();
        textComponent2 = TextObject2.GetComponent <Text> ();
        textComponent3 = TextObject3.GetComponent <Text> ();
        textComponent01 = TextObject01.GetComponent <Text> ();
        textComponent02 = TextObject02.GetComponent <Text> ();
        textComponent03 = TextObject03.GetComponent <Text> ();
        textComponent04 = TextObject04.GetComponent <Text> ();
        textComponent4 = TextObject4.GetComponent<TextMeshProUGUI>();
        dd1 = 0;
        dd2 = 0;
    }
    public void ClickFun()
    {
        
        anim.SetTrigger("Active");var range = UnityEngine.Random.Range( 0, 101 );
        if( 101 >= range && range >= 50+p1 )
        {
            stone = stone + farm;
        }
        if( 50+p1 > range && range >= 25+(p1*0.4) )
        {
            stone2 = stone2 +  farm;;
        }
        if( 25+(p1*0.4)> range && range >=10*(p1*0.1) ) {
            stone3 = stone3+ farm;
            // ДобавитьПредметВСумку( предмет #2 );
        }
        if( 10+(p1*0.1) > range ) {
            stone4 = stone4 + farm;
            // ДобавитьПредметВСумку( предмет #3 );
        }
    }
    public void Fun(int noom)
    {
        if (noom == 1 && coin>=problem1)
        {
            
            coin -= problem1;
            farm += 1;
            problem1 += 2;
        }

        if (noom == 2 && coin >= problem2)
        {
            
            BUR.SetActive(true);
            coin -= problem2;
            speed = speed + 1;
            problem2 *= 2;
        }

        if (noom == 3 && coin >= problem3)
        {
            coin -= problem3;
            farm = farm * 2;
            problem3 *= 3;
        }

        if (noom == 4 )
        {
            if (plant_has_grown == 2)
            {
                Plant.SetActive(false);
                coin += 50;
                plant_has_grown = 0;
            }
            else
            {
                if (dd1 == 0)
                {
                    Farm.SetActive(true);
                    dd1 = 1;
                }
                else
                {
                    Farm.SetActive(false);
                    dd1 = 0;
                }
            }
        }

        if (noom == 5)
        {
            Farm.SetActive(false);
            dd1 = 0;
        }

        if (noom == 6 && stone >= 50)
        {
            curr_time_plant = 31f;

            Farm.SetActive(false);
            dd1 = 0;
            if (plant_has_grown == 0)
            {
                stone -= 50;
                Plant.SetActive(true);
                plant_has_grown = 1;
                TextObject4.SetActive(true);
            }
            dd2 = 0;
        }
        if (noom == 7 && stone2 >= 30)
        {
            curr_time_plant = 120f;

            Farm.SetActive(false);
            dd1 = 0;
            if (plant_has_grown == 0)
            {
                stone2 -= 30;
                Plant2.SetActive(true);
                plant_has_grown = 1;
                TextObject4.SetActive(true);
            }
            dd2 = 0;
        }
        if (noom == 8 && coin >= problem4)
        {
            
            Table.SetActive(true);
            coin -= problem4;
            p1 += 10;
            problem4 *= 2;
        }
    }

    void Update()
    {
        
            textComponent.text = coin.ToString();
            textComponent01.text = stone.ToString(); 
            textComponent02.text = stone2.ToString();
            textComponent03.text = stone3.ToString();
            textComponent04.text = stone4.ToString();
            
            
            textComponent1.text = problem1.ToString();
            textComponent2.text = problem2.ToString();
            textComponent3.text = problem3.ToString();


            curr_time -= Time.deltaTime;
            curr_time_plant -= Time.deltaTime;/* Вычитаем из 10 время кадра (оно в миллисекундах) */ 
            
            if(curr_time <= 0)
            {
                coin += (int)(speed); 
                curr_time = repeat_time * 1f;
                textComponent4.text =
                    ((int)curr_time_plant).ToString(); /* запускает опять таймер на 10,чтобы повторялось бесконечно */
            }
            
            if(curr_time_plant <= 0 && plant_has_grown == 1)
            {
                TextObject4.SetActive(false);
                plant_has_grown = 2; /* запускает опять таймер на 10,чтобы повторялось бесконечно */
            }
    }
}
