// See https://aka.ms/new-console-template for more information
using Ionic.Zlib;
using System.IO.Compression;

var coreLibBuffer = new byte[7 * 1024 * 1024];
var dotnetZipBuffer = new byte[7 * 1024 * 1024];
using var coreLibStream = new ZLibStream(File.OpenRead("repro.zlib"), System.IO.Compression.CompressionMode.Decompress);
using var dotnetZipStream = new ZlibStream(File.OpenRead("repro.zlib"), Ionic.Zlib.CompressionMode.Decompress);
var coreLibAmount = coreLibStream.Read(coreLibBuffer, 0, coreLibBuffer.Length);
var dotnetZipAmount = dotnetZipStream.Read(dotnetZipBuffer, 0, dotnetZipBuffer.Length);

if(coreLibAmount != dotnetZipAmount)
{
    for(int i = 0; i < coreLibBuffer.Length; i++)
    {
        if(coreLibBuffer[i] != dotnetZipBuffer[i])
        {
            Console.WriteLine($"CoreLib read:{coreLibAmount}");
            Console.WriteLine($"DotNetZip Read:{dotnetZipAmount}");
            Console.WriteLine($"First discrepency found at byte {i} of output");
            break;
        }
    }
}
else
{
    Console.WriteLine("Both read the same amount");
}
Console.Read();