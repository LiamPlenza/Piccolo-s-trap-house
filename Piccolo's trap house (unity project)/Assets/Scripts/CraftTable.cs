using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftTable : Interactable
{
    public List<Item> itemsList;

    private int itemsInTable = 0;

    public GameObject mace;
    public GameObject maceHandle;
    public GameObject finalMace;
    public GameObject tuerca;

    public Item mazeItem;

    private GameObject maceInTable;
    private GameObject maceHandleInTable;
    private GameObject finalMaceInTable;
    private GameObject tuercaInTable;

    //public GameObject textCrafTable;

    public override void Interact()
    {
        base.Interact();

        Craft();
    }
    public void Craft()
    {
        //textCrafTable.SetActive(false);
        itemsList = player.GetComponent<Inventory>().items;
        foreach (var item in itemsList)
        {
            if (item.name == "Mango")
            {
                itemsInTable += 1;
                maceHandleInTable = Instantiate(maceHandle);
                maceHandleInTable.transform.position = new Vector3(132.559998f, 7.08775806f, 136.070007f);
                maceHandleInTable.transform.rotation = Quaternion.Euler(0.000160509444f, 60.0000572f, 270);
                maceHandleInTable.transform.localScale = new Vector3(1, 1, 1);
                player.GetComponent<Inventory>().Remove(item);
            }
            else if (item.name == "Punta de Mazo")
            {
                itemsInTable += 1;
                maceInTable = Instantiate(mace);
                maceInTable.transform.position = new Vector3(134.009995f, 6.19000006f, 136.089996f);
                maceInTable.transform.rotation = Quaternion.Euler(270, 315.000092f, 0);
                maceInTable.transform.localScale = new Vector3(1.47961938f, 1.47961938f, 1.47961938f);
                player.GetComponent<Inventory>().Remove(item);
            }
            else if (item.name == "Tuerca")
            {
                itemsInTable += 1;
                tuercaInTable = Instantiate(tuerca);
                tuercaInTable.transform.position = new Vector3(133.432999f, 7.03682995f, 135.770996f);
                tuercaInTable.transform.rotation = Quaternion.Euler(270.019775f, 0, 0);
                tuercaInTable.transform.localScale = new Vector3(32.6539116f, 32.6539116f, 32.6539116f);
                player.GetComponent<Inventory>().Remove(item);
            }
            //else
            //{
            //    textCrafTable.SetActive(true);
            //}
        }
        if (itemsInTable == 3)
        {
            Destroy(tuercaInTable);
            Destroy(maceInTable);
            Destroy(maceHandleInTable);
            finalMaceInTable = Instantiate(finalMace);
            finalMaceInTable.transform.position = new Vector3(133.271912f, 7.15700006f, 135.81517f);
            finalMaceInTable.transform.rotation = Quaternion.Euler(-5.46415067f, 180, 176.073318f);
            finalMaceInTable.transform.localScale = new Vector3(2.74106288f, 2.74106288f, 2.74106288f);
            finalMaceInTable.AddComponent<ItemPickup>();
            finalMaceInTable.GetComponent<ItemPickup>().item = mazeItem;
            this.GetComponent<CraftTable>().enabled = false;
            itemsInTable = 0;
        }
    }
}
