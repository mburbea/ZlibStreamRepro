# ZlibStreamRepro

CoreLib's ZlibStream seems to cut short on reading a zlibstream, but a 3rd party library does not.
This zlibstream is part of a save game file in Kingdoms of Amalur: Re-Reckoning. I extract out the bundle data from a save file and compared the amount read.
While the 3rd party nuget file can read the entire section, the built in System.IO.Compression.ZLibStream seems to only read about 55k.

This code is modelled after the code used in my editor
https://github.com/mburbea/koar-item-editor/blob/48d56f7eb8848351e85a31b20ca3ad53f139168a/KoAR.Core/GameSave.cs#L53-L54

The program shows the following output:

```
CoreLib read:51869
DotNetZip Read:133285
First discrepency found at byte 51869 of output
```

