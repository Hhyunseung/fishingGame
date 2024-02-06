using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Shop_Shopping : Shop_Ui
{
    public static Shop_Shopping Instance;

    int shopId;

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance.gameObject);

        ResetShop();
        QuestOpen();
        BaitButton();
        if (GameManager.Shop.ShopRod == 50006)
            rodBtn.interactable = false;
        if (GameManager.Shop.ShopBobber == 51006)
            bobberBtn.interactable = false;
        if (GameManager.Shop.ShopBait == 52006)
            baitBtn.interactable = false;
    }

    /// <summary> 상점 아이템 구입 </summary>
    public void BuyShop(Button button)
    {
        if (button == rodBtn)
            shopId = GameManager.Shop.ShopRod;
        else if (button == bobberBtn)
            shopId = GameManager.Shop.ShopBobber;
        else if (button == baitBtn)
            shopId = GameManager.Shop.ShopBait;

        if (GameManager.Player.Gold < TableShop.ShopData[shopId].price)
        {
            DialogManager.Instance.ShopDialog("돈이 부족하다냥...");
        }
        else
        {
            GameManager.Player.Gold = GameManager.Player.Gold - TableShop.ShopData[shopId].price;

            if (shopId % 10 != 6)
            {
                switch (shopId / 1000)
                {
                    case 50: // Rod
                        GameManager.Shop.ShopRod += 1;
                        GameManager.Player.PlayerRod += 1;
                        break;
                    case 51: // Bobber
                        GameManager.Shop.ShopBobber += 1;
                        GameManager.Player.PlayerBobber += 1;
                        break;
                    case 52: // Bait
                        GameManager.Shop.ShopBait += 1;
                        GameManager.Player.PlayerBait += 1;
                        break;
                }
                shopId += 1;
            }

            BaitButton();

            if (shopId % 10 == 6)
                // 상점 아이템을 다 구매했을 경우 이벤트
                button.interactable = false;

            QuestOpen();
            ChangePrice();
        }
    }

    /// <summary> Rod 와 Bobber 강화가 모두 끝날 경우 Bait 구입 활성화 </summary>
    void BaitButton()
    {
        if (GameManager.Player.PlayerRod == 90006 && GameManager.Player.PlayerBobber == 91006)
            baitBtn.interactable = true;
    }
}
