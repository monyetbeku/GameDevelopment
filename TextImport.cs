﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextImport : MonoBehaviour {

	public TextAsset textFile;
	public string[] textLines;

	// Use this for initialization
	void Start () {
		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));
		}	
	}
	

}
