using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.IO.Compression;
using UnityEngine;

[XmlRoot("XMLScore")]
public class XMLScore{

	public int[] score = new int[3];
	public int[] levels = new int[3];
	private string path = Application.dataPath + "saveScore.xml";

	public void Save(string path)
	{
		var serializer = new XmlSerializer(typeof(XMLScore));
		using (var stream  = new StreamWriter(File.Open(path, FileMode.Create), System.Text.Encoding.UTF8)) {
			serializer.Serialize(stream, this);
			stream.Close();
		}
	}

	public static XMLScore Load(string path)
	{
		if (!File.Exists(path))
			return null;
		
		var serializer = new XmlSerializer(typeof(XMLScore));
		using(var stream = new StreamReader(File.Open(path, FileMode.Open), System.Text.Encoding.UTF8))
		{
			try{
				return serializer.Deserialize(stream) as XMLScore;
			}
			catch (System.Exception){
				return null;
			}
		}
	}
}
