using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using IntelligenceEntity;

namespace Db {
    class Program {
        static void Main(string[] args) {
            var connectionString = "Server=192.168.0.105;Port=5432;Database=IntelligenceCapture; User Id=postgres;Password=abcABC123;";

            var options = new DbContextOptionsBuilder().UseNpgsql(connectionString).Options;
            using (var context = new IntelligenceEntity.IntelligenceContext(options)) {
                var outputs = context.Outputs.Where(x => x.Status == OutputStatus.Unclassified);
                foreach (var item in outputs) {
                    Console.WriteLine(item.Id);
                }
            }
        }
    }
}
