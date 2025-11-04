'' ===========================================================================
''
''  File: ADS_PersonObject_010.spin 
''
''  Modification History
''
''  Author:     Andre' LaMothe 
''  Copyright (c) Andre' LaMothe / Parallax Inc.
''  See end of file for terms of use
''  Version:    1.0
''  Date:       2/20/2011
''
''  Comments: This "object" is a container for the person record format. It includes
''  both local data for the fields of each element in the record as well as accessor
''  method to get and set the data in the record. It is used by the demo
''  ADS_ObjectArrayDemo_010.spin.

'' ===========================================================================


CON
' -----------------------------------------------------------------------------
' CONSTANTS, DEFINES, MACROS, ETC.   
' -----------------------------------------------------------------------------

  ' string processing constants
  MAX_NAME_LENGTH   = 33 ' max length of a person's name, 32 plus a NULL

VAR
' -----------------------------------------------------------------------------
' DECLARED VARIABLES, ARRAYS, ETC.   
' -----------------------------------------------------------------------------
' Each time the caller creates one of these "objects" another set of these variables
' are created that are local to this object. The idea is for the calling application
' to create an object array for the data structure/record and then use accessor
' methods to access the variables of each object array record
byte name[ MAX_NAME_LENGTH ] ' string as usual
byte age
byte height
byte weight

CON
' -----------------------------------------------------------------------------
' GETTER METHODS FIRST, convention will be to prefix "read" methods with "_"   
' -----------------------------------------------------------------------------

PUB _name
  return ( @name )

PUB _age
  return ( age )

PUB _height
  return ( height )

PUB _weight
  return ( weight )

CON
' -----------------------------------------------------------------------------
' SETTER METHODS NEXT, convention will be to suffix "write" methods with "_"   
' -----------------------------------------------------------------------------

PUB name_( pStrPtr )
  bytemove( @name, pStrPtr, strsize( pStrPtr ) + 1)

PUB age_( pAge )
  age := pAge
 
PUB height_( pHeight )
  height := pHeight

PUB weight_( pWeight )
  weight := pweight