using System;
namespace TestApplication.Data
{
    public class DataConstants
    {
        public class Bike
        {
            public const int BrandMinLength = 3;
            public const int BrandMaxLength = 20;

            public const int ModelMinLength = 3;
            public const int ModelMaxLength = 20;

            public const int DescriptionMinLength = 10;
        }

        public class Category
        {
            public const int NameMaxLength = 20;
        }

        public class Dealer
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 30;
            public const int PhoneNumberMinLength = 6;
            public const int PhoneNumberMaxLength = 30;
        }
        
    }
}
