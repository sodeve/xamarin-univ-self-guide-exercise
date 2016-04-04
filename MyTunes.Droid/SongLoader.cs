using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using System.Reflection;

namespace MyTunes
{
	public static partial class SongLoader
	{
		const string Filename = "songs.json";

	    private static Stream OpenData()
	    {
			// TODO: add code to open file here.
		    return Android.App.Application.Context.Assets.Open(Filename);
		}
	}
}

