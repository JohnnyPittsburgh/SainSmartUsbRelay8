using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTD2XX_NET;

// Do List
// 1) Add the ability to add relay device by serial number


namespace UsbRelay8Driver
{
    #region Exceptions
    class UsbRelayDeviceNotFoundException : Exception
    {
        public override string Message
        {
	        get { return "SainSmart USB relay not found."; }
        }
    }

    class UsbRelayConfigurationException : Exception
    {
        public override string Message
        {
            get { return "SainSmart USB relay configuration error."; }
        }
    }

    class UsbRelayInvalidRelayException : Exception
    {
        public override string Message
        {
	        get { return "SainSmart USB relay invalid relay number."; }
        }
    }

    class UsbRelayReadException : Exception
    {
        public override string Message
        {
            get { return "SainSmart USB relay read error."; }
        }
    }

    class UsbRelayWriteException : Exception
    {
        public override string Message
        {
            get { return "SainSmart USB relay write error."; }
        }
    }
    #endregion // Exceptions

    /// <summary>
    /// SainSmart USB Relay 8 Device Class
    /// This class handles the read/writes to a particular SainSmart USB
    /// relay 8 device.  Because of the nature of the writes/reads to the
    /// device with 8 relays.  It may work with device with less than
    /// 8 relays, but it has not been tested.
    /// </summary>
    class UsbRelay8
    {
        #region Constants
        const int BaudRate = 921600;
        const byte BitMask = 0xff;          // 8-bit mask
        const byte BitMode = FTDI.FT_BIT_MODES.FT_BIT_MODE_SYNC_BITBANG;
        const int RelayCount = 8;           // Maximum number of relays supported by device
        #endregion // Constants

        #region Private Variables
        uint _deviceIndex;
        FTDI _device;
        FTDI.FT_STATUS _status;

        // FTD2 driver requires byte arrays, only a byte is needed for device
        byte[] _writeBuffer = new byte[2];
        byte[] _readBuffer = new byte[2];

        #endregion // Private Variables

        #region Public Properties
        /// <summary>
        /// Relay Device ID
        /// </summary>
        public uint DeviceIndex
        {
            get {return _deviceIndex; }
            private set;
        }

        #endregion // Public Properties

        #region Constuctors
        /// <summary>
        /// Create a USB Relay Device
        /// </summary>
        /// <param name="deviceIndex">Device Index from FTDI driver</param>
        public UsbRelay8( uint deviceIndex )
        {

            // Open the relay device
            _device = new FTDI();
            _deviceIndex = deviceIndex;
            _status = _device.OpenByIndex(_deviceIndex);
            if (_status != FTDI.FT_STATUS.FT_OK)
            {
                throw new UsbRelayDeviceNotFoundException();
            }

            // Set the baud rate
            _status = _device.SetBaudRate(BaudRate);
            if (_status != FTDI.FT_STATUS.FT_OK)
            {
                throw new UsbRelayConfigurationException();
            }
            
            // Set the bit mode
            _status = _device.SetBitMode(BitMask, BitMode);
            if (_status != FTDI.FT_STATUS.FT_OK)
            {
                throw new UsbRelayConfigurationException();
            }
        }

        #endregion  // Constructors

        #region Public Methods
        /// <summary>
        /// Get the relay values
        /// </summary>
        /// <returns></returns>
        public byte GetRelayValues()
        {
            // Clear the read buffer
            Array.Clear(_readBuffer, 0, _readBuffer.Length);

            // Read the relay values
            uint readBytes = 1;
            uint bytesRead = 0;
            _status = _device.Read(_readBuffer, readBytes, ref bytesRead);
            if (_status != FTDI.FT_STATUS.FT_OK || bytesRead != 1)
            {
                throw new UsbRelayReadException();
            }

            return _readBuffer[0];
        }

        /// <summary>
        /// Set an individual relay value.
        /// </summary>
        /// <param name="relay">relay index, zero based</param>
        /// <param name="value">relay value</param>
        public void SetRelay(int relay, bool value)
        {
            // Relay sanity check
            if (relay < 0 || relay > RelayCount - 1)
            {
                throw new UsbRelayInvalidRelayException();
            }
            
            // Get the current values
            byte newValue = GetRelayValues();

            // Please note, that this only works for devices with up to 8 relays 
            // note: C# doesn't have a power operator, have to use a Math a method call. 
            byte bitValue = (byte) Math.Pow(2,relay);
            if (true == value)
            {
                // Setting a relay value, or it in.
                newValue |= bitValue;
            }
            else
            {
                // Clearing a relay value, and it out
                newValue &= (byte) ~bitValue;
            }
            _writeBuffer[0] = newValue;

            // Write the value
            uint bytesWritten = 0;
            _status = _device.Write(_writeBuffer, 1, ref bytesWritten);
            if (_status != FTDI.FT_STATUS.FT_OK || bytesWritten != 1)
            {
                throw new UsbRelayWriteException();
            }
        }

        /// <summary>
        /// Set all the relay values, each relay is a bit
        /// </summary>
        /// <param name="values">combined relay values</param>
        public void SetRelays(byte values)
        {
            // Set the write buffer with the values
            _writeBuffer[0] = values;

            // Write the value
            uint bytesWritten = 0;
            _status = _device.Write(_writeBuffer, 1, ref bytesWritten);
            if (_status != FTDI.FT_STATUS.FT_OK || bytesWritten != 1)
            {
                throw new UsbRelayWriteException();
            }
        }

        #endregion  // Public Methods
    }


    /// <summary>
    /// USB Relays Class.  
    /// This class holds a collection of relay devices and handles the setting
    /// of relays by using DeviceName:RelayNumber or assigned names for individual
    /// DeviceName:RelayNumber pairs.
    /// </summary>
    class UsbRelays
    {
        #region Constants
        #endregion      // Constants
       
        #region Private Variables
        private bool _Opened = false;
        private int _DeviceCount = 0;
        #endregion

        #region Properties

        /// <summary>
        /// Device Count
        /// </summary>
        public int DeviceCount
        {
            get { return GetDeviceCount(); }
            private set;
        }

        /// <summary>
        /// Return the device count
        /// </summary>
        /// <returns></returns>
        private int GetDeviceCount()
        {
            throw new NotImplementedException();
        }

        #endregion      // Constants

    }
}
