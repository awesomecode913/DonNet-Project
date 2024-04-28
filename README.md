# MT101 Swift message parser and validator

## Introduction
Your current task is to implement a parser and a validator for data that contains Swift MT101 messages.

The MT standards have a specific structure (described below).
The MT messages are divided into many categories from various financial areas. Each category has a specific message type.
The SWIFT MT101 message is a request for transfer, enabling the electronic transfer of funds from one account to another.

## MT 101 Format Specifications
**Notice: For the current task, the Swift MT101 message specification described below is limited only to the required range.**

### Blocks specification
All swift messages have a block structure (5 blocks) and each block starts and ends with a curly bracket:
**{1:data}{2:data}{3:data}{4:data}{4:data}..{4:data}{5:data}**
**Blocks 1, 2, 3 and 5** are not required. 
**Block 4** is required and at least one block 4 has to exist. 
**Block 4** always starts with `{4:` and ends with `-}` and can contains many lines. Line can not start with `-` except the ending `-}`.  Block 4 can not contains `{` and `}` inside block.
**Block 4** can start from new line or after other block 1..4.

**Sample of the MT 101:**

> **{1:** SOMETHING **}{2:** SOMETHING **}{3:**{113:SEPA}{108:SOMETHING}}**{4:**
:20:1106210100000003 
:28D:1/2 
:50H:/PL64114010100000123456001001
ORDERING CUSTOMER NAME
:52A:BREXPLPWXXX
:30:110621 
:21:2011062100000003 
:32B:EUR955,55 
:70:INVOICE 11/06/06 
:71A:SHA 
**-}{4:**:20:1106210100000003 
:28D:1/2 
:50H:/PL64114010100000123456001001
ORDERING CUSTOMER NAME
:52A:BREXPLPWXXX
:30:110621 
:21:2011062100000003 
:32B:EUR955,55 
:57A:CITIGB2LXXX 
:59:/IT40S0542811101000000123456
BENEFICIARY NAME
:70:INVOICE 2 
:71A:SHA **-}**
**{4:**
:20:1106210100000003 
:28D:1/2 
:50H:/PL64114010100000123456001001
ORDERING CUSTOMER NAME
:52A:BREXPLPWXXX
:30:110621 
:21:2011062100000003 
:32B:EUR955,55 
:57A:CITIGB2LXXX 
:59:/IT40S0542811101000000123456
BENEFICIARY NAME
:70:INVOICE 2 
:71A:SHA **-}**
**{5:**{MAC:00000000}{CHK:24857F4599E7}{TNG:}**}**

### SWIFT Characters Set
**Allowed characters:**
Letters and numbers: `a-z, A-Z, 0-9`
Other characters: `/-?:().,'+{}`
CR: `0x0D`
LF: `0x0A`
Space: `0x20`

## Requirements

**Remember:**
**The content is UTF-8 encoded.**
**The line separator is CR(`0x0D`)LF (`0x0A`).**

The `MT101Parser.ValidateFormat` method should check (**in the order described below**) if:
- **Attention: line numbers returned in exceptions should be counted from 1 (not from 0)**
- The content contains at least one character, otherwise the `NoDataException` should be thrown.
- There are no empty lines, otherwise you should throw `EmptyLinesException` containing invalid line numbers.
- There are no lines starting with `-`, except for `-}`; otherwise you should throw `IncorrectLinesException` containing invalid line numbers.
- There is at least one block `{4:`; otherwise the `MTFormatException` should be thrown.
- No other curly brackets (`{`,`}`) exist inside Block 4; otherwise the `MTFormatException` should be thrown.
- All lines contain only the allowed characters (see the **SWIFT characters set**), 
	otherwise the `NotAllowedCharactersException` with a list with the forbidden characters and their position in the file (counted from 1) should be thrown -
	for example, for content `{4:#-}` it should return `4` as the position of the invalid `#` character. 	
	
The `MT101Parser.Parse` should:
*We can assume that the data format is correct (`ValidateFormat` was executed before calling `Parse`).*
- Should read all **Block 4** and return them as an array of `Model.MT101Message` elements. The `Model.MT101Message.Raw` should contain the content of block 4.  

The functionality should be exposed as a RESTfull service:
- The `SwiftToolsApiController.ValidateMT101Content` should be available as a HTTP POST `/api/swift/validate-format-mt101`. 
	It should use `ValidateFormat` to validate the content.
	It should return the value according to the description in the code (see method description into `SwiftToolsApiController`).

## Hints
1. Your solution should pass all tests.
2. Follow the TODO comments.
3. *To run all tests, you may need to run Visual Studio with administrator privileges.*
