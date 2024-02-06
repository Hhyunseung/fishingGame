using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish_Event : MonoBehaviour
{
    public Animator ani;
    public Image exclamation;
    public Slider timer; // Event Timer
    public Button epicButton; // Epic ����� �̺�Ʈ ��ư
    public Button bossButton; // Boss ����� �̺�Ʈ ��ư
    public Scrollbar bossFish; // Boss ����� �̺�Ʈ ��
    public Scrollbar bossFishValue; // Boss ����� �̺�Ʈ ��

    [HideInInspector] public bool CatchFish;
    [HideInInspector] public bool EventFishing; // Event Ȱ��ȭ


    int epicBtnValue;
    float eventdelay;
    int bossValue;
    float randomBossTime;
    bool ButtonDown;
    float totalTime; // �̺�Ʈ �ð�

    private void Awake()
    {
        timer.value = 0.0f;
        totalTime = 4.0f;

        epicBtnValue = 0;
        eventdelay = 0.0f;
        EventFishing = false;

        bossValue = Random.Range(1, 5);
        randomBossTime = Random.Range(0.3f, 0.7f);
    }

    public void SetEvent()
    {
        epicBtnValue = 0;
        eventdelay = 0.0f;

        if (Fish_Fishing.fish.FishRare == FishRare.Epic)
            timer.value = 0.0f;
        else
            timer.value = 0.5f;
    }

    /// <summary> ���� �̺�Ʈ </summary>
    public void EventFish()
    {
        if (Fish_Fishing.fish.FishRare == FishRare.Epic) // Epic �����
        {
            EventUI(true, FishRare.Epic);

            eventdelay += Time.deltaTime;
            timer.value = eventdelay / totalTime;

            if (timer.value < 0.99f)
            {
                if (epicBtnValue == 10) // ����
                {
                    EventUI(false, FishRare.Epic);
                    ani.Play("PlayerFishing");
                    CatchFish = true;

                    // �̺�Ʈ ����
                    EventFishing = false;
                    StopCoroutine("EventCoroutine");
                }
            }
            else if (timer.value >= 0.99f) // ����
            {
                EventUI(false, FishRare.Epic);

                // �̺�Ʈ ����
                EventFishing = false;
                StopCoroutine("EventCoroutine");
            }
        }
        else // Boss �����
        {
            EventUI(true, FishRare.Boss);

            bossFish.value = Mathf.Clamp(bossFish.value, 0.0f, 1.0f);
            bossFishValue.value = Mathf.Clamp(bossFishValue.value, 0.0f, 1.0f);

            // ���� ����
            if (timer.value > 0.01f && timer.value < 0.99f)
            {
                BossValue();

                eventdelay += Time.deltaTime;
                if (eventdelay >= randomBossTime || bossFish.value <= 0.0f || bossFish.value >= 1.0f)
                {
                    randomBossTime = Random.Range(0.4f, 0.7f);
                    bossValue = Random.Range(1, 3);
                    eventdelay = 0.0f;
                }

                switch (bossValue)
                {
                    case 1:
                        bossFish.value += (Time.deltaTime * Random.Range(0.4f, 0.7f));
                        break;
                    case 2:
                        bossFish.value -= (Time.deltaTime * Random.Range(0.4f, 0.7f));
                        break;
                }
            }
            // ���� ����
            else if (timer.value >= 0.99f)
            {
                EventUI(false, FishRare.Boss);
                ani.Play("PlayerFishing");
                CatchFish = true;

                ButtonDown = false;
                bossFish.value = 0.5f;
                bossFishValue.value = 0.5f;

                // �̺�Ʈ ����
                EventFishing = false; 
                StopCoroutine("EventCoroutine");
            }
            // ���� ����
            else
            {
                EventUI(false, FishRare.Boss);

                ButtonDown = false;
                bossFish.value = 0.5f;
                bossFishValue.value = 0.5f;

                // �̺�Ʈ ����
                EventFishing = false;
                StopCoroutine("EventCoroutine");
            }
        }
    }

    public void ClickEpicButton()
    {
        epicBtnValue++;
    }

    /// <summary> ���� �̺�Ʈ �߻� �ڷ�ƾ </summary>
    IEnumerator EventCoroutine()
    {
        if (!timer.IsActive())
        {
            exclamation.gameObject.SetActive(true);
            ani.Play("PlayerIdle");
        }

        yield return new WaitForSeconds(1.0f);

        exclamation.gameObject.SetActive(false);
        ani.Play("PlayerEventFishing");

        EventFish();
    }

    /// <summary> �̺�Ʈ UI ���� </summary>
    public void EventUI(bool start, FishRare fishRare)
    {
        timer.gameObject.SetActive(start);

        if (fishRare == FishRare.Epic)
            epicButton.gameObject.SetActive(start);
        else
        {
            bossButton.gameObject.SetActive(start);
            bossFish.gameObject.SetActive(start);
            bossFishValue.gameObject.SetActive(start);
        }
    }

    /// <summary> �̴� ���� ��ġ ���� </summary>
    void BossValue()
    {
        if (ButtonDown)
            bossFishValue.value += 0.003f;
        else
            bossFishValue.value -= 0.003f;

        if (Fish_Trigger.TriggerBool)
            timer.value += Time.deltaTime * 0.15f;
        else
            timer.value -= Time.deltaTime * 0.15f;
    }

    /// <summary> ��ư Ŭ���� bool  </summary>
    public void PointerDown()
    {
        ButtonDown = true;
    }


    public void PointerUp()
    {
        ButtonDown = false;
    }
}
