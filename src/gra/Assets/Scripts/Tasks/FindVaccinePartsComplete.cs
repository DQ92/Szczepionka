using UnityEngine;
using System.Collections;

[System.Serializable]
public class FindVaccinePartsComplete : MonoBehaviour {

	public TaskManager manager;
	public GameObject gameObject;

	private Inventory inventory;
	void Start(){
		inventory=GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory>();

	}




	void OnDestroy()
	{


		bool strzykawka=inventory.InventoryContains ("strzykawka");
		bool skrzynka=inventory.InventoryContains ("skrzynka");
		bool kamien=inventory.InventoryContains ("kamien");
		bool butelka=inventory.InventoryContains ("butelka");
		if (strzykawka && skrzynka && kamien && butelka) {
			manager.markAsCompleted("findVaccineParts");
			string message = 
					"Doskonale zebrałeś\n" +
					"wszystkie części \n" +
					"szczepionki, teraz\n" +
					"musisz odnaleźć\n" +
					"wejście do tuneli\n" +
					"u podnóża wulkanu\n" +
					"to jest jedyna droga \n" +
					"do miasta\n\n" +
					"Ruszaj w drogę!";
			
			manager.addTask("endOfMission",message);

		}

	}
}
