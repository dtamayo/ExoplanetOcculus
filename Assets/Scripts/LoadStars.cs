using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;  

public class LoadStars : MonoBehaviour {

	public int nstars;
	public GameObject[] stararray;
	public Transform star;

	void Awake()
	{
		//bool success = Load ("stardata.csv");	
		stararray = new GameObject[nstars];
	}

	// Use this for initialization
	void Start () {
		Instantiate (star, new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
		bool success = Load ("stardata.csv");	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private bool Load(string fileName)
	{
		try
		{
			string line;
			StreamReader theReader = new StreamReader(fileName, Encoding.Default);
		
			using (theReader)
			{
				for(int i=0; i<nstars; i++)
				{
					line = theReader.ReadLine();
				
					if (line != null)
					{
						string[] entries = line.Split(',');
						if (entries.Length > 0) {
							Instantiate (star, new Vector3(float.Parse(entries[1]), float.Parse(entries[3]), float.Parse(entries[2])), Quaternion.identity);
							print (line);
						}

					}
				}
				//while (line != null);
			  
				theReader.Close();
				return true;
			}
		}
		catch 
		{
			print ("error");
			return false;
		}
	}

}
