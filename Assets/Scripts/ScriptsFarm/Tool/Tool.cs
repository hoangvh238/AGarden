using UnityEngine;
using UnityEngine.EventSystems;

public class Tool : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField] private GameObject toolPrefab;
	[SerializeField] private Canvas canvas;
	private GameObject toolInstance;

	private ManagerGame manager;
	private Camera mainCamera;
	private const float ScreenPointZ = 10.0f;

	void Start()
	{
		manager = ManagerGame.Key;
		mainCamera = Camera.main;

		if (manager == null)
		{
			Debug.LogError("ManagerGame.Key is not initialized.");
		}

		if (mainCamera == null)
		{
			Debug.LogError("Main camera is not found.");
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (toolInstance == null) return;

		UpdateToolInstancePosition();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		toolInstance = Instantiate(toolPrefab);
		UpdateToolInstancePosition();
		manager.DragObject = toolInstance;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (manager.DragObject == null || manager.ContainerObject == null)
		{
			ClearTool();
			return;
		};

		var dragObjectName = manager.DragObject.name;
		var containerObject = manager.ContainerObject;

		if (dragObjectName.Contains("ToolShovel"))
		{
			containerObject.GetComponent<Seed>().DestroySeed(0);
		}
	
		if (dragObjectName.Contains("ToolCatching"))
		{
			if (!containerObject.name.Contains("Nor"))
			{
				containerObject.GetComponent<Bug>().DestroyBug();
			}
		}

		if (dragObjectName.Contains("ToolWater"))
		{
			containerObject.GetComponent<Seed>().ChangeDry();
		}

		ClearTool();
		
	}

	private void UpdateToolInstancePosition()
	{
		Vector3 screenPoint = Input.mousePosition;
		screenPoint.z = ScreenPointZ;
		toolInstance.transform.position = mainCamera.ScreenToWorldPoint(screenPoint);
	}

	private void ClearTool()
	{
		Destroy(toolInstance);
		manager.DragObject = null;
	}
}
