namespace SqlConfigProvider.Demo
{
    using Microsoft.Extensions.Options;

    public class MyOptions : IOptions<MyOptions>
    {
        public MyOptions Value => this;

        public string MyValue
        {
            get; set;
        }
    }
}
