using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpAdvanced
{
    /// <summary>
    /// 垃圾回收机制：
    /// 回收非托管资源---Windows窗口句柄、数据库链接、GDI对象、独占文件锁等等对象。
    /// ApplicationContext,Brush,Component,ComponentDesigner,Container,Context,Cursor,
    ///FileStream,Font,Icon,Image,Matrix,Object,OdbcDataReader,OleDBDataReader,Pen,
    ///Regex,Socket,StreamWriter,Timer,Tooltip 等。
    ///
    /// 1--Dispose()需要实现IDisposable接口
    /// 2--Close()和Dispose()区别。区别---Close()方法关闭对象，没有完全释放。Dispose()方法完全释放了。
    /// 3--99%情况下不需要自己编写经典方法;
    /// </summary>
    public class DisposeTest : IDisposable
    {
        #region 方式一 语法糖
        public void connDB()
        {
            
            SqlConnection conn3 = new SqlConnection();
            try
            {
                conn3.Open();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn3.Close();
            }



            using (SqlConnection cnn = new SqlConnection())
            {
                //使用
            }

            //上面这段代码编译后是
            SqlConnection cnn2 = new SqlConnection();
            try
            {
                //这里写要执行的代码 
            }
            finally
            {
                cnn2.Dispose();
            }



        }
        #endregion

        #region 方式二 经典方式


        private readonly IntPtr unmanagedResource;//非托管内存
        private readonly SafeHandle managedResource;//托管资源

        public DisposeTest()
        {
            unmanagedResource = Marshal.AllocHGlobal(sizeof(int));//分配非托管内存
            managedResource = new SafeFileHandle(new IntPtr(), true);//创建托管资源
        }


        public void Dispose()
        {
           
            Dispose(true);//调用处理方法
            GC.SuppressFinalize(this);//让GC忽略
        }

        protected virtual void Dispose(bool isManualDisposing)
        {
            ReleaseUnmanagedResourse(unmanagedResource);//处理非托管资源
            if (isManualDisposing)
            {
                ReleaseManagedResources(managedResource);//处理托管资源 
            }
        }

        private void ReleaseManagedResources(SafeHandle safeHandle)
        {
            if (safeHandle != null)
            {
                safeHandle.Dispose();
            }
        }

        private void ReleaseUnmanagedResourse(IntPtr intPtr)
        {
            Marshal.FreeHGlobal(intPtr); //释放非托管内存
        }

        ~DisposeTest()
        {
            Dispose(false);
        }
        #endregion


    }
}
