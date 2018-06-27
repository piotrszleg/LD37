using UnityEngine;
using System.Collections;

public class InGameShop : MonoBehaviour, SaveSystem.Savable {

    [System.Serializable]
    public class Item
    {
        public string name;
        public bool unlocked = false;
        public int price = 100;
        public bool equiped = false;
    }
    [Savable]
    public Item[] items;
    public ShopItem itemUIPrefab;
    public RectTransform container;
    public int money = 150;
    int selectedItem;
    public UnityEngine.UI.Text moneyText;
    ShopItem[] itemUIs;

    // Use this for initialization
    void Start () {
        if (itemUIs == null) CreateItemUIs();
    }

    public void Equip(int index)
    {
        ShopItem[] itemsUI = transform.parent.GetComponentsInChildren<ShopItem>();
        for (int i = 0; i < itemsUI.Length; i++)
        {
            if (i != index)
            {
                itemsUI[i].equiped = false;
                items[i].equiped = false;
                itemsUI[i].UpdateButton();
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        moneyText.text = money.ToString();
    }
    void CreateItemUIs()
    {
        itemUIs = new ShopItem[items.Length];
        for (int i = 0; i < items.Length; i++)
        {
            ShopItem itemUI = Instantiate(itemUIPrefab);
            itemUI.nameText.text = items[i].name;
            itemUI.price = items[i].price;
            itemUI.unlocked = items[i].unlocked;
            itemUI.equiped = items[i].equiped;
            itemUI.UpdateButton();
            itemUI.transform.SetParent(container);
            itemUI.index = i;
            if (itemUI.price < 0 && !itemUI.unlocked)
                itemUI.gameObject.SetActive(false);
            itemUIs[i] = itemUI;
        }
    }
    public void GetValues(ref SaveSystem.Data data)
    {
        data.items = items;
        data.money = money;
    }
    public void SetValues(SaveSystem.Data data)
    {
        if (itemUIs==null) CreateItemUIs();
        //if(data.items!=null)items = data.items;
        if (data.money>=0)money = data.money;
        for (int i = 0; i < items.Length; i++)
        {
            ShopItem itemUI = itemUIs[i];
            itemUI.unlocked = items[i].unlocked = data.items[i].unlocked;
            itemUI.equiped = items[i].equiped = data.items[i].equiped;
            itemUI.UpdateButton();
        }
    }
}
