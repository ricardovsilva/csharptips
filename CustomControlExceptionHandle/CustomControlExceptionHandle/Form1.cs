using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomControlExceptionHandle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var customTextbox = new CustomTextBox();

            //We assigned one method with same signature of delegate created inside
            //custom text box. Everytime custom text box call this delegate, the method
            //that we assigned that will be called. Inside this we can handle with the
            //exception.
            customTextbox.OnExceptionThrown += this.SomeExceptionHappened;
        }

        public void SomeExceptionHappened(Exception ex, object sender)
        {
            //... handle exception. For example:
            MessageBox.Show(
                "Ops! Some error happened \n " + ex.Message,
                "E R R O R",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
