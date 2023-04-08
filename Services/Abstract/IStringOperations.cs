
namespace LivaSoftExam.Services.Abstract
{
    public interface IStringOperations
    {
         string CleanComments(string[] str); 
         string CleanSlashComments(string str);
         List<char> FindDifferenceString(string firstArgs, string secondArgs);
    }
}