using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
public class BookFish_UI : MonoBehaviour
{
    RectTransform rectContent;
    GameObject content;
    Sprite[] _spriteRenderer;
    GameObject NewBtn;

    List<Button> btnObjList = new List<Button>();
    List<TableFish.Fish> IDdataList = new List<TableFish.Fish>();

    public Image FishImage;
    public Button MainBtn;
    public TextMeshProUGUI TextName;
    public TextMeshProUGUI TextSeason;
    public TextMeshProUGUI TextTime;
    public TextMeshProUGUI TextExplain;

    void Awake()
    {
        SaveData.instance.LoadCatchFish();

        for (int i = 0; i < TableFish.DataList.Count; i++)
        {
            TableFish.DataList[i].fishCatchBook = GameManager.BookFish.PlayerCatchFish[i];
        }

        content = GameObject.Find("Content");
        rectContent =  content.GetComponent<RectTransform>();
        NewBtn = Resources.Load<GameObject>("Prefab/Button");
        _spriteRenderer = ResourceManager.Instance.fishSprite;

        MainBtn.onClick.AddListener(() => TrunScene.Instance.SceneChange("Main"));
        MainBtn.onClick.AddListener(() => TrunScene.Instance.IsLoadGame(true));

        CreateFishButton();
        SetFishButton("ID");
        UIFishButton(0);
    }

    /// <summary> ����� ���� ��ư ���� </summary>
    public void CreateFishButton()
    {
        int btnCount = TableFish.DataList.Count; // ����� ����

        for (int i = 0; i < btnCount; i++)
        {
            GameObject myInstance = GameObject.Instantiate(NewBtn, content.transform);
            myInstance.name = "fishBtn_" + i;
            myInstance.SetActive(true);
            btnObjList.Add(myInstance.GetComponent<Button>());
        }

        int btnHeight = (btnCount / 4) * 100;
        int btnHeight2 = (btnCount / 4) * 10;

        rectContent.sizeDelta = new Vector2(0, btnHeight + btnHeight2);
    }

    /// <summary> ����� ���� ��ư ���� </summary>>
    public void SetFishButton(string type)
    {
        for(int i = 0; i < btnObjList.Count; i++)
        {
            btnObjList[i].onClick.RemoveAllListeners();
        }

        int btnCount = TableFish.DataList.Count; // ����� ����

        // ����Ʈ ����
        ListUpdate(type);

        for (int i = 0; i < btnCount; i++)
        {
            // ��ư �̹��� ����
            for (int j = 0; j < _spriteRenderer.Length; j++)
            {

                if (IDdataList[i].fishImage == _spriteRenderer[j].name)
                {
                    btnObjList[i].image.sprite =  _spriteRenderer[j];
                    Color color = btnObjList[i].image.color;
                    if (!IDdataList[i].fishCatchBook)
                    {
                        color = new Color(0f, 0f, 0f, 1f);
                        btnObjList[i].image.color = color;
                    }
                    else
                    {
                        color = new Color(1f, 1f, 1f, 1f);
                        btnObjList[i].image.color = color;
                    }

                    break;
                }
            }

            int temp = i;

            btnObjList[i].onClick.AddListener(() => UIFishButton(temp));
        }
    }

    /// <summary> ��ư ����Ʈ ���� </summary>
    void ListUpdate(string type)
    {
        IDdataList.Clear();

        switch (type)
        {
            case "ID": // ���� ������
                IDdataList = TableFish.DataList.OrderByDescending(x => x.fishCatchBook).ToList<TableFish.Fish>();
                break;
            case "RARE": // ���
                IDdataList = TableFish.DataList.OrderBy(x => x.fishRare).ToList<TableFish.Fish>();
                break;
            case "SEASON": // ������
                IDdataList = TableFish.DataList.OrderBy(x => x.fishSeason).ToList<TableFish.Fish>();
                break;
        }
    }

    /// <summary> ����� ��ư Ŭ�� �� �� ���� UI </summary>>
    public void UIFishButton(int i)
    {
        FishImage.sprite = btnObjList[i].image.sprite;
        Color color = FishImage.color;
        if (!IDdataList[i].fishCatchBook)
        {
            color = new Color(0f, 0f, 0f, 1f);
            TextName.text = "???";
            TextSeason.text = "";
            TextTime.text = "";
            TextExplain.text = "";
            FishImage.color = color;
        }
        else
        {
            color = new Color(1f, 1f, 1f, 1f);
            TextName.text = IDdataList[i].fishName;
            switch (IDdataList[i].fishSeason)
            {
                case FishSeason.Spring: TextSeason.text = "�� �����";   break;
                case FishSeason.Summer: TextSeason.text = "���� �����"; break;
                case FishSeason.Fall:   TextSeason.text = "���� �����"; break;
                case FishSeason.Winter: TextSeason.text = "�ܿ� �����"; break;
            }
            if (IDdataList[i].fishDay == 1)
                TextTime.text = "��ħ";
            else
                TextTime.text = "��";
            TextExplain.text = IDdataList[i].fishExplain;
            FishImage.color = color;
        }
    }

}
