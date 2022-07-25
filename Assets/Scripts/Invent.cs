using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Invent: MonoBehaviour
{
    public GameObject[] plants;
    
    Animator anim;
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
    TextMeshProUGUI textComponent;

    public GameObject pos;


    public GameObject TextObject1;
    TextMeshProUGUI textComponent1;
    public GameObject TextObject2;
    TextMeshProUGUI textComponent2;
    public GameObject TextObject3;
    TextMeshProUGUI textComponent3;
    public GameObject TextTableUpdate;
    TextMeshProUGUI textTableUpdate;
    public GameObject TextObject4;
    TextMeshProUGUI textComponent4;
    public GameObject TextObject01;
    TextMeshProUGUI textComponent01;
    public GameObject TextObject02;
    TextMeshProUGUI textComponent02;
    public GameObject TextObject03;
    TextMeshProUGUI textComponent03;
    public GameObject TextObject04;
    TextMeshProUGUI textComponent04;


    public static float speed;
    public GameObject BUR;
    public GameObject Table;
    public GameObject Farm;


    public static int problem1;
    public static int problem2;
    public static int problem3;
    public static int problem4;
    public static int p1;
    public static int p2;

    public GameObject plant;
    public Plant plantData;
    public Animator plantAnim;

    public GameObject invent;
    
    [SerializeField] private float _persentShowAds;
    

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
        textComponent = TextObject.GetComponent<TextMeshProUGUI>();
        


        textComponent1 = TextObject1.GetComponent<TextMeshProUGUI>();
        textComponent2 = TextObject2.GetComponent<TextMeshProUGUI>();
        textComponent3 = TextObject3.GetComponent<TextMeshProUGUI>();
        textTableUpdate = TextTableUpdate.GetComponent<TextMeshProUGUI>();
        textComponent01 = TextObject01.GetComponent<TextMeshProUGUI>();
        textComponent02 = TextObject02.GetComponent<TextMeshProUGUI>();
        textComponent03 = TextObject03.GetComponent<TextMeshProUGUI>();
        textComponent04 = TextObject04.GetComponent<TextMeshProUGUI>();
        textComponent4 = TextObject4.GetComponent<TextMeshProUGUI>();
        
        textComponent1.text = problem1.ToString();
        textComponent2.text = problem2.ToString();
        textComponent3.text = problem3.ToString();
        textTableUpdate.text = problem4.ToString();

        InterstitialAd.S.LoadAd();
        //RewardedAds.S.LoadAd();
    }

    public void OpenInvent()
    {
        invent.SetActive(!invent.active);
    }
    
    
    public void ClickFun()
    {
        anim.SetTrigger("Active");
        var range = UnityEngine.Random.Range(0, 101);

        if (101 >= range && range >= 50 + p1)
        {
            stone += farm;
        }

        if (50 + p1 > range && range >= 25 + (p1 * 0.4))
        {
            stone2 += farm;
            ;
        }

        if (25 + (p1 * 0.4) > range && range >= 10 * (p1 * 0.1))
        {
            stone3 += farm;
            // ДобавитьПредметВСумку( предмет #2 );
        }

        if (10 + (p1 * 0.1) > range)
        {
            stone4 += farm;
            // ДобавитьПредметВСумку( предмет #3 );
        }
        float tempPersent = Random.Range(0f, 1f);

        if (tempPersent < _persentShowAds)
            InterstitialAd.S.ShowAd();
    }

    public void ImproveTheShovel()
    {
        if (coin >= problem1)
        {
            coin -= problem1;
            farm += 1;
            problem1 += 2;
            textComponent1.text = problem1.ToString();
        }
    }


    public void ImproveTheDrill()
    {
        if (coin >= problem2)
        {
            BUR.SetActive(true);
            coin -= problem2;
            speed += 1;
            problem2 *= 2;
            textComponent2.text = problem2.ToString();
        }
    }

    public void ImproveTheGoldenShovel()
    {
        if (coin >= problem3)
        {
            coin -= problem3;
            farm *= 2;
            problem3 *= 3;
            textComponent3.text = problem3.ToString();
        }
    }

    public void ClaimAPlant()
    {
        if (plant_has_grown == 2)
        {
            coin += plantData.moneyBrings;
            Destroy(plant);
            plant_has_grown = 0;
        }
        else
        {
            Farm.SetActive(!Farm.active);
        }
    }

    public void PlantAPlant(int plantID)
    {
        plantData = plants[plantID].GetComponent<Plant>();
        bool haveEnoughMoney = false;
        switch (plantData.type)
        {
            case CostType.Stone1:
                if (stone >= plantData.cost && plant_has_grown == 0)
                {
                    stone -= plantData.cost;
                    haveEnoughMoney = true;
                }
                break;
            case CostType.Stone2:
                if (stone2 >= plantData.cost && plant_has_grown == 0)
                {
                    stone2 -= plantData.cost;
                    haveEnoughMoney = true;
                }
                break;
            case CostType.Stone3:
                if (stone3 >= plantData.cost && plant_has_grown == 0)
                {
                    stone3 -= plantData.cost;
                    haveEnoughMoney = true;
                }
                break;
            case CostType.Stone4:
                if (stone4 >= plantData.cost && plant_has_grown == 0)
                {
                    stone4 -= plantData.cost;
                    haveEnoughMoney = true;
                }
                break;
        }

        if (haveEnoughMoney)
        {
            Farm.SetActive(false);
            TextObject4.SetActive(true);
            plant =  Instantiate(plants[plantID], pos.transform.position, Quaternion.identity) as GameObject;
            plantAnim = plant.GetComponent<Animator>();
            plantAnim.Play("Plant", -1, 0f);
            plant.transform.SetParent(pos.transform);
            plant.transform.localScale = new Vector3(1f, 1f, 1f);
            plant.GetComponent<Animator>().keepAnimatorControllerStateOnDisable = true;
            plant_has_grown = 1;
            curr_time_plant = plantData.timeToGrow;
        }
        
    }

    public void ImproveTheTable()
    {
        if (coin >= problem4)
        {
            Table.SetActive(true);
            coin -= problem4;
            p1 += 10;
            problem4 *= 2;
            textTableUpdate.text = problem4.ToString();
        }
    }

    public void GetGoldAfterReward(int gold)
    {
        coin += gold;
    }
    
    void Update()
    {
        textComponent.text = coin.ToString();
        textComponent01.text = stone.ToString();
        textComponent02.text = stone2.ToString();
        textComponent03.text = stone3.ToString();
        textComponent04.text = stone4.ToString();
        

        curr_time -= Time.deltaTime;
        curr_time_plant -= Time.deltaTime; /* Вычитаем из 10 время кадра (оно в миллисекундах) */

        if (curr_time <= 0)
        {
            coin += (int)(speed);
            curr_time = repeat_time * 1f;
            textComponent4.text =
                ((int)curr_time_plant).ToString(); /* запускает опять таймер на 10,чтобы повторялось бесконечно */
        }

        if (curr_time_plant <= 0 && plant_has_grown == 1)
        {
            TextObject4.SetActive(false);
            plant_has_grown = 2; /* запускает опять таймер на 10,чтобы повторялось бесконечно */
        }
    }
}