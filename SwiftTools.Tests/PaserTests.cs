using NUnit.Framework;
using SwiftTools.Model;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace SwiftTools.Tests
{
    public class ParserTests
    {
        #region validation

        /// <summary>
        /// The content contains any characters, otherwise the `NoDataException` should be thrown
        /// </summary>
        [Test]
        public void Validate_EmptyStream_Test()
        {
            Assert.Throws<NoDataException>(() => new MT101Parser.MT101Parser().ValidateFormat(new MemoryStream()));
        }

        /// <summary>
        /// There are no empty lines, otherwise you should throw `EmptyLinesException` containing invalid line numbers.
        /// </summary>
        [Test]
        public void Validate_EmptyLines_Test()
        {
            using (var stream = new MemoryStream())
            {
                var data = UTF8Encoding.UTF8.GetBytes("{1:}\r\n\r\n{2:}{3:}{4:\r\n-}\r\n\r\n{5:}");
                stream.Write(data, 0, data.Length);
                try
                {
                    new MT101Parser.MT101Parser().ValidateFormat(stream);
                    Assert.Fail($"{nameof(EmptyLinesException)} expected!");
                }
                catch (EmptyLinesException ex)
                {
                    Assert.IsNotNull(ex.IncorrectLines);
                    Assert.AreEqual(2, ex.IncorrectLines.Length);
                    Assert.AreEqual(2, ex.IncorrectLines[0]); // line no 2
                    Assert.AreEqual(5, ex.IncorrectLines[1]); // line no 5
                }
                catch (Exception)
                {
                    Assert.Fail($"{nameof(EmptyLinesException)} expected!");
                }
            }
        }

        /// <summary>
        /// There are no lines starting with `-`, except for `-}`; otherwise you should throw `IncorrectLinesException` containing invalid line numbers.
        /// </summary>
        [Test]
        public void Validate_IncorrectLines_Test()
        {
            using (var stream = new MemoryStream())
            {
                var data = UTF8Encoding.UTF8.GetBytes("{1:}\r\n-\r\n{2:}{3:}{4:\r\n-data\r\n-\r\n-}{5:}");
                stream.Write(data, 0, data.Length);
                try
                {
                    new MT101Parser.MT101Parser().ValidateFormat(stream);
                    Assert.Fail($"{nameof(IncorrectLinesException)} expected!");
                }
                catch (IncorrectLinesException ex)
                {
                    Assert.IsNotNull(ex.IncorrectLines);
                    Assert.AreEqual(3, ex.IncorrectLines.Length);
                    Assert.AreEqual(2, ex.IncorrectLines[0]); // line no 2
                    Assert.AreEqual(4, ex.IncorrectLines[1]); // line no 4
                    Assert.AreEqual(5, ex.IncorrectLines[2]); // line no 5
                }
                catch (Exception)
                {
                    Assert.Fail($"{nameof(IncorrectLinesException)} expected!");
                }
            }
        }

        /// <summary>
        /// There is at least one block `{4:`; otherwise the `MTFormatException` should be thrown.
        /// </summary>
        [Test]
        public void Validate_CorrectFormat_Test()
        {
            using (var stream = new MemoryStream())
            {
                var data = UTF8Encoding.UTF8.GetBytes("{1:}{2:}{3:}{4:\r\n-}{5:}");
                stream.Write(data, 0, data.Length);
                new MT101Parser.MT101Parser().ValidateFormat(stream);
            }
        }

        /// <summary>
        /// There is at least one block `{4:`; otherwise the `MTFormatException` should be thrown.
        /// </summary>
        [Test]
        public void Validate_CorrectFormatOnlyBlock4_Test()
        {
            using (var stream = new MemoryStream())
            {
                var data = UTF8Encoding.UTF8.GetBytes("{4:\r\n-}");
                stream.Write(data, 0, data.Length);
                new MT101Parser.MT101Parser().ValidateFormat(stream);
            }
        }

        /// <summary>
        /// There is at least one block `{4:`; otherwise the `MTFormatException` should be thrown.
        /// </summary>
        [Test]
        public void Validate_CorrectFormatOnlyBlock4_2_Test()
        {
            using (var stream = new MemoryStream())
            {
                var data = UTF8Encoding.UTF8.GetBytes("{4:-}");
                stream.Write(data, 0, data.Length);
                new MT101Parser.MT101Parser().ValidateFormat(stream);
            }
        }

        /// <summary>
        /// There is at least one block `{4:`; otherwise the `MTFormatException` should be thrown.
        /// </summary>
        [Test]
        public void Validate_NoBlock4_Test()
        {
            using (var stream = new MemoryStream())
            {
                var data = UTF8Encoding.UTF8.GetBytes("{1:}{2:}{3:}{5:}");
                stream.Write(data, 0, data.Length);
                Assert.Throws<MTFormatException>(() => new MT101Parser.MT101Parser().ValidateFormat(stream));
            }
        }

        /// <summary>
        /// No other curly brackets (`{`,`}`) exist inside Block `{4:...-}`; otherwise the `MTFormatException` should be thrown.
        /// </summary>
        [Test]
        public void Validate_IncorrectEndBlock4_Test()
        {
            using (var stream = new MemoryStream())
            {
                var data = UTF8Encoding.UTF8.GetBytes("{1:}{2:}{3:}{4:\r\n{5:}");
                stream.Write(data, 0, data.Length);
                Assert.Throws<MTFormatException>(() => new MT101Parser.MT101Parser().ValidateFormat(stream));
            }
        }

        /// <summary>
        /// No other curly brackets (`{`,`}`) exist inside Block `{4:...-}`; otherwise the `MTFormatException` should be thrown.
        /// </summary>
        [Test]
        public void Validate_IncorrectBlock4_CurlyBracketsInside_Test()
        {
            using (var stream = new MemoryStream())
            {
                var data = UTF8Encoding.UTF8.GetBytes("{1:}{2:}{3:}{4:{}\r\n-}{5:}");
                stream.Write(data, 0, data.Length);
                Assert.Throws<MTFormatException>(() => new MT101Parser.MT101Parser().ValidateFormat(stream));
            }
        }

        /// <summary>
        /// No other curly brackets (`{`,`}`) exist inside Block `{4:...-}`; otherwise the `MTFormatException` should be thrown.
        /// </summary>
        [Test]
        public void Validate_IncorrectBlock4_CurlyBracketsInside_3_Test()
        {
            using (var stream = new MemoryStream())
            {
                var data = UTF8Encoding.UTF8.GetBytes("{1:}{2:}{3:}{4:}\r\n-}{5:}");
                stream.Write(data, 0, data.Length);
                Assert.Throws<MTFormatException>(() => new MT101Parser.MT101Parser().ValidateFormat(stream));
            }
        }

        /// <summary>
        /// All lines contain only the allowed characters (see the **SWIFT characters set**), otherwise the `NotAllowedCharactersException` 
        /// with a list with the forbidden characters and their position in the file (counted from 1) should be thrown. 
        /// </summary>
        [Test]
        public void Validate_IncorrectCharacters_OnlyBlock4_Test()
        {
            using (var stream = new MemoryStream())
            {
                try
                {
                    var data = UTF8Encoding.UTF8.GetBytes("{4:$^&\r\n-}");
                    stream.Write(data, 0, data.Length);
                    new MT101Parser.MT101Parser().ValidateFormat(stream);
                    Assert.Fail($"{nameof(NotAllowedCharactersException)} expected!");
                }
                catch (NotAllowedCharactersException ex)
                {
                    Assert.IsNotNull(ex.IncorrectChars);
                    Assert.AreEqual(3, ex.IncorrectChars.Length);
                }
                catch (Exception)
                {
                    Assert.Fail($"{nameof(NotAllowedCharactersException)} expected!");
                }
            }
        }

        #endregion validation

        #region parser-tests

        [Test]
        public void Parse_OnlyOneBlock4_Test()
        {
            using (var stream = new MemoryStream())
            {
                var block41 = "{4:\r\n:20:1106210100000003\r\n:28D:1/2\r\n:50H:/PL64114010100000123456001001\r\n-}";

                var data = UTF8Encoding.UTF8.GetBytes("{1:}{2:}{3:}" + block41 + "{5:}");
                stream.Write(data, 0, data.Length);
                var allMt101 = new MT101Parser.MT101Parser().Parse(stream);
                Assert.AreEqual(1, allMt101.Length);

                var mt101 = allMt101[0];
                Assert.AreEqual(block41, mt101.Raw);
            }
        }

        [Test]
        public void Parse_OnlyTwoBlock4_Test()
        {
            using (var stream = new MemoryStream())
            {
                var block41 = "{4:\r\n:20:1106210100000003\r\n:50H:/PL64114010100000123456001001\r\n-}";
                var block42 = "{4:\r\n:20:1106210100000003\r\n:28D:1/2\r\n:50H:/PL64114010100000123456001001\r\nORDERING CUSTOMER NAME1\r\nORDERING CUSTOMER NAME2\r\n-}";

                var data = UTF8Encoding.UTF8.GetBytes("{1:}{2:}{3:}" + block41 + block42 + "{5:}");
                stream.Write(data, 0, data.Length);
                var allMt101 = new MT101Parser.MT101Parser().Parse(stream);
                Assert.AreEqual(2, allMt101.Length);

                Assert.AreEqual(block41, allMt101[0].Raw);
                Assert.AreEqual(block42, allMt101[1].Raw);
            }
        }

        [Test]
        public void Parse_OtherBlocksWithEmptyBlock4_Test()
        {
            using (var stream = new MemoryStream())
            {
                var block4 = "{4:-}";

                var data = UTF8Encoding.UTF8.GetBytes("{1:}{2:}{3:}" + block4 + "{5:}");
                stream.Write(data, 0, data.Length);
                var allMt101 = new MT101Parser.MT101Parser().Parse(stream);
                Assert.AreEqual(1, allMt101.Length);

                Assert.AreEqual(block4, allMt101[0].Raw);
            }
        }

        [Test]
        public void Parse_OtherBlocksWith2EmptyBlock4_Test()
        {
            using (var stream = new MemoryStream())
            {
                var block4 = "{4:-}";

                var data = UTF8Encoding.UTF8.GetBytes("{1:}{2:}{3:}" + block4 + block4 + "{5:}");
                stream.Write(data, 0, data.Length);
                var allMt101 = new MT101Parser.MT101Parser().Parse(stream);
                Assert.AreEqual(2, allMt101.Length);

                Assert.AreEqual(block4, allMt101[0].Raw);
                Assert.AreEqual(block4, allMt101[1].Raw);
            }
        }

        #endregion parser-tests
    }
}
