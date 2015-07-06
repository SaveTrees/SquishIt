namespace SquishIt.Framework.Invalidation
{
    using System.IO;

    public class DefaultCacheInvalidationStrategy : ICacheInvalidationStrategy
    {
        public string GetOutputFileLocation(string outputFile, string hash)
        {
            var fileName = Path.GetFileName(outputFile);

            if (fileName != null && fileName.Contains("#"))
            {
                var outputFileWithHashValue = fileName.Replace("#", hash);
                var directory = Path.GetDirectoryName(outputFile);
                outputFileWithHashValue = directory == null ? outputFileWithHashValue : Path.Combine(directory, outputFileWithHashValue);

                return outputFileWithHashValue;
            }

            return outputFile;
        }

        public string GetOutputWebPath(string renderToPath, string hashKeyName, string hash)
        {
            if (renderToPath.Contains("#"))
            {
                return renderToPath.Replace("#", hash);
            }
            if (!string.IsNullOrEmpty(hashKeyName))
            {
                return renderToPath + (renderToPath.Contains("?") ? "&" : "?") + hashKeyName + "=" + hash;
            }
            return renderToPath;
        }
    }
}