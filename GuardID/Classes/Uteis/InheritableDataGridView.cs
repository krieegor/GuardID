﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.Design;
using System.ComponentModel;

namespace System.Uteis
{
    [Designer(typeof(ControlDesigner))]
    public class InheritableDataGridView : DataGridViewGuard
    {
        public InheritableDataGridView()
            : base()
        { }
    }
}
