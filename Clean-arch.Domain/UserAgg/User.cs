using Clean_arch.Domain.Shared;
using Clean_arch.Domain.UserAgg.Events;
using Clean_arch.Domain.Users.ValueObjects;

namespace Clean_arch.Domain.Users;

public class User : AggregateRoot
{
    private User()
    {

    }
    public User(string name, string family, PhoneNumber phoneNumber, string email)
    {
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
    }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Family { get; private set; }
    public PhoneNumber PhoneNumber { get; set; }

    public static User Register(string email, PhoneNumber phoneNumber)
    {
        var user = new User("", "", phoneNumber, email);
        user.AddDomainEvent(new UserRegistered(user.Id, email));
        return user;
    }
}