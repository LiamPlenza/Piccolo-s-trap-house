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
                maceHandleInTable.transform.position = new Vector3(120.059998f, 1.66999996f, 82.3899994f);
                maceHandleInTable.transform.rotation = Quaternion.Euler(359.357239f, 251.948883f, 87.0570908f);
                maceHandleInTable.transform.localScale = new Vector3(1, 1, 1);
                player.GetComponent<Inventory>().Remove(item);
            }
            else if (item.name == "Punta de Mazo")
            {
                itemsInTable += 1;
                maceInTable = Instantiate(mace);
                maceInTable.transform.position = new Vector3(118.410004f, 0.159999996f, 82.1699982f);
                maceInTable.transform.rotation = Quaternion.Euler(270, 310.73291f, 0);
                maceInTable.transform.localScale = new Vector3(1.47961938f, 1.47961938f, 1.47961938f);
                player.GetComponent<Inventory>().Remove(item);
            }
            else if (item.name == "Tuerca")
            {
                itemsInTable += 1;
                tuercaInTable = Instantiate(tuerca);
                tuercaInTable.transform.position = new Vector3(117.82f, 1.60300004f, 81.8199997f);
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
            finalMaceInTable.transform.position = new Vector3(119.342003f, 1.68599999f, 82.4300003f);
            finalMaceInTable.transform.rotation = Quaternion.Euler(-5.46415067f, 180, 176.073318f);
            finalMaceInTable.transform.localScale = new Vector3(2.74106288f, 2.74106288f, 2.74106288f);
            finalMaceInTable.AddComponent<ItemPickup>();
            this.GetComponent<CraftTable>().enabled = false;
            itemsInTable = 0;
        }
    }
}
