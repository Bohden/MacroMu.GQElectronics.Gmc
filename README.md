# MacroMu.GQElectronics.Gmc

## About the Project

GQ Electronics, LLC. makes a line of geiger counters which can work with a computer over USB/UART. This library uses RFC1801 (http://www.gqelectronicsllc.com/download/GQ-RFC1801.txt or in the repository directly) to create a thread-safe interface for communication with, and control of, the GMC-500, GMC-500+, GMC-600, and GMC-600+ Gieger counters.

## Using the Library

After installing the library, you can create a GmcConnection object. This contains the serial port information and facilitates UART level communications with the GQ GMC device. Aside from creation/initialization of this object, you shouldn't need to use any method on it, although they are available if you need them.

Pass the GmcConnection object in when you create a GmcController object, and now you have a channel to issue commands with straight method calls. All calls are async, and thread-safety is maintained- although this is accomplished by using semaphore to ensure there is only one command executing at a time.

All basic calls listed in RFC1801 are available, although GETTEMP is still unsupported and will throw a NotImplementedException until sensors/firmware are available. ESP8266 WiFi module "AT" commands are not yet implemented, but we plan to implement this as well within the next couple of months.

Examples will be made available as well in the coming weeks/months.

## LICENSE

Distributed under the GPLv3. See LICENSE.txt for more information.
