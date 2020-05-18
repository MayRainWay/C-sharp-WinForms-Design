using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AboutReaderWriterLock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private Thread thread1 = null;
        private Thread thread2 = null;
        private Thread thread3 = null;
        private Thread thread4 = null;
        private Thread thread5 = null;

        private ReaderWriterLock rwl = new ReaderWriterLock();
        //剩下的代码暂时不写了，因为实现要求不明确！
    }
}
