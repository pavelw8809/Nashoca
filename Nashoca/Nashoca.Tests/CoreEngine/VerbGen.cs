using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Nashoca.CoreEngine.Core;
using Nashoca.CoreEngine.Generators.Turkish;
using Nashoca.CoreEngine.Models;
using Nashoca.Domain.Entities;
using Nashoca.Tests.Model;
using System.Globalization;
using Xunit;
using Xunit.Abstractions;

namespace Nashoca.Tests.CoreEngine
{
    public class VerbGen
    {
        private readonly ITestOutputHelper _outputHelper;

        public VerbGen(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        public static IEnumerable<T> GetCsvData<T>(string filePath, string delimeter = ",")
        {
            Console.WriteLine(filePath);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = delimeter,
                HasHeaderRecord = true,
                IgnoreBlankLines = true,
                MissingFieldFound = null,
                HeaderValidated = null
            };

            if (File.Exists(filePath))
            {
                using var csvReader = new StreamReader(filePath);
                using var csv = new CsvReader(csvReader, config);
                csv.Context.TypeConverterCache.AddConverter<bool>(new BooleanConverter());

                return csv.GetRecords<T>().ToList();
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public static IEnumerable<object[]> GetVerbTestData()
        {
            var testType = 4;
            var projectDir = AppContext.BaseDirectory;
            var verbGenList = GetCsvData<VerbGenObj>(Path.Combine(projectDir, "CoreEngine", "TestData", "VerbGen.csv"));
            var verbTrList = GetCsvData<VerbTr>(Path.Combine(projectDir, "CoreEngine", "TestData", "VerbTr.csv"));
            var verbEnList = GetCsvData<VerbEnMin>(Path.Combine(projectDir, "CoreEngine", "TestData", "VerbEn.csv"));

            foreach (var verbTr in verbTrList)
            {
                var verbEn = verbEnList.FirstOrDefault(x => x.Id == verbTr.Id);

                var forms = verbGenList.Where(x => x.VerbNo == verbTr.Id && x.FormNo >= testType*100 && x.FormNo < (testType*100)+100);


                foreach (var form in forms)
                {
                    Console.WriteLine($"Filtered Form: {form.FormCode}, {form.Form}, {form.IsPlural}");
                    yield return new object[] { verbTr, verbEn, form };
                }
            }
        }

        [Theory]
        [MemberData(nameof(GetVerbTestData))]
        public void VerbConstruction_Generate_ShouldReturnValidOutput(VerbTr verbTr, VerbEnMin verbEn, VerbGenObj expectedForm)
        {
            // Arrange
            var gen = new VerbGenerator();
            var input = GenerateInputList(verbTr, verbEn);
            input.FormNo = expectedForm.FormNo;

            Console.WriteLine($"current Item: {input.FormNo}");

            // Act
            var result = gen.Generate(new List<InputObjTrEn> { input }).First();

            _outputHelper.WriteLine($"expected obj: {expectedForm.Form} - isPlural: {expectedForm.IsPlural}");
            _outputHelper.WriteLine($"ITEM RESULT: {result.FormCode} - isPlural: {result.IsPlural} - expected: {expectedForm.IsPlural}");

            foreach (var item in result.SuffixList)
            {
                _outputHelper.WriteLine($"RESULT: {item.Type} - {item.Value}");
            }

            // Assert
            Assert.Equal(expectedForm.FormCode, result.FormCode);
            Assert.Equal(input.TrName, result.Name);
            Assert.Equal(expectedForm.Form, result.FormName);
            Assert.Equal(expectedForm.IsPlural, result.IsPlural);
            Assert.Equal(expectedForm.PersonNo, result.Person);
            Assert.Equal(expectedForm.Eng, result.EnTranslation.EnTranslation);
        }

        /*
        private void VerbConstruction_Generate_ShouldReturnValidOutput_Main(int Mode, IEnumerable<VerbTr> verbTrs, IEnumerable<VerbEnMin> verbEns, IEnumerable<VerbGenObj> formList)
        {
            if (verbTrs.Any())
            {
                foreach (var verbTr in verbTrs)
                {
                    var gen = new VerbGenerator();

                    var verbEn = verbEns.FirstOrDefault(x => x.Id == verbTr.Id);
                    var verbForms = formList.Where(x => x.VerbNo == verbTr.Id && (x.FormNo >= Mode*100 && x.FormNo < (Mode*100)+100)).ToList();

                    if (verbForms.Count > 0)
                    {
                        var inputObj = GenerateInputList(verbTr, verbEn);

                        foreach (var form in verbForms)
                        {
                            inputObj.FormNo = form.FormNo;
                            Console.WriteLine(form.FormNo);
                            var testList = new List<InputObjTrEn>() { inputObj };

                            var result = gen.Generate(testList);

                            var output = result.First();
                            var verbTrCode = formList.FirstOrDefault(x => x.FormNo == form.FormNo && x.VerbNo == form.VerbNo);

                            Console.WriteLine($"Output: {output.FormCode} - {output.VerbName} - {output.VerbFormName} - {output.IsPlural} - {output.Person}");

                            Assert.Equal(verbTrCode.FormCode, output.FormCode);
                            Assert.Equal(inputObj.TrName, output.VerbName);
                            Assert.Equal(form.Form, output.VerbFormName);
                            if (form.IsPlural)
                            {
                                Assert.True(output.IsPlural);
                            }
                            else
                            {
                                Assert.False(output.IsPlural);
                            }
                            Assert.Equal(form.PersonNo, output.Person);
                        }
                    }
                }
            }
        }
        */

        /*
        public void PresentContinuous_Generate_ShouldReturnValidOutput(IEnumerable<VerbTr> verbTrs, IEnumerable<VerbEnMin> verbEns, IEnumerable<VerbGenObj> formList)
        {
            if (verbTrs.Any())
            {
                foreach (var verbTr in verbTrs)
                {
                    var gen = new VerbGenerator();

                    var verbEn = verbEns.FirstOrDefault(x => x.Id == verbTr.Id);
                    var verbForms = formList.Where(x => x.VerbNo == verbTr.Id && (x.FormNo >= 100 && x.FormNo < 200)).ToList();

                    if (verbForms.Count > 0)
                    {
                        var inputObj = GenerateInputList(verbTr, verbEn);

                        foreach (var form in verbForms)
                        {
                            inputObj.FormNo = form.FormNo;
                            Console.WriteLine(form.FormNo);
                            var testList = new List<InputObjTrEn>() { inputObj };

                            var result = gen.Generate(testList);

                            var output = result.First();
                            var verbTrCode = formList.FirstOrDefault(x => x.FormNo == form.FormNo && x.VerbNo == form.VerbNo);

                            Console.WriteLine($"Output: {output.FormCode} - {output.VerbName} - {output.VerbFormName} - {output.IsPlural} - {output.Person}");

                            Assert.Equal(verbTrCode.FormCode, output.FormCode);
                            Assert.Equal(inputObj.TrName, output.VerbName);
                            Assert.Equal(form.Form, output.VerbFormName);
                            if (form.IsPlural)
                            {
                                Assert.True(output.IsPlural);
                            }
                            else
                            {
                                Assert.False(output.IsPlural);
                            }
                            Assert.Equal(form.PersonNo, output.Person);
                        }
                    }
                }
            }
        }
        */

        private InputObjTrEn GenerateInputList(VerbTr verbTr, VerbEnMin verbEn)
        {
            return new InputObjTrEn()
            {
                TrSymbol = verbTr.Symbol,
                TrName = verbTr.Name,
                TrPrefP = verbTr.PrefP,
                TrMainF = verbTr.MainF,
                TrMinF = verbTr.MinF,
                TrAoS = verbTr.AoristS,
                TrPassS = verbTr.PassS,
                TrRules = verbTr.Rules,
                EnPrefP = verbEn.PrefP,
                EnMainF = verbEn.MainF,
                EnPostP = verbEn.PostP,
                EnContF = verbEn.ContF,
                EnPastF = verbEn.PastF,
                EnPPastF = verbEn.PPastF,
                EnRules = verbEn.Rules,
                TransId = verbTr.Id
            };
        }
    }

    public class BooleanConverter : CsvHelper.TypeConversion.BooleanConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;

            text = text.Trim().ToLowerInvariant();
            return text == "true" || text == "1" || text == "yes" || text == "y";
        }
    }
}