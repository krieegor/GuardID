using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;

namespace System.Uteis
{
    [ToolboxBitmap(@"S:\Sistemas dotNet\Figuras\iGroupbox.ico")]
    public partial class GroupBoxGuard : GroupBox
    {
        public GroupBoxGuard()
        {
            InitializeComponent();
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        public GroupBoxGuard(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
