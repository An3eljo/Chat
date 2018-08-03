using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatServer.Library
{
    public static class IdCreator
    {
        private static List<char> Chars;

        public static void Initialize()
        {
            Chars = new List<char>();
            Chars.AddRange(new []
            {
                'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
                'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
                '0','1','2','3','4','5','6','7','8','9',
                '!','#','$','&','%','\'','(',')','+',',','-','.',';','=','@','[',']','^','_','`','{','}','~'
            });
        }

        public static string CreateId(int length)
        {
            var id = MakeId(length);
            return id;
        }

        public static string CreateId()
        {
            var random = new Random();
            var lenght = random.Next(0, Chars.Count - 1);

            var id = MakeId(lenght);
            return id;
        }

        private static string MakeId(int lenght)
        {
            var random = new Random();
            var id = String.Empty;
            for (int i = 0; i < lenght; i++)
            {
                id += Chars[random.Next(0, Chars.Count - 1)];
            }

            return id;
        }
    }
}