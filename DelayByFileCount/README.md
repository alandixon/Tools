# DelayByFileCount

A Windows .Net Core console app extending the [DOS timeout command](https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/timeout_1) by allowing the pause duration to depend on the number of files found in a directory.


## Table of contents
1. [Overview](#Overview)
2. [Usage](#Usage)
3. [Credits](#Credits)

## Overview <a name="Overview"></a>

A small command-line app that pauses until the filecount in a given directory matches a specified value.

## Usage <a name="Usage"></a>

### Parameters
`-d, --Directory (Required) Directory to Watch`

`-f, --FileCount (Required)`
<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`n or +n : Pause until there are n or MORE files.`
<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`-n : Pause until there are n or LESS files`

`--help             Display this help screen.`

`--version          Display version information.`

### Example 1
__Pause until there are 4 or more files in c:\temp:__
<br>
`DelayByFileCount --Directory c:\temp --FileCount 4`

### Example 2
__Pause until there are 3 or less files in c:\temp:__
<br>
`DelayByFileCount --Directory c:\temp --FileCount -3`

## Credits <a name="Credits"></a>

Command Line Parser Library for CLR and NetStandard
https://github.com/commandlineparser/commandline


