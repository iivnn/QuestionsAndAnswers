using Humanizer;
using Microsoft.EntityFrameworkCore;
using NLipsum.Core;
using QuestionsAndAnswers.Models;

namespace QuestionsAndAnswers.Data
{
    public static class DbInitializer
    {
        public static void Initialize(QuestionsAndAnswersContext context)
        {
            #region Tags
            if (context.Tags != null)
            {
                if (!context.Tags.Any())
                {
                    using var transaction = context.Database.BeginTransaction();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Tags ON");
                    context.SaveChanges();

                    var tags = new Tag[]
                    {
                        new() 
                        {
                            Id = 1,
                            Name = "javascript",
                            DescriptionEN = "JavaScript is a versatile, high-level programming language primarily used for creating interactive web pages. It enables developers to add dynamic " +
                            "functionality and interactivity to websites, making it a cornerstone of modern web development.",
                            DescriptionPT = "JavaScript é uma linguagem de programação versátil e de alto nível, usada principalmente para criar páginas da web interativas. Ela permite aos desenvolvedores " +
                            "adicionar funcionalidade dinâmica e interatividade aos sites, tornando-se um elemento fundamental no desenvolvimento web moderno.",
                            Color = "#ECE931",
                            InnerColor = "#000000",
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new() 
                        {
                            Id = 2,
                            Name = "c#",
                            DescriptionEN = "C# is a versatile, object-oriented programming language developed by Microsoft for the .NET framework. It's used for building a wide range of applications, " +
                            "from desktop software to web applications and games.",
                            DescriptionPT = "C# é uma linguagem de programação versátil e orientada a objetos, desenvolvida pela Microsoft para o framework .NET. É usada para construir uma ampla variedade de " +
                            "aplicativos, desde software para desktop até aplicativos web e jogos.",
                            Color = "#581B92",
                            InnerColor = "#FFFFFF",
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new() 
                        {
                            Id = 3,
                            Name = "java",
                            DescriptionEN = "Java is a popular, object-oriented programming language known for its platform independence. Developed by Sun Microsystems (now owned by Oracle)," +
                            " Java is widely used for building mobile apps, web applications, and enterprise software systems.",
                            DescriptionPT = "Java é uma linguagem de programação popular e orientada a objetos conhecida por sua independência de plataforma. Desenvolvida pela Sun Microsystems " +
                            "(agora pertencente à Oracle), o Java é amplamente utilizado para construir aplicativos móveis, aplicativos web e sistemas de software empresariais.",
                            Color = "#F8B867",
                            InnerColor = "#54566F",
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new() 
                        {
                            Id = 4,
                            Name = "python",
                            DescriptionEN = "Python is a versatile, high-level programming language known for its simplicity and readability. It is widely used for web development, data analysis, " +
                            "artificial intelligence, scientific computing, and more. Python's elegant syntax and extensive standard libraries make it a favorite among developers for rapid application development.",
                            DescriptionPT = "Python é uma linguagem de programação versátil e de alto nível conhecida por sua simplicidade e legibilidade. É amplamente utilizada para desenvolvimento web, análise de dados, " +
                            "inteligência artificial, computação científica e muito mais. A sintaxe elegante do Python e suas extensas bibliotecas padrão o tornam um favorito entre os desenvolvedores para o desenvolvimento rápido de aplicativos.",
                            Color = "#3C55DE",
                            InnerColor = "#EBEB42",
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new() 
                        {
                            Id = 5,
                            Name = "php",
                            DescriptionEN = "PHP is a popular server-side scripting language used for web development. It is particularly well-suited for creating dynamic web pages and interacting with databases. " +
                            "PHP is widely used in conjunction with HTML to build websites and web applications, powering a significant portion of the internet.",
                            DescriptionPT = "PHP é uma linguagem de script do lado do servidor popular usada para desenvolvimento web. É especialmente adequada para criar páginas da web dinâmicas e interagir com bancos de dados. O " +
                            "PHP é amplamente utilizado em conjunto com HTML para construir sites e aplicativos web, impulsionando uma parte significativa da internet.",
                            Color = "#AC9FE3",
                            InnerColor = "#FFFFFF",
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new() 
                        {
                            Id = 6,
                            Name = "c++",
                            DescriptionEN = "C++ is a powerful, high-level programming language known for its efficiency and performance. It is widely used for system/software development, game development, and high-performance applications. " +
                            "C++ offers features such as object-oriented programming, memory management control, and low-level manipulation, making it a versatile language for various domains.",
                            DescriptionPT = "C++ é uma linguagem de programação poderosa e de alto nível conhecida por sua eficiência e desempenho. É amplamente utilizada para desenvolvimento de sistemas/software, desenvolvimento de jogos e " +
                            "aplicações de alto desempenho. C++ oferece recursos como programação orientada a objetos, controle de gerenciamento de memória e manipulação de baixo nível, tornando-se uma linguagem versátil para diversos domínios.",
                            Color = "#004482",
                            InnerColor = "#FFFFFF",
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new() 
                        {
                            Id = 7,
                            Name = "c",
                            DescriptionEN = "C is a procedural programming language originally developed for system programming tasks. It is known for its efficiency, simplicity, and flexibility. C has been widely used in developing operating" +
                            " systems, compilers, and embedded systems due to its low-level features and ability to directly manipulate memory.",
                            DescriptionPT = "C é uma linguagem de programação procedural desenvolvida originalmente para tarefas de programação de sistemas. É conhecida por sua eficiência, simplicidade e flexibilidade. O C tem sido amplamente " +
                            "utilizado no desenvolvimento de sistemas operacionais, compiladores e sistemas embarcados devido às suas características de baixo nível e capacidade de manipulação direta de memória.",
                            Color = "#A9BACD",
                            InnerColor = "#FFFFFF",
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new() 
                        {
                            Id = 8,
                            Name = "ruby",
                            DescriptionEN = "Ruby is a dynamic, object-oriented programming language known for its simplicity and productivity. It emphasizes readability and flexibility, making it popular for web development, particularly " +
                            "with the Ruby on Rails framework. Ruby's elegant syntax and extensive libraries promote rapid development and maintainability of applications.",
                            DescriptionPT = "Ruby é uma linguagem de programação dinâmica e orientada a objetos conhecida por sua simplicidade e produtividade. Ela enfatiza a legibilidade e a flexibilidade, tornando-se popular para o " +
                            "desenvolvimento web, especialmente com o framework Ruby on Rails. A sintaxe elegante do Ruby e suas extensas bibliotecas promovem o desenvolvimento rápido e a manutenibilidade de aplicativos.",
                            Color = "#BF2533",
                            InnerColor = "#FFFFFF",
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new() 
                        {
                            Id = 9,
                            Name = "kotlin",
                            DescriptionEN = "Kotlin is a modern, statically typed programming language developed by JetBrains. It is designed to be fully interoperable with Java and is often used for Android app development. Kotlin " +
                            "offers concise syntax, null safety features, and functional programming capabilities, making it popular among developers for its ease of use and enhanced productivity.",
                            DescriptionPT = "Kotlin é uma linguagem de programação moderna e fortemente tipada desenvolvida pela JetBrains. Foi projetada para ser totalmente interoperável com Java e é frequentemente usada para o " +
                            "desenvolvimento de aplicativos Android. Kotlin oferece uma sintaxe concisa, recursos de segurança nula e capacidades de programação funcional, tornando-se popular entre os desenvolvedores por sua facilidade de " +
                            "uso e produtividade aprimorada.",
                            Color = "#0898D8",
                            InnerColor = "#7A4906",
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new() 
                        {
                            Id = 10,
                            Name = "sql",
                            DescriptionEN = "SQL (Structured Query Language) is a domain-specific language used for managing relational databases. It provides a standardized way to interact with databases, allowing users to query, " +
                            "insert, update, and delete data. SQL is widely used in database management systems such as MySQL, PostgreSQL, SQL Server, and Oracle Database, among others. It is essential for data manipulation, retrieval, " +
                            "and management in various applications and industries.",
                            DescriptionPT = "SQL (Structured Query Language) é uma linguagem específica de domínio usada para gerenciar bancos de dados relacionais. Ela fornece uma maneira padronizada de interagir com bancos de dados, " +
                            "permitindo que os usuários consultem, insiram, atualizem e excluam dados. O SQL é amplamente utilizado em sistemas de gerenciamento de banco de dados como MySQL, PostgreSQL, SQL Server e Oracle Database, " +
                            "entre outros. É essencial para a manipulação, recuperação e gerenciamento de dados em várias aplicações e setores industriais.",
                            Color = "#0072C6",
                            InnerColor = "#FFFFFF",
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new() 
                        {
                            Id = 11,
                            Name = "css",
                            DescriptionEN = "CSS (Cascading Style Sheets) is a style sheet language used to define the presentation of HTML and XML documents. It controls the layout, formatting, and appearance of web pages, allowing " +
                            "developers to customize the visual aspects such as colors, fonts, spacing, and positioning. CSS works by selecting HTML elements and applying styles to them, either directly within HTML documents or externally " +
                            "through separate CSS files. It plays a crucial role in web design and front-end development, enabling the creation of visually appealing and responsive websites.",
                            DescriptionPT = "CSS (Cascading Style Sheets) é uma linguagem de folha de estilo usada para definir a apresentação de documentos HTML e XML. Ela controla o layout, formatação e aparência de páginas da web, " +
                            "permitindo que os desenvolvedores personalizem aspectos visuais como cores, fontes, espaçamento e posicionamento. O CSS funciona selecionando elementos HTML e aplicando estilos a eles, seja diretamente " +
                            "dentro de documentos HTML ou externamente por meio de arquivos CSS separados. Ele desempenha um papel crucial no design web e no desenvolvimento front-end, permitindo a criação de sites visualmente atraentes" +
                            " e responsivos.",
                            Color = "#0072C6",
                            InnerColor = "#000000",
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new() 
                        {
                            Id = 12,
                            Name = "swift",
                            DescriptionEN = "Swift is a modern, powerful programming language developed by Apple for building apps on their platforms like macOS, iOS, watchOS, and tvOS. It's designed to be safe, efficient, and easy to" +
                            " learn, with features like type inference and optionals for writing clean, concise code.",
                            DescriptionPT = "Swift é uma linguagem de programação moderna e poderosa desenvolvida pela Apple para construir aplicativos em suas plataformas como macOS, iOS, watchOS e tvOS. Ela foi projetada para ser segura, " +
                            "eficiente e fácil de aprender, com recursos como inferência de tipo e opcionais para escrever código limpo e conciso.",
                            Color = "#F0563E",
                            InnerColor = "#FFFFFF",
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new() 
                        {
                            Id = 13,
                            Name = "cobol",
                            DescriptionEN = "COBOL (Common Business-Oriented Language) is a high-level programming language used mainly for business and administrative systems. It's known for its readability and robustness, particularly" +
                            " in industries like banking, insurance, and government.",
                            DescriptionPT = "COBOL (Common Business-Oriented Language) é uma linguagem de programação de alto nível usada principalmente para sistemas de negócios e administrativos. É conhecida por sua legibilidade e " +
                            "robustez, especialmente em setores como bancos, seguros e governo.",
                            Color = "#4F4F54",
                            InnerColor = "#000000",
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new() 
                        {
                            Id = 14,
                            Name = "perl",
                            DescriptionEN = "Perl is a high-level programming language known for its versatility and text processing capabilities. It's often used for system administration, web development, and network programming." +
                            " Perl's syntax is designed to make common tasks easy and concise, making it popular among developers for its flexibility and expressiveness.",
                            DescriptionPT = "Perl é uma linguagem de programação de alto nível conhecida por sua versatilidade e capacidades de processamento de texto. É frequentemente utilizada para administração de sistemas, " +
                            "desenvolvimento web e programação de redes. A sintaxe do Perl é projetada para facilitar e tornar concisas tarefas comuns, tornando-a popular entre os desenvolvedores pela sua flexibilidade e expressividade.",
                            Color = "#000000",
                            InnerColor = "#FFFFFF",
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new() 
                        {
                            Id = 15,
                            Name = "go",
                            DescriptionEN = "Go, also known as Golang, is a statically typed, compiled programming language developed by Google. It's designed for simplicity and efficiency, with features like concurrency support and" +
                            " built-in garbage collection. Go is commonly used for building scalable, high-performance web servers, distributed systems, and cloud applications.",
                            DescriptionPT = "Go, também conhecido como Golang, é uma linguagem de programação compilada e fortemente tipada desenvolvida pelo Google. Ela foi projetada para simplicidade e eficiência, com recursos como " +
                            "suporte à concorrência e coleta de lixo embutida. Go é comumente utilizado para construir servidores web escaláveis e de alto desempenho, sistemas distribuídos e aplicativos em nuvem.",
                            Color = "#00ACD7",
                            InnerColor = "#FFFFFF",
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new() 
                        {
                            Id = 16,
                            Name = "html",
                            DescriptionEN = "HTML (Hypertext Markup Language) is the standard markup language for creating web pages and web applications. It defines the structure and content of a web page using elements" +
                            " such as headings, paragraphs, links, images, and forms. HTML is complemented by CSS (Cascading Style Sheets) for styling and JavaScript for interactivity, forming the core technologies of the World Wide Web.",
                            DescriptionPT = "HTML (Hypertext Markup Language) é a linguagem de marcação padrão para criar páginas da web e aplicativos web. Ela define a estrutura e o conteúdo de uma página da web usando elementos como " +
                            "cabeçalhos, parágrafos, links, imagens e formulários. O HTML é complementado pelo CSS (Cascading Style Sheets) para estilização e pelo JavaScript para interatividade, formando as tecnologias essenciais da World Wide Web.",
                            Color = "#E44D26",
                            InnerColor = "#FFFFFF",
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new() 
                        {
                            Id = 17,
                            Name = "typescript",
                            DescriptionEN = "TypeScript is a superset of JavaScript with optional static typing and additional features. Developed by Microsoft, it helps catch errors early in development, compiles to JavaScript, and is" +
                            " widely used for building web applications, often with frameworks like Angular and React.",
                            DescriptionPT = "TypeScript é um superset do JavaScript com tipagem estática opcional e recursos adicionais. Desenvolvido pela Microsoft, ele ajuda a detectar erros precocemente no desenvolvimento, compila " +
                            "para JavaScript e é amplamente utilizado para construir aplicações web, frequentemente com frameworks como Angular e React.",
                            Color = "#377CC8",
                            InnerColor = "#FFFFFF",
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        }
                    };
                    context.Tags.AddRange(tags);
                    context.SaveChanges();

                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Tags OFF");
                    context.SaveChanges();
                    transaction.Commit();
                }
            }
            #endregion

            #region Users
            if (context.Users != null)
            {
                if (!context.Users.Any())
                {
                    using var transaction = context.Database.BeginTransaction();

                    var users = new User[]
                    {
                        new()//0
                        {
                            Id = Guid.NewGuid().ToString(),
                            About = "Just another user",
                            ImageName = "user123.jpg",
                            UserName = "user123",
                            NormalizedUserName = "USER123",
                            Email = "user123@example.com",
                            NormalizedEmail = "USER123@EXAMPLE.COM",
                            EmailConfirmed = true,
                            PasswordHash = "AQAAAAIAAYagAAAAECk8zkp/0rIBzueHYjyJfUMouMVXBLRsaekBiNxUfMocn1pirnInBVz1E+rILF1dSw==", //123123
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            LockoutEnd = null,
                            LockoutEnabled = true,
                            AccessFailedCount = 0,
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new()//1
                        {
                            Id = Guid.NewGuid().ToString(),
                            About = "Coding enthusiast and coffee lover ☕️",
                            ImageName = "codejava.png",
                            UserName = "codejava",
                            NormalizedUserName = "CODEJAVA",
                            Email = "codejava@example.com",
                            NormalizedEmail = "CODEJAVA@EXAMPLE.COM",
                            EmailConfirmed = true,
                            PasswordHash = "AQAAAAIAAYagAAAAECk8zkp/0rIBzueHYjyJfUMouMVXBLRsaekBiNxUfMocn1pirnInBVz1E+rILF1dSw==", //123123
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            LockoutEnd = null,
                            LockoutEnabled = true,
                            AccessFailedCount = 0,
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new()//2
                        {
                            Id = Guid.NewGuid().ToString(),
                            About = "Music lover and aspiring musician 🎸",
                            ImageName = "rockstar.jpg",
                            UserName = "rockstar",
                            NormalizedUserName = "ROCKSTAR",
                            Email = "rockstar@example.com",
                            NormalizedEmail = "ROCKSTAR@EXAMPLE.COM",
                            EmailConfirmed = true,
                            PasswordHash = "AQAAAAIAAYagAAAAECk8zkp/0rIBzueHYjyJfUMouMVXBLRsaekBiNxUfMocn1pirnInBVz1E+rILF1dSw==", //123123
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            LockoutEnd = null,
                            LockoutEnabled = true,
                            AccessFailedCount = 0,
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new()//3
                        {
                            Id = Guid.NewGuid().ToString(),
                            About = "Gaming addict and eSports enthusiast 🎮",
                            ImageName = "gameon.jpg",
                            UserName = "gameon",
                            NormalizedUserName = "GAMEON",
                            Email = "gameon@example.com",
                            NormalizedEmail = "GAMEON@EXAMPLE.COM",
                            EmailConfirmed = true,
                            PasswordHash = "AQAAAAIAAYagAAAAECk8zkp/0rIBzueHYjyJfUMouMVXBLRsaekBiNxUfMocn1pirnInBVz1E+rILF1dSw==", //123123
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            LockoutEnd = null,
                            LockoutEnabled = true,
                            AccessFailedCount = 0,
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new()//4
                        {
                            Id = Guid.NewGuid().ToString(),
                            About = "Foodie exploring the culinary world 🍔",
                            ImageName = "foodlover.jpg",
                            UserName = "foodlover",
                            NormalizedUserName = "FOODLOVER",
                            Email = "foodlover@example.com",
                            NormalizedEmail = "FOODLOVER@EXAMPLE.COM",
                            EmailConfirmed = true,
                            PasswordHash = "AQAAAAIAAYagAAAAECk8zkp/0rIBzueHYjyJfUMouMVXBLRsaekBiNxUfMocn1pirnInBVz1E+rILF1dSw==", //123123
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            LockoutEnd = null,
                            LockoutEnabled = true,
                            AccessFailedCount = 0,
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new()//5
                        {
                            Id = Guid.NewGuid().ToString(),
                            About = "Travel enthusiast with a passion for exploring new cultures ✈️",
                            ImageName = "globetrotter.jpg",
                            UserName = "globetrotter",
                            NormalizedUserName = "GLOBETROTTER",
                            Email = "globetrotter@example.com",
                            NormalizedEmail = "GLOBETROTTER@EXAMPLE.COM",
                            EmailConfirmed = true,
                            PasswordHash = "AQAAAAIAAYagAAAAECk8zkp/0rIBzueHYjyJfUMouMVXBLRsaekBiNxUfMocn1pirnInBVz1E+rILF1dSw==", //123123
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            LockoutEnd = null,
                            LockoutEnabled = true,
                            AccessFailedCount = 0,
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new()//6
                        {
                            Id = Guid.NewGuid().ToString(),
                            About = "Bookworm and literature enthusiast 📚",
                            ImageName = "bookworm.jpg",
                            UserName = "bookworm",
                            NormalizedUserName = "BOOKWORM",
                            Email = "bookworm@example.com",
                            NormalizedEmail = "BOOKWORM@EXAMPLE.COM",
                            EmailConfirmed = true,
                            PasswordHash = "AQAAAAIAAYagAAAAECk8zkp/0rIBzueHYjyJfUMouMVXBLRsaekBiNxUfMocn1pirnInBVz1E+rILF1dSw==", //123123
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            LockoutEnd = null,
                            LockoutEnabled = true,
                            AccessFailedCount = 0,
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new()//7
                        {
                            Id = Guid.NewGuid().ToString(),
                            About = "Fitness enthusiast and gym rat 💪",
                            ImageName = "fitfreak.jpg",
                            UserName = "fitfreak",
                            NormalizedUserName = "FITFREAK",
                            Email = "fitfreak@example.com",
                            NormalizedEmail = "FITFREAK@EXAMPLE.COM",
                            EmailConfirmed = true,
                            PasswordHash = "AQAAAAIAAYagAAAAECk8zkp/0rIBzueHYjyJfUMouMVXBLRsaekBiNxUfMocn1pirnInBVz1E+rILF1dSw==", //123123
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            LockoutEnd = null,
                            LockoutEnabled = true,
                            AccessFailedCount = 0,
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new()//8
                        {
                            Id = Guid.NewGuid().ToString(),
                            About = "Tech enthusiast exploring the digital world!",
                            ImageName = "digital_nomad.jpg",
                            UserName = "digital_nomad",
                            NormalizedUserName = "DIGITAL_NOMAD",
                            Email = "digital_nomad@example.com",
                            NormalizedEmail = "DIGITAL_NOMAD@EXAMPLE.COM",
                            EmailConfirmed = true,
                            PasswordHash = "AQAAAAIAAYagAAAAECk8zkp/0rIBzueHYjyJfUMouMVXBLRsaekBiNxUfMocn1pirnInBVz1E+rILF1dSw==", //123123
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            LockoutEnd = null,
                            LockoutEnabled = true,
                            AccessFailedCount = 0,
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new()//9
                        {
                            Id = Guid.NewGuid().ToString(),
                            About = "Foodie on a culinary adventure!",
                            ImageName = "gourmet_explorer.jpg",
                            UserName = "gourmet_explorer",
                            NormalizedUserName = "GOURMET_EXPLORER",
                            Email = "gourmet_explorer@example.com",
                            NormalizedEmail = "GOURMET_EXPLORER@EXAMPLE.COM",
                            EmailConfirmed = true,
                            PasswordHash = "AQAAAAIAAYagAAAAECk8zkp/0rIBzueHYjyJfUMouMVXBLRsaekBiNxUfMocn1pirnInBVz1E+rILF1dSw==", //123123
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            LockoutEnd = null,
                            LockoutEnabled = true,
                            AccessFailedCount = 0,
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new()//10
                        {
                            Id = Guid.NewGuid().ToString(),
                            About = "Art lover creating beauty one stroke at a time!",
                            ImageName = "artistic_soul.jpg",
                            UserName = "artistic_soul",
                            NormalizedUserName = "ARTISTIC_SOUL",
                            Email = "artistic_soul@example.com",
                            NormalizedEmail = "ARTISTIC_SOUL@EXAMPLE.COM",
                            EmailConfirmed = true,
                            PasswordHash = "AQAAAAIAAYagAAAAECk8zkp/0rIBzueHYjyJfUMouMVXBLRsaekBiNxUfMocn1pirnInBVz1E+rILF1dSw==", //123123
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            LockoutEnd = null,
                            LockoutEnabled = true,
                            AccessFailedCount = 0,
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new()//11
                        {
                            Id = Guid.NewGuid().ToString(),
                            About = "Adventurous spirit seeking new horizons!",
                            ImageName = "wanderlust_86.jpg",
                            UserName = "wanderlust_86",
                            NormalizedUserName = "WANDERLUST_86",
                            Email = "wanderlust_86@example.com",
                            NormalizedEmail = "WANDERLUST_86@EXAMPLE.COM",
                            EmailConfirmed = true,
                            PasswordHash = "AQAAAAIAAYagAAAAECk8zkp/0rIBzueHYjyJfUMouMVXBLRsaekBiNxUfMocn1pirnInBVz1E+rILF1dSw==", //123123
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            LockoutEnd = null,
                            LockoutEnabled = true,
                            AccessFailedCount = 0,
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new()//12
                        {
                            Id = Guid.NewGuid().ToString(),
                            About = "Bookworm lost in the pages of fantasy!",
                            ImageName = "fantasy_reader.jpg",
                            UserName = "fantasy_reader",
                            NormalizedUserName = "FANTASY_READER",
                            Email = "fantasy_reader@example.com",
                            NormalizedEmail = "FANTASY_READER@EXAMPLE.COM",
                            EmailConfirmed = true,
                            PasswordHash = "AQAAAAIAAYagAAAAECk8zkp/0rIBzueHYjyJfUMouMVXBLRsaekBiNxUfMocn1pirnInBVz1E+rILF1dSw==", //123123
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            LockoutEnd = null,
                            LockoutEnabled = true,
                            AccessFailedCount = 0,
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new()//13
                        {
                            Id = Guid.NewGuid().ToString(),
                            About = "Fitness enthusiast pushing boundaries!",
                            ImageName = "fit_frenzy.jpg",
                            UserName = "fit_frenzy",
                            NormalizedUserName = "FIT_FRENZY",
                            Email = "fit_frenzy@example.com",
                            NormalizedEmail = "FIT_FRENZY@EXAMPLE.COM",
                            EmailConfirmed = true,
                            PasswordHash = "AQAAAAIAAYagAAAAECk8zkp/0rIBzueHYjyJfUMouMVXBLRsaekBiNxUfMocn1pirnInBVz1E+rILF1dSw==", //123123
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            LockoutEnd = null,
                            LockoutEnabled = true,
                            AccessFailedCount = 0,
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new()//14
                        {
                            Id = Guid.NewGuid().ToString(),
                            About = "Coffee addict fueled by caffeine and creativity!",
                            ImageName = "java_junkie.jpg",
                            UserName = "java_junkie",
                            NormalizedUserName = "JAVA_JUNKIE",
                            Email = "java_junkie@example.com",
                            NormalizedEmail = "JAVA_JUNKIE@EXAMPLE.COM",
                            EmailConfirmed = true,
                            PasswordHash = "AQAAAAIAAYagAAAAECk8zkp/0rIBzueHYjyJfUMouMVXBLRsaekBiNxUfMocn1pirnInBVz1E+rILF1dSw==", //123123
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            LockoutEnd = null,
                            LockoutEnabled = true,
                            AccessFailedCount = 0,
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new()//15
                        {
                            Id = Guid.NewGuid().ToString(),
                            About = "Adventure seeker exploring the great outdoors!",
                            ImageName = "wild_wanderer.jpg",
                            UserName = "wild_wanderer",
                            NormalizedUserName = "WILD_WANDERER",
                            Email = "wild_wanderer@example.com",
                            NormalizedEmail = "WILD_WANDERER@EXAMPLE.COM",
                            EmailConfirmed = true,
                            PasswordHash = "AQAAAAIAAYagAAAAECk8zkp/0rIBzueHYjyJfUMouMVXBLRsaekBiNxUfMocn1pirnInBVz1E+rILF1dSw==", //123123
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            LockoutEnd = null,
                            LockoutEnabled = true,
                            AccessFailedCount = 0,
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new()//16
                        {
                            Id = Guid.NewGuid().ToString(),
                            About = "Music lover dancing through life's rhythms!",
                            ImageName = "rhythm_rover.jpg",
                            UserName = "rhythm_rover",
                            NormalizedUserName = "RHYTHM_ROVER",
                            Email = "rhythm_rover@example.com",
                            NormalizedEmail = "RHYTHM_ROVER@EXAMPLE.COM",
                            EmailConfirmed = true,
                            PasswordHash = "AQAAAAIAAYagAAAAECk8zkp/0rIBzueHYjyJfUMouMVXBLRsaekBiNxUfMocn1pirnInBVz1E+rILF1dSw==", //123123
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            LockoutEnd = null,
                            LockoutEnabled = true,
                            AccessFailedCount = 0,
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new()//17
                        {
                            Id = Guid.NewGuid().ToString(),
                            About = "Fashionista defining style with flair!",
                            ImageName = "style_savant.jpg",
                            UserName = "style_savant",
                            NormalizedUserName = "STYLE_SAVANT",
                            Email = "style_savant@example.com",
                            NormalizedEmail = "STYLE_SAVANT@EXAMPLE.COM",
                            EmailConfirmed = true,
                            PasswordHash = "AQAAAAIAAYagAAAAECk8zkp/0rIBzueHYjyJfUMouMVXBLRsaekBiNxUfMocn1pirnInBVz1E+rILF1dSw==", //123123
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            LockoutEnd = null,
                            LockoutEnabled = true,
                            AccessFailedCount = 0,
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        },
                        new()//18
                        {
                            Id = Guid.NewGuid().ToString(),
                            About = "Nature enthusiast embracing the beauty of the wild!",
                            ImageName = "wilderness_wanderer.jpg",
                            UserName = "wilderness_wanderer",
                            NormalizedUserName = "WILDERNESS_WANDERER",
                            Email = "wilderness_wanderer@example.com",
                            NormalizedEmail = "WILDERNESS_WANDERER@EXAMPLE.COM",
                            EmailConfirmed = true,
                            PasswordHash = "AQAAAAIAAYagAAAAECk8zkp/0rIBzueHYjyJfUMouMVXBLRsaekBiNxUfMocn1pirnInBVz1E+rILF1dSw==", //123123
                            SecurityStamp = Guid.NewGuid().ToString(),
                            ConcurrencyStamp = Guid.NewGuid().ToString(),
                            PhoneNumber = null,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            LockoutEnd = null,
                            LockoutEnabled = true,
                            AccessFailedCount = 0,
                            Added = DateTime.Now,
                            Deleted = DateTime.MinValue,
                            Modified = DateTime.MinValue,
                        }
                    };

                    var tagUsers = new TagUser[]
                    {
                        new()//0
                        {
                            FollowedTagsId = 1,
                            UsersId = users[0].Id
                        },
                        new()
                        {
                            FollowedTagsId = 2,
                            UsersId = users[0].Id
                        },
                        new()
                        {
                            FollowedTagsId = 4,
                            UsersId = users[0].Id
                        },
                        new()
                        {
                            FollowedTagsId = 8,
                            UsersId = users[0].Id
                        },
                        new()
                        {
                            FollowedTagsId = 16,
                            UsersId = users[0].Id
                        },
                        new()//1
                        {
                            FollowedTagsId = 2,
                            UsersId = users[1].Id
                        },
                        new()
                        {
                            FollowedTagsId = 7,
                            UsersId = users[1].Id
                        },
                        new()
                        {
                            FollowedTagsId = 8,
                            UsersId = users[1].Id
                        },
                        new()//2
                        {
                            FollowedTagsId = 1,
                            UsersId = users[2].Id
                        },
                        new()
                        {
                            FollowedTagsId = 10,
                            UsersId = users[2].Id
                        },
                        new()
                        {
                            FollowedTagsId = 11,
                            UsersId = users[2].Id
                        },
                        new()
                        {
                            FollowedTagsId = 17,
                            UsersId = users[2].Id
                        },
                        new()//3
                        {
                            FollowedTagsId = 11,
                            UsersId = users[3].Id
                        },
                        new()
                        {
                            FollowedTagsId = 12,
                            UsersId = users[3].Id
                        },
                        new()//4
                        {
                            FollowedTagsId = 1,
                            UsersId = users[4].Id
                        },
                        new()
                        {
                            FollowedTagsId = 2,
                            UsersId = users[4].Id
                        },
                        new()
                        {
                            FollowedTagsId = 3,
                            UsersId = users[4].Id
                        },
                        new()
                        {
                            FollowedTagsId = 4,
                            UsersId = users[4].Id
                        },
                        new()//5
                        {
                            FollowedTagsId = 3,
                            UsersId = users[5].Id
                        },
                        new()
                        {
                            FollowedTagsId = 4,
                            UsersId = users[5].Id
                        },
                        new()
                        {
                            FollowedTagsId = 11,
                            UsersId = users[5].Id
                        },
                        new()
                        {
                            FollowedTagsId = 12,
                            UsersId = users[5].Id
                        },
                        new()
                        {
                            FollowedTagsId = 13,
                            UsersId = users[5].Id
                        },
                        new()
                        {
                            FollowedTagsId = 14,
                            UsersId = users[5].Id
                        },
                        new()//6
                        {
                            FollowedTagsId = 4,
                            UsersId = users[6].Id
                        },
                        new()
                        {
                            FollowedTagsId = 11,
                            UsersId = users[6].Id
                        },
                        new()//7
                        {
                            FollowedTagsId = 3,
                            UsersId = users[7].Id
                        },
                        new()
                        {
                            FollowedTagsId = 5,
                            UsersId = users[7].Id
                        },
                        new()
                        {
                            FollowedTagsId = 7,
                            UsersId = users[7].Id
                        },
                        new()
                        {
                            FollowedTagsId = 9,
                            UsersId = users[7].Id
                        },
                        new()
                        {
                            FollowedTagsId = 11,
                            UsersId = users[7].Id
                        },
                        new()//8
                        {
                            FollowedTagsId = 15,
                            UsersId = users[8].Id
                        },
                        new()
                        {
                            FollowedTagsId = 16,
                            UsersId = users[8].Id
                        },
                        new()
                        {
                            FollowedTagsId = 17,
                            UsersId = users[8].Id
                        }
                    };

                    context.Users.AddRange(users);
                    context.TagUsers.AddRange(tagUsers);

                    context.SaveChanges();

                    transaction.Commit();
                }
            }
            #endregion

            #region Questions
            if (context.Questions != null)
            {
                if (!context.Questions.Any())
                {
                    using var transaction = context.Database.BeginTransaction();

                    var nLipsum = new LipsumGenerator();

                    var random = new Random();

                    List<Question> questions = [];

                    var users = context.Users!.ToList();

                    var tags = context.Tags!.ToList();

                    for (int i = 0; i < 200; i++) 
                    {
                        int randomUserIndex = random.Next(users.Count);
                        int randomTagIndex = random.Next(tags.Count);
                        int descriptionLength = random.Next(1, 7);

                        Question question = new()
                        {
                            Title = nLipsum.GenerateLipsum(1, Features.Sentences, string.Empty).ApplyCase(LetterCasing.Sentence),
                            Description = nLipsum.GenerateLipsum(descriptionLength),
                            Tag = tags[randomTagIndex],
                            User = users[randomUserIndex]
                        };

                        questions.Add(question);
                    }

                    context.Questions.AddRange(questions);

                    context.SaveChanges();
                    transaction.Commit();
                }
            }
            #endregion
        }
    }
}
