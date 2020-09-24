// DecompilerFi decompiler from Assembly-CSharp.dll class: DataSet
using System;
using System.Collections.Generic;

[Serializable]
public class DataSet
{
	public string word
	{
		get;
		set;
	}

	public string countrycode
	{
		get;
		set;
	}

	public string timestamp
	{
		get;
		set;
	}

	public bool recognized
	{
		get;
		set;
	}

	public string key_id
	{
		get;
		set;
	}

    public List<List<List<float>>> drawing
    {
		get;
		set;
	}
}
