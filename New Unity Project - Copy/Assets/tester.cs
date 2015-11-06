using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class tester : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FileStream file = null;
        FileInfo fileinfo = null;

        try
        {
            fileinfo = new FileInfo("file.txt");
            file = fileinfo.OpenWrite();

            for (int i = 0; i < 255; i++)

                file.WriteByte((byte)i);

            throw new ArgumentNullException("something happend");
        }
        catch (UnauthorizedAccessException e)
        {
            Debug.LogWarning(e.Message);
        }
        catch(ArgumentNullException e)
        {
            Debug.LogWarning(e.Message);
        }
        finally
        {
            if (file != null)
                file.Close();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
