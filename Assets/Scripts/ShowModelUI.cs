using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModelUI : MonoBehaviour
{
    [SerializeField] private ShowModelButton buttonPrefab;

	// Use this for initialization
	void Start ()
    {
        var models = FindObjectOfType<ShowModelController>().GetModels();
        foreach (var model in models)
        {
            CreateButtonForModel(model);
        }
	}
	
    private void CreateButtonForModel (Transform model)
    {
        var button = Instantiate(buttonPrefab);
        button.transform.SetParent(this.transform);
        button.transform.localScale = Vector3.one;
        button.transform.localRotation = Quaternion.identity;

        button.Initialize(model, FindObjectOfType<ShowModelController>().EnableModel);
    }
}
