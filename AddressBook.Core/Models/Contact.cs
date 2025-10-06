namespace AddressBook
{
	public class Contact
	{
		public string Name { get; set; }
		public string Street { get; set; }
		public string PostalCode { get; set; }
		public string City { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }

		public static List<Contact> GetSampleContacts()
		{
            return new List<Contact>
            {
                new Contact { Name = "Anders Larsson", Street = "Björkvägen 12", PostalCode = "43245", City = "Varberg", PhoneNumber = "0702345678", Email = "anders.larsson@mail.com" },
                new Contact { Name = "Johanna Eriksson", Street = "Kullavägen 8", PostalCode = "25431", City = "Helsingborg", PhoneNumber = "0739988776", Email = "johanna.eriksson@mail.com" },
                new Contact { Name = "Peter Nilsson", Street = "Storgatan 4", PostalCode = "85234", City = "Sundsvall", PhoneNumber = "0704455667", Email = "peter.nilsson@mail.com" },
                new Contact { Name = "Carina Persson", Street = "Skogsvägen 10", PostalCode = "70215", City = "Örebro", PhoneNumber = "0723344556", Email = "carina.persson@mail.com" },
                new Contact { Name = "Mats Karlsson", Street = "Stationsgatan 3", PostalCode = "50431", City = "Borås", PhoneNumber = "0762233445", Email = "mats.karlsson@mail.com" },
                new Contact { Name = "Eva Holmberg", Street = "Lillgatan 5", PostalCode = "33141", City = "Värnamo", PhoneNumber = "0731122334", Email = "eva.holmberg@mail.com" },
                new Contact { Name = "Fredrik Andersson", Street = "Blomgatan 7", PostalCode = "21134", City = "Malmö", PhoneNumber = "0705566778", Email = "fredrik.andersson@mail.com" },
                new Contact { Name = "Linda Svensson", Street = "Tallvägen 2", PostalCode = "54142", City = "Skövde", PhoneNumber = "0729988776", Email = "linda.svensson@mail.com" },
                new Contact { Name = "Jonas Bergström", Street = "Ekstigen 14", PostalCode = "56132", City = "Huskvarna", PhoneNumber = "0736677889", Email = "jonas.bergstrom@mail.com" },
                new Contact { Name = "Annika Lund", Street = "Åkervägen 18", PostalCode = "90334", City = "Umeå", PhoneNumber = "0769988776", Email = "annika.lund@mail.com" },
                new Contact { Name = "Henrik Dahl", Street = "Kopparvägen 9", PostalCode = "79141", City = "Falun", PhoneNumber = "0704455332", Email = "henrik.dahl@mail.com" },
                new Contact { Name = "Karin Olsson", Street = "Furugatan 6", PostalCode = "35234", City = "Växjö", PhoneNumber = "0723355779", Email = "karin.olsson@mail.com" },
                new Contact { Name = "Marcus Nilsson", Street = "Aspvägen 3", PostalCode = "98141", City = "Kiruna", PhoneNumber = "0765544332", Email = "marcus.nilsson@mail.com" },
                new Contact { Name = "Sofia Lindberg", Street = "Norrbackagatan 22", PostalCode = "11341", City = "Stockholm", PhoneNumber = "0707766554", Email = "sofia.lindberg@mail.com" },
                new Contact { Name = "Thomas Johansson", Street = "Brunnsgatan 8", PostalCode = "58233", City = "Linköping", PhoneNumber = "0735544332", Email = "thomas.johansson@mail.com" },
                new Contact { Name = "Rebecca Pettersson", Street = "Rådhusgatan 15", PostalCode = "83145", City = "Östersund", PhoneNumber = "0724455667", Email = "rebecca.pettersson@mail.com" },
                new Contact { Name = "Daniel Berg", Street = "Hantverkargatan 17", PostalCode = "72215", City = "Västerås", PhoneNumber = "0739988112", Email = "daniel.berg@mail.com" },
                new Contact { Name = "Elin Andersson", Street = "Höjdvägen 20", PostalCode = "29131", City = "Kristianstad", PhoneNumber = "0731115589", Email = "elin.andersson@mail.com" },
                new Contact { Name = "Viktor Holm", Street = "Vasagatan 5", PostalCode = "41124", City = "Göteborg", PhoneNumber = "0763322114", Email = "viktor.holm@mail.com" },
                new Contact { Name = "Maria Lundgren", Street = "Ängsvägen 9", PostalCode = "66140", City = "Karlstad", PhoneNumber = "0705544778", Email = "maria.lundgren@mail.com" },
                new Contact { Name = "Patrik Eriksson", Street = "Granvägen 7", PostalCode = "23145", City = "Trelleborg", PhoneNumber = "0708899001", Email = "patrik.eriksson@mail.com" },
                new Contact { Name = "Sandra Karlsson", Street = "Sjövägen 11", PostalCode = "13642", City = "Haninge", PhoneNumber = "0731155779", Email = "sandra.karlsson@mail.com" },
                new Contact { Name = "Hanna Berglund", Street = "Rosenvägen 19", PostalCode = "35234", City = "Växjö", PhoneNumber = "0703344556", Email = "hanna.berglund@mail.com" },
                new Contact { Name = "Niklas Jonsson", Street = "Furuvägen 13", PostalCode = "89123", City = "Örnsköldsvik", PhoneNumber = "0704455991", Email = "niklas.jonsson@mail.com" },
                new Contact { Name = "Malin Persson", Street = "Lundavägen 16", PostalCode = "22233", City = "Lund", PhoneNumber = "0738899224", Email = "malin.persson@mail.com" }
            };
        }
    }   
}
