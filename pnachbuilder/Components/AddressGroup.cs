using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace angelpnacher.Components
{
    public class AddressGroup
    {
        string name;
        List<string> addresses;
        Panel control;
        FlowLayoutPanel addressPanel;

        Dictionary<string, string> existingAddresses;
        Dictionary<string, FlowLayoutPanel> displayControls = new Dictionary<string, FlowLayoutPanel>();
        Dictionary<string, TextBox> editorControls = new Dictionary<string, TextBox>();

        public AddressGroup(int index, string name, Dictionary<string, string> existingAddresses)
        {
            this.name = name;
            this.existingAddresses = existingAddresses;
            control = new Panel()
            {
                Name = "addressGroup" + index,
                AutoSize = true
            };

        }

        // Add an address to the group
        public void Add(string newAddress, bool isHidden, FlowLayoutPanel addressPanel)
        {
            this.addressPanel = addressPanel;
            FlowLayoutPanel newFlp = new FlowLayoutPanel()
            {
                Name = newAddress,
                Height = 50,
                Width = addressPanel.Width - 30,
                Parent = addressPanel,
                FlowDirection = FlowDirection.LeftToRight,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = Padding.Empty,
                Padding = new Padding(5, 8, 5, 5),
            };
            Label newLabel = new Label()
            {
                Name = newAddress + "_label",
                Text = newAddress,
                Width = (int)MathF.Round(newFlp.Width * 0.70f),
                Parent = newFlp,
                Margin = Padding.Empty,
                Padding = new Padding(0, 5, 0, 0),
                AutoEllipsis = true
            };
            Button newHideButton = new Button()
            {
                Name = newAddress + "_hide",
                Text = isHidden ? "Show" : "Hide",
                Width = ((int)MathF.Round(newFlp.Width * 0.30f)) - 12,
                Height = 30,
                Parent = newFlp,
                Margin = Padding.Empty,
                Anchor = AnchorStyles.Right & AnchorStyles.Top
            };
            TextBox labelEditor = new TextBox()
            {
                Name = newAddress + "_editor",
                Text = "",
                Width = addressPanel.Width - 30,
                Height = 50,
                BorderStyle = BorderStyle.Fixed3D,
                AcceptsTab = false,
                AcceptsReturn = false,
                Margin = Padding.Empty,
                Multiline = true
            };
            newLabel.MouseClick += StartEditing;
            if (isHidden)
                newHideButton.Click += ShowAddress;
            else
                newHideButton.Click += HideAddress;
            labelEditor.KeyDown += FinishEditingWithEnter;
            labelEditor.Leave += FinishEditingWithLeave;
            displayControls[newAddress] = newFlp;
            editorControls[newAddress] = labelEditor;
        }

        private void StartEditing(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Label baseLabel = (Label)sender;
                string labelName = baseLabel.Name.Split("_")[0];
                Control labelParent = addressPanel.Controls.Find(labelName, false)[0];
                int childIndex = addressPanel.Controls.GetChildIndex(labelParent);

                addressPanel.Controls.Remove(labelParent);
                addressPanel.Controls.Add(editorControls[labelName]);

                addressPanel.Controls.SetChildIndex(editorControls[labelName], childIndex);
                editorControls[labelName].Focus();
            }
        }

        private void FinishEditingWithEnter(object sender, EventArgs e)
        {
            if (((KeyEventArgs)e).KeyCode == Keys.Enter)
            {
                TextBox labelEditor = (TextBox)sender;
                labelEditor.Leave -= FinishEditingWithLeave;
                FinishEditingLabel(labelEditor);
            }
        }

        private void FinishEditingWithLeave(object sender, EventArgs e)
        {
            FinishEditingLabel((TextBox)sender);
        }

        private void FinishEditingLabel(TextBox labelEditor)
        {
            //Add code here to move address' controls to another group
            int childIndex = addressPanel.Controls.GetChildIndex(labelEditor);
            string labelName = labelEditor.Name.Split("_")[0];
            string labelText = labelEditor.Text.Length > 0 ? labelEditor.Text : labelName;
            existingAddresses[labelName] = labelText;

            addressPanel.Controls.Remove(labelEditor);
            addressPanel.Controls.Add(displayControls[labelName]);
            addressPanel.Controls.SetChildIndex(displayControls[labelName], childIndex);
        }

        private void HideAddress(object sender, EventArgs e)
        {
            Control hideButton = (Control)sender;
            hideButton.Text = "Show";
            hideButton.Click -= HideAddress;
            hideButton.Click += ShowAddress;
            Control addressBase = addressPanel.Controls.Find(hideButton.Name.Split("_")[0], false)[0];
            numHidden++;
            if (!hiddenLink.Enabled)
            {
                hiddenLink.Enabled = true;
                hiddenLink.Visible = true;
            }
            hiddenLink.Text = numHidden + " entr" + (numHidden != 1 ? "ies" : "y") + " hidden. View";
            hiddenLink.LinkArea = new LinkArea(hiddenLink.Text.IndexOf('.') + 2, 4);
            addressPanel.Controls.Remove(addressBase);
            dummyAddressContainer.Controls.Add(addressBase);
        }
        private void ShowAddress(object sender, EventArgs e)
        {
            Control showButton = (Control)sender;
            showButton.Text = "Hide";
            showButton.Click -= ShowAddress;
            showButton.Click += HideAddress;
            Control addressBase = addressPanel.Controls.Find(showButton.Name.Split("_")[0], false)[0];
            numHidden--;
            if (hiddenLink.Enabled && numHidden == 0)
            {
                hiddenLink.Enabled = true;
                hiddenLink.Visible = true;
            }
            int numNotHidden = existingAddresses.Count - numHidden;
            hiddenLink.Text = (numNotHidden > 0 ? numNotHidden : 0) + " entr" + (numNotHidden != 1 ? "ies" : "y") + " available. View";
            hiddenLink.LinkArea = new LinkArea(hiddenLink.Text.IndexOf('.') + 2, 4);
            addressPanel.Controls.Remove(addressBase);
            dummyAddressContainer.Controls.Add(addressBase);
        }

        public Panel Control
        {
            get { return control; }
        }

        public List<string> Addresses
        {
            get { return addresses; }
        }
    }
}
