using System;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Collections.Specialized;
using System.Diagnostics;

//todo reflection & generics
namespace news
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			try
			{
				//Debug.Listeners.Add(new TextWriterTraceListener(System.Console.Out));
				Article nntpArticle = new Article(ConfigurationManager.AppSettings.Get("hostname"),
				                                  ConfigurationManager.AppSettings.Get("username"), 
				                                  ConfigurationManager.AppSettings.Get("password"));

				/**
				 * Returns a list of all newsgroups available on the server
				 */ 
				/*ArrayList list = nntpArticle.getNewsGroups();
				foreach(string newsgroup in list)
				{
					System.Console.WriteLine("Newsgroup: {0}",newsgroup);
				}

				/**
				 * Returns a list of all capabilities used on this server
				 */
				/*
				ArrayList capabilities = nntpArticle.getCapabilities();
				foreach(string capability in capabilities)
				{
					System.Console.WriteLine("Capability: {0}",capability);
				}*/

				//nntpArticle.post("blerf","kahlan","Just a little test","alt.test");

				/**
				 * Complete news test
				 */
				/*
				ArrayList newsPostings = nntpArticle.getCompleteNews("alt.test");
				int i =0;
				foreach(string newsPosting in newsPostings)
				{
					System.Console.WriteLine(newsPosting);
					i++;
				}
				System.Console.WriteLine(i + " postings read");
				*/
				ArrayList newsPostings = nntpArticle.getHeadNews("alt.binaries.boneless");
				int i = 0;
				foreach(string newsPosting in newsPostings)
				{
					System.Console.WriteLine(newsPosting);
					i++;
				}
				System.Console.WriteLine(i + " postings read");


			}
			catch(System.Exception e)
			{
				System.Console.WriteLine(e);
			}
		}
	}
}
