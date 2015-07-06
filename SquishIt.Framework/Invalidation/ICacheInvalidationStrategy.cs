namespace SquishIt.Framework.Invalidation
{
    public interface ICacheInvalidationStrategy
    {
		/// <summary>
		/// Returns the name and path of the rendered file
		/// </summary>
		/// <param name="outputFile"></param>
		/// <param name="hash">The hash value, replacing the hash key</param>
		/// <returns></returns>
        string GetOutputFileLocation(string outputFile, string hash);

        string GetOutputWebPath(string renderToPath, string hashKeyName, string hash);
    }
}
