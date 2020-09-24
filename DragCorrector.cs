// DecompilerFi decompiler from Assembly-CSharp.dll class: DragCorrector
using UnityEngine;
using UnityEngine.EventSystems;

public class DragCorrector : MonoBehaviour
{
	[SerializeField]
	public int m_baseTH = 10;

	[SerializeField]
	public int m_basePPI = 210;

	private int m_dragTH;

	private void Start()
	{
		m_dragTH = m_baseTH * (int)Screen.dpi / m_basePPI;
		EventSystem.current.pixelDragThreshold = m_dragTH;
	}
}
