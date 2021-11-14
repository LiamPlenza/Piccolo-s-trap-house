using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftTable : Interactable
{
    public List<Item> itemsList;

    private int itemsInTable = 0;

    public GameObject axe;
    public GameObject crawbar;
    public GameObject hacksaw;

    private GameObject hacksawInTable;

    private GameObject axeInTable;

    private GameObject crowbarInTable;
    public override void Interact()
    {
        base.Interact();

        Craft();
    }
    public void Craft()
    {
        itemsList = player.GetComponent<Inventory>().items;
        foreach (var item in itemsList)
        {
            if (item.name == "Axe")
            {
                itemsInTable += 1;
                axeInTable = Instantiate(axe);
                axeInTable.transform.position = new Vector3(121.290001f, 1.66999996f, 82.276001f);
                axeInTable.transform.rotation = Quaternion.Euler(14.9998064f, 59.9998856f, 0.0f);
                axeInTable.transform.localScale = new Vector3(2.12193513f, 2.12193513f, 2.12193513f);
                player.GetComponent<Inventory>().Remove(item);
            }
            if (item.name == "Hacksaw")
            {
                itemsInTable += 1;
                hacksawInTable = Instantiate(hacksaw);
                hacksawInTable.transform.position = new Vector3(118.024284f, 1.61000001f, 82.4550171f);
                hacksawInTable.transform.rotation = Quaternion.Euler(349.015015f, 193.187027f, 180);
                hacksawInTable.transform.localScale = new Vector3(2.58979988f, 2.58979988f, 2.58979988f);
                player.GetComponent<Inventory>().Remove(item);
            }
            if (item.name == "Crowbar")
            {
                itemsInTable += 1;
                crowbarInTable = Instantiate(crawbar);
                crowbarInTable.transform.position = new Vector3(119.609001f, 1.62453961f, 82.3313293f);
                crowbarInTable.transform.rotation = Quaternion.Euler(-0.000167339706f, 145.600891f, 180);
                crowbarInTable.transform.localScale = new Vector3(2.4216001f, 2.4216001f, 2.4216001f);
                player.GetComponent<Inventory>().Remove(item);
            }
        }
        if (itemsInTable == 3)
        {
            Destroy(axeInTable);
            Destroy(hacksawInTable);
            Destroy(crowbarInTable);
            itemsInTable = 0;
        }
    }
}
