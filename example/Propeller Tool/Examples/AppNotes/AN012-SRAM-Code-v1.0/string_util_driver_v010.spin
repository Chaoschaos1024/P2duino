' /////////////////////////////////////////////////////////////////////////////
{ String / Character / Utility Driver - string_util_driver_v010.spin

 AUTHOR: Andre' LaMothe
 COPYRIGHT: Parallax Inc.
 LAST MODIFIED: 4/5/11
 LICENSE: MIT (see end of file)
 VERSION 1.0

 COMMENTS: This object contains a set of misc string, character, and utility
 methods to make string processing, parsing, etc. easier.  
          
}
' /////////////////////////////////////////////////////////////////////////////


'//////////////////////////////////////////////////////////////////////////////
' CONSTANTS SECTION ///////////////////////////////////////////////////////////
'//////////////////////////////////////////////////////////////////////////////

CON

'//////////////////////////////////////////////////////////////////////////////
' PROP CHIP / SYSTEM DEFINES //////////////////////////////////////////////////
'//////////////////////////////////////////////////////////////////////////////

  ' set for 5 Mhz clock, change below if you change XTAL
  CLOCKS_PER_MICROSECOND = 5*16     ' simple xin*pll / 1_000_000                     
  CLOCKS_PER_MILLISECOND = 5000*16  ' simple xin*pll / 1_000

   ' ASCII codes for ease of parser development
  ASCII_A       = 65
  ASCII_B       = 66
  ASCII_C       = 67
  ASCII_D       = 68
  ASCII_E       = 69
  ASCII_F       = 70
  ASCII_G       = 71
  ASCII_H       = 72
  ASCII_O       = 79  
  ASCII_P       = 80
  ASCII_Z       = 90
  ASCII_0       = 48
  ASCII_9       = 57
  ASCII_LEFT   = $C0
  ASCII_RIGHT  = $C1
  ASCII_UP     = $C2
  ASCII_DOWN   = $C3 
  ASCII_BS     = $08 ' backspace
  ASCII_DEL    = $7F ' delete   
  ASCII_LF     = $0A ' line feed 
  ASCII_CR     = $0D ' carriage return
  ASCII_ESC    = $1B ' escape
  ASCII_HEX    = $24 ' $ for hex
  ASCII_BIN    = $25 ' % for binary
  ASCII_LB     = $5B ' [ 
  ASCII_SEMI   = $3A ' ; 
  ASCII_EQUALS = $3D ' = 
  ASCII_PERIOD = $2E ' .
  ASCII_COMMA  = $2C ' ,
  ASCII_SHARP  = $23 ' #
  ASCII_NULL   = $00 ' null character
  ASCII_SPACE  = $20 ' space
  ASCII_TAB    = $09 ' horizontal tab

  ' null pointer, null character
  NULL         = 0  
    
'//////////////////////////////////////////////////////////////////////////////
' VARS SECTION ////////////////////////////////////////////////////////////////
'//////////////////////////////////////////////////////////////////////////////        
  
'//////////////////////////////////////////////////////////////////////////////
'OBJS SECTION /////////////////////////////////////////////////////////////////
'//////////////////////////////////////////////////////////////////////////////

OBJ

' /////////////////////////////////////////////////////////////////////////////
' UTILITY ROUTINES ////////////////////////////////////////////////////////////
' /////////////////////////////////////////////////////////////////////////////

PUB StrCpy( dest_str_ptr, source_str_ptr ) | _index
{{
DESCRIPTION: mimics C strcpy, copies source -> destination including NULL
PARMS:
RETURNS:
}}

' test if there is storage
if (dest_str_ptr == NULL)
  return (NULL)

_index := 0

repeat while (byte [ source_str_ptr ][_index] <> NULL)
  ' copy next byte
   byte [ dest_str_ptr ][_index] := byte [ source_str_ptr ][_index]    
   _index++

' null terminate
byte [ dest_str_ptr ][_index] := NULL

' return number of bytes copied
return ( _index )

' // end StrCpy

' /////////////////////////////////////////////////////////////////////////////

PUB StrUpper(string_ptr)
{{
DESCRIPTION: upcases a string 
PARMS:
RETURNS:
}}

  if (string_ptr <> NULL)
    repeat while (byte[ string_ptr ] <> NULL)
      byte[ string_ptr ] :=  ToUpper( byte[ string_ptr ] )
      string_ptr++  

  ' return string
  return (string_ptr)

' // end StrUpper

' /////////////////////////////////////////////////////////////////////////////

PUB ToUpper(ch)
{{
DESCRIPTION: returns the uppercase of the sent character 
PARMS:
RETURNS:
}}

if (ch => $61 and ch =< $7A)
  return(ch-32)
else
  return(ch)

' // end ToUpper

' /////////////////////////////////////////////////////////////////////////////

PUB IsInSet(ch, set_string)
{{
DESCRIPTION: tests if sent character is in string 
PARMS:
RETURNS:
}}

repeat while (byte[set_string][0] <> NULL)
  if (ch == byte[set_string++][0])
    'serial.txstring(string ("found!") )
    return( ch )

'serial.txstring(string ("not found!") )
' not found
return( -1 )    

' // end IsInSet

' /////////////////////////////////////////////////////////////////////////////

PUB IsSpace(ch)
{{
DESCRIPTION: tests if sent character is white space, cr, lf, space, tab 
PARMS:
RETURNS:
}}

if ( (ch == ASCII_SPACE) or (ch == ASCII_LF) or (ch == ASCII_CR) or (ch == ASCII_TAB))
  return (ch)
else
  return(-1)  

' // end IsSpace

' /////////////////////////////////////////////////////////////////////////////

PUB IsNull(ch)
{{
DESCRIPTION: tests if sent character is null 
PARMS:
RETURNS:
}}

if ( (ch == NULL))
  return (1)
else
  return(-1)  

' // end IsNull

' /////////////////////////////////////////////////////////////////////////////

PUB IsDigit(ch)
{{
DESCRIPTION: tests if sent character is a number 0..9, returns integer 0..9 
PARMS:
RETURNS:
}}

if (ch => ASCII_0 and ch =< ASCII_9)
  return (ch-ASCII_0)
else
  return(-1)  

' // end IsDigit

' /////////////////////////////////////////////////////////////////////////////

PUB IsAlpha(ch)
{{
DESCRIPTION: tests if sent character is a number a...zA...Z 
PARMS:
RETURNS:
}}

ch := ToUpper(ch)

if ( (ch => ASCII_A) and (ch =< ASCII_Z))
  return (ch)
else
  return(-1)  

' end IsAlpha

' /////////////////////////////////////////////////////////////////////////////

PUB IsPunc(ch)
{{
DESCRIPTION: tests if sent character is a punctuation symbol !@#$%^&*()--+={}[]|\;:'",<.>/? 
PARMS:
RETURNS:
}}

ch := ToUpper(ch)

if (  ((ch => 33) and (ch =< 47)) or  ((ch => 58) and (ch =< 64)) or ((ch => 91) and (ch =< 96)) or ((ch =>123) and (ch =< 126))  ) 
  return (ch)
else
  return(-1)  

' // end IsPunc
                                                                                
' /////////////////////////////////////////////////////////////////////////////

PUB HexToDec(n)
{{
DESCRIPTION: converts hex digit to decimal 
PARMS:
RETURNS:
}} 
  if ( (n => "0") and (n =< "9") )
    return (n - ASCII_0)
  elseif ( (n => "A") and (n =< "F") )
    return (n - "A" + 10)
  else
    return ( 0 )  

' // end HexToDec

' /////////////////////////////////////////////////////////////////////////////

PUB itoa(value, string_ptr) | i
{{
DESCRIPTION: converts value into a string and stores in string_ptr with NULL termination 
PARMS:
RETURNS:
}}

  if value < 0
    -value
    byte [ string_ptr++ ]  := "-"

  i := 1_000_000_000

  repeat 10
    if value => i
      byte [ string_ptr++ ]  := value / i + "0"
      value //= i
      result~~
    elseif result or i == 1
      byte [ string_ptr++ ]  := "0"
    i /= 10

  ' null terminate
  byte [ string_ptr ] := NULL    

' // end itoa

' /////////////////////////////////////////////////////////////////////////////

PUB atoi2(string_ptr, length) | _index, _sum, _ch, _sign
{{
DESCRIPTION: this method tries to convert the string to a number, supports binary %, hex $, decimal (default)
string_ptr can be to a null terminated string, or the length can be overridden by sending the length shorter
than the null terminator, ignores ws
Eg. %001010110, $EF, 25

PARMS:

RETURNS:
}}

' initialize vars
_index := 0
_sum   := 0
_sign  := 1
 
' consume white space
repeat while (IsSpace( byte[ string_ptr ][_index] ) <> -1)
  _index++
 
' is there a +/- sign?
if (byte [string_ptr][_index] == "+")
  ' consume it
  _index++
elseif (byte [string_ptr][_index] == "-")
  ' consume it
  _index++
  _sign := -1    
     
' try to determine number base
if (byte [string_ptr][_index] == ASCII_HEX)
  _index++
  repeat while ( ( IsDigit(_ch := byte [string_ptr][_index]) <> -1) or ( IsAlpha(_ch := byte [string_ptr][_index]) <> -1)  )
    _index++
    _sum := (_sum << 4) + HexToDec( ToUpper(_ch) )
    if (_index => length)
      return (_sum*_sign)
 
  return(_sum*_sign)
' // end if hex number    
elseif (byte [string_ptr][_index] == ASCII_BIN)
  repeat while ( IsDigit(_ch := byte [string_ptr][++_index]) <> -1)
    _sum := (_sum << 1) + (_ch - ASCII_0)
    if (_index => length)
      return (_sum*_sign)
 
  return(_sum*_sign)
' // end if binary number  
else
  ' must be in default base 10, assume that
  repeat while ( IsDigit(_ch := byte [string_ptr][_index++]) <> -1)
    _sum := (_sum * 10) + (_ch - ASCII_0)
    if (_index => length)
      return (_sum*_sign)
 
  return(_sum*_sign)
 
' else, have no idea of number format!
return(0)
 
' // end atoi2

' /////////////////////////////////////////////////////////////////////////////

PUB Delay_MS( time )
{{
DESCRIPTION: Delays "time" milliseconds and returns. 
PARMS:
RETURNS:
}}

  waitcnt (cnt + time*CLOCKS_PER_MILLISECOND)

' // end Delay_MS

' /////////////////////////////////////////////////////////////////////////////

PUB Delay_US( time )
{{
DESCRIPTION: Delays "time" microseconds and returns. 
PARMS:
RETURNS:
}}

  waitcnt (cnt + time*CLOCKS_PER_MICROSECOND)

' // end Delay_US

'//////////////////////////////////////////////////////////////////////////////

DAT

newline_string          byte      $0D, $0A, $00  ' $0D carriage return, $0A line feed

CON

{{
 ______________________________________________________________________________________________________________________________
|                                                   TERMS OF USE: MIT License                                                  |                                                            
|______________________________________________________________________________________________________________________________|
|Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation    |     
|files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy,    |
|modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software|
|is furnished to do so, subject to the following conditions:                                                                   |
|                                                                                                                              |
|The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.|
|                                                                                                                              |
|THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE          |
|WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR         |
|COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,   |
|ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.                         |
 ------------------------------------------------------------------------------------------------------------------------------ 
}}