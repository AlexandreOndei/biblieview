using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;

namespace BibleView.Request
{
    public class Request
    {
        private const string BASE_URL = "https://www.bibliatodo.com/pt/a-biblia";
        private const string VERSAO_PATH = "versao";

        private static void GetVersionsTest()
        {
            var version = new Models.Version()
            {
                Name = "King James Atualizada 1999",
                BooksList = new List<Models.Book>
                {
                    new Models.Book
                    {
                        Name = "Gênesis",
                        ChaptersList = new List<Models.Chapter>
                        {
                            new Models.Chapter
                            {
                                Number = 1,
                                VersesList = new List<Models.Verse>
                                {
                                    new Models.Verse
                                    {
                                        Number = 1,
                                        Text = "No princípio, Deus criou os céus e a terra."
                                    },
                                    new Models.Verse
                                    {
                                        Number = 2,
                                        Text = "A terra, entretanto, era sem forma e vazia. A escuridão cobria o mar que envolvia toda a terra, e o Espírito de Deus se movia sobre a face das águas."
                                    }
                                }
                            },
                            new Models.Chapter
                            {
                                Number = 2,
                                VersesList = new List<Models.Verse>
                                {
                                    new Models.Verse
                                    {
                                        Number = 1,
                                        Text = "Assim foram concluídos o Céu e a Terra, como todo o seu exército."
                                    }
                                }
                            }
                        }
                    }
                }
            };

            Serialize(version);
        }

        public static void ImportBibles(Action<string> statusCallback, Action<int> progressSettingsCallback)
        {
            statusCallback("Buscando versões");

            var versionsList = GetVersions();

            foreach (var version in versionsList)
            {
                statusCallback($"Buscando livros da versão {version.Name}");

                version.BooksList = GetBooks(version.URL);

                progressSettingsCallback(versionsList.Count * version.BooksList.Sum(x => x.ChaptersCount));

                foreach (var book in version.BooksList)
                {
                    statusCallback($"Percorrendo capítulos do livro de {book.Name}");

                    for (int i = 0; i < book.ChaptersCount; i++)
                    {
                        statusCallback($"Buscando {book.Name} ({version.Name}) capítulo ({i + 1}/{book.ChaptersCount})");

                        var chapter = GetChapter(version.URL, book.URL, i + 1);

                        book.ChaptersList.Add(chapter);

                        Serialize(version);
                    }
                }

                statusCallback($"Salvando versâo {version.Name}");

                Serialize(version);
            }
        }

        private static List<Models.Version> GetVersions()
        {
            try
            {
                string responseText = DoRequest(BASE_URL);

                var list = string.Join("\n", responseText.Replace("\n", "").Replace("<select", "\n<select").Split('\n').Where(x => x.Contains("id=\"versiones\"")))
                    .Replace("<", "\n<").Split('\n')
                    .Where(x => x.Contains("<option"))
                    .Skip(1)
                    .Select(x =>
                    {
                        var line = Regex.Replace(x, "<option.*value=\"", "").Replace("\">", "|").Replace("</option>", "").Split('|');
                        return new Models.Version
                        {
                            Name = line[1].Trim(),
                            URL = line[0].Trim()
                        };
                    }).ToList();

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static List<Models.Book> GetBooks(string versionURL)
        {
            try
            {
                string responseText = DoRequest($"{BASE_URL}/{VERSAO_PATH}/{versionURL}");

                int index = 0;
                var list = string.Join("\n", responseText.Replace("\n", "").Replace("<select", "\n<select").Split('\n').Where(x => x.Contains("id=\"libros\"")))
                    .Replace("<", "\n<").Split('\n')
                    .Where(x => x.Contains("<option"))
                    .Select(x =>
                    {
                        var line = Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(x, "<option.*id=\"", ""), "\".*value=\"", "|"), "\">.*</option>", ""), "\">.*", "").Split('|');
                        var bookURL = line[0].Trim();
                        return new Models.Book
                        {
                            Name = line[1].Trim(),
                            URL = bookURL,
                            ChaptersCount = GetChaptersCount(versionURL, bookURL, (index++) == 0 ? responseText : null)
                        };
                    }).ToList();

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static int GetChaptersCountFromContent(string content)
        {
            return string.Join("\n", content.Replace("\n", "").Replace("<select", "\n<select").Split('\n').Where(x => x.Contains("id=\"num_capitulos\"")))
                    .Replace("<", "\n<").Split('\n')
                    .Count(x => x.Contains("<option"));
        }

        private static int GetChaptersCount(string versionURL, string bookURL, string content = null)
        {
            try
            {
                if (string.IsNullOrEmpty(content))
                    content = DoRequest($"{BASE_URL}/{versionURL}/{bookURL}-1");

                return GetChaptersCountFromContent(content);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static Models.Chapter GetChapter(string versionURL, string bookURL, int chapterNumber)
        {
            try
            {
                var responseText = DoRequest($"{BASE_URL}/{versionURL}/{bookURL}-{chapterNumber}");

                var matches = Regex.Matches(responseText, "<p style=\".*\">.*</p>");
                var chapter = new Models.Chapter
                {
                    Number = chapterNumber
                };
                
                int verseNumber = 1;
                foreach (var match in matches)
                {
                    var text = Regex.Replace(Regex.Replace(match.ToString(), "<p.*style=\".*\"", "").Replace("</p>", ""), ">\\d{1,}\\..*</strong>", "").Trim();
                    chapter.VersesList.Add(new Models.Verse
                    {
                        Number = verseNumber++,
                        Text = text
                    });
                }

                return chapter;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static string DoRequest(string url, string method = "GET")
        {
            try
            {
                WebRequest request = WebRequest.CreateHttp(url);
                request.Method = method;
                Stream responseStream = request.GetResponse().GetResponseStream();
                StreamReader stream = new StreamReader(responseStream);
                string responseText = stream.ReadToEnd();

                return responseText;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static void Serialize(Models.Version version)
        {
            if (!Directory.Exists("data"))
                Directory.CreateDirectory("data");

            XmlSerializer serializer = new XmlSerializer(typeof(Models.Version));
            TextWriter writer = new StreamWriter($"data/{version.Name}.xml");
            serializer.Serialize(writer, version);
            writer.Close();
        }
    }
}
