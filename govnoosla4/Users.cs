namespace govnoosla4;

public class Users
{
    public int id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string gender { get; set; }

    public Users(int id, string firstName, string lastName, string gender)
    {
        this.id = id;
        first_name = firstName;
        last_name = lastName;
        this.gender = gender;
    }

    public string GetUserData()
    {
        return $"Id: {id} Имя: {first_name} Фамилия: {last_name} Пол: {gender}";
    }
}