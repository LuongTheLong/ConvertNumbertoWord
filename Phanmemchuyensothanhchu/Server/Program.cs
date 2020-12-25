using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;
using System.CodeDom;

namespace SimpleTcpSrvr
{
    class Program
    {
        
        static readonly object _lock = new object();
        static readonly Dictionary< int, TcpClient> list_clients = new Dictionary< int, TcpClient>();
        #region Lectureseulement 
        // hàm xử lý việc đọc thập phân tiếng pháp 
        private static string Lectureseulement(string so)
        {
            string[] chuso = { "zéro ", "une ", "deux ", "trois ", "quatre ", "cinq ", "six ", "sept ", "huit ", "neuve " };
            string total = "";
            string chuoi = "";
            for (int i = 0; i < so.Length; i++)
            {
                char a = so[i]; 
                int b = Convert.ToInt32(new string(a, 1));
                chuoi = chuso[b]; // khi b bằng một số nào đó thì tương đương với một chữ trong chuỗi string
                total += chuoi;
            }
            return total;
        }
        #endregion
        #region Readonly
        // hàm xử lý việc đọc thập phân tiếng anh
        private static string Readonly(string so)
        {
            string[] chuso = { "zero ", "one ", "two ", "three ", "four ", "five ", "six ", "seven ", "eight ", "nice " };
            string total = "";
            string chuoi = "";
            for (int i = 0; i < so.Length; i++)
            {
                char a = so[i];
                int b = Convert.ToInt32(new string(a, 1));
                chuoi = chuso[b];
                total += chuoi;
            }
            return total;
        }
        #endregion
        #region docchay
        // hàm đọc thập phân tiếng việt
        private static string docchay(string so)
        {
            string[] chuso = { "không ", "một ", "hai ", "ba ", "bốn ", "năm ", "sáu ", "bảy ", "tám ", "chín " };
            string total = "";
            string chuoi = "";
            for (int i = 0; i < so.Length; i++)
            {
                char a = so[i];
                int b = Convert.ToInt32(new string(a, 1));
                chuoi = chuso[b];
                total += chuoi;
            }
            return total;
        }
        #endregion
        #region TiengViet
        // hàm xử lý dịch từ số sang tiếng việt
        static string[] numText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');

        //Đọc hàng chục: 123 -> một trăm hai ba
        private static string DocHangChuc(long so, bool daydu)
        {
            string chuoi = "";

            //Hàm lấy chữ số hàng chục
            Int64 chuc = so / 10; //hàm Math.Floor: làm tròn xuống (21/10 = 2.1 -> 2)

            //Hàm lấy chữ số hàng đơn vị bằng phép chia lấy dư 21 % 10 = 1
            Int64 donvi = (Int64)so % 10;

            if (chuc > 1)
            {
                chuoi = " " + numText[chuc] + " mươi";

                if (donvi == 1) chuoi += " mốt";
            }
            else if (chuc == 1)
            {
                chuoi = " mười";

                if (donvi == 1) chuoi += " một";
            }
            else if (daydu && donvi > 0) chuoi = " lẻ";

            if (donvi == 5 && chuc >= 1)
            {
                chuoi += " lăm";
            }
            else if (donvi > 1 || (donvi == 1 && chuc == 0))
            {
                chuoi += " " + numText[donvi];
            }

            return chuoi;
        }

        private static string DocHangTram(long so, bool daydu)
        {
            string chuoi = "";

            Int64 tram = so / 100;

            //Lấy phần còn lại của hàng trăm bằng cách chia lấy dư 100
            so = so % 100;

            if (daydu || tram > 0)
            {
                chuoi = " " + numText[tram] + " trăm";
                chuoi += DocHangChuc(so, true);
            }
            else
            {
                chuoi = DocHangChuc(so, false);
            }

            return chuoi;
        }

        private static string DocHangTrieu(long so, bool daydu)
        {
            string chuoi = "";

            //Lấy số hàng triệu
            Int64 trieu = so / 1000000;

            //Lấy phần dư sau số hàng triệu (2,123,000 -> so: 123,000)
            so = so % 1000000;

            if (trieu > 0)
            {
                chuoi = DocHangTram(trieu, daydu) + " triệu";
                daydu = true;
            }

            //Lấy số hàng nghìn
            Int64 nghin = so / 1000;

            so = so % 1000;

            if (nghin > 0)
            {
                chuoi += DocHangTram(nghin, daydu) + " nghìn";
                daydu = true;
            }

            if (so > 0)
            {
                chuoi += DocHangTram(so, daydu);
            }

            return chuoi;
        }

        private static string ChuyenSangChuoi(long so)
        {
            if (so == 0) return numText[0];

            string chuoi = "", hauto = "";
            if (so < 0)
            {
                so *= -1;
            }

            while (so > 0)
            {
                //Lấy số hàng tỷ
                long ty = so % 1000000000;

                //Lấy phần dư sau số hàng tỷ
                so = so / 1000000000;

                if (so > 0)
                {
                    chuoi = DocHangTrieu(ty, true) + hauto + chuoi;
                }
                else
                {
                    chuoi = DocHangTrieu(ty, false) + hauto + chuoi;
                }

                hauto = " tỷ";
            }

            return chuoi;

        }

        #endregion
        #region TiengAnh
        // hàm xử lý việc đọc từ số sang tiếng anh
        string[] numtextforE = "zero;one;two;three;four;five;six;seven;eight;nine".Split(';');

        public static string NumberToWords(long number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
            {
                number *= -1;
            }
            string words = "";

            if ((number / 1000000000) > 0) // xét hàng tỷ
            {
                words += NumberToWords(number / 1000000000) + " billion ";
                number %= 1000000000;
            }

            if ((number / 1000000) > 0) // xét hàng triệu
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0) // xét hàng ngàn
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0) // xét hàng trăm
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0) 
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" }; // đọc từ 11 -> 19
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" }; // đọc số tròn chục

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10]; 
                }
            }

            return words;
        }

        #endregion
        #region TiengPhap

        string[] read = "zéro;une;deux;trois;quatre;cinq;six;sept;huit;neuf".Split(';');

        public static string nombreàmot(long number)
        {
            if (number == 0)
                return "zéro";

            if (number < 0)
            {
                number *= -1;
            }
            string words = "";

            if ((number / 1000000000) > 0)
            {
                words += nombreàmot(number / 1000000000) + " milliard ";
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words += nombreàmot(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += nombreàmot(number / 1000) + " mille ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += nombreàmot(number / 100) + " cent ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "et ";

                var unitsMap = new[] { "zéro", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "Dix", "Onze", "Douze", "treize", "Quatorze", "quinze", "seize", "dix-sept", "dix-huit", "dix-neuf" };
                var tensMap = new[] { "zéro", "dix", "vingt", "trente", "quarante", "cinquante", "soixante", "soixante-dix", "quatre-vingts", "quatre vingt dix" };

                if (number < 20)
                {
                    words += unitsMap[number];
                }
                else if (number % 10 == 1)
                {
                    words += tensMap[number / 10] + "-et-" + unitsMap[1];
                }
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        #endregion
        [Obsolete]
        static void Main(string[] args)
        {
            int count = list_clients.Count; // bắt đầu đếm bằng 0
            String strHostName = Dns.GetHostName();
            Console.WriteLine("Host Name: " + strHostName);

            // Lấy tên Host
            IPHostEntry iphostentry = Dns.GetHostByName(strHostName);
            // Lấy địa chỉ IPv4Address
            IPAddress[] ipa = iphostentry.AddressList;
            Console.WriteLine("IP: " + ipa[0]);
            Console.WriteLine("IP: " + ipa[1]);
            IPAddress aps = ipa[1];
            Console.WriteLine("IPv4Address: " + aps);
            Console.OutputEncoding = Encoding.UTF8; // khai báo việc dịch sang ngôn ngữ UTF8
            
            IPAddress IP; // khai báo IP
            TcpListener ServerSocket = new TcpListener(IPAddress.Any, 9050); // dùng giao thức TCP 
            try
            {
                IP = aps; // địa chỉ IPv4Address của server
                ServerSocket = new TcpListener(IP, 9050); // socket bao gồm IP và port
                ServerSocket.Start(); // mở Socket
                Console.WriteLine("Waiting for Client....");
            }
            catch
            {
                Console.WriteLine("Khong ket noi duoc!!");
                Console.Read();
            }
            TcpClient client;
            try
            {
                while (true)
                {
                    
                    client = ServerSocket.AcceptTcpClient(); // nhận biết khi client kết nối được
                    lock (_lock) list_clients.Add(count, client); // bắt đầu thêm bộ đếm
                    Console.WriteLine("Client connected!!");
                    Thread t = new Thread(handle_clients); // xử lý luồng
                    t.Start(count); // đếm
                    count = list_clients.Count;
                    Console.WriteLine("so ket noi: " + (count).ToString());
                }
            }
            catch
            {
                Console.WriteLine("Cant connect!!!!");
                Console.Read();
            }
        }
        public static void handle_clients(object o)
        {
            int id = (int)o;
            TcpClient client; // khai báo dạng kết nối của client
            lock (_lock) client = list_clients[id];
            try
            {
                while (true)
                {
                    NetworkStream stream = client.GetStream(); // nhận dữ liệu
                    byte[] buffer = new byte[1024]; // khai báo buffer dạng byte
                    int byte_count = stream.Read(buffer, 0, buffer.Length); // đọc dữ liệu buffer

                    if (byte_count == 0)
                    {
                        break;
                    }

                    string st = Encoding.UTF8.GetString(buffer, 0, byte_count); // gán dữ liệu byte vào chuỗi st
                    Console.WriteLine(st);
                    string tv, ta, tp;
                    for (int i = 0; i < st.Length; i++)
                    {
                        string mystr = st.Substring(3, st.Length - 3);
                        char a = st[i];
                        if (a == 'v') // nếu chữ nhận được là tv thì biết phải dịch sang tiếng việt
                        {
                            if (st == " ")
                            {
                                Console.WriteLine("Mời bạn nhập lại dãy số cần chuyển đổi");
                            }

                            else if (mystr[0] == '.') // nếu số nhận về là .1 (Phần này đã lẽ là dùng được nhưng bọn em xử lý bên client lun òi =3=)
                            {
                                string phay = mystr.Substring(1, mystr.Length - 1);
                                tv = "không phẩy " + docchay(phay);
                                broadcast(tv);
                            }

                            else if (mystr.Contains(".")) // xét tiếp nếu có dấu chấm 
                            {
                                string[] parts = mystr.Split('.'); // chia ra làm từng part
                                string part1 = parts[0]; // part phần thực
                                string part2 = parts[1]; // part phần thập phân
                                long b = Int64.Parse(part1); // chuyển part 1 từ string về long, lý do dùng long để xử lý việc số quá lớn tầm tỷ tỷ

                                if (part2 == "") // nếu phần thập phân = 0
                                {
                                    if (part1.Contains("-")) // và có dấu âm trong phần thực
                                    {
                                        tv = "âm " + ChuyenSangChuoi(Convert.ToInt64(part1)); // thì sẽ là âm + phần thực
                                        broadcast(tv);
                                    }
                                    else
                                    {
                                        tv = ChuyenSangChuoi(Convert.ToInt64(part1)); // còn không có thì phần thực thôi
                                        broadcast(tv);
                                    }
                                }

                                else
                                {
                                    char[] charsToTrim = { '0' }; // xử lý số 0 trong phần thập phân
                                    string[] numbers = part2.Split();
                                    foreach (string charac in numbers)
                                    {
                                        string part3 = charac.TrimEnd(charsToTrim); // xóa bỏ số 0 phía sau cùng trong thập phân

                                        if (part1.Contains("-")) // xét tiếp việc phần thực có dấu âm khi mà có dấu "."
                                        {
                                            tv = "âm " + ChuyenSangChuoi(Convert.ToInt64(part1)) + " phẩy " + docchay(part3);
                                            broadcast(tv);
                                        }
                                        else if (part3 == "") // nếu không có phần thập phân
                                        {
                                            tv = ChuyenSangChuoi(Convert.ToInt64(part1));
                                            broadcast(tv);
                                        }
                                        else // các trường hợp còn lại -3-
                                        {
                                            tv = ChuyenSangChuoi(Convert.ToInt64(part1)) + " phẩy " + docchay(part3);
                                            broadcast(tv);
                                        }
                                    }
                                }
                            }
                            else if (mystr.Contains("-") && Convert.ToInt64(mystr) != 0 && !mystr.Contains(".")) // nếu mà không có dấu "." và có dấu "-"
                            {
                                tv = "âm " + ChuyenSangChuoi(Convert.ToInt64(mystr));
                                broadcast(tv);
                            }
                            else // khi không có dấu "." và dấu "-"
                            {
                                tv = ChuyenSangChuoi(Convert.ToInt64(mystr));
                                broadcast(tv);
                            }
                        }
                        else if (a == 'a') // xử lý tiếng anh
                        {
                            if (st == " ")
                            {
                                Console.WriteLine("Please type again, you still dont type anything");
                            }

                            else if (mystr[0] == '.')
                            {
                                string phay = mystr.Substring(1, mystr.Length - 1);
                                ta = "Zero point " + Readonly(phay);
                                broadcast(ta);
                            }

                            else if (mystr.Contains("."))
                            {
                                string[] parts = mystr.Split('.');
                                string part1 = parts[0];
                                string part2 = parts[1];
                                long b = Int64.Parse(part1);
                                if (part2 == "")
                                {
                                    if (part1.Contains("-"))
                                    {
                                        ta = "Minus " + NumberToWords(Convert.ToInt64(part1));
                                        broadcast(ta);
                                    }
                                    else
                                    {
                                        ta = NumberToWords(Convert.ToInt64(part1));
                                        broadcast(ta);
                                    }
                                }
                                else
                                {
                                    char[] charsToTrim = { '0' };
                                    string[] numbers = part2.Split();
                                    foreach (string charac in numbers)
                                    {
                                        string part3 = charac.TrimEnd(charsToTrim);
                                        if (part1.Contains("-"))
                                        {
                                            ta = "Minus " + NumberToWords(Convert.ToInt64(part1)) + " point " + Readonly(part3);
                                            broadcast(ta);
                                        }
                                        else if (part3 == "")
                                        {
                                            ta = NumberToWords(Convert.ToInt64(part1));
                                            broadcast(ta);
                                        }
                                        else
                                        {
                                            ta = NumberToWords(Convert.ToInt64(part1)) + " point " + Readonly(part3);
                                            broadcast(ta);
                                        }

                                    }
                                }
                            }
                            else if (mystr.Contains("-") && Convert.ToInt64(mystr) != 0 && !mystr.Contains("."))
                            {
                                tv = "Minus " + NumberToWords(Convert.ToInt64(mystr));
                                broadcast(tv);
                            }
                            else
                            {
                                ta = NumberToWords(Convert.ToInt64(mystr));
                                broadcast(ta);
                            }

                        }
                        else if (a == 'p') // xử lý tiếng Pháp
                        {
                            if (st == " ")
                            {
                                Console.WriteLine("Veuillez saisir à nouveau le nombre à convertir");
                            }

                            else if (mystr[0] == '.')
                            {
                                string phay = mystr.Substring(1, mystr.Length - 1);
                                tp = "Zéro point " + Lectureseulement(phay);
                                broadcast(tp);
                            }

                            else if (mystr.Contains("."))
                            {
                                string[] parts = mystr.Split('.');
                                string part1 = parts[0];
                                string part2 = parts[1];
                                long b = Int64.Parse(part1);
                                if (part2 == "")
                                {
                                    if (part1.Contains("-"))
                                    {
                                        tp = "Moins " + nombreàmot(Convert.ToInt64(part1));
                                        broadcast(tp);
                                    }
                                    else
                                    {
                                        tp = nombreàmot(Convert.ToInt64(part1));
                                        broadcast(tp);
                                    }
                                }
                                else
                                {
                                    char[] charsToTrim = { '0' };
                                    string[] numbers = part2.Split();
                                    foreach (string charac in numbers)
                                    {
                                        string part3 = charac.TrimEnd(charsToTrim);
                                        if (part1.Contains("-"))
                                        {
                                            tp = "Moins " + nombreàmot(Convert.ToInt64(part1)) + " point " + Lectureseulement(part3);
                                            broadcast(tp);
                                        }
                                        else if (part3 == "")
                                        {
                                            tp = nombreàmot(Convert.ToInt64(part1));
                                            broadcast(tp);
                                        }
                                        else
                                        {
                                            tp = nombreàmot(Convert.ToInt64(part1)) + " point " + Lectureseulement(part3);
                                            broadcast(tp);
                                        }

                                    }
                                }
                            }
                            else if (mystr.Contains("-") && Convert.ToInt64(mystr) != 0 && !mystr.Contains("."))
                            {
                                tp = "Moins " + nombreàmot(Convert.ToInt64(mystr));
                                broadcast(tp);
                            }
                            else
                            {
                                tp = nombreàmot(Convert.ToInt64(mystr));
                                broadcast(tp);
                            }

                        }
                    }
                }

                lock (_lock) list_clients.Remove(id);
                client.Client.Shutdown(SocketShutdown.Both);
                client.Close();
                Console.WriteLine("Client Disconnected!!!!");
                // khi mà client ngắt kết nối
                Console.WriteLine("So ket noi con lai: " + list_clients.Count);

            }
            catch (Exception)
            { }

        }

        public static void broadcast(string data) // hàm xử lý việc gửi lại cho client
        {
            byte[] buffer = Encoding.UTF8.GetBytes(data + Environment.NewLine);

            lock (_lock)
            {
                foreach (TcpClient c in list_clients.Values)
                {
                    NetworkStream stream = c.GetStream();

                    stream.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}