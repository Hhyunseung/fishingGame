using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public static bool BottonDown;

    public void OpenPanel(GameObject obj)
    {
        obj.gameObject.SetActive(true);
    }
    public void ClosePanel(GameObject obj)
    {
        obj.gameObject.SetActive(false);
    }
    public void SceneChagne(string name)
    {
        SaveData.instance.SaveJsonData();

        TrunScene.Instance.SceneChange(name);
    }
    public void SaveJsonData()
    {
        SaveData.instance.SaveJsonData();
    }
}
