using Entities;
using System;
using System.Collections;
using System.Linq;

namespace Business
{
    public static class Sherlock
    {
        public static HistoryModel ValidateString(string input)
        {
           
            return new HistoryModel { Input = input, 
                                      Output = Validate(input)
            };
        }

        private static string Validate(string input)
        {
            var frequencies = new Hashtable();

            foreach (char character in input)
            {
                if (frequencies.Contains(character))
                {
                    var count = (int)frequencies[character];
                    frequencies[character] = count + 1;
                }
                else
                {
                    frequencies.Add(character, 1);
                }
            }


            var output = String.Empty;
            var frequenciesValues = new int[frequencies.Count];
            frequencies.Values.CopyTo(frequenciesValues, 0);
            var diferentValues = frequenciesValues.Select(x => x).Distinct();

            if (diferentValues.Count() < 4)
            {

                if (diferentValues.Count() == 1)
                {
                    output = input;
                }
                else if (diferentValues.Count() == 2)
                {
                    if (Math.Abs(diferentValues.ToList()[0] - diferentValues.ToList()[1]) == 1)
                    {
                        
                        output =   ReplaceChar(input,  diferentValues.ToList().Max(), frequencies);

                        

                    }
                    else if (diferentValues.ToList()[0] == 1 || diferentValues.ToList()[1] == 1)
                    {

                        output = ReplaceChar(input, 1, frequencies);

                        //foreach (DictionaryEntry item in frequencies)
                        //{
                        //    if ((int)item.Value == 1)
                        //    {
                        //        output = input.Replace((char)item.Key, ' ');
                        //    }

                        //}

                    }
                }

                if (diferentValues.Count() == 3)
                {
                    if (diferentValues.ToList()[0] == 1 ||
                        diferentValues.ToList()[1] == 1 ||
                        diferentValues.ToList()[2] == 1)
                    {
                        if ((Math.Abs(diferentValues.ToList()[0] - diferentValues.ToList()[1]) == 1 && diferentValues.ToList()[0] != 1 && diferentValues.ToList()[1] != 1) ||
                           (Math.Abs(diferentValues.ToList()[0] - diferentValues.ToList()[2]) == 1 && diferentValues.ToList()[0] != 1 && diferentValues.ToList()[2] != 1) ||
                           (Math.Abs(diferentValues.ToList()[2] - diferentValues.ToList()[1]) == 1 && diferentValues.ToList()[2] != 1 && diferentValues.ToList()[1] != 1))
                        {
                            output = ReplaceChar(input, 1, frequencies);
                            output = ReplaceChar(output, diferentValues.ToList().Max(), frequencies);
                            //foreach (DictionaryEntry item in frequencies)
                            //{
                            //    if ((int)item.Value == 1 || (int)item.Value == diferentValues.ToList().Max())
                            //    {
                            //        output = input.Replace((char)item.Key, ' ');
                            //    }

                            //}


                        }
                    }
                }

            }
            return output;
        }

        private static string ReplaceChar(string output, int value,Hashtable frequencies)
        {
            foreach (DictionaryEntry item in frequencies)
            {
                if ((int)item.Value == value)
                {
                    output = ReplaceFirst(output, item.Key.ToString(), string.Empty);
                }
            }
            return output;
        }

        public static string ReplaceFirst(  string text, string search, string replace)
        {
            int position = text.IndexOf(search);
            if (position < 0)
            {
                return text;
            }
            return text.Substring(0, position) + replace + text.Substring(position + search.Length);
        }
    }
}
