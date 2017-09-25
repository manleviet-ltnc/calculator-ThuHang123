using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace calculator
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        bool isTypingNumber = false;
        enum PhepToan { Cong, Tru, Nhan, Chia, PhanTram };
        PhepToan pheptoan;

        double nho;

        private void NhapSo(object sender, EventArgs e)
        {
            string so = ((Button)sender).Text;
            NhapSo(so);
        }
        private void NhapSo(string so)
        {
            if (isTypingNumber)
                lblDisplay.Text = lblDisplay.Text + so;
            else
            {
                lblDisplay.Text = so;
                isTypingNumber = true;
            }
        }
        private void NhapPhepToan(object sender, EventArgs e)
        {
            TinhKetQua();
            Button btn = (Button)sender;
            switch (btn.Text)
            {
                case "+": pheptoan = PhepToan.Cong; break;
                case "-": pheptoan = PhepToan.Tru; break;
                case "*": pheptoan = PhepToan.Nhan; break;
                case "/": pheptoan = PhepToan.Chia; break;
                case "%": pheptoan = PhepToan.PhanTram; break;
            }

            nho = double.Parse(lblDisplay.Text);
            isTypingNumber = false;

        }

        private void TinhKetQua()
        {
            // tinh toan dua tren: nho, pheptoan, lblDisplay.Text
            double tam = double.Parse(lblDisplay.Text);
            double Ketqua = 0.0;
            switch (pheptoan)
            {
                case PhepToan.Cong: Ketqua = nho + tam; break;
                case PhepToan.Tru: Ketqua = nho - tam; break;
                case PhepToan.Nhan: Ketqua = nho * tam; break;
                case PhepToan.Chia: Ketqua = nho / tam; break;
                case PhepToan.PhanTram: Ketqua = 100 / tam; break;
            }
            // gan ket qua tinh duoc len lblDisplay
            lblDisplay.Text = Ketqua.ToString();

        }

        private void btnBang_Click(object sender, EventArgs e)
        {
            TinhKetQua();
            isTypingNumber = false;
        }

        private void btnDoiDau_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Contains("-")) //Kiểm tra có dấu - chưa
            {
                lblDisplay.Text = lblDisplay.Text.Remove(0, 1);
            }
            else
            lblDisplay.Text = "-" + lblDisplay.Text;
        }

        private void btnThapPhan_Click(object sender, EventArgs e)
        {
          if (lblDisplay.Text.Contains("."))
          {
                return;
          }
         lblDisplay.Text += btnThapPhan.Text;
        }

        private void btnPhanTram_Click(object sender, EventArgs e)
        {
            double tam = 100 * double.Parse(lblDisplay.Text);
            lblDisplay.Text= tam.ToString();
            isTypingNumber = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length > 0)
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1, 1);
        }

        private void btnCanBac2_Click(object sender, EventArgs e)
        {
            double tam = Math.Sqrt(double.Parse(lblDisplay.Text));
            lblDisplay.Text = tam.ToString();
            isTypingNumber = false;
        }

        private void btnNho_Click(object sender, EventArgs e)
        {
            nho = 0;
            lblDisplay.ResetText();
        }

        private void FrmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    NhapSo("" + e.KeyChar);
                    break;
            }
        }
    }
}
