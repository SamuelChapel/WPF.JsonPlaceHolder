using WPF.JsonPlaceHolder.Models.Base;

namespace WPF.JsonPlaceHolder.Models;

public class User(int id, string name, string username, string email, Address address, string phone, string website, Company company) : EntityBase<int>(id)
{
	public string Name { get; set; } = name;
	public string Username { get; set; } = username;
	public string Email { get; set; } = email;
	public Address Address { get; set; } = address;
	public string Phone { get; set; } = phone;
	public string Website { get; set; } = website;
	public Company Company { get; set; } = company;
}

public class Address(string street, string suite, string city, string zipcode, Geo geo)
{
	public string Street { get; set; } = street;
	public string Suite { get; set; } = suite;
	public string City { get; set; } = city;
	public string Zipcode { get; set; } = zipcode;
	public Geo Geo { get; set; } = geo;
}

public class Geo(string lat, string lng)
{
	public string Lat { get; set; } = lat;
	public string Lng { get; set; } = lng;
}

public class Company(string name, string catchPhrase, string bs)
{
	public string Name { get; set; } = name;
	public string CatchPhrase { get; set; } = catchPhrase;
	public string Bs { get; set; } = bs;
}