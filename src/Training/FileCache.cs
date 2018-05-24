using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class FileContainer
    {
        public string fileName;
        public MemoryStream content;
    }
    class FileCache
    {
        private int cacheSize;
        private int currentCacheSize = 0;

        Dictionary<string, LinkedListNode<FileContainer>> map = new Dictionary<string, LinkedListNode<FileContainer>>();
        LinkedList<FileContainer> queue = new LinkedList<FileContainer>();

        public static void RunTestCases()
        {
            using (var fw = new StreamWriter("FileCacheTestOutput.txt"))
            {
                using (var fr = new StreamReader("FileCacheTestInput.txt"))
                {
                    int cacheSize = Convert.ToInt32(fr.ReadLine());
                    var fc = new FileCache(cacheSize);
                    int numberOfFiles = Convert.ToInt32(fr.ReadLine());
                    for (int i = 0; i < numberOfFiles; i++)
                    {
                        var fileUrl = fr.ReadLine();
                        var fileContainer = fc.Get(fileUrl);
                        if (null == fileContainer)
                        {
                            var fileContent = fc.DownloadFile(fileUrl);
                            fc.Add(fileUrl, fileContent);
                            fw.WriteLine("{0} DOWNLOADED {1}", fileUrl, fileContent.Capacity);
                        }
                        else
                        {
                            fw.WriteLine("{0} IN_CACHE {1}", fileContainer.fileName, fileContainer.content.Capacity);
                        }
                    }
                }
            }
        }

        public void ReadFromFile()
        {
            using (var fr = new StreamReader("c:\test.txt"))
            {

            }
        }

        public FileCache(int cacheSize)
        {
            this.cacheSize = cacheSize;
        }

        public void Add(string fileUrl, MemoryStream fileContent)
        {
            lock (this)
            {
                if (!map.ContainsKey(fileUrl))
                {
                    var fileSize = fileContent.Capacity;
                    while (this.currentCacheSize + fileSize > this.cacheSize)
                    {
                        if (map.Count == 0)
                            throw new Exception("File is too big");
                        RemoveOldest();
                    }

                    FileContainer fc = new FileContainer()
                    {
                        fileName = fileUrl,
                        content = fileContent
                    };
                    var node = queue.AddFirst(fc);
                    map.Add(fileUrl, node);
                    currentCacheSize += fileSize;
                }
                else
                {
                    Get(fileUrl);
                }
            }
        }

        public FileContainer Get(string fileUrl)
        {

            lock (this)
            {
                if (map.ContainsKey(fileUrl))
                {
                    var node = map[fileUrl];
                    queue.Remove(node);
                    queue.AddFirst(node);
                    return node.Value;
                }
                return null;
            }
        }

        public void RemoveOldest()
        {
            var node = queue.Last;
            this.currentCacheSize -= node.Value.content.Capacity;
            map.Remove(node.Value.fileName);
            queue.RemoveLast();
        }

        private int GetFileSize(string fileUrl)
        {
            using (WebClient client = new WebClient())
            {
                using (var stream = client.OpenRead(fileUrl))
                {
                    return Convert.ToInt32(client.ResponseHeaders["Content-Length"]);
                }
            }
        }

        private MemoryStream DownloadFile(string fileUrl)
        {
            using (WebClient client = new WebClient())
            {
                return new MemoryStream(client.DownloadData(fileUrl));
            }
        }
    }
}
