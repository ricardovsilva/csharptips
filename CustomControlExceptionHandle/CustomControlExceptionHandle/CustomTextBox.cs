namespace CustomControlExceptionHandle
{
    using System;
    using System.Windows.Forms;

    public delegate void ExceptionDelegate(Exception ex, object sender);

    public class CustomTextBox : TextBox
    {
        public CustomTextBox()
        {
            this.TextChanged += new EventHandler(CustomTextBox_TextChanged);
        }

        /// <summary>
        /// Gets or sets the delegate to when some exception will be thrown.
        /// This will called anytime this control throw some exception.
        /// </summary>
        public ExceptionDelegate OnExceptionThrown { get; set; }

        void CustomTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // .. do something.
            }
            catch (Exception ex)
            {
                // .. something unexpected happened. Let's throw this error
                // outside this component. Let who uses this handle with the error.
                if (this.OnExceptionThrown != null)
                {
                    //Now we're dispatching some kind of event, indicating that some exception was thrown.
                    //Let who uses this component handle with exception.
                    this.OnExceptionThrown.Invoke(ex, sender); 
                }
                else
                {
                    throw ex; //This will throw as unhandled exception, but is better do this
                              //than override exception with NullArgumentException if delegate is null.
                              //You can guarantee by constructor too that the delegate has some value assigned to it.
                }
            }
        }
    }
}
