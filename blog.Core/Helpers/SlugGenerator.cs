using System.Text.RegularExpressions;

namespace blog.Core.Helpers
{
    public static class SlugGenerator
    {
            public static async Task<string> GenerateUniqueSlugAsync(string title, Func<string, Task<List<string>>> existingSlugsFetcher)
            {
                if (string.IsNullOrWhiteSpace(title))
                    throw new ArgumentException("Title cannot be null or empty.");

                var baseSlug = GenerateSlug(title);

                var existingSlugs = await existingSlugsFetcher(baseSlug);
                if (!existingSlugs.Contains(baseSlug))
                    return baseSlug;

                int i = 1;
                string newSlug;
                do
                {
                    newSlug = $"{baseSlug}-{i++}";
                } while (existingSlugs.Contains(newSlug));

                return newSlug;
            }

            public static string GenerateSlug(string slug)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(slug))
                    {
                        return "item"; // fallback if title is null or whitespace
                    }

                slug = Regex.Replace(slug.ToLowerInvariant(), @"[^a-z0-9]+", "-").Trim('-');

                    if (string.IsNullOrWhiteSpace(slug))
                    {
                        return "item"; // fallback if only special characters
                    }

                    return slug;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error generating slug", ex);
                }
            }
    }
}
