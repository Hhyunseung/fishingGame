using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish
{
    public int FishId { get { return _fishId; } set { _fishId = value; } }
    public string FishName { get { return _fishName; } set { _fishName = value; } }
    public string FishImage { get { return _fishImage; } set { _fishImage = value; } }
    public FishRare FishRare { get { return _fishRare; } set { _fishRare = value; } }
    public int FishGold { get { return _fishGold; } set { _fishGold = value; } }
    public FishSeason FishSeason { get { return _fishSeason; } set { _fishSeason = value; } }
    public int FishDay { get { return _fishDay; } set { _fishDay = value; } }
    public bool FishCatchBook { get { return _fishCatchBook; } set { _fishCatchBook = value; } }

    private int _fishId;
    private string _fishName;
    private string _fishImage;
    private FishRare _fishRare;
    private int _fishGold;
    private FishSeason _fishSeason;
    private int _fishDay;
    private bool _fishCatchBook;

    /// <summary> 货肺款 拱绊扁 积己 </summary>
    public Fish CreatedFish(int key)
    {
        TableFish.Fish data = TableFish.FishData[key];
        Fish fish = new Fish();
        fish._fishId = data.fishId;
        fish._fishName = data.fishName;
        fish._fishImage = data.fishImage;
        fish._fishRare = data.fishRare;
        fish._fishGold = data.fishGold;
        fish._fishSeason = data.fishSeason;
        fish._fishDay = data.fishDay;
        fish._fishCatchBook = data.fishCatchBook;
        return fish;
    }
}

