namespace ToastmasterTools.Core.ViewModels
{
    public class Member
    {
        public Member()
        {
            
        }
        public Member(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public string Function { get; set; }
    }
}