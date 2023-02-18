using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace angelpnacher.Components
{
    public class AddressContainer
    {
        string address;
        Control control;
        
        public event EventHandler<NameUpdateArgs> OnNameUpdate;
        public class NameUpdateArgs:EventArgs
        {
            public string name;
        }

        public AddressContainer(string address, FlowLayoutPanel control)
        {
            this.address = address;
            this.control = control;
        }

        public void UpdateName(string name)
        {
            OnNameUpdate?.Invoke(this, new NameUpdateArgs { name = name });
        }

        public string Address
        {
            get { return address; }
        }

        public Control Control
        {
            get { return control; }
            set { control = value; }
        }
    }
}
