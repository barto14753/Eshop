namespace Eshop.Application.Shared
{
    public class CustomerDto
    {
        public Guid Id { get; private set; }

        public String Name { get; private set; }

        private CustomerDto()
        {

        }

        public CustomerDto(Guid id, String name)
        {
            Id = id;
            Name = name;
        }
    }
}
