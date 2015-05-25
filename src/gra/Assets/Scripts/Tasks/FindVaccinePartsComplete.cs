using UnityEngine;
using System.Collections;

[System.Serializable]
public class FindVaccinePartsComplete : MonoBehaviour {

	public TaskManager manager;


	void OnDestroy()
	{

		bool strzykawka=GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ().InventoryContains ("strzykawka");
		bool skrzynka=GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ().InventoryContains ("skrzynka");
		bool kamien=GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ().InventoryContains ("kamien");
		bool butelka=GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ().InventoryContains ("butelka");
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
