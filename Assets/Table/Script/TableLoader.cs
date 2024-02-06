using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableLoader : MonoBehaviour
{
    public static TableLoader Instance;

    List<TableBase> _allTableList = new List<TableBase>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        AllTableLoad();
    }

    public List<TableBase> AllTableList
    {
        get
        {
            return _allTableList;
        }
    }
    public TableLoader() // »ý¼ºÀÚ
    {
        _allTableList.Add(new Table_Fish());
        _allTableList.Add(new Table_Bobber());
        _allTableList.Add(new Table_Rod());
        _allTableList.Add(new Table_Bait());
        _allTableList.Add(new Table_Shop());
        _allTableList.Add(new Table_Quest());
    }

    public void AllTableLoad()
    {
        for (int i = 0; i < AllTableList.Count; i++)
        {
            AllTableList[i].DataLoad();
        }
    }
}
