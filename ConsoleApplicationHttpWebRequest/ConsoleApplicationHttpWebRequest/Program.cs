using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace ConsoleApplicationHttpWebRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://www.baidu.com"); //create one request
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //get the response
            //Stream responseStream = response.GetResponseStream();
            //StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
            //string html = streamReader.ReadToEnd();
            //Console.WriteLine(html);
            //Console.ReadKey();

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            CookieContainer cc = new CookieContainer();
            request = (HttpWebRequest)WebRequest.Create("http://lts.sonyericsson.net/");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/5.0 Firefox/19.0";

            string requestForm = "Email=a@a.com&Password=1";
            byte[] postdatabyte = Encoding.UTF8.GetBytes(requestForm);
            request.ContentLength = postdatabyte.Length;
            request.AllowAutoRedirect = true;
            request.CookieContainer = cc;
            request.KeepAlive = true;

            Stream stream;
            stream = request.GetRequestStream();
            stream.Write(postdatabyte, 0, postdatabyte.Length);
            stream.Close();

            response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine();

            Stream stream1 = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream1);
            Console.WriteLine(sr.ReadToEnd());

            Console.ReadKey();
        }
    }
}
