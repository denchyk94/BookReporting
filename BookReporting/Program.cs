using BookReporting.Application.Mappers;
using BookReporting.Application.Mappers.Contracts;
using BookReporting.Application.Models;
using BookReporting.Application.Services;
using BookReporting.Application.Services.Contracts;
using BookReporting.Domain.AggregateRoots;
using BookReporting.Domain.Constants;
using BookReporting.Infrastructure.Factories;
using BookReporting.Infrastructure.Factories.Contracts;
using BookReporting.Infrastructure.Handlers;
using BookReporting.Infrastructure.Handlers.Contracts;
using BookReporting.Infrastructure.Repositories;
using BookReporting.Infrastructure.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookReporting
{
    internal class Program
    {
        private static List<int> m_roleIds = new List<int>
        {
            Constants.LibrarianId,
            Constants.StudentId,
            Constants.ResearcherId,
            Constants.BusinessAnalystId
        };

        static async Task Main(string[] args)
        {
            // Register services
            var serviceProvider = GetServiceProvider();

            // Request role
            var helloMessage = "Specify id of your role:\r\n" +
                $"{Constants.LibrarianId}. Librarian\r\n" +
                $"{Constants.StudentId}. Student\r\n" +
                $"{Constants.ResearcherId}. Researcher\r\n" +
                $"{Constants.BusinessAnalystId}. Business Analyst\r\n";
            Console.WriteLine(helloMessage);

            // Validate if role id exists in the list
            // Provide input dialog until valid id is entered
            int roleId = -1;
            while (!int.TryParse(Console.ReadLine(), out roleId) || !m_roleIds.Any(x => x == roleId))
            {
                Console.WriteLine("Provided id is invalid.");
                Console.WriteLine(helloMessage);
            }

            // List all availble books
            // And request to choose the book for processing
            Console.WriteLine("Choose available book to be processed:");
            string[] fileEntries = Directory.GetFiles(@"wwwroot\Books");
            for (var i = 0; i < fileEntries.Length; i++)
            {
                var entry = fileEntries[i];
                Console.WriteLine($"{i}. {entry}");
            }

            int bookId = -1;
            while (!int.TryParse(Console.ReadLine(), out bookId) || (bookId > fileEntries.Length - 1) || bookId < 0)
            {
                Console.WriteLine("Provided book id is invalid.");
            }

            var bookPath = fileEntries[bookId];
            Console.WriteLine($"Book to be processed:\r\n {bookPath}");

            // Fetch report model
            BaseReportModel reportModel = null;
            switch (roleId)
            {
                case Constants.LibrarianId:
                    {
                        var service = serviceProvider.GetService<ILibrarianService>();
                        reportModel = await service.Get(bookPath);
                    }
                    break;
                case Constants.StudentId:
                    {
                        Console.WriteLine("Please provide search key:");
                        var searchKey = Console.ReadLine();

                        var service = serviceProvider.GetService<IStudentService>();
                        reportModel = await service.Get(bookPath, searchKey);
                    }
                    break;
                case Constants.ResearcherId:
                    {
                        var service = serviceProvider.GetService<IResearcherService>();
                        reportModel = await service.Get(bookPath);
                    }
                    break;
                case Constants.BusinessAnalystId:
                    {
                        var service = serviceProvider.GetService<IBusinessAnalystService>();
                        reportModel = await service.Get(bookPath);
                    }
                    break;
                default:
                    break;
            }


            Console.WriteLine("Finished processing with result: ");
            Console.WriteLine(reportModel?.ToString());

            Console.WriteLine("Press any key to exit");

            Console.Read();
        }

        private static ServiceProvider GetServiceProvider()
        {
            return new ServiceCollection()
                .AddSingleton<IFileRepository, FileRepository>()
                .AddSingleton<IBookHandler, BookHandler>()
                // Repositories
                .AddSingleton<ILibrarianRepository<Librarian>, LibrarianRepository>()
                .AddSingleton<IStudentRepository<Student>, StudentRepository>()
                .AddSingleton<IResearcherRepository<Researcher>, ResearcherRepository>()
                .AddSingleton<IBusinessAnalystRepository<BusinessAnalyst>, BusinessAnalystRepository>()
                // Factories
                .AddSingleton<ILibrarianFactory, LibrarianFactory>()
                .AddSingleton<IStudentFactory, StudentFactory>()
                .AddSingleton<IResearcherFactory, ResearcherFactory>()
                .AddSingleton<IBusinessAnalystFactory, BusinessAnalystFactory>()
                // Mappers
                .AddSingleton<IMapper<Librarian, LibrarianReportModel>, LibrarianReportModelMapper>()
                .AddSingleton<IMapper<Student, StudentReportModel>, StudentReportModelMapper>()
                .AddSingleton<IMapper<Researcher, ResearcherReportModel>, ResearcherReportModelMapper>()
                .AddSingleton<IMapper<BusinessAnalyst, BusinessAnalystReportModel>, BusinessAnalystReportModelMapper>()
                // Services
                .AddSingleton<ILibrarianService, LibrarianService>()
                .AddSingleton<IStudentService, StudentService>()
                .AddSingleton<IResearcherService, ResearcherService>()
                .AddSingleton<IBusinessAnalystService, BusinessAnalystService>()
                .BuildServiceProvider();
        }
    }
}
