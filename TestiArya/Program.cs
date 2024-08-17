using iArya.DataLayer.Interfaces;
using iArya.DataLayer.Repositories;

IRoleRepository repository = new RoleRepository ();

var AllRole = repository.GetAllRoles();

Console.ReadKey();