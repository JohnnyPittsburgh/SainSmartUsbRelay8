using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsbRelay8Driver;

namespace SainSmartUsbRelay8
{
    public partial class frmMain : Form
    {
        UsbRelays _relays;
        List<CheckBox> _relayControls;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            _relays = new UsbRelays();

            // Populate the Device Count
            tbDeviceCount.Text = _relays.DeviceCount.ToString();

            // Open each device
            foreach( string device in _relays.DeviceSerialNumbers)
            {
                _relays.OpenDevice(device);
            }

            // Populate the relay check Boxes
            CreateRelayCheckBoxes();

            // Populate the USB Relay Devices Drop Down
            cbDevices.DataSource = _relays.DeviceSerialNumbers;

            // Add the combo box idex changed event
            //  Have to do it here to ensure everything is created and ready to go.
            cbDevices.SelectedIndexChanged += cbDevices_SelectedIndexChanged;
        }


        private void CreateRelayCheckBoxes()
        {
            flpRelays.Controls.Clear();
            _relayControls = new List<CheckBox>();

            for (int i=0; i<8; i++)
            {
                // Cheat and use the tag to store the relay number
                //  so we don't have to keep track of the relay
                CheckBox cb = new CheckBox();
                cb.Name = "Relay" + i.ToString();
                cb.Text = "Relay " + i.ToString();
                cb.Tag = i;
                cb.CheckedChanged += RelayControlChangedEvent;
                _relayControls.Add(cb);
                flpRelays.Controls.Add(cb);
            }
        }


        private void UpdateRelays()
        {
            String sn = cbDevices.Text;
            if (sn == "")
            {
                return;
            }

            byte values = _relays.GetRelays(sn);
            //Console.WriteLine("SN: " + sn + "  Values: " + values.ToString());

            foreach( CheckBox cb in _relayControls )
            {
                int relayNum = (int)cb.TabIndex;
                byte mask = (byte)(1 << relayNum);

                //Console.WriteLine("relayNum: " + relayNum.ToString() +
                //    String.Format("  values {0:x}", values) + 
                //    String.Format("  mask {0:x}", mask) );
                    
                if ((mask & values) > 0)
                {
                    cb.Checked = true;
                }
                else
                {
                    cb.Checked = false;
                }
            }
        }


        private void RelayControlChangedEvent(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox) sender;
            
            String sn = cbDevices.Text;
            int relay = (int) cb.Tag;
            bool value = cb.Checked;

            _relays.SetRelay(sn, relay, value);
        }

        private void cbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("Relay item changed!");
            UpdateRelays();
        }
    }
}
