using System;
using System.Collections.Generic;


namespace Gamess.Core.Entities;
public partial class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string? Telephone { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<Game> UploadedGames { get; set; } = new List<Game>();
    public ICollection<Review> Review { get; set; } = new List<Review>();
}

