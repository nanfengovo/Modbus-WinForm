using NModbus;
using NModbus.Extensions.Enron;
using System.Net;
using System.Net.Sockets;

namespace Modbus_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {

            #region 定义初始的变量

            //ip
            string IP = TxtIP.Text;
            //port
            int Port = Convert.ToInt32(TxtPort.Text);
            //Slaveid
            byte SlaveID = Convert.ToByte(Txtid.Text);
            //Function
            int Function = Convert.ToInt32(TxtFun.Text);
            //Address
            ushort Address = Convert.ToUInt16(TxtAdd.Text);
            //Query
            ushort Query = Convert.ToUInt16(SelectQuery.Text);

            #endregion

            #region 核心逻辑
            try
            {
                using (var Client = new TcpClient(IP, Port))
                {
                    //使用NMdobus工厂创建NModbus主站
                    var factory = new ModbusFactory();
                    var master = factory.CreateMaster(Client);

                    switch (Function)
                    {
                        case 1:
                            var result1 = master.ReadCoils(SlaveID, Address, Query);
                            //PrintResult(result1,Address);
                            for (int i = 0; i < result1.Length; i++)
                            {
                                TxtResult.AppendText($"寄存器 {Address + i}: {result1[i]}\r\n");
                            }
                            break;
                        case 2:
                            var result2 = master.ReadInputs(SlaveID, Address, Query);
                            //PrintResult(result1,Address);
                            for (int i = 0; i < result2.Length; i++)
                            {
                                TxtResult.AppendText($"寄存器 {Address + i}: {result2[i]}\r\n");
                            }
                            break;
                        case 3:
                            var result3 = master.ReadHoldingRegisters(SlaveID, Address, Query);
                            //PrintResult(result3,Address);
                            for (int i = 0; i < result3.Length; i++)
                            {
                                TxtResult.AppendText($"寄存器 {Address + i}: {result3[i]}\r\n");
                            }
                            break;
                        case 4:
                            var result4 = master.ReadInputRegisters(SlaveID, Address, Query);
                            //PrintResult(result3,Address);
                            for (int i = 0; i < result4.Length; i++)
                            {
                                TxtResult.AppendText($"寄存器 {Address + i}: {result4[i]}\r\n");
                            }
                            break;

                    }

                    

                    
                   

                }
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message) ;
            }

           

            #endregion


        }

        private void PrintResult(ushort[] result ,ushort Address)
        {
            for (int i = 0; i < result.Length; i++)
            {
                TxtResult.AppendText($"寄存器 {Address + i}: {result[i]}\r\n");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region 避免重复输入
            TxtIP.Text = "127.0.0.1";
            TxtPort.Text = "502";
            #endregion

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtResult.Clear();
        }
    }
}
