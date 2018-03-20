using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour {

    public int indRow;  //Row
    public int indCol;
    public Sprite Big;
    public Sprite StartSp;

    public int Number
    {
        get
        {
            return number;
        }
        set
        {
            number = value;
            if (number == 0)
                SetEmpty();
            else if (0 < number && number < 16)
            {
                TileImage.sprite = StartSp;
                ApplyStyle(number);
                SetVisible();
            }
            else if (number >= 16)
            {
                TileImage.sprite = Big;
                ApplyStyle(number);
                SetVisible();
            }
        }
    }

    public string Color
    {
        get
        {
            return TileImage.color.ToString();
        }
    }


    private int number;

    private Text TileText;
    private Image TileImage;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        TileText = GetComponentInChildren<Text>();             // What is TileText and TileImage
        TileImage = transform.Find("NumberedCell").GetComponent<Image>();
    }

    public void PlayMergedAnimation()
    {
        anim.SetTrigger("Merge");
    }

    public void PlayAppearAnimation()
    {
        anim.SetTrigger("Appear");
    }

    public void PlayBigAnimation()
    {
        anim.SetTrigger("Big");
    }


    void ApplyStyleFromHolder(int index)
    {
        TileText.text = TileStyleHolder.Instance.TileStyles[index].Number.ToString();    //call an enemy 
        TileText.color = TileStyleHolder.Instance.TileStyles[index].TextColor;
        TileImage.color = TileStyleHolder.Instance.TileStyles[index].TileColor;
    }

    void ApplyStyle(int num)
    {
        switch (num)
        {
            case 1:
                ApplyStyleFromHolder(0);
                break;
            case 2:
                ApplyStyleFromHolder(1);
                break;
            case 3:
                ApplyStyleFromHolder(2);
                break;
            case 4:
                ApplyStyleFromHolder(3);
                break;
            case 5:
                ApplyStyleFromHolder(4);
                break;
            case 6:
                ApplyStyleFromHolder(5);
                break;
            case 7:
                ApplyStyleFromHolder(6);
                break;
            case 8:
                ApplyStyleFromHolder(7);
                break;
            case 9:
                ApplyStyleFromHolder(8);
                break;
            case 10:
                ApplyStyleFromHolder(9);
                break;
            case 11:
                ApplyStyleFromHolder(10);
                break;
            case 12:
                ApplyStyleFromHolder(11);
                break;
            case 13:
                ApplyStyleFromHolder(12);
                break;
            case 14:
                ApplyStyleFromHolder(13);
                break;
            case 15:
                ApplyStyleFromHolder(14);
                break;
            case 16:
                ApplyStyleFromHolder(15);
                break;
            default:
                Debug.LogError("Check the number that you pass to ApplyStyle !! L");
                break;
        }
    }

    // Use this for initialization

    private void SetVisible()
    {
        TileImage.enabled = true;
        TileText.enabled = true;
    }

    private void SetEmpty()
    {
        TileImage.enabled = false;
        TileText.enabled = false;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}