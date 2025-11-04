'' =================================================================================================
''
''   File....... gps_basic_demo.spin
''   Purpose.... Demonstrates basic use of gps_basic object
''   Author..... 
''   E-mail..... 
''   Started.... 
''   Updated.... 19 FEB 2011
''
'' =================================================================================================


con

  _clkmode = xtal1 + pll16x
  _xinfreq = 5_000_000                                          ' use 5MHz crystal
' _xinfreq = 6_250_000                                          ' use 6.25MHz crystal

  CLK_FREQ = ((_clkmode - xtal1) >> 6) * _xinfreq
  MS_001   = CLK_FREQ / 1_000
  US_001   = CLK_FREQ / 1_000_000


con

  RX1    = 31                                                   ' programming port
  TX1    = 30
  SDA    = 29                                                   ' boot EEPROM
  SCL    = 28

  GPS_RX = 7                                                    ' GPS input (connect to GPS TX)


con

  PST = -8                                                      ' US time zone offsets
  MST = -7
  CST = -6
  EST = -5


con

   #1, HOME, GOTOXY, #8, BKSP, TAB, LF, CLREOL, CLRDN, CR       ' PST formmatting control
  #14, GOTOX, GOTOY, CLS


obj

  gps  : "gps_basic"                                            ' gps input
  term : "fullduplexserial"                                     ' for terminal comms


dat

screen                  byte    "============================", CR
                        byte    "          GPS Demo          ", CR
                        byte    "============================", CR
                        byte                                    CR
                        byte    "GPS Fix........ ",             CR
                        byte    "Satellites..... ",             CR
                        byte                                    CR
                        byte    "UTC time....... ",             CR
                        byte    "Local time..... ",             CR
                        byte    "Latitude....... ",             CR
                        byte    "Longitude...... ",             CR
                        byte    "Altitude (M)... ",             CR
                        byte    0


pub main | sync, ok

  'gps.startx(GPS_RX, PST, 9600, 1250)                          ' Parallax #28505
  gps.startx(GPS_RX, PST, -4800, 2500)                          ' for Garmin eTrex
  
  term.start(RX1, TX1, %0000, 115_200)                          ' start terminal comms
  waitcnt(clkfreq / 500 + cnt)                                  ' let objects start

  term.tx(CLS)                                                  ' clean-up terminal
  term.str(@screen)

  waitcnt(clkfreq << 1 + cnt)                                   ' let gps buffers fill

  sync := cnt                                                   ' create sync for refreshes
  repeat
    if (gps.hasgps == false)                                    ' connected?
      term.tx(CLS)                                              ' no, reset screen
      term.str(@screen)
      moveto(16, 4)
      term.str(string("No GPS"))                                ' display no-connect msg
    else
      moveto(16, 4)
      term.str(gps.s_gpsfix)                                    ' gps quality (fix)
      term.tx(CLREOL)
      ok := gps.n_gpsfix                                        ' flag for other fields
      
      moveto(16, 5)
      term.str(gps.s_satellites)
      term.tx(CLREOL)

      moveto(16, 7)
      term.str(gps.fs_utc_time)
      term.tx(CLREOL)

      moveto(16, 8)
      term.str(gps.fs_local_time)
      term.tx(CLREOL)
              
      moveto(16, 9)
      term.tx(" ")
      term.str(gps.s_latitude)
      term.tx(CLREOL)

      moveto(16, 10)
      term.str(gps.s_longitude)
      term.tx(CLREOL)

      moveto(16, 11)
      term.str(gps.s_altm)
      term.tx(CLREOL)

    waitcnt((clkfreq >> 3) + cnt)                               ' refresh 8x per second
    

pub moveto(x, y)

'' Position PST cursor at x/y

  term.tx(GOTOXY)
  term.tx(x)
  term.tx(y)
  

dat

{{

  Terms of Use: MIT License

  Permission is hereby granted, free of charge, to any person obtaining a copy of this
  software and associated documentation files (the "Software"), to deal in the Software
  without restriction, including without limitation the rights to use, copy, modify,
  merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
  permit persons to whom the Software is furnished to do so, subject to the following
  conditions:

  The above copyright notice and this permission notice shall be included in all copies
  or substantial portions of the Software.

  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
  INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
  PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
  HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
  CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE
  OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

}}  