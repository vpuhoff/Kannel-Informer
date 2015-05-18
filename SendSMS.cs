using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Kannel_Informer_v2
{
    class SendSMS
    {
        public static string Send(string text , string to , string from , int portint , string ip, string originator , string user , string pass )
        {
            text = Converter(text, Encoding.UTF8, Encoding.BigEndianUnicode);
            text = HttpUtility.UrlEncode (text);
            string port = portint.ToString();
            string id = Guid.NewGuid().ToString("N");
            string myip = "";
            foreach (System.Net.IPAddress ipip in System.Net.Dns.GetHostEntry (System.Net.Dns.GetHostName()).AddressList)
            {
                Console.WriteLine(ipip.ToString());
                myip = ipip.ToString();
            }
            if (System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.Length > 1)
            {
                Console.WriteLine("У вашего компьютера больше одного IP адреса! Беру первый:)");
            }
            string answer_deliver_url = "http://$IPIP:999/smsdeliv.php?smsid=$sms_id&type=%d&status=%d&answer=%A&to=%P&from=%p&ts=%t&id=$$$";
            answer_deliver_url = answer_deliver_url.Replace("$$$", id);
            answer_deliver_url = answer_deliver_url.Replace("$IPIP", myip);
            answer_deliver_url = HttpUtility.UrlEncode(answer_deliver_url);
            string url = "";
            string templateurl = "http://$ip:$port/cgi-bin/sendsms?user=$user&pass=$pass&from=$from&priority=1&to=$to&text=$mytext&coding=2&validity=2000&dlr-mask=31&dlr-url=$dlrurl";
            url = templateurl.Replace("$mytext", text);
            url = url.Replace("$dlrurl", answer_deliver_url);
            url = url.Replace("$to", to);
            url = url.Replace("$port", port);
            url = url.Replace("$user", user);
            url = url.Replace("$pass", pass);
            url = url.Replace("$from", from);
            url = url.Replace("$ip", ip);
            System.Net.WebClient web = new System.Net.WebClient();
            Console.WriteLine(url);    //write debug info
            try
            {
                string result = web.DownloadString(url);
                Console.WriteLine(result); //write debug info
            }
            catch (Exception x)
            {
                Console.WriteLine("Ошибка - сообщение не отправлено!");
                Console.WriteLine(x.Message);
                if (x.Message.Contains("407"))
                {
                    Console.WriteLine("Приложение не может работать через прокси с авторизацией в текущей версии!");
                }
            }
            return id;
        }

        public static string Converter(string value, Encoding src, Encoding trg) 
        {
            Decoder dec = src.GetDecoder();
            byte[] ba = trg.GetBytes(value);
            int len = dec.GetCharCount(ba, 0, ba.Length);
            char[] ca = new char[len];
            dec.GetChars(ba, 0, ba.Length, ca, 0);
            return new string(ca);
        }
    }
}
