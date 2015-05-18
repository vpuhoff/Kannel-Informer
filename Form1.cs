using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;

namespace Kannel_Informer_v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            if (System.Environment.GetCommandLineArgs().Length > 1)
            {
                string ss = System.Environment.GetCommandLineArgs()[1];
                string ss2 = System.Environment.GetCommandLineArgs()[2];
                to.Text = ss;
                text.Text = ss2;
                button1_Click(sender, e);
                this.Visible = false;
                this.ShowInTaskbar = false; 
                shutdown = true;
            }
            Application.DoEvents();
            Thread.Sleep(100);
            Application.DoEvents();
            if (!shutdown)
            {
                backgroundWorker1.RunWorkerAsync();
                WriteLine("Kannel delivery listener started..");
                Thread mt = new Thread(startserver);
                mt.Start();
                timer1.Enabled = true;

            }
            _writer = new TextBoxStreamWriter(ConsoleOut );//перенаправление консоли
            Console.SetOut(_writer);
        }

        TextWriter _writer = null;

        public class TextBoxStreamWriter : TextWriter
        {
            TextBox _output = null;

            public TextBoxStreamWriter(TextBox output)
            {
                _output = output;
            }

            public override void Write(char value)
            {
                base.Write(value);
                _output.AppendText(value.ToString()); // Когда символ записывается в поток, добавляем его в textbox.
            }

            public override Encoding Encoding
            {
                get { return System.Text.Encoding.UTF8; }
            }
        }
        bool shutdown = false;
       static  public  string Output = "";

       static public void WriteLine(string s)
        {
                Output+=s+"\r\n";
        }

         void startserver()
        {
            if (!shutdown )
            {
                int MaxThreadsCount = Environment.ProcessorCount * 4;
                // Установим максимальное количество рабочих потоков
                ThreadPool.SetMaxThreads(MaxThreadsCount, MaxThreadsCount);
                // Установим минимальное количество рабочих потоков
                ThreadPool.SetMinThreads(2, 2);
                // Создадим новый сервер на порту 80
                WriteLine("Запуск службы анализа ответов о доставке kannel...");
                new Server(999);
            }
            
        }

        class Client
        {
            // Отправка страницы с ошибкой
            private void SendError(TcpClient Client, int Code)
            {
                // Получаем строку вида "200 OK"
                // HttpStatusCode хранит в себе все статус-коды HTTP/1.1
                string CodeStr = Code.ToString() + " " + ((HttpStatusCode)Code).ToString();
                // Код простой HTML-странички
                string Html = "<html><body><h1>" + CodeStr + "</h1></body></html>";
                // Необходимые заголовки: ответ сервера, тип и длина содержимого. После двух пустых строк - само содержимое
                string Str = "HTTP/1.1 " + CodeStr + "\nContent-type: text/html\nContent-Length:" + Html.Length.ToString() + "\n\n" + Html;
                // Приведем строку к виду массива байт
                byte[] Buffer = Encoding.ASCII.GetBytes(Str);
                // Отправим его клиенту
                Client.GetStream().Write(Buffer, 0, Buffer.Length);
                // Закроем соединение
                Client.Close();
            }

            // Конструктор класса. Ему нужно передавать принятого клиента от TcpListener
            public Client(TcpClient Client)
            {
                WriteLine("New Client at " + DateTime.Now.ToLongTimeString());
                // Объявим строку, в которой будет хранится запрос клиента
                string Request = "";
                // Буфер для хранения принятых от клиента данных
                byte[] Buffer = new byte[1024];
                // Переменная для хранения количества байт, принятых от клиента
                int Count;
                // Читаем из потока клиента до тех пор, пока от него поступают данные
                while ((Count = Client.GetStream().Read(Buffer, 0, Buffer.Length)) > 0)
                {
                    // Преобразуем эти данные в строку и добавим ее к переменной Request
                    Request += Encoding.ASCII.GetString(Buffer, 0, Count);
                    // Запрос должен обрываться последовательностью \r\n\r\n
                    // Либо обрываем прием данных сами, если длина строки Request превышает 4 килобайта
                    // Нам не нужно получать данные из POST-запроса (и т. п.), а обычный запрос
                    // по идее не должен быть больше 4 килобайт
                    if (Request.IndexOf("\r\n\r\n") >= 0 || Request.Length > 4096)
                    {
                        break;
                    }
                }
                //WriteLine(Request);
                Request = HttpUtility.UrlDecode(Request);
                WriteLine(Request);
                savereq(Request);
                //data.Add(Request);
                //
                // Парсим строку запроса с использованием регулярных выражений
                // При этом отсекаем все переменные GET-запроса
                Match ReqMatch = Regex.Match(Request, @"^\w+\s+([^\s\?]+)[^\s]*\s+HTTP/.*|");

                // Если запрос не удался
                if (ReqMatch == Match.Empty)
                {
                    // Передаем клиенту ошибку 400 - неверный запрос
                    SendError(Client, 400);
                    return;
                }

                // Получаем строку запроса
                string RequestUri = ReqMatch.Groups[1].Value;

                // Приводим ее к изначальному виду, преобразуя экранированные символы
                // Например, "%20" -> " "
                RequestUri = Uri.UnescapeDataString(RequestUri);

                // Если в строке содержится двоеточие, передадим ошибку 400
                // Это нужно для защиты от URL типа http://example.com/../../file.txt
                if (RequestUri.IndexOf("..") >= 0)
                {
                    SendError(Client, 400);
                    return;
                }

                // Если строка запроса оканчивается на "/", то добавим к ней index.html
                if (RequestUri.EndsWith("/"))
                {
                    RequestUri += "index.html";
                }

                string FilePath = "www/" + RequestUri;

                // Если в папке www не существует данного файла, посылаем ошибку 404
                if (!File.Exists(FilePath))
                {
                    string Headers2 = "HTTP/1.1 200 OK\n";
                    byte[] HeadersBuffer2 = Encoding.ASCII.GetBytes(Headers2);
                    //Client.GetStream().Write(HeadersBuffer2, 0, HeadersBuffer2.Length);
                    Headers2 = Request;
                    HeadersBuffer2 = Encoding.ASCII.GetBytes(Headers2);
                    Client.GetStream().Write(HeadersBuffer2, 0, HeadersBuffer2.Length);
                    Client.Close();
                    // Console.Write(Request);
                    //SendError(Client, 404);
                    return;
                }

                // Получаем расширение файла из строки запроса
                string Extension = RequestUri.Substring(RequestUri.LastIndexOf('.'));

                // Тип содержимого
                string ContentType = "";

                // Пытаемся определить тип содержимого по расширению файла
                switch (Extension)
                {
                    case ".htm":
                    case ".html":
                        ContentType = "text/html";
                        break;
                    case ".css":
                        ContentType = "text/stylesheet";
                        break;
                    case ".js":
                        ContentType = "text/javascript";
                        break;
                    case ".jpg":
                        ContentType = "image/jpeg";
                        break;
                    case ".jpeg":
                    case ".png":
                    case ".gif":
                        ContentType = "image/" + Extension.Substring(1);
                        break;
                    default:
                        if (Extension.Length > 1)
                        {
                            ContentType = "application/" + Extension.Substring(1);
                        }
                        else
                        {
                            ContentType = "application/unknown";
                        }
                        break;
                }

                // Открываем файл, страхуясь на случай ошибки
                FileStream FS;
                try
                {
                    FS = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                }
                catch (Exception)
                {
                    // Если случилась ошибка, посылаем клиенту ошибку 500
                    SendError(Client, 500);
                    return;
                }

                // Посылаем заголовки
                string Headers = "HTTP/1.1 200 OK\nContent-Type: " + ContentType + "\nContent-Length: " + FS.Length + "\n\n";
                byte[] HeadersBuffer = Encoding.ASCII.GetBytes(Headers);
                Client.GetStream().Write(HeadersBuffer, 0, HeadersBuffer.Length);

                // Пока не достигнут конец файла
                while (FS.Position < FS.Length)
                {
                    // Читаем данные из файла
                    Count = FS.Read(Buffer, 0, Buffer.Length);
                    // И передаем их клиенту
                    Client.GetStream().Write(Buffer, 0, Count);
                }

                // Закроем файл и соединение
                WriteLine("Client closed" + DateTime.Now.ToLongTimeString());
                FS.Close();
                Client.Close();
            }

            void savereq(string req)
            {
                string s = Application.StartupPath + "\\";
                s = s + Guid.NewGuid().ToString("N");
                s = s + ".dlr";
                File.WriteAllText(s, req);
            }
        }



        class Server
        {
            TcpListener Listener; // Объект, принимающий TCP-клиентов
            // Запуск сервера
            public Server(int Port)
            {
                Listener = new TcpListener(IPAddress.Any, Port); // Создаем "слушателя" для указанного порта
                Listener.Start(); // Запускаем его
                WriteLine("Слушатель запущен. Порт "+ Port.ToString());
                // В бесконечном цикле
                while (true)
                {
                    // Принимаем новых клиентов. После того, как клиент был принят, он передается в новый поток (ClientThread)
                    // с использованием пула потоков.
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ClientThread), Listener.AcceptTcpClient());
                    if (Application.AllowQuit )
                    {
                        break;
                    }
                }
            }

            static void ClientThread(Object StateInfo)
            {
                // Просто создаем новый экземпляр класса Client и передаем ему приведенный к классу TcpClient объект StateInfo
                new Client((TcpClient)StateInfo);
            }

            // Остановка сервера
            ~Server()
            {
                // Если "слушатель" был создан
                if (Listener != null)
                {
                    // Остановим его

                    Listener.Stop();
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            text.Text += " " + DateTime.Now.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          string s=  SendSMS.Send(text.Text, to.Text, from.Text, int.Parse(portint.Text),ip.Text,originator.Text,user.Text,pass.Text );
          int n = dataGridView1.Rows.Add();
          dataGridView1.Rows[n].Cells[7].Value = s;
          dataGridView1.Rows[n].Cells[0].Value = n.ToString();
          dataGridView1.Rows[n].Cells[2].Value = "Передано";
          dataGridView1.Rows[n].Cells[9].Value = DateTime.Now.AddSeconds(23).ToLongTimeString();
          dataGridView1.Rows[n].Cells[4].Value = from.Text ;
          dataGridView1.Rows[n].Cells[5].Value = to.Text ;
          dataGridView1.Rows[n].Cells[3].Value = text.Text;
        }

        bool exit = false;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {
                if (!exit)
                {
                    try
                    {
                        BeginInvoke(new MethodInvoker(delegate
                        {
                            //textBox1.AppendText("Программа завершила свою работу!");
                            var t = Directory.GetFiles(Application.StartupPath, "*.dlr");
                            foreach (string item in t)
                            {
                                string s = File.ReadAllText(item);
                                //listBox1.Items.Add(s);
                                s = s.Replace("id=", "");
                                s = s.Replace("to=", "");
                                s = s.Replace("answer=", "");
                                s = s.Replace("from=", "");
                                s = s.Replace("ts=", "");
                                s = s.Replace("status=1", "Доставлено");
                                s = s.Replace("status=8", "Отправлено");
                                s = s.Replace(" HTTP/1.1", "&");

                                string[] tt = s.Split('&');
                                int n = dataGridView1.Rows.Add();
                                for (int i = 0; i < tt.Length; i++)
                                {
                                    if (i==0)
                                    {
                                        tt[i] = n.ToString();
                                    }
                                    if (i == 6)
                                    {
                                        string ti= tt[i];
                                        DateTime dt = DateTime.Parse(ti);
                                        dt=dt.AddHours(11);
                                        ti = dt.ToLongTimeString();
                                        tt[i] = ti;
                                    }
                                    dataGridView1.Rows[n].Cells[i].Value = tt[i];
                                }
                                dataGridView1.Rows[n].Cells[9].Value = DateTime.Now.AddSeconds(23).ToLongTimeString();
                                //dataGridView1.DataSource=Log;
                                File.Delete(item);
                            }
                        }));
                        Thread.Sleep(100);
                    }
                    catch (Exception x)
                    {
                        Debug.WriteLine(x.Message);
                        return;
                    }
                }
                else
                {
                    return;
                }

            } while (true);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Output.Length!=0)
            {
                ConsoleOut.Text += "\r\n" + Output;
                Output = "";
            }
            ConsoleOut.Select(ConsoleOut.Text.Length - 2, 1);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save(); 
            exit = true;
            Application.DoEvents();
            System.Environment.Exit(0);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (shutdown )
            {
                Application.Exit();
                this.Dispose();
            }
        }

        private void text_TextChanged(object sender, EventArgs e)
        {
            label2.Text = "Длина: " + text.Text.Length.ToString();
        }
    }
}
