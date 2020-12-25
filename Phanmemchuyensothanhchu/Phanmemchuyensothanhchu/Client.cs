using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phanmemchuyensothanhchu
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        /*IPEndPoint ipe;
        Socket client;
        TcpListener tcplistener;*/

        #region TiengViet

        string[] numText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');

        //Đọc hàng chục: 123 -> một trăm hai ba
        private string DocHangChuc(double so, bool daydu)
        {
            string chuoi = "";

            //Hàm lấy chữ số hàng chục
            Int64 chuc = Convert.ToInt64(Math.Floor((double)(so / 10))); //hàm Math.Floor: làm tròn xuống (21/10 = 2.1 -> 2)

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

        private string DocHangTram(double so, bool daydu)
        {
            string chuoi = "";

            Int64 tram = Convert.ToInt64(Math.Floor((double)so / 100));

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

        private string DocHangTrieu(double so, bool daydu)
        {
            string chuoi = "";

            //Lấy số hàng triệu
            Int64 trieu = Convert.ToInt64(Math.Floor((double)so / 1000000));

            //Lấy phần dư sau số hàng triệu (2,123,000 -> so: 123,000)
            so = so % 1000000;

            if (trieu > 0)
            {
                chuoi = DocHangTram(trieu, daydu) + " triệu";
                daydu = true;
            }

            //Lấy số hàng nghìn
            Int64 nghin = Convert.ToInt64(Math.Floor((double)so / 1000));

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

        public string ChuyenSangChuoi(double so)
        {
            if (so == 0) return numText[0];

            string chuoi = "", hauto = "", dau = "";

            if (so < 0)
            {
                dau = "Âm";

                so *= -1;
            }

            while (so > 0)
            {
                //Lấy số hàng tỷ
                double ty = so % 1000000000;

                //Lấy phần dư sau số hàng tỷ
                so = Convert.ToInt64(Math.Floor((double)so / 1000000000));

                if (so > 0)
                {
                    chuoi =  DocHangTrieu(ty, true) + hauto + chuoi;
                }
                else
                {
                    chuoi = DocHangTrieu(ty, false) + hauto + chuoi;
                }

                hauto = " tỷ";
            }
            
            return dau + chuoi;

        }

        #endregion

        #region TiengAnh

        string[] numtextforE = "zero;one;two;three;four;five;six;seven;eight;nine".Split(';');

        public static string NumberToWords(long number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

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

        #region ThapPhanTiengViet
        public string DocPhanThapPhan(string so)
        {
            string[] numText1 = { " không", " một", " hai", " ba", " bốn", " năm", " sáu", " bảy", " tám", " chín" };

            string total = "";
            string chuoi = "";

            for(int i = 0; i<so.Length; i++)
            {
                char a = so[i];
                int b = Convert.ToInt32(new string(a, 1));
                chuoi = numText1[b];
                total += chuoi;
            }

            return total;
        }
        #endregion

        #region ThapPhanTiengAnh
        public string ReadDecimal(string number)
        {
            string[] numText2 = { " zero", " one", " two", " three", " four", " five", " six", " seven", " eight", " nine" };

            string Total = "";
            string words = "";

            for (int i = 0; i < number.Length; i++)
            {
                char c = number[i];
                int d = Convert.ToInt32(new string(c, 1));
                words = numText2[d];
                Total += words;
            }

            return Total;
        }
        #endregion

        #region Events
        private void txbSocanchuyen_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txbSocanchuyen.Text, "  ^ [0-9]"))
            {
                txbSocanchuyen.Text = "";
            }
        }

        private void txbSocanchuyen_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '.'  && e.KeyChar != '-')
            {                
                e.Handled = true;             
            }
            //if (e.KeyChar == '.' && txbSocanchuyen.Text.IndexOf('.') > -1) e.Handled = true;

            //else if (e.KeyChar == '-' && txbSocanchuyen.Text.IndexOf('-') > -1) e.Handled = true;

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            String st = txbSocanchuyen.Text;

            double n;

            if (!double.TryParse(st, out n))
            {
                MessageBox.Show("Sai định dạng", "Sai định dạng", MessageBoxButtons.OK);

                return;
            }

            if (txbSocanchuyen.Text == " ")
            {
                MessageBox.Show("Mời bạn nhập lại dãy số cần chuyển đổi");
            }
                                    
            if (st.Contains("."))
            {
                string[] parts = st.Split('.');
                string part1 = parts[0];
                string part2 = parts[1];
                long d = Int64.Parse(part2);

                if(d==0)
                {
                    txbKetquaTV.Text = ChuyenSangChuoi(Double.Parse(part1));
                    txbKetquaTA.Text = NumberToWords(Int64.Parse(part1));
                }

                else if (part2 == "")
                {
                    txbKetquaTV.Text = ChuyenSangChuoi(Double.Parse(part1));
                    txbKetquaTA.Text = NumberToWords(Int64.Parse(part1));
                }

                else
                {
                    char[] charsToTrim = { '0' };
                    string[] numbers = part2.Split();
                    foreach (string number in numbers)
                    {
                        string part3 = number.TrimEnd(charsToTrim);

                        txbKetquaTV.Text = ChuyenSangChuoi(Double.Parse(part1)) + " phẩy" + DocPhanThapPhan(part3);
                        txbKetquaTA.Text = NumberToWords(Int64.Parse(part1)) + " point " + ReadDecimal(part3);
                    }
                }
                                
            }

            else
            {
                txbKetquaTV.Text = ChuyenSangChuoi(Double.Parse(txbSocanchuyen.Text));
                txbKetquaTA.Text = NumberToWords(Int64.Parse(txbSocanchuyen.Text));
            }

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txbSocanchuyen.Clear();
            txbKetquaTV.Clear();
            txbKetquaTA.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        
    }
}
