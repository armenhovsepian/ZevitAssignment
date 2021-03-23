using Domain.Dtos;
using Domain.Entities;
using Domain.Entities.AggregatesModel;
using System.Linq;

namespace Infrastructure.Data
{
    public class ContactContextSeed
    {

        public static void SeedData(ContactContext context)
        {
            using (context)
            {
                context.Database.EnsureCreated();

                if (!context.Contacts.Any())
                {
                    foreach (var item in CONTACTS)
                    {
                        var contact = new Contact(
                            new FullName(item.FirstName, item.LastName),
                            new EmailAddress(item.EmailAddress),
                            new PhoneNumber(item.PhoneNumber),
                            new Address(item.Street, item.City, item.State, item.Country, item.ZipCode)
                            );

                        context.Contacts.Add(contact);
                    }

                    context.SaveChanges();
                }
            }
        }

        private static ContactDto[] CONTACTS = new ContactDto[]
        { new ContactDto
        {
            FirstName = "Kassandra",
            LastName = "Sapauton",
            EmailAddress = "ksapauton0@amazon.co.uk",
            PhoneNumber = "871-834-8155",
            Street = "Gale",
            City = "Bentar",
            State = null,
            Country = "Indonesia",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Gery",
            LastName = "Lagden",
            EmailAddress = "glagden1@infoseek.co.jp",
            PhoneNumber = "821-683-5993",
            Street = "Buena Vista",
            City = "Zliv",
            State = null,
            Country = "Czech Republic",
            ZipCode = "507 23"
        }, new ContactDto
        {
            FirstName = "Celestine",
            LastName = "Creenan",
            EmailAddress = "ccreenan2@hatena.ne.jp",
            PhoneNumber = "998-303-0866",
            Street = "Orin",
            City = "Pingyi",
            State = null,
            Country = "China",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Alyce",
            LastName = "Sheward",
            EmailAddress = "asheward3@berkeley.edu",
            PhoneNumber = "383-619-5234",
            Street = "Roth",
            City = "Rathdrum",
            State = null,
            Country = "Ireland",
            ZipCode = "V14"
        }, new ContactDto
        {
            FirstName = "Cris",
            LastName = "While",
            EmailAddress = "cwhile4@i2i.jp",
            PhoneNumber = "667-902-0200",
            Street = "Lillian",
            City = "Huibu",
            State = null,
            Country = "China",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Ardisj",
            LastName = "Storms",
            EmailAddress = "astorms5@google.de",
            PhoneNumber = "644-981-0514",
            Street = "Hansons",
            City = "Monaragala",
            State = null,
            Country = "Sri Lanka",
            ZipCode = "91000"
        }, new ContactDto
        {
            FirstName = "Ralph",
            LastName = "Vakhrushin",
            EmailAddress = "rvakhrushin6@ow.ly",
            PhoneNumber = "947-386-2570",
            Street = "Blackbird",
            City = "Sanguansi",
            State = null,
            Country = "China",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Cecilla",
            LastName = "Hamlett",
            EmailAddress = "chamlett7@tumblr.com",
            PhoneNumber = "276-853-9715",
            Street = "Farmco",
            City = "Candi Prambanan",
            State = null,
            Country = "Indonesia",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "North",
            LastName = "Blackesland",
            EmailAddress = "nblackesland8@howstuffworks.com",
            PhoneNumber = "902-859-2891",
            Street = "Cascade",
            City = "Jiamachi",
            State = null,
            Country = "China",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Mord",
            LastName = "Daens",
            EmailAddress = "mdaens9@usda.gov",
            PhoneNumber = "323-140-7955",
            Street = "Lakewood Gardens",
            City = "Skawica",
            State = null,
            Country = "Poland",
            ZipCode = "34-221"
        }, new ContactDto
        {
            FirstName = "Bel",
            LastName = "Arzu",
            EmailAddress = "barzua@geocities.jp",
            PhoneNumber = "520-153-8974",
            Street = "Gina",
            City = "Jiangkou",
            State = null,
            Country = "China",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Fabian",
            LastName = "Laurie",
            EmailAddress = "flaurieb@storify.com",
            PhoneNumber = "589-404-3927",
            Street = "Killdeer",
            City = "Sajan",
            State = null,
            Country = "Serbia",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Rycca",
            LastName = "MacCosty",
            EmailAddress = "rmaccostyc@so-net.ne.jp",
            PhoneNumber = "725-658-5114",
            Street = "Portage",
            City = "Ludvika",
            State = "Dalarna",
            Country = "Sweden",
            ZipCode = "771 31"
        }, new ContactDto
        {
            FirstName = "Alfonse",
            LastName = "Mitcheson",
            EmailAddress = "amitchesond@fc2.com",
            PhoneNumber = "502-971-9342",
            Street = "Sunbrook",
            City = "Sabnie",
            State = null,
            Country = "Poland",
            ZipCode = "08-331"
        }, new ContactDto
        {
            FirstName = "Ira",
            LastName = "Akram",
            EmailAddress = "iakrame@ihg.com",
            PhoneNumber = "880-573-7891",
            Street = "Crest Line",
            City = "Suileng",
            State = null,
            Country = "China",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Gallagher",
            LastName = "St Leger",
            EmailAddress = "gstlegerf@samsung.com",
            PhoneNumber = "507-689-2499",
            Street = "Aberg",
            City = "Bang Ban",
            State = null,
            Country = "Thailand",
            ZipCode = "13250"
        }, new ContactDto
        {
            FirstName = "Timmie",
            LastName = "O'Doghesty",
            EmailAddress = "todoghestyg@virginia.edu",
            PhoneNumber = "615-324-2660",
            Street = "Dayton",
            City = "Itzer",
            State = null,
            Country = "Morocco",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Florina",
            LastName = "Pikesley",
            EmailAddress = "fpikesleyh@ucoz.ru",
            PhoneNumber = "129-828-7157",
            Street = "Crownhardt",
            City = "Nuevo Chamelecón",
            State = null,
            Country = "Honduras",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Ed",
            LastName = "Sherburn",
            EmailAddress = "esherburni@washingtonpost.com",
            PhoneNumber = "140-327-1985",
            Street = "Eliot",
            City = "Meilin",
            State = null,
            Country = "China",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Isahella",
            LastName = "Winkett",
            EmailAddress = "iwinkettj@ning.com",
            PhoneNumber = "557-713-9744",
            Street = "School",
            City = "Santol",
            State = null,
            Country = "Philippines",
            ZipCode = "2516"
        }, new ContactDto
        {
            FirstName = "Jewell",
            LastName = "Sleicht",
            EmailAddress = "jsleichtk@ehow.com",
            PhoneNumber = "809-634-1100",
            Street = "Shopko",
            City = "Garajati",
            State = null,
            Country = "Indonesia",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Dorice",
            LastName = "Presdie",
            EmailAddress = "dpresdiel@barnesandnoble.com",
            PhoneNumber = "514-234-6190",
            Street = "Rusk",
            City = "Union",
            State = null,
            Country = "Philippines",
            ZipCode = "5609"
        }, new ContactDto
        {
            FirstName = "Seumas",
            LastName = "Zannutti",
            EmailAddress = "szannuttim@newyorker.com",
            PhoneNumber = "835-178-7835",
            Street = "Carberry",
            City = "Daga",
            State = null,
            Country = "Bhutan",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Renard",
            LastName = "Brummitt",
            EmailAddress = "rbrummittn@mayoclinic.com",
            PhoneNumber = "469-754-0971",
            Street = "Nova",
            City = "Bayabas",
            State = null,
            Country = "Philippines",
            ZipCode = "8303"
        }, new ContactDto
        {
            FirstName = "Jaquenetta",
            LastName = "Dargavel",
            EmailAddress = "jdargavelo@uol.com.br",
            PhoneNumber = "582-588-2834",
            Street = "Namekagon",
            City = "Montería",
            State = null,
            Country = "Colombia",
            ZipCode = "230029"
        }, new ContactDto
        {
            FirstName = "Adrienne",
            LastName = "Colwill",
            EmailAddress = "acolwillp@deviantart.com",
            PhoneNumber = "965-794-9427",
            Street = "Karstens",
            City = "Liubo",
            State = null,
            Country = "China",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Kristi",
            LastName = "Toffano",
            EmailAddress = "ktoffanoq@epa.gov",
            PhoneNumber = "986-725-8071",
            Street = "Summerview",
            City = "Kao Liao",
            State = null,
            Country = "Thailand",
            ZipCode = "60230"
        }, new ContactDto
        {
            FirstName = "Clemmie",
            LastName = "Leatherborrow",
            EmailAddress = "cleatherborrowr@google.it",
            PhoneNumber = "822-769-5685",
            Street = "Nobel",
            City = "Colares",
            State = "Lisboa",
            Country = "Portugal",
            ZipCode = "2705-188"
        }, new ContactDto
        {
            FirstName = "Evin",
            LastName = "Harrigan",
            EmailAddress = "eharrigans@ow.ly",
            PhoneNumber = "216-312-0344",
            Street = "Little Fleur",
            City = "Batur Kidul",
            State = null,
            Country = "Indonesia",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Chantalle",
            LastName = "Hentzer",
            EmailAddress = "chentzert@salon.com",
            PhoneNumber = "781-344-4310",
            Street = "Merchant",
            City = "Dzüünharaa",
            State = null,
            Country = "Mongolia",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Hally",
            LastName = "Ure",
            EmailAddress = "hureu@qq.com",
            PhoneNumber = "757-390-9263",
            Street = "Dayton",
            City = "Rossosh’",
            State = null,
            Country = "Russia",
            ZipCode = "689400"
        }, new ContactDto
        {
            FirstName = "Berthe",
            LastName = "Shortland",
            EmailAddress = "bshortlandv@usatoday.com",
            PhoneNumber = "684-213-8441",
            Street = "Prairieview",
            City = "Krajan Alastengah",
            State = null,
            Country = "Indonesia",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Kalil",
            LastName = "Ickowics",
            EmailAddress = "kickowicsw@google.co.jp",
            PhoneNumber = "560-465-9677",
            Street = "Wayridge",
            City = "Rizhao",
            State = null,
            Country = "China",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Torry",
            LastName = "Downs",
            EmailAddress = "tdownsx@eepurl.com",
            PhoneNumber = "237-221-0642",
            Street = "Sachs",
            City = "Tilamuta",
            State = null,
            Country = "Indonesia",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Birgit",
            LastName = "Fassam",
            EmailAddress = "bfassamy@weather.com",
            PhoneNumber = "655-247-8599",
            Street = "East",
            City = "Taoyuan",
            State = null,
            Country = "China",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Renell",
            LastName = "Anthes",
            EmailAddress = "ranthesz@google.es",
            PhoneNumber = "676-752-6114",
            Street = "Lotheville",
            City = "Banjiang",
            State = null,
            Country = "China",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Tommie",
            LastName = "Weatherburn",
            EmailAddress = "tweatherburn10@dmoz.org",
            PhoneNumber = "403-864-5276",
            Street = "Crest Line",
            City = "Bocowanti",
            State = null,
            Country = "Indonesia",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Ursala",
            LastName = "Clapham",
            EmailAddress = "uclapham11@simplemachines.org",
            PhoneNumber = "244-985-4150",
            Street = "Transport",
            City = "Tubo",
            State = null,
            Country = "Philippines",
            ZipCode = "2814"
        }, new ContactDto
        {
            FirstName = "Freida",
            LastName = "Dukes",
            EmailAddress = "fdukes12@people.com.cn",
            PhoneNumber = "145-267-2305",
            Street = "Monterey",
            City = "Qijiazuo",
            State = null,
            Country = "China",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Thia",
            LastName = "Gepp",
            EmailAddress = "tgepp13@pbs.org",
            PhoneNumber = "117-381-0433",
            Street = "Pepper Wood",
            City = "Zhuli",
            State = null,
            Country = "China",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Rosalie",
            LastName = "Sextie",
            EmailAddress = "rsextie14@ovh.net",
            PhoneNumber = "373-575-5949",
            Street = "Fulton",
            City = "Isabela",
            State = null,
            Country = "Philippines",
            ZipCode = "6128"
        }, new ContactDto
        {
            FirstName = "Anatola",
            LastName = "Marritt",
            EmailAddress = "amarritt15@wiley.com",
            PhoneNumber = "387-337-2028",
            Street = "Fordem",
            City = "Longtanhe",
            State = null,
            Country = "China",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Ingamar",
            LastName = "Eustace",
            EmailAddress = "ieustace16@soup.io",
            PhoneNumber = "504-531-1995",
            Street = "Hovde",
            City = "Bangkalan",
            State = null,
            Country = "Indonesia",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Calvin",
            LastName = "Bellam",
            EmailAddress = "cbellam17@globo.com",
            PhoneNumber = "994-751-1460",
            Street = "Caliangt",
            City = "Pakusari",
            State = null,
            Country = "Indonesia",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Murdock",
            LastName = "Bulloch",
            EmailAddress = "mbulloch18@lulu.com",
            PhoneNumber = "611-718-8849",
            Street = "Monica",
            City = "Jingu",
            State = null,
            Country = "China",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Tyrone",
            LastName = "Passion",
            EmailAddress = "tpassion19@linkedin.com",
            PhoneNumber = "542-294-9102",
            Street = "Southridge",
            City = "Perniö",
            State = null,
            Country = "Finland",
            ZipCode = "25501"
        }, new ContactDto
        {
            FirstName = "Louisette",
            LastName = "Dudney",
            EmailAddress = "ldudney1a@un.org",
            PhoneNumber = "764-573-7789",
            Street = "Magdeline",
            City = "Sōka",
            State = null,
            Country = "Japan",
            ZipCode = "341-0053"
        }, new ContactDto
        {
            FirstName = "Bernetta",
            LastName = "Keenan",
            EmailAddress = "bkeenan1b@bizjournals.com",
            PhoneNumber = "652-535-3503",
            Street = "Clyde Gallagher",
            City = "Besko",
            State = null,
            Country = "Poland",
            ZipCode = "38-524"
        }, new ContactDto
        {
            FirstName = "Shem",
            LastName = "Kilbey",
            EmailAddress = "skilbey1c@51.la",
            PhoneNumber = "862-902-8646",
            Street = "Kinsman",
            City = "Krian",
            State = null,
            Country = "Indonesia",
            ZipCode = null
        }, new ContactDto
        {
            FirstName = "Keene",
            LastName = "Vooght",
            EmailAddress = "kvooght1d@gravatar.com",
            PhoneNumber = "773-309-3539",
            Street = "Arkansas",
            City = "Meishan",
            State = null,
            Country = "China",
            ZipCode = null
        }};

    }
}
