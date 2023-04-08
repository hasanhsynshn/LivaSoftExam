using LivaSoftExam.Services.Abstract;

namespace LivaSoftExam.Services.Concrete
{
    public class StringOperations : IStringOperations
    {
        public string CleanComments(string[] txt)
        {
            try
            {
                var text = string.Join("@", txt);
                var startComment = text.IndexOf("/*");

                if (startComment != -1)
                {
                    var endComment = text.IndexOf("*/", (startComment + 2));

                    if (endComment != -1)

                    {
                        var cnt = (endComment + 2) - startComment;

                        text = text.Remove(startComment, cnt);

                        text = CleanComments(text.Split("@").ToArray());
                    }

                }
                text = CleanSlashComments(text);
                return text;
            }
            catch
            {
                return null;
            }

        }
        public string CleanSlashComments(string txt)
        {
            try
            {
                var startComment = txt.IndexOf("//");

                if (startComment != -1)
                {
                    var endComment = txt.IndexOf("@", (startComment + 2));
                    if (endComment != -1)

                    {
                        var cnt = endComment - startComment;
                        txt = txt.Remove(startComment, cnt);
                    }
                    else
                    {
                        txt = txt.Remove(startComment);
                    }

                    txt = CleanSlashComments(CleanComments(txt.Split("@").ToArray()));

                }

                return txt;
            }
            catch 
            {

                return string.Empty;
            }

        }

        public List<char> FindDifferenceString(string firstArgs, string secondArgs)
        {
            try
            {
                if (string.IsNullOrEmpty(firstArgs) || string.IsNullOrEmpty(secondArgs))
                {
                    return null;
                }

                var differences = new List<char>();
                foreach (char c in firstArgs)
                {
                    if (!secondArgs.Contains(c) && !differences.Contains(c))
                    {
                        differences.Add(c);
                    }
                }

                foreach (char c in secondArgs)
                {
                    if (!firstArgs.Contains(c) && !differences.Contains(c))
                    {
                        differences.Add(c);
                    }
                }
                return differences;
            }
            catch
            {

                return null;
            }
        }
    }
}



