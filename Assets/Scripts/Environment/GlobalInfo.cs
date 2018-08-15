using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInfo : MonoBehaviour {

    [SerializeField] private NejikoController m_nejikoController;

    public static NejikoController NejikoController;

	// Use this for initialization
	void Start () {
        NejikoController = m_nejikoController;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
