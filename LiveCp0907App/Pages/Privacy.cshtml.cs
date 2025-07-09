
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System;

namespace LiveCp0907App.Pages;

public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime HiringDate { get; set; }
    public string Department { get; set; }
    public string JobTitle { get; set; }
}

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;
    private readonly IWebHostEnvironment _env;

    public List<Employee> Employees { get; set; } = new();

    public PrivacyModel(ILogger<PrivacyModel> logger, IWebHostEnvironment env)
    {
        _logger = logger;
        _env = env;
    }

    public void OnGet()
    {
        var filePath = Path.Combine(_env.ContentRootPath, "sampledata.json");
        if (System.IO.File.Exists(filePath))
        {
            var json = System.IO.File.ReadAllText(filePath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Employees = JsonSerializer.Deserialize<List<Employee>>(json, options) ?? new List<Employee>();
        }
    }
}

