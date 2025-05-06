using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using UWC.Utilities;

namespace UHFAPP
{
    public class UHFAPI
    {



        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UHFSetTempVal(byte tempVal);
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UHFGetTempVal(byte[] tempVal);


        // [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        // public extern static int UHFSetIp(byte[] ip, byte[] port);
        //[DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        //public extern static int UHFGetIp(byte[] ip, byte[] port);

        /*
         * 函数功能：  获取本机 IP 和端口号
         * 输出参数：  ipbuf + postbuf， IP+端口号
			           mask:掩码，4字节
			           gate:网关，4字节
         * 返回值：   0:成功    其它：失败
         */
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UHFGetIp(byte[] ip, byte[] port, byte[] mask, byte[] gate);
        /*
         * 函数功能：  设置本机 IP 和端口号
         * 输入参数：  ipbuf： IP， 
			           postbuf：端口号
			           mask:掩码，4字节
			           gate：网关，4字节

         * 返回值：   0:成功    其它：失败
         */
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UHFSetIp(byte[] ipbuf, byte[] postbuf, byte[] mask, byte[] gate);



        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UHFSetDestIp(byte[] ip, byte[] port);
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UHFGetDestIp(byte[] ip, byte[] port);

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UHFSetWorkMode(byte mode);
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UHFGetWorkMode(byte[] mode);

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UHFSetBeep(byte mode);
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UHFGetBeep(byte[] mode);



        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int TCPConnect(StringBuilder ip, uint hostport);
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void TCPDisconnect();

        //打开串口
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int ComOpenWithBaud(int port, int baudrate);

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int ComOpen(int comName);
        //关闭串口
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void ClosePort();

        /**********************************************************************************************************
           * 功能：获取硬件版本号
           * 输出：version[0]--版本号长度 ,  version[1--x]--版本号
           *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetHardwareVersion(byte[] version);
        /**********************************************************************************************************
          * 功能：获取软件版本号
          * 输出：version[0]--版本号长度 ,  version[1--x]--版本号
          *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetSoftwareVersion(byte[] version);
        /**********************************************************************************************************
           * 功能：获取ID号
           * 输出：id--整型ID号
           *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetDeviceID(ref int id);

        /**********************************************************************************************************
        * 功能：设置功率
        * 输入：saveflag  -- 1:保存设置   0：不保存
        * 输入：uPower -- 功率（DB）
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetPower(byte save, byte uPower);
        /**********************************************************************************************************
        * 功能：设置天线功率
        * 输入：saveflag  -- 1:保存设置   0：不保存
        * 输入：num -- 天线编号(1~N)
                read_power -- 接收功率（DB）
                write_power -- 发送功率（DB）
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetAntennaPower(byte save, byte num, byte read_power, byte write_power);
        /**********************************************************************************************************
        * 功能：获取功率
        * 输出：uPower -- 功率（DB）
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetPower(ref byte uPower);
        /**********************************************************************************************************
        * 功能：获取天线功率
        * 输出：ppower -- 天线功率,格式为（天线编号+读功率+写功率+天线编号+读功率+写功率+.......+天线编号+读功率+写功率）
		        nBytesReturned -- ppower数据长度 
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetAntennaPower(byte[] ppower, int[] nBytesReturned);




        /**********************************************************************************************************
        * 功能：设置跳频
        * 输入：nums -- 跳频个数
        * 输入：Freqbuf--频点数组（整型） ，如920125，921250.....
       *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetJumpFrequency(byte nums, int[] Freqbuf);
        /**********************************************************************************************************
        * 功能：获取跳频
        * 输出：Freqbuf[0]--频点个数， Freqbuf[1]..[x]--频点数组（整型）
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetJumpFrequency(int[] Freqbuf);
        /**********************************************************************************************************
        * 功能：设置Gen2参数
        * 输入：
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetGen2(byte Target, byte Action, byte T, byte Q, byte StartQ, byte MinQ, byte MaxQ, byte D, byte C, byte P, byte Sel, byte Session, byte G, byte LF);
        /**********************************************************************************************************
        * 功能：获取Gen2参数
        * 输入：
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetGen2(ref byte Target, ref byte Action, ref byte T, ref byte Q, ref byte StartQ, ref byte MinQ, ref byte MaxQ, ref byte D, ref byte Coding, ref byte P, ref byte Sel, ref byte Session, ref byte G, ref byte LF);
        /**********************************************************************************************************
        * 功能：设置CW
        * 输入：flag -- 1:开CW，  0：关CW
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetCW(byte flag);
        /**********************************************************************************************************
        * 功能：获取CW
        * 输出：flag -- 1:开CW，  0：关CW
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetCW(ref byte flag);

        /**********************************************************************************************************
        * 功能：天线设置
        * 输入：saveflag -- 1:掉电保存，  0：不保存
        * 输入：buf--2bytes, 共16bits, 每bit 置1选择对应天线
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetANT(byte saveflag, byte[] buf);

        /**********************************************************************************************************
        * 功能：获取天线设置
        * 输出：buf--2bytes, 共16bits,
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetANT(byte[] buf);

        /**********************************************************************************************************
        * 功能：区域设置
        * 输入：saveflag -- 1:掉电保存，  0：不保存
        * 输入：region -- 0x01(China1),0x02(China2),0x04(Europe),0x08(USA),0x16(Korea),0x32(Japan)
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetRegion(byte saveflag, byte region);

        /**********************************************************************************************************
        * 功能：获取区域设置
        * 输出：region -- 0x01(China1),0x02(China2),0x04(Europe),0x08(USA),0x16(Korea),0x32(Japan)
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetRegion(ref byte region);

        /**********************************************************************************************************
        * 功能：获取当前温度
        * 输出：temperature -- 整型
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetTemperature(ref int temperature);

        /**********************************************************************************************************
        * 功能：设置温度保护
        * 输入：flag -- 1:温度保护， 0：无温度保护
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetTemperatureProtect(byte flag);
        /**********************************************************************************************************
        * 功能：获取温度保护
        * 输出：flag -- 1:温度保护， 0：无温度保护
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetTemperatureProtect(ref byte flag);
        /**********************************************************************************************************
        * 功能：设置天线工作时间
        * 输入：antnum -- 天线号
        * 输入：saveflag -- 1:掉电保存， 0：不保存
        * 输入：WorkTime -- 工作时间 ，单位ms, 范围 10-65535ms
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetANTWorkTime(byte antnum, byte saveflag, int WorkTime);
        /**********************************************************************************************************
        * 功能：获取天线工作时间
        * 输入：antnum -- 天线号
        * 输出：WorkTime -- 工作时间 ，单位ms, 范围 10-65535ms
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetANTWorkTime(byte antnum, ref int WorkTime);
        /**********************************************************************************************************
        * 功能：设置链路组合
        * 输入：saveflag -- 1:掉电保存， 0：不保存
        * 输入：mode --  0:DSB_ASK/FM0/40KHZ , 1:PR_ASK/Miller4/250KHZ , 2:PR_ASK/Miller4/300KHZ, 3:DSB_ASK/FM0/400KHZ
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetRFLink(byte saveflag, byte mode);

        /**********************************************************************************************************
        * 功能：获取链路组合
        * 输出：mode --  0:DSB_ASK/FM0/40KHZ , 1:PR_ASK/Miller4/250KHZ , 2:PR_ASK/Miller4/300KHZ, 3:DSB_ASK/FM0/400KHZ
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetRFLink(ref byte uMode);
        /**********************************************************************************************************
        * 功能：设置FastID功能
        * 输入：flag -- 1:开启， 0：关闭
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetFastID(byte flag);
        /**********************************************************************************************************
        * 功能：获取FastID功能
        * 输出：flag -- 1:开启， 0：关闭
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetFastID(ref byte flag);
        /**********************************************************************************************************
        * 功能：设置Tagfocus功能
        * 输入：flag -- 1:开启， 0：关闭
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetTagfocus(byte flag);
        /**********************************************************************************************************
        * 功能：获取Tagfocus功能
        * 输出：flag -- 1:开启， 0：关闭
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetTagfocus(ref byte flag);
        /**********************************************************************************************************
        * 功能：设置软件复位
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetSoftReset();
        /**********************************************************************************************************
        * 功能：设置Dual和Singel模式
        * 输入：saveflag -- 1:掉电保存， 0：不保存
        * 输入：mode -- 1:设置Singel模式， 0：设置Dual模式
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetDualSingelMode(byte saveflag, byte mode);
        /**********************************************************************************************************
        * 功能：获取Dual和Singel模式
        * 输出：mode -- 1:设置Singel模式， 0：设置Dual模式
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetDualSingelMode(ref byte mode);
        /**********************************************************************************************************
        * 功能：设置寻标签过滤设置
        * 输入：saveflag -- 1:掉电保存， 0：不保存
        * 输入：bank --  0x01:EPC , 0x02:TID, 0x03:USR
        * 输入：startaddr 起始地址，单位：字节
        * 输入：datalen 数据长度， 单位:字节
        * 输入：databuf 数据
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetFilter(byte saveflag, byte bank, int startaddr, int datalen, byte[] databuf);
        /**********************************************************************************************************
        * 功能：设置EPC和TID模式
        * 输入：saveflag -- 1:掉电保存， 0：不保存
        * 输入：mode -- 1：开启EPC和TID， 0:关闭
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetEPCTIDMode(byte saveflag, byte mode);
        /**********************************************************************************************************
        * 功能：获取EPC和TID模式
        * 输出：mode -- 1：开启EPC和TID， 0:关闭
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetEPCTIDMode(ref byte mode);

        /**********************************************************************************************************
       * 功能：恢复出厂设置
       *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetDefaultMode();
        /**********************************************************************************************************
        * 功能：单次盘存标签
        * 输出：uLenUii -- UII长度
        * 输出：uUii -- UII数据
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFInventorySingle(ref byte uLenUii, byte[] uUii);
        /**********************************************************************************************************
        * 功能：连续盘存标签
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFInventory();
        /**********************************************************************************************************
        * 功能：停止盘存标签
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFStopGet();
        /**********************************************************************************************************
          * 功能：获取连续盘存标签数据
          * 输出：uLenUii -- UII长度
          * 输出：uUii -- UII数据
          *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHF_GetReceived_EX(ref int uLenUii, byte[] uUii);
        /**********************************************************************************************************
        * 功能：读标签数据区
        * 输入：uAccessPwd -- 4字节密码
        * 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
        * 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
        * 输入：FilterLen -- 启动过滤的长度， 单位：字节
        * 输入：FilterData -- 启动过滤的数据
        * 输入：uBank -- 读取数据的bank
        * 输入：uPtr --  读取数据的起始地址， 单位：字
        * 输入：uCnt --  读取数据的长度， 单位：字
        * 输出：uReadDatabuf --  读取到的数据
        * 输出：uReadDataLen --  读取到的数据长度
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFReadData(byte[] uAccessPwd,
             byte FilterBank,
             int FilterStartaddr,
             int FilterLen,
             byte[] FilterData,
             byte uBank,
             int uPtr,
             int uCnt,
             byte[] uReadDatabuf,
             ref int uReadDataLen);

        /**********************************************************************************************************
          * 功能：写标签数据区
          * 输入：uAccessPwd -- 4字节密码
          * 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
          * 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：bit
          * 输入：FilterLen -- 启动过滤的长度， 单位：bit
          * 输入：FilterData -- 启动过滤的数据
          * 输入：uBank -- 写入数据的bank
          * 输入：uPtr --  写入数据的起始地址， 单位：字
          * 输入：uCnt --  写入数据的长度， 单位：字
          * 输入：uWriteDatabuf --  写入的数据
          *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFWriteData(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte uBank, int uPtr, byte uCnt, byte[] uDatabuf);
        /**********************************************************************************************************
        * 功能：LOCK标签
        * 输入：uAccessPwd -- 4字节密码
        * 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
        * 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
        * 输入：FilterLen -- 启动过滤的长度， 单位：字节
        * 输入：FilterData -- 启动过滤的数据
        * 输入：lockbuf --  3字节，第0-9位为Action位， 第10-19位为Mask位
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFLockTag(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte[] lockbuf);

        /**********************************************************************************************************
        * 功能：KILL标签
        * 输入：uAccessPwd -- 4字节密码
        * 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
        * 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
        * 输入：FilterLen -- 启动过滤的长度， 单位：字节
        * 输入：FilterData -- 启动过滤的数据
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFKillTag(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData);

        /**********************************************************************************************************
          * 功能：BlockWrite 特定长度的数据到标签的特定地址
          * 输入：uAccessPwd -- 4字节密码
          * 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
          * 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
          * 输入：FilterLen -- 启动过滤的长度， 单位：字节
          * 输入：FilterData -- 启动过滤的数据
          * 输入：uBank -- 块号  1：EPC, 2:TID, 3:USR
          * 输入：uPtr --  写入数据的起始地址， 单位：字
          * 输入：uCnt --   写入数据的长度， 单位：字
          * 输入：uWriteDatabuf --  写入的数据
          *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFBlockWriteData(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte uBank, int uPtr, int uCnt, byte[] uDatabuf);

        /**********************************************************************************************************
        * 功能：BlockErase 特定长度的数据到标签的特定地址
        * 输入：uAccessPwd -- 4字节密码
        * 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
        * 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
        * 输入：FilterLen -- 启动过滤的长度， 单位：字节
        * 输入：FilterData -- 启动过滤的数据
        * 输入：uBank -- 块号  1：EPC, 2:TID, 3:USR
        * 输入：uPtr --  读取数据的起始地址， 单位：字
        * 输入：uCnt --  读取数据的长度， 单位：字
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFBlockEraseData(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte uBank, int uPtr, byte uCnt);
        /**********************************************************************************************************
        * 功能：设置QT命令参数
        * 输入：uAccessPwd -- 4字节密码
        * 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
        * 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
        * 输入：FilterLen -- 启动过滤的长度， 单位：字节
        * 输入：FilterData -- 启动过滤的数据
        * 输入：QTData --  bit0：（0：表示无近距离控制 ， 1：表示启用近距离控制）  bit1：(0:表示启用public Memory map, 1：启用public memory map)
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetQT(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte QTData);
        /**********************************************************************************************************
        * 功能：获取QT命令参数
        * 输入：uAccessPwd -- 4字节密码
        * 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
        * 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
        * 输入：FilterLen -- 启动过滤的长度， 单位：字节
        * 输入：FilterData -- 启动过滤的数据
        * 输出：QTData --  bit0：（0：表示无近距离控制 ， 1：表示启用近距离控制）  bit1：(0:表示启用public Memory map, 1：启用public memory map)
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetQT(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, ref byte QTData);
        /**********************************************************************************************************
        * 功能：QT标签读操作
        * 输入：uAccessPwd -- 4字节密码
        * 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
        * 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
        * 输入：FilterLen -- 启动过滤的长度， 单位：字节
        * 输入：FilterData -- 启动过滤的数据
        * 输入：QTData --  bit0：（0：表示无近距离控制 ， 1：表示启用近距离控制）  
        * 输入：uBank -- 块号  1：EPC, 2:TID, 3:USR
        * 输入：uPtr --  读取数据的起始地址， 单位：字
        * 输入：uCnt --  读取数据的长度， 单位：字
        * 输出：uReadDatabuf --  读出的数据
        * 输出：uReadDataLen --  读出的数据长度
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFReadQT(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte QTData, byte uBank, int uPtr, byte uCnt, byte[] uReadDatabuf, ref byte uReadDataLen);
        /**********************************************************************************************************
        * 功能：QT标签写操作
        * 输入：uAccessPwd -- 4字节密码
        * 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
        * 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
        * 输入：FilterLen -- 启动过滤的长度， 单位：字节
        * 输入：FilterData -- 启动过滤的数据
        * 输入：QTData --  bit0：（0：表示无近距离控制 ， 1：表示启用近距离控制）  
        * 输入：uBank -- 块号  1：EPC, 2:TID, 3:USR
        * 输入：uPtr --  读取数据的起始地址， 单位：字
        * 输入：uCnt --  读取数据的长度， 单位：字
        * 输入：uWriteDatabuf --  写入的数据
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFWriteQT(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte QTData, byte uBank, int uPtr, byte uCnt, byte[] uDatabuf);
        /**********************************************************************************************************
        * 功能：Block Permalock操作
        * 输入：uAccessPwd -- 4字节密码
        * 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
        * 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
        * 输入：FilterLen -- 启动过滤的长度， 单位：字节
        * 输入：FilterData -- 启动过滤的数据
        * 输入：ReadLock --  bit0：（0：表示Read ， 1：表示Permalock）  
        * 输入：uBank -- 块号  1：EPC, 2:TID, 3:USR
        * 输入：uPtr --  Block起始地址 ，单位为16个块
        * 输入：uRange --  Block范围，单位为16个块
        * 输入：uMaskbuf -- 块掩码数据，2个字节，16bit 对应16个块
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFBlockPermalock(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte ReadLock, byte uBank, int uPtr, byte uRange, byte[] uMaskbuf);

        /**********************************************************************************************************
        * 功能：激活或失效EM4124标签
        * 输入：cmd --整形
        * 输入：uAccessPwd -- 4字节密码
        * 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
        * 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
        * 输入：FilterData -- 启动过滤的数据
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFDeactivate(int cmd, byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData);

        /**********************************************************************************************************
        * 功能：获取协议类型  
        * 输出：type  0x00 表示 ISO18000-6C 协议,    0x01 表示 GB/T 29768 国标协议,      0x02 表示 GJB 7377.1 国军标协议

        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetProtocolType(byte[] type);


        /**********************************************************************************************************
        * 功能：设置协议类型
        * 输入：type  0x00 表示 ISO18000-6C 协议,0x01 表示 GB/T 29768 国标协议,0x02 表示 GJB 7377.1 国军标协议
        * 
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetProtocolType(byte type);
        /**********************************************************************************************************
        * 功能：国标LOCK标签
        * 输入：uAccessPwd -- 4字节密码
        * 输入：FilterBank -- 启动过滤的bank号， 1：EPC, 2:TID, 3:USR
        * 输入：FilterStartaddr -- 启动过滤的起始地址， 单位：字节
        * 输入：FilterLen -- 启动过滤的长度， 单位：字节
        * 输入：FilterData -- 启动过滤的数据

        * 输入：memory 存储区：  0x00 表示标签信息区,   0x10 表示编码区,   0x20 表示安全区,   0x3x 表示用户区 0x30-0x3F 表示用户区编号 0 到编号 15
                config 配置：    0x00 表示配置存储区属性,    0x01 表示配置安全模式


		        action:  

                      配置存储区属性:  0x00:可读可写,  0x01:可读不可写,  0x02:不可读可写,  0x03:不可读不可写

			          配置安全模式:    0x00:保留,   0x01:不需要鉴别,   0x02:需要鉴别,不需要安全通信,   0x03:需要鉴别,需要安全通信

        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGBTagLock(byte[] uAccessPwd, byte FilterBank, int FilterStartaddr, int FilterLen, byte[] FilterData, byte memory, byte config, byte action);



        /**********************************************************************************************************
         * 功能：获取继电器和 IO 控制输出设置状态
         * 输入：outData[0]:    0:低电平   1：高电平
                 outData[1]:    0:低电平   1：高电平
           返回值：2：数据长度    -1：获取失败
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetIOControl(byte[] inputData);

        /**********************************************************************************************************
        * 功能：继电器和 IO 控制输出设置
        * 输入：output1:    0:低电平   1：高电平
                output2:    0:低电平   1：高电平
		        outStatus： 0：断开    1：闭合
          返回值：0：设置成功     -1：设置失败
        * 
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetIOControl(byte output1, byte output2, byte outStatus);



        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetOutputIO(byte[] output, byte outputLen);

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetIOStatus(byte[] statusData, int[] dataLen);



        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFBuildDateTime(byte[] build_date, byte[] build_time);

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetVersionCode(byte[] datetime);


        /**********************************************************************************************************
        * 功能：设置连续寻卡工作及等待时间
        * 输入：DByte4 为掉电保存标志，0 表示不保存，1 表示保存；DByte3、DByte2 为工作时间，高字节在前，DByte1、DByte0 为等待时间，高字节在前


          返回值：0：设置成功     -1：设置失败

        * 
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetWorkTime(byte save, byte work1, byte work2, byte wait1, byte wait2);

        /**********************************************************************************************************
        * 功能：获取连续寻卡工作及等待时间
        * 输出：DByte[0]、DByte[1] 表示工作时间；DByte[2]、DByte[3] 表示等待时间，单位为 ms，高位在前，最大 65535ms

          返回值：4：数据长度    -1：获取失败
        * 
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetWorkTime(byte[] data);



        /**********************************************************************************************************
        * 功能：设置EPC TID USER模式

        * 输入：saveflag -- 1:掉电保存， 0：不保存

        * 输入：Memory 0x00，表示关闭； 0x01，表示开启EPC+TID模式（默认 地址为 0x00, 长 度 为 6 个 字 ） ； 0x02, 表 示 开 启EPC+TID+USER模式

        * 输入：address 为USER区的起始地址（单位为字）
        * 输入：为USER区的长度（单位为字）
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetEPCTIDUSERMode(byte saveflag, byte memory, byte address, byte lenth);
        /**********************************************************************************************************
        * 功能：获取EPC TID USER 模式
        * 输入：rev1 :保留数据，传入0
        * 输入：rev2 :保留数据，传入0
        * 输出：mode[0]，Memory 0x00，表示关闭； 0x01，表示开启EPC+TID模式（默认 地址为 0x00, 长 度 为 6 个 字 ） ； 0x02, 表 示 开 启EPC+TID+USER模式
        * 输出：mode[1]address 为USER区的起始地址（单位为字）
        * 输出：mode[2]为USER区的长度（单位为字）
        * 返回值：3：正确，其它：错误
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetEPCTIDUSERMode(byte rev1, byte rev2, byte[] mode);





        /*
        初始化温度标签
        return: 0--success, -1--unknow error, others--error code
        mask_bank：掩码的数据区(0x00 为 Reserve 0x01 为 EPC， 0x02 表示 TID， 0x03 表示USR)。
        mask_addr：为掩码的地址(bit为单位)，高字节在前。
        mask_len：为掩码的长度(bit为单位)，高字节在前。
        mask_data：为掩码数据，mask_len为0时，这里没有数据
        */

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFInitRegFile(byte mask_bank, int mask_addr, int mask_len, byte[] mask_data);

        /*
        读取标签温度
        return: 0--success, -1--unknow error, others--error code
        mask_bank：掩码的数据区(0x00 为 Reserve 0x01 为 EPC， 0x02 表示 TID， 0x03 表示USR)。
        mask_addr：为掩码的地址(bit为单位)，高字节在前。
        mask_len：为掩码的长度(bit为单位)，高字节在前。
        mask_data：为掩码数据，mask_len为0时，这里没有数据
        temp:output,the point of temperature
        */
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFReadTagTemp(byte mask_bank, int mask_addr, int mask_len, byte[] mask_data, float[] outtemp);

        //level:0-close log output, 3-base log,4-detail log
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetLogLevel(int level);


        /**********************************************************************************************************
        * 功能：设置是否保存传输过程中的日志文件，默认不保存
        * 输入： 
        *save -- 0-不保存、1-保存日志文件
        *返回值：无 
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SaveLogFile(int lsaveevel);



        // zjx 20191127 UHF升级--- start ---
        /*
            flag: 0,upgrade reader application
	              1,upgrade UHF module
	              2,upgrade reader bootloader 
	              3,upgrade Ex10 SDK firmware
            */
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFJump2Boot(byte flag);

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFStartUpd();

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFUpdating(byte[] buf);

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHF_Upgrade(byte[] buf, int length);

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFStopUpdate();



        /**********************************************************************************************************
* 功能：获取读写器软件版本号
* 输出：version[0]--版本号长度 ,  version[1--x]--版本号
*********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetReaderVersion(byte[] version);


        // zjx 20191127 UHF升级--- end ---


        /****************************  zjx 20200416 触发工作模式参数设置获取  -------- start -------- **************************/
        /**********************************************************************************************************
        * 功能：设置触发工作模式参数
        * 输入：
                para[0],	     触发IO：0x00表示触发输入1；0x01表示触发输入2。
                para[1],para[2]  触发工作时间：表示有触发输入时读卡工作时间，单位是10ms，高字节先，低字节后。
                para[3],para[4]	触发时间间隔：表示触发工作时间结束后，间隔多久再判断触发输入IO口进行触发。
                para[5]     	标签输出方式：0x00表示串口输出，0x01表示UDP输出
        * 
        * 返回值：   0:成功    其它：失败
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFSetWorkModePara(byte[] para);


        /**********************************************************************************************************
        * 功能：获取触发工作模式参数
        * 输出：
                para[0],	     触发IO：0x00表示触发输入1；0x01表示触发输入2。
                para[1],para[2]  触发工作时间：表示有触发输入时读卡工作时间，单位是10ms，高字节先，低字节后。
                para[3],para[4]	 触发时间间隔：表示触发工作时间结束后，间隔多久再判断触发输入IO口进行触发。
                para[5]     	 标签输出方式：0x00表示串口输出，0x01表示UDP输出
        * 
        * 返回值：   0:成功    其它：失败
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int UHFGetWorkModePara(byte[] para);


        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UsbOpen();
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void UsbClose();

        /****************************  zjx 20200416 触发工作模式参数设置获取   -------- end -------- **************************/




        /***************************************************************************************/
        //获取当前连接的ip信息
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int LinkGetInfo(byte[] info, int len);

        //选择要操作的id，根据LinkGetInfo获取id信息
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int LinkSelect(int id);

        //获取当前可以操作的id
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int LinkGetSelected();

        //断开所以连接
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void LinkCloseAll();


        /**********************************************************************************************************
        * function:get status of antennas linked
        * out:link_status,status of antenna linked,bit0~bit15 indicate antenna1~antenna16,bit 0/not link 1/linked
        * return：0：success    -1：failure
        *********************************************************************************************************/
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UHFGetAntennaLinkStatus(short[] link_status);

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UHFVerifyVoltage(int[] value);




        /*
           按块写无源电子标签带水墨屏显示
           pwd：4 个字节的块写密码
           sector：掩码的数据区(0x00 为 Reserve，0x01 为 EPC，0x02 表示 TID，0x03 表示 USR)。
           mask_addr：为掩码的地址。
           mask_len：为掩码的长度。
           mask_data：为掩码数据。
           w_addr：为写入数据区的地址（单位是字）。
           w_len：为写入的数据长度（单位是字）。
           w_data：为写入的具体数据（txt 文件中的数据）。
           */
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UHFWriteScreenBlockData(byte[] pwd, byte sector, short mask_addr, short mask_len, byte[] mask_data, byte type,
            short w_addr, short w_len, byte[] w_data);



        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UHFUploadUserParam(byte[] param, short paramLen);

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UHFDownloadUserParam(byte[] param, short[] paramLen);


        //return 0,no data, > 0 tag length, < 0 error code
        //tdata tag data, type+length+content+...+type+length+content
        //type:1-epc,2-tid,3-user,4-rssi,5-antenna,6-id
        //
        // #define CONTENT_TYPE_INVALID        0
        // #define CONTENT_TYPE_EPC            1
        // #define CONTENT_TYPE_TID            2
        // #define CONTENT_TYPE_USER           3
        // #define CONTENT_TYPE_RSSI           4
        // #define CONTENT_TYPE_ANT            5
        // #define CONTENT_TYPE_ID             6
        // #define CONTENT_TYPE_IP             7
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UHFGetTagData(byte[] tdata, int recvlen);


        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UHFInventorySingle(int id);

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UHFStopSingle(int id);

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UHFInventoryById(int id);

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int UHFStopById(int id);



        //   typedef enum{CELL_INVALID=0, CELL_CONNECT_ID=1, CELL_CONNECT_IP, CELL_UHF_PC, CELL_UHF_RSSI, CELL_UHF_ANTENNA, CELL_UHF_EPC, CELL_UHF_TID, CELL_UHF_USER,CELL_UHF_RESERVE,CELL_BARCODE, CELL_UHF_SENSOR} CELL_DATA_TYPE;









        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnDataReceived(IntPtr epc, short recvLen);//[MarshalAs(UnmanagedType.LPArray, SizeConst = 4096)]


        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void setOnDataReceived(OnDataReceived onDataRecved);

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int PrintTextToCursor(int codeType, byte[] text, short len);

        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.StdCall)]
        public extern static int BindUDP(int bindport);
        [DllImport("UHFAPI.dll", CallingConvention = CallingConvention.StdCall)]
        public extern static void UnbindUDP();

        //typedef enum {CHAR_CODE_ASCII=1, CHAR_CODE_GB2312=2, CHAR_CODE_GBK=3, CHAR_CODE_BIG5=4, CHAR_CODE_UTF8=5}ENUM_CHAR_CODE_TYPE;


        //extern "C" UHFAPI_API int PrintTextToCursor(ENUM_CHAR_CODE_TYPE type, const char *text, unsigned short len);

        public static bool GetReceived_EX(ref int uLenUii, ref byte[] uUii)
        {
            if (UHF_GetReceived_EX(ref uLenUii, uUii) == 0)
            {
                return true;
            }
            return false;
        }
        //读取epc
        public static bool uhfGetReceived(ref string epc, ref string tid, ref string rssi, ref string ant)
        {
            int uLen = 0;
            byte[] bufData = new byte[256];
            if (GetReceived_EX(ref uLen, ref bufData))
            {
                //  uUii = 1byteUII长度+UII数据+1byteTID数据+TID+2bytesRSSI
                string epc_data = string.Empty;
                string uii_data = string.Empty;//uii数据
                string tid_data = string.Empty; //tid数据
                string rssi_data = string.Empty;
                string ant_data = string.Empty;
                int uii_len = bufData[0];//uii长度
                int tid_leng = bufData[uii_len + 1];//tid数据长度
                int tid_idex = uii_len + 2;//tid起始位
                int rssi_index = 1 + uii_len + 1 + tid_leng;
                int ant_index = rssi_index + 2;
                string strData = BitConverter.ToString(bufData, 0, uLen).Replace("-", "");
                epc_data = strData.Substring(6, uii_len * 2 - 4);  //Epc
                tid_data = strData.Substring(tid_idex * 2, tid_leng * 2); //Tid
                string temp = strData.Substring(rssi_index * 2, 4);
                int rssiTemp = Convert.ToInt32(temp, 16) - 65535;
                rssi_data = ((float)rssiTemp / 10.0).ToString();// RSSI  =  (0xFED6   -65535)/10
                ant_data = Convert.ToInt32((strData.Substring(ant_index * 2, 2)), 16).ToString();
                epc = epc_data;
                tid = tid_data;
                rssi = rssi_data;
                ant = ant_data;
                return true;
            }
            else
            {
                return false;
            }
        }
        public static UHFTAGInfo uhfGetReceived()
        {
            int uLen = 0;
            byte[] bufData = new byte[256];
            if (GetReceived_EX(ref uLen, ref bufData))
            {
                string epc_data = string.Empty;
                string uii_data = string.Empty;//uii数据
                string tid_data = string.Empty; //tid数据
                string rssi_data = string.Empty;
                string ant_data = string.Empty;
                string user_data = string.Empty;
                int uii_len = bufData[0];//uii长度
                int tid_leng = bufData[uii_len + 1];//tid数据长度
                int tid_idex = uii_len + 2;//tid起始位
                int rssi_index = 1 + uii_len + 1 + tid_leng;
                int ant_index = rssi_index + 2;
                string strData = BitConverter.ToString(bufData, 0, uLen).Replace("-", "");
                epc_data = strData.Substring(6, uii_len * 2 - 4);  //Epc
                if (tid_leng > 12)
                {
                    tid_data = strData.Substring(tid_idex * 2, 24); //Tid
                    user_data = strData.Substring(tid_idex * 2 + 24, (tid_leng - 12) * 2); //Tid
                }
                else
                {
                    tid_data = strData.Substring(tid_idex * 2, tid_leng * 2); //Tid
                    if (tid_data.Length < 8)
                    {
                        tid_data = "";
                    }
                }
                string temp = strData.Substring(rssi_index * 2, 4);
                int rssiTemp = Convert.ToInt32(temp, 16) - 65535;
                rssi_data = ((float)rssiTemp / 10.0).ToString();// RSSI  =  (0xFED6   -65535)/10
                if (!rssi_data.Contains("."))
                {
                    rssi_data = rssi_data + ".0";
                }
                ant_data = Convert.ToInt32((strData.Substring(ant_index * 2, 2)), 16).ToString();
                UHFTAGInfo info = new UHFTAGInfo();
                info.Epc = epc_data;
                info.Tid = tid_data;
                info.Rssi = rssi_data;
                info.Ant = ant_data;
                info.User = user_data;
                return info;
            }
            else
            {
                return null;
            }
        }
        public static TagInfo getTagData()
        {
            TagInfo info = new TagInfo();
            byte[] tagTempData = new byte[150]; //Array.Clear(tagTempData, 0, tagTempData.Length);
            int result = UHFGetTagData(tagTempData, tagTempData.Length);
            info.ErrCode = result;
            if (result > 0)
            {
                // if (tagTempData[0] == 0)
                {
                    string hex = BitConverter.ToString(tagTempData, 0, result);
                    // Console.WriteLine("hex=" + hex + " result=" + result);
                }
                int index = 0;
                UHFTAGInfo uhfinfo = new UHFTAGInfo();
                while (true)
                {
                    if (index > result)
                    {
                        break;
                    }
                    int type = tagTempData[index];
                    index = index + 1;
                    if (index > result)
                    {
                        break;
                    }
                    int len = tagTempData[index];
                    index = index + 1;
                    if (index + len > result)
                    {
                        break;
                    }
                    byte[] data = Utils.CopyArray<byte>(tagTempData, index, len);
                    index = index + len;
                    if (type == 1)
                    {
                        //epc
                        uhfinfo.Epc = BitConverter.ToString(data, 2, data.Length - 2).Replace("-", "");
                    }
                    else if (type == 2)
                    {
                        //tid
                        uhfinfo.Tid = BitConverter.ToString(data, 0, data.Length).Replace("-", "");
                    }
                    else if (type == 3)
                    {
                        //user
                        uhfinfo.User = BitConverter.ToString(data, 0, data.Length).Replace("-", "");
                    }
                    else if (type == 4)
                    {
                        //rssi
                        int rssiTemp = (data[1] | (data[0] << 8)) - 65535;
                        string rssi_data = ((float)rssiTemp / 10.0).ToString();// RSSI  =  (0xFED6   -65535)/10
                        if (!rssi_data.Contains("."))
                        {
                            rssi_data = rssi_data + ".0";
                        }
                        uhfinfo.Rssi = rssi_data;
                    }
                    else if (type == 5)
                    {
                        //ant
                        uhfinfo.Ant = data[0].ToString();
                    }
                    else if (type == 6)
                    {
                        //id
                        info.Id = data[1];
                    }
                    else if (type == 8)
                    {
                        //Sensor
                        uhfinfo.Sensor = BitConverter.ToString(data, 0, data.Length).Replace("-", "");
                    }
                }
                info.UhfTagInfo = uhfinfo;
            }
            return info;
        }

    }
}






 