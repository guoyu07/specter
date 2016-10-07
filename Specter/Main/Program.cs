using System;

namespace Specter.Main
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var pass = @"
                Feature: OpenAgoda
                Scenario: LandToHome
                    Given Land to Agoda
                    Then Agoda title should contain Agoda
                    Then Agoda title should be Agoda.com: Smarter Hotel Booking
                    Then Home tab size should be 2
            ";

            var passresult = new Actor().Run(pass);
            Console.Write("OpenAgoda: " + passresult);

            var fail = @"
                Feature: OpenAgoda
                Scenario: LandToHome
                    Given Land to Agoda
                    Then Agoda title should contain Agoda
                    Then Agoda title should be Agoda.com: Smarter Hotel Booking
                    Then Home tab size should be 3
            ";

            var failresult = new Actor().Run(fail);
            Console.Write("OpenAgoda: " + failresult);
        }
    }
}
