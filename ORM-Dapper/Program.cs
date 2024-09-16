using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using ORM_Dapper;

//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

var departmentRepo = new DapperDepartmentRepository(conn);

//departmentRepo.InsertDepartment("CSharp-50");  //If keep running, will keep adding CSharp-50 as #6/#7/38/etc so comment out after running.

var departments = departmentRepo.GetAllDepartments();

foreach (var dept in departments)
{
    Console.WriteLine($"DepartmentID: {dept.DepartmentID} | Name: {dept.Name}");
}


