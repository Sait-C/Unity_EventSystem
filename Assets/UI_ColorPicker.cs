using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_ColorPicker : MonoBehaviour
{
	//The target object: GameObject whose Material we want to change.
	public GameObject target;
	private Material targetMaterial;
	private GraphicRaycaster rc;
	private PointerEventData pt;
	private EventSystem eventSystem;

	void Start(){
		//Obtain the target object's material
		if(target != null){
			targetMaterial = target.GetComponent<Renderer>().material;
		} 
		//Obtain the Canvas Raycaster and EventSystem Components
		rc = GetComponent<GraphicRaycaster>();
		eventSystem = GetComponent<EventSystem>();
	}

	void Update(){
		/*responsible for registering a "hit" and keeping track of all the objects hit by the
		Graphic Raycaster in our Canvas.These Objects are the swatches we created earlier.
		For every swatch our Raycaster hits, we only want to pay attention to the color of
		its image component.*/
		pt = new PointerEventData(eventSystem);
		pt.position = Input.mousePosition;

		List<RaycastResult> results = new List<RaycastResult>();
		rc.Raycast(pt, results);

		foreach(RaycastResult swatch in results){
			if(swatch.gameObject.GetComponent<Image>().color != null){
				ChangeColor(swatch.gameObject.GetComponent<Image>().color);
			}
		}
	}

	void ChangeColor(Color c){
		targetMaterial.color = c;
	}

}
