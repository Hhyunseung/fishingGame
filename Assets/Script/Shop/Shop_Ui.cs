using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class Shop_Ui : MonoBehaviour
{
    public GameObject[] QuestPanel;
    public GameObject ShopPanel;

    public Image rodImage;
    public Image bobberImage;
    public Image baitImage;

    public TextMeshProUGUI rodText;
    public TextMeshProUGUI bobberText;
    public TextMeshProUGUI baitText;

    public Button rodBtn;
    public Button bobberBtn;
    public Button baitBtn;

    /// <summary> ����Ʈ ���� </summary>
    public void QuestOpen()
    {
        if (GameManager.Shop.ShopRod == 50006)
            QuestPanel[0].gameObject.SetActive(true);
        if (GameManager.Shop.ShopBobber == 51006)
            QuestPanel[1].gameObject.SetActive(true);
        if (GameManager.Shop.ShopBait == 52006)
            QuestPanel[2].gameObject.SetActive(true);
    }

    /// <summary> ���� UI ���� </summary>
    public void ChangePrice()
    {
        // ����
        rodText.text = TableShop.ShopData[GameManager.Shop.ShopRod].price.ToString();
        bobberText.text = TableShop.ShopData[GameManager.Shop.ShopBobber].price.ToString();
        baitText.text = TableShop.ShopData[GameManager.Shop.ShopBait].price.ToString();

        if (GameManager.Shop.ShopRod == 50006)
            rodText.text = "MAX";
        if (GameManager.Shop.ShopBobber == 51006)
            bobberText.text = "MAX";
        if (GameManager.Shop.ShopBait == 52006)
            baitText.text = "MAX";

        // �̹���
        rodImage.sprite = ResourceManager.Instance.shopRodSprite[TableShop.ShopData[GameManager.Shop.ShopRod].itemImage];
        bobberImage.sprite = ResourceManager.Instance.shopBobberSprite[TableShop.ShopData[GameManager.Shop.ShopBobber].itemImage];
        baitImage.sprite = ResourceManager.Instance.shopBaitSprite[TableShop.ShopData[GameManager.Shop.ShopBait].itemImage];
    }

    public void ResetShop()
    {
        ShopPanel.SetActive(false);
        ChangePrice();

        for(int i = 0; i < 3; i++)
        {
            QuestPanel[i].SetActive(false);
        }
        rodBtn.interactable = true;
        bobberBtn.interactable = true;
        baitBtn.interactable = false;
    }
}
