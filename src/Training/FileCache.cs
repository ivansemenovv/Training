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
            var fc = new FileCache(12000);

            fc.Add("https://placeholdit.imgix.net/~text?txt=image1");
            fc.Add("https://placeholdit.imgix.net/~text?txt=image2");
            fc.Add("https://placeholdit.imgix.net/~text?txt=image3");
            fc.Get("https://placeholdit.imgix.net/~text?txt=image2");
            fc.Add("https://placeholdit.imgix.net/~text?txt=image4");
        }

        public FileCache(int cacheSize)
        {
            this.cacheSize = cacheSize;
        }

        public void Add(string fileUrl)
        {
            lock (this)
            {
                if (!map.ContainsKey(fileUrl))
                {
                    var fileSize = GetFileSize(fileUrl);
                    while (this.currentCacheSize + fileSize > this.cacheSize)
                    {
                        if (map.Count == 0)
                            throw new Exception("File is too big");
                        RemoveOldest();
                    }

                    FileContainer fc = new FileContainer()
                    {
                        fileName = fileUrl,
                        content = DownloadFile(fileUrl)
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
