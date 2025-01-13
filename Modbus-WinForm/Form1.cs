using NLog;
using NModbus;
using NModbus.Extensions.Enron;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Modbus_WinForm
{
    public partial class Form1 : Form
    {

        //Log
        public static Logger logger = LogManager.GetCurrentClassLogger();

        public Form1()
        {
            InitializeComponent();
            logger.Info("程序启动！！！");
        }

        /// <summary>
        /// 禁用按钮
        /// </summary>
        private void DisableButtons()
        {
            BtnRead.Enabled = false;
            BtnClear.Enabled = false;
            BtnConn.Enabled = false;
        }

        /// <summary>
        /// 启用按钮
        /// </summary>
        private void EnableButtons()
        {
            BtnRead.Enabled = true;
            BtnClear.Enabled = true;
            BtnConn.Enabled = true;
        }



        /// <summary>
        /// 验证ip合法性
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
            //点击按钮后就禁用
            DisableButtons();

            #region 填写提示
            //if (TxtIP.Text == null)
            //{
            //    MessageBox.Show("请填写设备的IP地址！！");
            //}
            //else if (TxtPort.Text == null)
            //{
            //    MessageBox.Show("请填写设备的端口号！！");
            //}
            //else if (Txtid.Text == null)
            //{
            //    MessageBox.Show("请填写设备号！！");
            //}
            //else if (TxtFun.Text == null)
            //{
            //    MessageBox.Show("请填写设备的Function！！");
            //}
            //else if (TxtAdd.Text == null)
            //{
            //    MessageBox.Show("请填写设备的读取地址！！");
            //}
            //else if (SelectQuery.Text == null)
            //{
            //    MessageBox.Show("请填写设备的读取数量！！");
            //}

            #endregion


            try
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
                    if (!IsValidIPAddress(IP))
                    {
                        MessageBox.Show("输入的IP地址不合法！！请重新输入！");
                        logger.Warn("输入的IP地址不合法！！请重新输入！");
                        TxtIP.Clear();
                        logger.Info("由于输入的地址不合法系统自动清除！");

                    }
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
                                    TxtResult.AppendText($"线圈地址 {Address + i}: {result1[i]}\r\n");
                                    logger.Info($"成功对ip为{IP},端口为{Port}的设备起始地址为{Address}数量为{Query}读取，设备id为{SlaveID},读取结果为线圈地址 {Address + i}: {result1[i]}\r\n");
                                }
                                break;
                            case 2:
                                var result2 = master.ReadInputs(SlaveID, Address, Query);
                                //PrintResult(result1,Address);
                                for (int i = 0; i < result2.Length; i++)
                                {
                                    TxtResult.AppendText($"输入状态地址 {Address + i}: {result2[i]}\r\n");
                                    logger.Info($"成功对ip为{IP},端口为{Port}的设备起始地址为{Address}数量为{Query}读取，设备id为{SlaveID},读取结果为输入状态地址 {Address + i}: {result2[i]}\r\n");
                                }
                                break;
                            case 3:
                                var result3 = master.ReadHoldingRegisters(SlaveID, Address, Query);
                                //PrintResult(result3,Address);
                                for (int i = 0; i < result3.Length; i++)
                                {
                                    TxtResult.AppendText($"保持寄存器地址 {Address + i}: {result3[i]}\r\n");
                                    logger.Info($"成功对ip为{IP},端口为{Port}的设备起始地址为{Address}数量为{Query}读取，设备id为{SlaveID},读取结果为保持寄存器地址 {Address + i}: {result3[i]}\r\n");
                                }
                                break;
                            case 4:
                                var result4 = master.ReadInputRegisters(SlaveID, Address, Query);
                                //PrintResult(result3,Address);
                                for (int i = 0; i < result4.Length; i++)
                                {
                                    TxtResult.AppendText($"输入寄存器地址 {Address + i}: {result4[i]}\r\n");
                                    logger.Info($"成功对ip为{IP},端口为{Port}的设备起始地址为{Address}数量为{Query}读取，设备id为{SlaveID},读取结果为输入寄存器地址 {Address + i}: {result4[i]}\r\n");
                                }
                                break;
                        }
                    }
                }
                catch (NModbus.SlaveException ex)
                {
                    if (ex.FunctionCode == 129)
                    {
                        MessageBox.Show("地址数量超过可读取的数量！！！");
                        logger.Error(ex.StackTrace);
                    }
                    else if (ex.FunctionCode == 130 || ex.FunctionCode == 131 || ex.FunctionCode == 132)
                    {
                        MessageBox.Show("功能码和从站不匹配！！");
                        logger.Warn(ex.Message);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                        logger.Warn(ex.Message);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {

                MessageBox.Show("存在输入框没填或输入的格式不正确！");
                logger.Warn(ex.Message);
            }
            finally
            {
                //启用按钮
                EnableButtons();
            }




        }


        /// <summary>
        /// HelpTest
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            #region 避免重复输入
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
            logger.Info("执行了一次清空结果！");
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

                if (!IsValidIPAddress(IP))
                {
                    MessageBox.Show("输入的IP地址不合法！！请重新输入！");
                    TxtIP.Clear();
                    logger.Info($"输入的IP地址不合法！！请重新输入！！");

                }

                try
                {
                    var Client = new TcpClient(IP, Port);
                    MessageBox.Show("连接成功！！！");
                    logger.Info($"成功与ip为{IP},端口为{Port}的设备建立连接！！");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    logger.Warn(ex.Message);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("IP或Port不能为空！！");
                logger.Warn(ex.Message);
            }


        }


    }
}
