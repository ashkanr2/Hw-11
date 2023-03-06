using _10.Models;
namespace _10.Data_Access
{
    public class AcountRippo
    {
        public static List<Account> Accounts = new List<Account>
        {
            new Account{ Id =1,Name="admin",Email="admin",Password="admin",Phone="111"},
            new Account{Id =2,Name="ashkan ",Email="person",Password="person",Phone="222"}
        };
        public List<Account> GetList()
        {
            return Accounts;
        }
    }

}
