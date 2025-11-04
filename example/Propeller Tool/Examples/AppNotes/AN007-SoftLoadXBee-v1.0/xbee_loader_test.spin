{
File:           XBee_Loader_Test.spin
Version:        1.0
Date:           February 10, 2011

Description:
Sample code that implements wireless soft loading fucntionality
for the P8X32A Propeller microcontroller.  The code is a minimal
implementation which starts the xbee_loader object in an available
cog.  After the xbee_loader object is started, the method
"YourCodeHere" is called which blinks an LED at 1 Hz forever.

}
CON
  'set up the system clock
  _clkmode = xtal1 + pll16x                             
  _clkfreq = 80_000_000                   
  
  'xbee_loader definitions
  DOUT_PIN  = 26
  DIN_PIN   = 27
  XBEE_BAUD = 9_600

  'other constant definitions
  LED_PIN   = 0
  
OBJ

  'import xbee_loader object
  soft_loader   : "xbee_loader.spin"                    

PUB go

  'start xbee_loader object
  soft_loader.start(DOUT_PIN, DIN_PIN, XBEE_BAUD)       

  'call to the "YourCodeHere" method
  YourCodeHere                                          


PUB YourCodeHere

  'set pin to output  
  dira[LED_PIN]~~                                       

  'main loop, repeat forever.  Toggles an LED.  
  repeat                                                
    !outa[LED_PIN]                                      
    waitcnt(cnt+clkfreq/8)                              
  