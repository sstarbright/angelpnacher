using System.Media;

namespace pnachbuilder
{
    public partial class angelpnacher : Form
    {
        class ComboItem
        {
            public int ID { get; set; }
            public string Text { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }

        ComboItem[] codeSelectItems = new ComboItem[]
        {
            new ComboItem{ ID = 0, Text = "Write" },
            new ComboItem{ ID = 1, Text = "Increment/Decrement" },
            new ComboItem{ ID = 2, Text = "Serial Write" },
            new ComboItem{ ID = 3, Text = "Copy" },
            new ComboItem{ ID = 4, Text = "Pointer Write" },
            new ComboItem{ ID = 5, Text = "Boolean" },
            new ComboItem{ ID = 6, Text = "If" },
            new ComboItem{ ID = 7, Text = "Comment" },
            new ComboItem{ ID = 8, Text = "Raw Text" }
        };

        //HashSet<string> existingAddresses = new HashSet<string>();
        Dictionary<string, string> existingAddresses = new Dictionary<string, string>();

        int numHidden = 0;

        ContainerControl dummyAddressContainer = new ContainerControl();

        bool showingHidden = false;

        //Hex Conversion from https://stackoverflow.com/questions/35449339/c-sharp-converting-from-float-to-hexstring-via-ieee-754-and-back-to-float
        string ToHexString(float f)
        {
            var bytes = BitConverter.GetBytes(f);
            var i = BitConverter.ToInt32(bytes, 0);
            return i.ToString("X8");
        }

        float FromHexString(string s)
        {
            try
            {
                var i = Convert.ToInt32(s, 16);
                var bytes = BitConverter.GetBytes(i);
                return BitConverter.ToSingle(bytes, 0);
            } catch
            {
                throw new Exception();
            }
        }

        public angelpnacher()
        {
            InitializeComponent();
        }

        private void appendCode_Click(object sender, EventArgs e)
        {

        }

        private void AddAddress()
        {
            try
            {
                float testFloat = FromHexString(newAddressBox.Text);
                if (!existingAddresses.ContainsKey(newAddressBox.Text))
                {
                    existingAddresses.Add(newAddressBox.Text, newAddressBox.Text);
                    FlowLayoutPanel newFlp = new FlowLayoutPanel()
                    {
                        Name = newAddressBox.Text,
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
                        Name = newAddressBox.Text + "_label",
                        Text = newAddressBox.Text,
                        Width = (int)MathF.Round(newFlp.Width * 0.70f),
                        Parent = newFlp,
                        Margin = Padding.Empty,
                        Padding = new Padding(0, 5, 0, 0),
                        AutoEllipsis = true
                    };
                    Button newHideButton = new Button()
                    {
                        Name = newAddressBox.Text + "_hide",
                        Text = showingHidden ? "Show" : "Hide",
                        Width = ((int)MathF.Round(newFlp.Width * 0.30f)) - 12,
                        Height = 30,
                        Parent = newFlp,
                        Margin = Padding.Empty,
                        Anchor = AnchorStyles.Right & AnchorStyles.Top
                    };
                    newLabel.MouseClick += listedAddress_Click;
                    if (showingHidden)
                    {
                        newHideButton.Click += listedAddress_Show;
                        numHidden++;
                    } else
                        newHideButton.Click += listedAddress_Hide;
                    newAddressBox.Text = "";
                } else
                    SystemSounds.Asterisk.Play();
            }
            catch
            {
                SystemSounds.Asterisk.Play();
            }
        }

        private void addAddress_Click(object sender, EventArgs e)
        {
            AddAddress();
        }

        private void newAddressBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AddAddress();
        }

        private void newAddressBox_TextChanged(object sender, EventArgs e)
        {
            newAddressBox.Text = newAddressBox.Text.Trim();
            int selectPoint = newAddressBox.SelectionStart;
            newAddressBox.Text = newAddressBox.Text.ToUpper();
            newAddressBox.SelectionStart = selectPoint;
        }

        private void listedAddress_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Label baseLabel = (Label)sender;
                string labelName = baseLabel.Name.Split("_")[0];
                Control labelParent = addressPanel.Controls.Find(labelName, false)[0];
                int childIndex = addressPanel.Controls.GetChildIndex(labelParent);
                int labelHeight = labelParent.Height;
                string labelText = baseLabel.Text;

                addressPanel.Controls.Remove(labelParent);
                labelParent.Dispose();
                TextBox labelEditor = new TextBox()
                {
                    Name = labelName,
                    Text = labelName == labelText ? "" : labelText,
                    Parent = addressPanel,
                    Width = addressPanel.Width-30,
                    Height = 50,
                    BorderStyle = BorderStyle.Fixed3D,
                    AcceptsTab = false,
                    AcceptsReturn = false,
                    Margin = Padding.Empty,
                    Multiline = true
                };
                labelEditor.KeyDown += labelEditor_KeyDown;
                labelEditor.Leave += labelEditor_Leave;
                addressPanel.Controls.SetChildIndex(labelEditor, childIndex);
                labelEditor.Focus();
            }
        }
        private void listedAddress_Hide(object sender, EventArgs e)
        {
            Control hideButton = (Control)sender;
            hideButton.Text = "Show";
            hideButton.Click -= listedAddress_Hide;
            hideButton.Click += listedAddress_Show;
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
        private void listedAddress_Show(object sender, EventArgs e)
        {
            Control showButton = (Control)sender;
            showButton.Text = "Hide";
            showButton.Click -= listedAddress_Show;
            showButton.Click += listedAddress_Hide;
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

        private void labelEditor_KeyDown(object sender, EventArgs e)
        {
            TextBox labelEditor = (TextBox)sender;
            if (((KeyEventArgs)e).KeyCode == Keys.Enter)
            {
                labelEditor.Leave -= labelEditor_Leave;
                FinishEditingLabel(labelEditor);
            }
        }

        private void labelEditor_Leave(object sender, EventArgs e)
        {
            FinishEditingLabel((TextBox)sender);
        }

        private void FinishEditingLabel(TextBox labelEditor)
        {
            int childIndex = addressPanel.Controls.GetChildIndex(labelEditor);
            string labelName = labelEditor.Name;
            string labelText = labelEditor.Text.Length > 0 ? labelEditor.Text : labelName;
            existingAddresses[labelName] = labelText;
            addressPanel.Controls.Remove(labelEditor);
            labelEditor.Dispose();
            FlowLayoutPanel newFlp = new FlowLayoutPanel()
            {
                Name = labelName,
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
                Name = labelName + "_label",
                Text = labelText,
                Width = (int)MathF.Round(newFlp.Width * 0.70f),
                Parent = newFlp,
                Margin = Padding.Empty,
                Padding = new Padding(0, 5, 0, 0),
                AutoEllipsis = true
            };
            Button newHideButton = new Button()
            {
                Name = labelName + "_hide",
                Text = showingHidden ? "Show" : "Hide",
                Width = ((int)MathF.Round(newFlp.Width * 0.30f)) - 12,
                Height = 30,
                Parent = newFlp,
                Margin = Padding.Empty,
                Anchor = AnchorStyles.Right & AnchorStyles.Top
            };
            newLabel.MouseClick += listedAddress_Click;
            if (showingHidden)
                newHideButton.Click += listedAddress_Show;
            else
                newHideButton.Click += listedAddress_Hide;
            if (labelName != labelText)
                toolTip1.SetToolTip(newLabel, labelText + ": Address " + labelName);
            addressPanel.Controls.SetChildIndex(newFlp, childIndex);
        }

        private void pnachbuilder_Load(object sender, EventArgs e)
        {
            codeSelector.DataSource = codeSelectItems;
            hiddenLink.Enabled = false;
            hiddenLink.Visible = false;
        }

        private void addressPanel_Click(object sender, EventArgs e)
        {
            addressPanel.Focus();
        }

        private void hiddenLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (showingHidden)
                hiddenLink.Text = numHidden + " entr" + (numHidden != 1 ? "ies" : "y") + " hidden. View";
            else
            {
                int numNotHidden = existingAddresses.Count - numHidden;
                hiddenLink.Text = (numNotHidden > 0 ? numNotHidden : 0) + " entr" + (numNotHidden != 1 ? "ies" : "y") + " available. View";
            }
            hiddenLink.LinkArea = new LinkArea(hiddenLink.Text.IndexOf('.') + 2, 4);

            Control[] panelAddresses = new Control[addressPanel.Controls.Count];
            Control[] storedAddresses = new Control[dummyAddressContainer.Controls.Count];
            addressPanel.Controls.CopyTo(panelAddresses, 0);
            dummyAddressContainer.Controls.CopyTo(storedAddresses, 0);
            dummyAddressContainer.Controls.Clear();
            dummyAddressContainer.Controls.AddRange(panelAddresses);
            addressPanel.Controls.Clear();
            addressPanel.Controls.AddRange(storedAddresses);
            showingHidden = !showingHidden;
        }
    }
}