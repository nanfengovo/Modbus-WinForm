using NModbus;
using NModbus.Extensions.Enron;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Modbus_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ��֤ip�Ϸ���
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        private bool IsValidIPAddress(string ipAddress)
        {
            string pattern = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(ipAddress);
        }

        /// <summary>
        /// read
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRead_Click(object sender, EventArgs e)
        {


            #region ��д��ʾ
            //if (TxtIP.Text == null)
            //{
            //    MessageBox.Show("����д�豸��IP��ַ����");
            //}
            //else if (TxtPort.Text == null)
            //{
            //    MessageBox.Show("����д�豸�Ķ˿ںţ���");
            //}
            //else if (Txtid.Text == null)
            //{
            //    MessageBox.Show("����д�豸�ţ���");
            //}
            //else if (TxtFun.Text == null)
            //{
            //    MessageBox.Show("����д�豸��Function����");
            //}
            //else if (TxtAdd.Text == null)
            //{
            //    MessageBox.Show("����д�豸�Ķ�ȡ��ַ����");
            //}
            //else if (SelectQuery.Text == null)
            //{
            //    MessageBox.Show("����д�豸�Ķ�ȡ��������");
            //}

            #endregion


            try
            {
                #region �����ʼ�ı���

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



                #region �����߼�
                try
                {
                    if (!IsValidIPAddress(IP))
                    {
                        MessageBox.Show("�����IP��ַ���Ϸ��������������룡");
                        TxtIP.Clear();

                    }
                    using (var Client = new TcpClient(IP, Port))
                    {
                        //ʹ��NMdobus��������NModbus��վ
                        var factory = new ModbusFactory();
                        var master = factory.CreateMaster(Client);

                        switch (Function)
                        {
                            case 1:
                                var result1 = master.ReadCoils(SlaveID, Address, Query);
                                //PrintResult(result1,Address);
                                for (int i = 0; i < result1.Length; i++)
                                {
                                    TxtResult.AppendText($"��Ȧ��ַ {Address + i}: {result1[i]}\r\n");
                                }
                                break;
                            case 2:
                                var result2 = master.ReadInputs(SlaveID, Address, Query);
                                //PrintResult(result1,Address);
                                for (int i = 0; i < result2.Length; i++)
                                {
                                    TxtResult.AppendText($"����״̬��ַ {Address + i}: {result2[i]}\r\n");
                                }
                                break;
                            case 3:
                                var result3 = master.ReadHoldingRegisters(SlaveID, Address, Query);
                                //PrintResult(result3,Address);
                                for (int i = 0; i < result3.Length; i++)
                                {
                                    TxtResult.AppendText($"���ּĴ�����ַ {Address + i}: {result3[i]}\r\n");
                                }
                                break;
                            case 4:
                                var result4 = master.ReadInputRegisters(SlaveID, Address, Query);
                                //PrintResult(result3,Address);
                                for (int i = 0; i < result4.Length; i++)
                                {
                                    TxtResult.AppendText($"����Ĵ�����ַ {Address + i}: {result4[i]}\r\n");
                                }
                                break;

                        }






                    }
                }
                catch (NModbus.SlaveException ex)
                {
                    if (ex.FunctionCode == 129)
                    {
                        MessageBox.Show("��ַ���������ɶ�ȡ������������");
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }

                }



                #endregion
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error: {ex.Message}");
            }

           


        }

       
        /// <summary>
        /// HelpTest
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            #region �����ظ�����
            TxtIP.Text = "127.0.0.1";
            TxtPort.Text = "502";
            #endregion

        }


        /// <summary>
        /// Clear Result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtResult.Clear();
        }


        /// <summary>
        /// Test Connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConn_Click(object sender, EventArgs e)
        {
           
            try
            {
                //ip
                string IP = TxtIP.Text;
                //port
                int Port = Convert.ToInt32(TxtPort.Text);

                if(!IsValidIPAddress(IP))
                {
                    MessageBox.Show("�����IP��ַ���Ϸ��������������룡");
                    TxtIP.Clear();

                }
               
                try
                {
                    var Client = new TcpClient(IP, Port);
                    MessageBox.Show("���ӳɹ�������");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("IP��Port����Ϊ�գ���");
            }
           

        }
    }
}
