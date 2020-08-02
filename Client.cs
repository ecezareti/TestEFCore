using System;

namespace TestEFCore
{
    public sealed class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
