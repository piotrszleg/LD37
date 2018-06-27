using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour {

    InGameShop shop;
    public Text nameText;
    public Text buttonText;
    public Button button;
    public bool unlocked = false;
    public int price = 100;
    public bool equiped = false;
    public int index=0;

    // Use this for initialization
    void Start () {
        shop = GameObject.FindObjectOfType<InGameShop>();
        button.onClick.AddListener(ButtonHandler);
    }

   void ButtonHandler()
    {
        if (unlocked && !equiped)
        {
            equiped = true;
            shop.items[index].equiped = true;
            shop.Equip(transform.GetSiblingIndex());
        }
        else
        {
            equiped = false;
            shop.items[index].equiped = false;
        }
        if (!unlocked && price <= shop.money)
        {
            shop.money -= price;
            unlocked = true;
            shop.items[index].unlocked = true;
        }
        UpdateButton();
    }

    public void UpdateButton()
    {
        if (!unlocked)
            buttonText.text = price.ToString();
        else if (!equiped)
            buttonText.text = "Equip";
        else
        {
            buttonText.text = "Equiped";
            
        }
    }
	
	// Update is called once per frame
	void Update () {
        if ((price > shop.money&&!unlocked) || equiped)
        {
            button.interactable = false;
        }else
        {
            button.interactable = true;
        }
    }
}
