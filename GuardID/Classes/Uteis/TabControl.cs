﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace System.Uteis
{
    //[ToolboxBitmap(@"iGroupbox.ico")]
    public partial class TabControlGuard : TabControl
    {
        public TabControlGuard()
        {
            InitializeComponent();
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
    }
}
