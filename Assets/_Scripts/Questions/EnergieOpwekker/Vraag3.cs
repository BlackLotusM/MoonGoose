using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Vraag3 : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI[] txt_names;
    [SerializeField]
    public TextMeshProUGUI[] txt_senders;

    [SerializeField]
    private Sprite[] windEnergie, windInfo;
    [SerializeField]
    private String[] namesWind;
    [SerializeField]
    private String[] sendersWind;
    
    [Space]
    [SerializeField]
    private Sprite[] waterEnergie, waterInfo;
    [SerializeField]
    private String[] namesWater;
    [SerializeField]
    private String[] sendersWater;

    [Space]
    [SerializeField]
    private Sprite[] zonEnergie, zonInfo;
    [SerializeField]
    private String[] namesEnergie;
    [SerializeField]
    private String[] sendersEnergie;

    public bool opdrachtCheck;

    public Image targetImage;
    public Image uitlegTarget;
    public int correctBtn;

    public Button[] btn;
    public Button[] sendBtn;
    public Button butBtn;

    public AudioSource send;
    public AudioSource select;

    //used for randomize
    private List<int> intList;

    [SerializeField]
    public List<Collect> intPicState;
    public IEnumerator running;
    public float waitTime;

    public int activeInt = 0;

    public DialogTesting answer;
    public DialogTesting answerRedo;
    public int atempt = 0;

    public bool toetsActive;
    public GameObject questLeer;
    public GameObject questToets;
    public GameObject parent;

    public bool active = false;

    public void SetActive()
    {
        active = true;
    }

    [Serializable]
    public class Collect
    {
        public int picState = 0;
        public int btnInt;
        public List<Sprite> sprites = new List<Sprite>();
        public Sprite uitleg;
    }

    [Serializable]
    public class ButtonStats
    {
        public Button theBtn;
        public TextMeshProUGUI title;
        public TextMeshProUGUI sender;
    }

    private void Start()
    {
        running = updateNum();
        SetAnswer();
    }

    private void Update()
    {
        targetImage.sprite = intPicState[activeInt].sprites[intPicState[activeInt].picState];
        uitlegTarget.sprite = intPicState[activeInt].uitleg;
    }

    public IEnumerator updateNum()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            foreach (Collect item in intPicState)
            {
                item.picState += 1;
              
            }
            yield return new WaitForSeconds(waitTime);
            foreach (Collect item in intPicState)
            {
                item.picState -= 1;
            }
        }
    }

    public void SetAnswer()
    {
        StopCoroutine(running);
        intPicState = new List<Collect>();
        intList = new List<int>() { 0, 1, 2 };

        foreach (Button bt in btn)
        {
            bt.onClick.RemoveAllListeners();
        }

        foreach (Button bt in sendBtn)
        {
            bt.onClick.RemoveAllListeners();
        }

        for (int typeIndex = 0; typeIndex < btn.Length; typeIndex++)
        {
            int random = UnityEngine.Random.Range(0, intList.Count);
            int selected = intList[random];
            intList.Remove(selected);

            //Zon energie
            if (typeIndex == 0)
            {
                //Add listener to btn
                btn[selected].onClick.AddListener(delegate { ChangeInxdex(0); });
                sendBtn[selected].onClick.AddListener(delegate { CheckAnswer(1); });
                correctBtn = selected;

                //Gets random zon object
                int zonSelected = UnityEngine.Random.Range(0, zonEnergie.Length - 1);
                if (zonSelected % 2 != 0)
                    zonSelected += 1;

                //Sets temp object for IntPicState
                Collect temp = new Collect();
                temp.btnInt = selected;
                correctBtn = selected;
                temp.picState = 0;

                //Checks what one to pic
                if (zonSelected == 0)
                {
                    temp.uitleg = zonInfo[zonSelected];
                    txt_names[selected].text = namesEnergie[zonSelected];
                    txt_senders[selected].text = sendersEnergie[zonSelected];
                }
                else
                {
                    temp.uitleg = zonInfo[zonSelected - 1];
                    txt_names[selected].text = namesEnergie[zonSelected - 1];
                    txt_senders[selected].text = sendersEnergie[zonSelected - 1];
                }
                temp.sprites.Add(zonEnergie[zonSelected]);
                temp.sprites.Add(zonEnergie[zonSelected + 1]);

                intPicState.Insert(typeIndex, temp);
            }
            //water energie
            else if (typeIndex == 1)
            {
                //Add listener to btn
                btn[selected].onClick.AddListener(delegate { ChangeInxdex(1); });
                sendBtn[selected].onClick.AddListener(delegate { CheckAnswer(0); });

                //Gets random water object
                int waterSelected = UnityEngine.Random.Range(0, waterEnergie.Length - 1);
                if (waterSelected % 2 != 0)
                    waterSelected += 1;

                //Sets temp object for IntPicState
                Collect temp = new Collect();
                temp.btnInt = selected;
                correctBtn = selected;
                temp.picState = 0;

                //Checks what one to pic
                if (waterSelected == 0)
                {
                    temp.uitleg = waterInfo[waterSelected];
                    txt_names[selected].text = namesWater[waterSelected];
                    txt_senders[selected].text = sendersWater[waterSelected];
                }
                else
                {
                    temp.uitleg = waterInfo[waterSelected - 1];
                    txt_names[selected].text = namesWater[waterSelected - 1];
                    txt_senders[selected].text = sendersWater[waterSelected - 1];
                }
                temp.sprites.Add(waterEnergie[waterSelected]);
                temp.sprites.Add(waterEnergie[waterSelected + 1]);

                intPicState.Insert(typeIndex, temp);
            }
            //wind energie
            else if (typeIndex == 2)
            {
                //Add listener to btn
                btn[selected].onClick.AddListener(delegate { ChangeInxdex(2); });
                sendBtn[selected].onClick.AddListener(delegate { CheckAnswer(0); });

                //Gets random water object
                int windSelected = UnityEngine.Random.Range(0, windEnergie.Length - 1);
                if (windSelected % 2 != 0)
                    windSelected += 1;

                //Sets temp object for IntPicState
                Collect temp = new Collect();
                temp.btnInt = selected;
                correctBtn = selected;
                temp.picState = 0;

                //Checks what one to pic
                if (windSelected == 0)
                {
                    temp.uitleg = windInfo[windSelected];
                    txt_names[selected].text = namesWind[windSelected];
                    txt_senders[selected].text = sendersWind[windSelected];
                }
                else
                {
                    temp.uitleg = windInfo[windSelected - 1];
                    txt_names[selected].text = namesWind[windSelected - 1];
                    txt_senders[selected].text = sendersWind[windSelected - 1];
                }
                temp.sprites.Add(windEnergie[windSelected]);
                temp.sprites.Add(windEnergie[windSelected + 1]);

                intPicState.Insert(typeIndex, temp);
            }
        }
        running = updateNum();
        StartCoroutine(running);
    }

    public void ChangeInxdex(int index)
    {
        if (!active)
            return;
        butBtn.onClick.RemoveAllListeners();
        butBtn.onClick.AddListener(delegate { CheckAnswer(index); });
        select.PlayOneShot(select.clip);
        uitlegTarget.sprite = intPicState[index].uitleg;
        targetImage.gameObject.SetActive(true);
        uitlegTarget.gameObject.SetActive(true);
        activeInt = index;
    }

    public void CheckAnswer(int value)
    {
        if (!active)
            return;
        send.PlayOneShot(send.clip);
        atempt++;
        questLeer.transform.parent = parent.transform;
        answer.dm.StopCor();

        if (atempt == 1)
        {
            opdrachtCheck = true;
            answer.SetAndStart();
        }
        else
        {
            answerRedo.dm.panel.SetActive(false);
            opdrachtCheck = false;
            answerRedo.currentConvoIndex = 0;
            answerRedo.currentSentenceIndex = -1;
            answerRedo.active = true;
            answerRedo.SetAndStart();
        }
    }
}
