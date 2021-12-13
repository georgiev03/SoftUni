using System;
using System.IO;
using System.Threading.Tasks;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await using FileStream reader = new FileStream("copyMe.png", FileMode.Open);

            await using FileStream writer = new FileStream("../../../CopiedPic.png", FileMode.Create);

            while (reader.CanRead)
            {
                byte[] buffer = new byte[4096];

                int readBytes = await reader.ReadAsync(buffer, 0, buffer.Length);

                if (readBytes == 0)
                {
                    break;
                }

                await writer.WriteAsync(buffer, 0, readBytes);
            }
        }
    }
}
