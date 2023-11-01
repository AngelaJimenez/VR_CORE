using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
	public InputActionReference activeReference = null;
	public InputActionReference selectReference = null;
    public GameObject handModelPrefab;

	
	private GameObject spawnedHandModel;
	
    private Animator handAnimator;

	// Start is called before the first frame update
	void Start()
	{
		spawnHand();
	}

	// Update is called once per frame
	void Update()
    {
		UpdateHandAnimation();
	}

	void spawnHand()
	{
		spawnedHandModel = Instantiate(handModelPrefab, transform);
		
		handAnimator = spawnedHandModel.GetComponent<Animator>();
	}

	void UpdateHandAnimation()
    {
		onActivePress(activeReference.action.ReadValue<float>());
		onGripPress(selectReference.action.ReadValue<float>());
	}

	public void onSelectEntered(SelectEnterEventArgs interactor)
    {
        if (interactor.interactableObject.transform.gameObject.tag == "NetworkNode")
        {
			this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
			this.transform.parent.gameObject.GetComponent<XRRayInteractor>().enabled = false;
		}
	}

	public void onSelectExited(SelectExitEventArgs interactor)
	{
		if (interactor.interactableObject.transform.gameObject.tag == "NetworkNode")
		{
			this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
			this.transform.parent.gameObject.GetComponent<XRRayInteractor>().enabled = true;
		}
	}

	private void onActivePress(float triggerValue)
    {
		handAnimator.SetFloat("Trigger", triggerValue);
	}

	private void onGripPress(float gripValue)
    {
		handAnimator.SetFloat("Grip", gripValue);
	}
}
